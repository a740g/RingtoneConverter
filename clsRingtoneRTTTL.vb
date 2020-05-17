' Standard RTTTL format to the internal ringtone format converter
' Copyright (c) Samuel Gomes, 2003-2020
' mailto: v_2samg@hotmail.com
'
' RTTTL Format Specifications
'
' RTTTL(RingTone Text Transfer Language) Is the primary format used To distribute 
' ringtones for Nokia phones. An RTTTL file Is a text file, containing the 
' ringtone name, a control section And a section containing a comma separated 
' sequence of ring tone commands. White space must be ignored by any reader 
' application. 
'
' Example:
' Simpsons: d = 4,o=5,b=160:32p,c.6,e6,f#6,8a6,g.6,e6,c6,8a,8f#,8f#,8f#,2g
'
' This file describes a ringtone whose name Is 'Simpsons'. The control section 
' sets the beats per minute at 160, the Default note length As 4, And the Default 
' scale as Octave 5. 
' <RTX file> := <name> ":" [<control section>] ":" <tone-commands>
'
' 	<name> := <Char> ; maximum name length 10 characters
'
' 	<Control-section> := <control-pair> ["," <control-section>]
'
' 		<Control-pair> := <control-name> ["="] <control-value>
'
' 		<Control-name> := "o" | "d" | "b"
' 		; Valid in control section: o =default scale, d=default duration, b=default beats per minute. 
' 		; if Not specified, defaults are 4=duration, 6=scale, 63=beats-per-minute
' 		; any unknown control-names must be ignored
'
' 		<tone-commands> := <tone-command> ["," <tone-commands>]
'
' 		<tone-command> :=<note> | <control-pair>
'
' 		<note> := [<duration>] <note> [<scale>] [<special-duration>] <delimiter>
'
' 			<duration> := "1" | "2" | "4" | "8" | "16" | "32" 
' 			; duration Is divider of full note duration, eg. 4 represents a quarter note
'
' 			<note> := "P" | "C" | "C#" | "D" | "D#" | "E" | "F" | "F#" | "G" | "G#" | "A" | "A#" | "B" 
'
' 			<scale> :="4" | "5" | "6" | "7"
' 			; Note that octave 4: A = 440Hz, 5: A = 880Hz, 6: A = 1.76 kHz, 7: A = 3.52 kHz
' 			; The lowest note on the Nokia 61xx Is A4, the highest Is B7
'
' 			<special-duration> := "." ; Dotted note

Imports Microsoft.VisualBasic

Friend Class ClsRingtoneRTTTL

	' Stores the ringtone in a internal variable
	Public Data As String = vbNullString

	' Returns the ringtone name
	Public Function Name() As String
		Return Trim(ParseString(Data, ":", 1))
	End Function

	' Converts the RTTTL ringtone to the internal ringtone format
	Public Sub ConvertTo(ByVal RTP As ClsRingTonePlayer)
		Dim i As Integer
		Dim sParams As String, sTemp As String = vbNullString
		Dim cDefOctave, cDefDuration, cDefTempo As Byte
		Dim sData As String
		Dim cDuration As Byte
		Dim bIsDot As Boolean
		Dim sNote As Char
		Dim cOctave As Byte
		Dim bIsSharp As Boolean

		' Start converting to internal format
		' Parse default parameters
		cDefDuration = 4
		cDefOctave = 5
		cDefTempo = 200
		sParams = ParseString(Data, ":", 2)

		For i = 1 To 3
			sTemp = LCase(ParseString(sParams, ", " & vbTab, i))

			If InStr(sTemp, "o") > 0 Then
				cDefOctave = CByte(Val(ParseString(sTemp, "= " & vbTab, 2)))
			End If

			If InStr(sTemp, "b") > 0 Then
				cDefTempo = CByte(Val(ParseString(sTemp, "= " & vbTab, 2)))
			End If

			If InStr(sTemp, "d") > 0 Then
				cDefDuration = CByte(Val(ParseString(sTemp, "= " & vbTab, 2)))
			End If
		Next

		' Initialize player
		RTP.Clear()
		RTP.Name = Name
		RTP.Tempo = cDefTempo

		sData = ParseString(Data, ":", 3)
		i = 0

		Do
			i += 1
			sTemp = LCase(ParseString(sData, ", " & vbTab, i))
			If sTemp = vbNullString Then Exit Do
			If Val(sTemp) < 1 Then sTemp = "0" & sTemp ' zero duration atleast; helps to parse

			sNote = CChar(IIf(InStr(sTemp, "c") > 0, "c", IIf(InStr(sTemp, "d") > 0, "d", IIf(InStr(sTemp, "e") > 0, "e", IIf(InStr(sTemp, "f") > 0, "f", IIf(InStr(sTemp, "g") > 0, "g", IIf(InStr(sTemp, "a") > 0, "a", IIf(InStr(sTemp, "b") > 0, "b", IIf(InStr(sTemp, "p") > 0, "p", "p")))))))))
			bIsSharp = InStr(sTemp, "#") > 0
			cOctave = CByte(Val(ParseString(sTemp, "cdefgabp.#", 2)))
			cOctave = CByte(IIf(cOctave < 4, cDefOctave, cOctave)) - CByte(4)
			cOctave = CByte(Clamp(cOctave, ClsRingTonePlayer.NOTE_OCTAVE_MIN, ClsRingTonePlayer.NOTE_OCTAVE_MAX))
			cDuration = CByte(Val(ParseString(sTemp, "cdefgabp.#", 1)))
			cDuration = CByte(IIf(cDuration < 1, cDefDuration, cDuration))
			cDuration = CByte(IIf(cDuration > 16, 1, IIf(cDuration > 8, 2, IIf(cDuration > 4, 3, IIf(cDuration > 2, 4, IIf(cDuration > 1, 5, IIf(cDuration >= 0, 6, 6)))))))
			bIsDot = InStr(sTemp, ".") > 0 And CStr(sNote) <> "p"

			RTP.AddNote(CStr(sNote), bIsSharp, cOctave, cDuration, bIsDot)
		Loop While sTemp <> vbNullString
	End Sub
End Class