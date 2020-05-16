' iMelody format encoder
' Copyright (c) Samuel Gomes, 2003-2020
' mailto: v_2samg@hotmail.com
'
' Sony Ericsson monophonic rintones are actually iMelody (.imy) files with the following format:
'
' BEGIN:IMELODY
' VERSION:<version>
' FORMAT:<format>
' [NAME:<tone-name>]
' [COMPOSER:<compose-information>]
' [BEAT:<bpm>]
' [STYLE:<style>]
' [VOLUME:<volume>]
' MELODY:<melody>
' END:IMELODY
'
' version := <1.2>
' format := <CLASS1.0>
' name := <"sting value">
' composer := <"string value">
' beat := <25> | ... | <900>
' style := <S0> | <S1> | <S2>
' volume-modifier := <V+> | <V->
' volume := <V1> | ... | <V15> | [volume-modifier]
' basic-note := <c> | <d> | <e> | <f> | <g> | <a> | <b>
' ess-note := <&c> | <&d> | <&e> | <&f> | <&g> | <&a> | <&b>
' iss-note := <#c> | <#d> | <#e> | <#f> | <#g> | <#a> | <#b>
' basic-ess-iss-note := <basic-note> | <ess-note> | <iss-note>
' octave-prefix := <*0> | ... | <*8>
' duration := <0> | ... | <5>
' duration-specifier := <.> | <:> | <;>
' rest := <r>
' led := <ledoff> | <ledon>
' vibe := <vibeoff> | <vibeon>
' backlight := <backoff> | <backon>
' note := [octave-prefix]<basic-ess-iss-note><duration>[duration-specifier]
' silence := <rest><duration>[duration-specifier]
' repeat-count := <0> | ...         {where 0 means forever}
' repeat := "("{<silence> | <note> | <led> | <vibe> | <volume> | <backlight>}+ "@"<repeat-count> [<volume-modifier>]")"
' melody := {<silence> | <note> | <led> | <vibe> | <volume> | <backlight>}+
'
' Duration details:
'   0 = full note
'   1 = 1/2 note
'   2 = 1/4 note
'   3 = 1/8 note
'   4 = 1/16 note
'   5 = 1/32 note
' Duration modifier details:
'   . = dot note
'   : = double dot note
'   ; = 2/3 length
' Style details:
'   S0 = natural; very short rests
'   S1 = continious; no rests
'   S2 = staccato; notes shortened and rests inserted
'
' BTW I am a proud owner of a Sony Ericsson T610 mobile :)

Imports Microsoft.VisualBasic

Friend Class ClsRingtoneSE
	' Option emumeration
	Private Enum IMYOptions
		Style = 1
		Repeat
		AutoVibration
		AutoBacklight
		AutoLED
		Volume
	End Enum

	Private ReadOnly cOptions(5) As Byte
	Private sRingtone As String = vbNullString, sName As String = vbNullString


	Public Function GetData() As String
		Return sRingtone
	End Function

	Public Sub SetOptions(ParamArray ByVal vpaArgs() As Object)
		Dim vVal As Byte
		Dim cOption As Byte = 0

		For Each vValIterator As Byte In vpaArgs
			vVal = vValIterator
			cOptions(cOption) = vVal
			cOption += CByte(1)
		Next vValIterator
	End Sub

	' Returns the ringtone name
	Public ReadOnly Property Name() As String
		Get
			Return sName
		End Get
	End Property

	Public Sub ConvertFrom(ByVal RTP As ClsRingTonePlayer)
		Dim sNote As Char
		Dim lNoteCtr As Integer
		Dim bLOn, bVOn, bBOn As Boolean

		' Store name
		sName = RTP.Name

		sRingtone = "BEGIN:IMELODY" & Environment.NewLine
		sRingtone = sRingtone & "VERSION:1.2" & Environment.NewLine
		sRingtone = sRingtone & "FORMAT:CLASS1.0" & Environment.NewLine
		sRingtone = sRingtone & "NAME:" & RTP.Name & Environment.NewLine
		sRingtone = sRingtone & "COMPOSER:Samuel Gomes (Blade) (c) " & CStr(Date.Now.Year) & " for Sony Ericsson Mobile" & Environment.NewLine
		sRingtone = sRingtone & "BEAT:" & CStr(RTP.Tempo) & Environment.NewLine
		sRingtone = sRingtone & "STYLE:S" & CStr(Clamp(cOptions(IMYOptions.Style - 1), 0, 2)) & Environment.NewLine
		sRingtone = sRingtone & "VOLUME:V" & CStr(Clamp(cOptions(IMYOptions.Volume - 1), 1, 15)) & Environment.NewLine
		sRingtone &= "MELODY:"

		If cOptions(IMYOptions.Repeat - 1) > 0 Then
			sRingtone &= "(r1"
		Else
			sRingtone &= "r5"
		End If

		If RTP.FirstNote() Then
			Do
				sNote = CChar(RTP.GetNote().ToLower())
				If CStr(sNote) = "p" Then
					sRingtone = sRingtone & "r" & CStr(6 - RTP.GetDuration())
				Else
					sRingtone = sRingtone & "*" & CStr(3 + RTP.GetOctave()) & CStr(IIf(RTP.IsSharp(), "#", vbNullString)) & CStr(sNote) & CStr(6 - RTP.GetDuration()) & CStr(IIf(RTP.IsDot(), ".", vbNullString))
				End If

				' Increase note counter
				lNoteCtr += 1

				' Backlight effect
				If cOptions(IMYOptions.AutoBacklight - 1) > 0 Then
					If lNoteCtr Mod cOptions(IMYOptions.AutoBacklight - 1) = 0 Then
						bBOn = Not bBOn ' flip state
						sRingtone &= CStr(IIf(bBOn, "backon", "backoff"))
					End If
				End If

				' LED effect
				If cOptions(IMYOptions.AutoLED - 1) > 0 Then
					If lNoteCtr Mod cOptions(IMYOptions.AutoLED - 1) = 0 Then
						bLOn = Not bLOn ' flip state
						sRingtone &= CStr(IIf(bLOn, "ledon", "ledoff"))
					End If
				End If

				' Vibration effect
				If cOptions(IMYOptions.AutoVibration - 1) > 0 Then
					If lNoteCtr Mod cOptions(IMYOptions.AutoVibration - 1) = 0 Then
						bVOn = Not bVOn ' flip state
						sRingtone &= CStr(IIf(bVOn, "vibeon", "vibeoff"))
					End If
				End If
			Loop While RTP.NextNote()
		End If

		' Turn on backlight if it is not active
		If cOptions(IMYOptions.AutoBacklight - 1) > 0 Then
			If Not bBOn Then
				sRingtone &= "backon"
			End If
		End If

		' Turn off LED if it is active
		If cOptions(IMYOptions.AutoLED - 1) > 0 Then
			If bLOn Then
				sRingtone &= "ledoff"
			End If
		End If

		' Turn off vibration if it is active
		If cOptions(IMYOptions.AutoVibration - 1) > 0 Then
			If bVOn Then
				sRingtone &= "vibeoff"
			End If
		End If

		If cOptions(IMYOptions.Repeat - 1) > 0 Then
			sRingtone = sRingtone & "@" & CStr(cOptions(IMYOptions.Repeat - 1)) & ")"
		Else
			sRingtone &= "r5"
		End If

		sRingtone = sRingtone & Environment.NewLine & "END:IMELODY"
	End Sub

	Public Sub New()
		MyBase.New()
		sRingtone = vbNullString
		cOptions(IMYOptions.AutoVibration - 1) = 8
		cOptions(IMYOptions.AutoLED - 1) = 2
		cOptions(IMYOptions.AutoBacklight - 1) = 1
		cOptions(IMYOptions.Repeat - 1) = 4
		cOptions(IMYOptions.Style - 1) = 1
		cOptions(IMYOptions.Volume - 1) = 15
	End Sub
End Class