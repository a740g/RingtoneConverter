' Ringtone playback class
' Copyright (c) Samuel Gomes, 2003-2020
' mailto: v_2samg@hotmail.com
'
' This implements ringtone playback in the application.
' It is responsible for playing a single tone given the note, duration etc.
' It also handles silence.
' The details:
' Supports playback of the folowing notes: c, d, e, f, g, a, b and their #s
' Supports octaves: 1, 2, 3 & 4 where 1 is the lowest and 4 is the highest
' Supports dot notes: '.' (affects duration of the note played back)
' Supports durations: 1, 2, 3, 4, 5, 6 (where 1 is the shortest and 6 is the longest or full)
' Supports silence: p (p = pause :)
' Hence a playable note may look like '6.c#3'
' And a silence may look like '6p' (no dots here!)
' BTW this is an internal format we use, just to keep the playback part consistent and simple.
' It's up to the individual 'Ringtone classes' to convert it's data to this format.
' As you can see, if we do this, then interconversion between various formats becomes very simple. :)
' Also, it supports a global tempo, which ranges from 1 to 255 (200 is the default)
'
' Playback was previously done using Win32 Beep() API
' However this API does not work as expected on all systems and configurations
' Hence, We now implement playback Using DirectSound via SharpDX

Imports Microsoft.VisualBasic
Imports System.Collections.Specialized
Imports SharpDX
Imports SharpDX.DirectSound

Friend Class ClsRingTonePlayer

	' The main note frequencies. We calculate the sharps mathematically. :)
	' I hope these are correct. Can someone provide me values with more precision?
	Private Const NOTE_FRQ_C As Single = 261.63!
	Private Const NOTE_FRQ_D As Single = 293.66!
	Private Const NOTE_FRQ_E As Single = 329.63!
	Private Const NOTE_FRQ_F As Single = 349.23!
	Private Const NOTE_FRQ_G As Single = 392.0!
	Private Const NOTE_FRQ_A As Single = 440.0!
	Private Const NOTE_FRQ_B As Single = 493.88!
	' Note duration and octave constants
	Public Const NOTE_OCTAVE_MIN As Integer = 1
	Public Const NOTE_OCTAVE_MAX As Integer = 4
	' The full note duration in ms. The rest as usual is calculated mathematically. ;)
	Private Const NOTE_DURATION_FULL As Integer = 1200
	Private Const NOTE_DURATION_MIN As Integer = 1
	Private Const NOTE_DURATION_MAX As Integer = 6
	' Default tempo. Why 200? Look at the comments later :)
	Private Const NOTE_TEMPO_DEFAULT As Integer = 200
	Private Const NOTE_TEMPO_MIN As Integer = 1
	' String representations of the vaid notes and symbols
	Private Const NOTE_C As String = "C"
	Private Const NOTE_D As String = "D"
	Private Const NOTE_E As String = "E"
	Private Const NOTE_F As String = "F"
	Private Const NOTE_G As String = "G"
	Private Const NOTE_A As String = "A"
	Private Const NOTE_B As String = "B"
	Private Const NOTE_PAUSE As String = "P"
	Private Const NOTE_DOT As String = "."
	Private Const NOTE_SHARP As String = "#"
	Private Const NOTE_CHARS As String = NOTE_C & NOTE_D & NOTE_E & NOTE_F & NOTE_G & NOTE_A & NOTE_B & NOTE_PAUSE & NOTE_DOT & NOTE_SHARP

	' These probably should Not be changed
	Private Const MAX_FREQ As Integer = 32767
	Private Const MIN_FREQ As Integer = 37
	Private Const BITS_PER_SAMPLE As Integer = 16
	Private Const NUM_CHANNELS As Integer = 1
	Private Const SAMPLING_RATE As Integer = 44100
	Private Const SCALE As Integer = (1 << (BITS_PER_SAMPLE - 1)) - 1

	' Target frequency precision: less than 0.5% Error
	'   37  Hz @ 44.1kHz sampling -> half-period of ~596 samples
	' 32.8 kHz @ 44.1kHz sampling -> half-period of ~0.67 samples

	' Global class variables
	Private cTempo As Byte
	' Hold the ringtone in internal format
	Private colRingtone As OrderedDictionary
	' Which note we are currently pointing to?
	Private lNoteIndex As Integer

	Private SndDevice As DirectSound = Nothing
	Private SndWaveFormat As Multimedia.WaveFormat = Nothing
	Private SndBufferDesc As SoundBufferDescription = Nothing
	Private SndBuffer As PrimarySoundBuffer = Nothing

	' Ringtone optimization flag
	Public Optimize As Boolean = False
	Public Name As String = vbNullString

	' Events
	Public Event Playing(ByVal sNote As String, ByVal fFrequency As Single, ByVal fDuration As Single)

	Public Sub New(ByVal frmForm As FrmMain)
		MyBase.New()
		Clear()

		SndDevice = New DirectSound()
		' Set Cooperative Level to PRIORITY (priority level can call the SetFormat and Compact methods)
		SndDevice.SetCooperativeLevel(frmForm.Handle, CooperativeLevel.Normal)

		' Setup the wave format. This will not change so we do it once
		SndWaveFormat = New Multimedia.WaveFormat(SAMPLING_RATE, BITS_PER_SAMPLE, NUM_CHANNELS)

		' Create PrimarySoundBuffer
		SndBufferDesc = New SoundBufferDescription With {
			.Flags = BufferFlags.ControlPositionNotify Or BufferFlags.ControlFrequency Or BufferFlags.GlobalFocus,
			.Format = SndWaveFormat
		}
	End Sub

	Protected Overrides Sub Finalize()
		' Stop DirectSound stuff
		SndBufferDesc = Nothing
		SndWaveFormat = Nothing
		SndDevice = Nothing

		colRingtone = Nothing
	End Sub

	' Our DSound Beep
	Private Function Beep(ByVal dwFreq As Integer, ByVal dwDuration As Integer) As Boolean
		If SndDevice Is Nothing Then Return False

		' Clamp the frequency to the acceptable range
		dwFreq = Clamp(dwFreq, MIN_FREQ, MAX_FREQ)

		' 1/dwFreq = period of wave, in seconds
		' SAMPLING_RATE / dwFreq = samples per wave-period
		Dim half_period As Integer = SAMPLING_RATE * NUM_CHANNELS \ (2 * dwFreq)
		' The above line introduces roundoff error, which at higher
		' frequencies Is significant (>30% at the 32kHz,
		' easily above 1% in general, Not good). We will fix this below.

		' If frequency too high, make sure it's not just a constant DC level
		If half_period < 1 Then half_period = 1
		Dim BUFFER_SIZE As Integer = 2 * half_period * BITS_PER_SAMPLE \ 8

		' Make buffer
		SndBufferDesc.BufferBytes = BUFFER_SIZE

		SndBuffer = New PrimarySoundBuffer(SndDevice, SndBufferDesc)
		If SndBuffer Is Nothing Then Return False

		' Frequency adjustment to correct for the roundoff error above.
		Dim play_freq As Integer = SndBuffer.Frequency

		' When we set the half_period above, we rounded down, so if
		' we play the buffer as Is, it will sound higher frequency
		' than it ought to be.
		' To compensate, we should play the buffer at a slower speed.
		' The slowdown factor Is precisely the rounded-down period
		' divided by the true period:
		' half_period / [ SAMPLING_RATE * NUM_CHANNELS / (2*dwFreq) ]
		' = 2*dwFreq*half_period / (SAMPLING_RATE * NUM_CHANNELS)
		'
		' The adjusted frequency needs to be multiplied by this factor:
		' play_freq *= 2*dwFreq*half_period / (SAMPLING_RATE * NUM_CHANNELS)
		' To do this computation (in a way that works on 32-bit machines),
		' we cannot multiply the numerator directly, since that may
		' cause rounding problems (44100 * 2*44100*1 ~ 3.9 billion which
		' Is uncomfortable close to the upper limit of 4.3 billion).
		' Therefore, we use MulDiv to safely (And efficiently) avoid any
		' problems.

		play_freq = CInt(Math.BigMul(play_freq, 2 * dwFreq * half_period) \ SAMPLING_RATE * NUM_CHANNELS)

		SndBuffer.Frequency = play_freq

		Dim i, j, k As Integer
		Dim bSnd(BUFFER_SIZE \ 2) As Short

		' Write the square wave to buffer
		k = 0
		For i = 1 To half_period
			For j = 1 To NUM_CHANNELS
				bSnd(k) = -SCALE
				k += 1
			Next
		Next

		For i = 1 To half_period
			For j = 1 To NUM_CHANNELS
				bSnd(k) = SCALE
				k += 1
			Next
		Next

		' Send the buffer for playback
		SndBuffer.Write(bSnd, 0, LockFlags.EntireBuffer)

		' Play the sound
		SndBuffer.Play(0, PlayFlags.Looping)
		Threading.Thread.Sleep(dwDuration)
		SndBuffer.Stop()

		' Delete buffer
		SndBuffer = Nothing

		Return True
	End Function

	' Calculates the duration in MS
	Private Function CalcDuration(ByVal iDuration As Integer, ByVal bIsDot As Boolean) As Single

		' Calculate the duration in milliseconds
		Dim fDuration As Single = CSng(NOTE_DURATION_FULL / (2.0! ^ (NOTE_DURATION_MAX - iDuration)))
		' Correct duration if we have a dot note.
		' A dot note is the average of this duration and the "next" duration
		If bIsDot Then fDuration = fDuration * 3.0! / 2.0!
		' Calculate correct duration based on tempo
		' Some history: BPM = Beats/minute = quater notes/minute
		' In one minute we have 60 secs or 60 x 1000 = 60000 ms
		' One quater note = 300 ms
		' Therefore the normal BPM = 60000 / 300 = 200
		Return fDuration * NOTE_TEMPO_DEFAULT / cTempo
	End Function

	' Calculates the frequency
	Private Function CalcFrequency(ByVal cNote As Byte, ByVal bIsSharp As Boolean, ByVal cOctave As Byte) As Single
		Dim fTemp As Single

		' Get the frequency for the corresponding note (for below middle c octave)
		Dim fFrequency As Single = CSng(Choose(cNote, NOTE_FRQ_C, NOTE_FRQ_D, NOTE_FRQ_E, NOTE_FRQ_F, NOTE_FRQ_G, NOTE_FRQ_A, NOTE_FRQ_B))
		' Correct frequency if we have a sharp (i.e. mean of this note and the "next" note)
		If bIsSharp Then
			' Get the frequency of next note. Note how we rotated the notes to the left (no pun intended)
			' Handle special case 'c' from next octave
			fTemp = CSng(Choose(cNote, NOTE_FRQ_D, NOTE_FRQ_E, NOTE_FRQ_F, NOTE_FRQ_G, NOTE_FRQ_A, NOTE_FRQ_B, NOTE_FRQ_C * 2.0!))
			' Calculate sharp
			fFrequency = (fFrequency + fTemp) / 2.0!
		End If
		' Calculate frequency for the corresponding octave
		Return fFrequency * cOctave
	End Function

	' Gets the current full note
	Private Function GetFullNote() As String
		' Ignore if index is out of bounds
		Dim result As String = vbNullString

		Try
			result = CStr(colRingtone(CStr(lNoteIndex)))

		Catch
			' Nothing
		End Try

		Return result
	End Function

	' Tempo get set methods
	Public Property Tempo() As Byte
		Get
			Return cTempo
		End Get
		Set(ByVal Value As Byte)
			If Value < NOTE_TEMPO_MIN Then
				Throw New Exception((vbObjectError + 1011).ToString() + ", , Tempo out of range")
			End If

			cTempo = Value
		End Set
	End Property

	' Clears the ringtone data
	Public Sub Clear()
		cTempo = NOTE_TEMPO_DEFAULT
		colRingtone = Nothing
		colRingtone = New OrderedDictionary()
		lNoteIndex = 0
		Name = vbNullString
	End Sub

	' Adds a note to the ringtone
	Public Sub AddNote(ByVal sNote As String, ByVal bIsSharp As Boolean, ByVal cOctave As Byte, ByVal cDuration As Byte, ByVal bIsDot As Boolean)
		Dim sPrevNote As String

		' Validate all parameters
		sNote = UCase(Trim(sNote))

		Select Case sNote
			Case NOTE_C, NOTE_D, NOTE_E, NOTE_F, NOTE_G, NOTE_A, NOTE_B
				' Ok
			Case NOTE_PAUSE
				If bIsDot Then
					Throw New Exception((vbObjectError + 1015).ToString() + ", , A pause cannot be a dot note")
				End If
			Case Else
				Throw New Exception((vbObjectError + 1012).ToString() + ", , Invalid note")
		End Select

		If cOctave < NOTE_OCTAVE_MIN Or cOctave > NOTE_OCTAVE_MAX Then
			Throw New Exception((vbObjectError + 1013).ToString() + ", , Note octave out of range")
		End If

		If cDuration < NOTE_DURATION_MIN Or cDuration > NOTE_DURATION_MAX Then
			Throw New Exception((vbObjectError + 1014).ToString() + ", , Note duration out of range")
		End If

		' Create the full note
		Dim sFullNote As String = CStr(cDuration)
		If sNote <> NOTE_PAUSE And bIsDot Then sFullNote &= NOTE_DOT
		sFullNote &= sNote
		If sNote <> NOTE_PAUSE And bIsSharp Then sFullNote &= NOTE_SHARP
		If sNote <> NOTE_PAUSE Then sFullNote &= CStr(cOctave)

		If Optimize And colRingtone.Count > 0 Then
			' Club notes with duration between 1 to 5
			' Get previous note
			sPrevNote = CStr(colRingtone(CStr(colRingtone.Count - 1)))
			' If both notes are similar then proceed
			If sPrevNote = sFullNote And cDuration < NOTE_DURATION_MAX Then
				' Remove the last note from the collection
				colRingtone.Remove(CStr(colRingtone.Count - 1))
				' Modify this note to reflect the duration change
				sFullNote = CStr(cDuration + 1)
				If sNote <> NOTE_PAUSE And bIsDot Then sFullNote &= NOTE_DOT
				sFullNote &= sNote
				If sNote <> NOTE_PAUSE And bIsSharp Then sFullNote &= NOTE_SHARP
				If sNote <> NOTE_PAUSE Then sFullNote &= CStr(cOctave)
			End If
		End If

		' Add note to collection
		colRingtone.Add(CStr(colRingtone.Count), sFullNote)
	End Sub

	' Moves the note index to the next note
	Public Function NextNote() As Boolean
		lNoteIndex += 1
		Return GetFullNote() <> vbNullString
	End Function

	' Moves to the first note
	Public Function FirstNote() As Boolean
		lNoteIndex = 0
		Return GetFullNote() <> vbNullString
	End Function

	' Retuns the duration of the current note
	Public Function GetDuration() As Byte
		Return CByte(ParseString(GetFullNote(), NOTE_CHARS, 1))
	End Function

	' Returns true if current note is a dot note
	Public Function IsDot() As Boolean
		Return GetFullNote().IndexOf(NOTE_DOT) >= 0
	End Function

	' Returns the sole note from the current full note
	Public Function GetNote() As String

		Dim sTemp As String = GetFullNote()

		Return CStr(IIf(sTemp.IndexOf(NOTE_C) >= 0, NOTE_C, IIf(sTemp.IndexOf(NOTE_D) >= 0, NOTE_D, IIf(sTemp.IndexOf(NOTE_E) >= 0, NOTE_E, IIf(sTemp.IndexOf(NOTE_F) >= 0, NOTE_F, IIf(sTemp.IndexOf(NOTE_G) >= 0, NOTE_G, IIf(sTemp.IndexOf(NOTE_A) >= 0, NOTE_A, IIf(sTemp.IndexOf(NOTE_B) >= 0, NOTE_B, IIf(sTemp.IndexOf(NOTE_PAUSE) >= 0, NOTE_PAUSE, vbNullString)))))))))
	End Function

	' Returns true if note is sharp
	Public Function IsSharp() As Boolean
		Return GetFullNote().IndexOf(NOTE_SHARP) >= 0
	End Function

	' Returns the current note octave
	Public Function GetOctave() As Byte
		Return CByte(ParseString(GetFullNote(), NOTE_CHARS, 2))
	End Function

	' Main note playback workhorse
	Public Sub Play()
		Dim sNote As Char
		Dim fFrequency As Single

		If colRingtone.Count = 0 Then Exit Sub

		' Get the sole note
		sNote = CChar(GetNote())
		' Convert note to a numeric form
		Dim cNote As Byte = CByte(IIf(CStr(sNote).IndexOf(NOTE_C) >= 0, 1, IIf(CStr(sNote).IndexOf(NOTE_D) >= 0, 2, IIf(CStr(sNote).IndexOf(NOTE_E) >= 0, 3, IIf(CStr(sNote).IndexOf(NOTE_F) >= 0, 4, IIf(CStr(sNote).IndexOf(NOTE_G) >= 0, 5, IIf(CStr(sNote).IndexOf(NOTE_A) >= 0, 6, IIf(CStr(sNote).IndexOf(NOTE_B) >= 0, 7, IIf(CStr(sNote).IndexOf(NOTE_PAUSE) >= 0, 0, 0)))))))))

		' Calculate the appropriate duration to play
		Dim fDuration As Single = CalcDuration(GetDuration(), IsDot())

		If cNote = 0 Then
			' Simulate silence
			RaiseEvent Playing(GetFullNote(), 0, fDuration)
			Threading.Thread.Sleep(CInt(fDuration))
		Else
			' Calculate the frequency to play
			fFrequency = CalcFrequency(cNote, IsSharp(), GetOctave())
			RaiseEvent Playing(GetFullNote(), fFrequency, fDuration)
			Beep(CInt(fFrequency), CInt(fDuration))
		End If
	End Sub
End Class