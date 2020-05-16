' Standard RTTTL format to the internal ringtone format converter
' Copyright (c) Samuel Gomes, 2003-2020
' mailto: v_2samg@hotmail.com

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
		Dim iUser As DialogResult

		' Start converting to internal format
		Try

			' Parse default parameters
			cDefDuration = 4
			cDefOctave = 5
			cDefTempo = 200
			sParams = ParseString(Data, ":", 2)

			For i = 1 To 3
				sTemp = ParseString(sParams, ", " & vbTab, i).ToLower()

				If sTemp.IndexOf("o"c) >= 0 Then
					cDefOctave = CByte(ParseString(sTemp, "= " & vbTab, 2))
				End If

				If sTemp.IndexOf("b"c) >= 0 Then
					cDefTempo = CByte(ParseString(sTemp, "= " & vbTab, 2))
				End If

				If sTemp.IndexOf("d"c) >= 0 Then
					cDefDuration = CByte(ParseString(sTemp, "= " & vbTab, 2))
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

				sNote = "p"c ' default note
				sNote = CChar(IIf(sTemp.IndexOf("c"c) >= 0, "c", IIf(sTemp.IndexOf("d"c) >= 0, "d", IIf(sTemp.IndexOf("e"c) >= 0, "e", IIf(sTemp.IndexOf("f"c) >= 0, "f", IIf(sTemp.IndexOf("g"c) >= 0, "g", IIf(sTemp.IndexOf("a"c) >= 0, "a", IIf(sTemp.IndexOf("b"c) >= 0, "b", IIf(sTemp.IndexOf("p"c) >= 0, "p", vbNullString)))))))))
				bIsSharp = sTemp.IndexOf("#"c) >= 0
				cOctave = CByte(ParseString(sTemp, "cdefgabp.#", 2))
				cOctave = CByte(IIf(cOctave < 1, cDefOctave, cOctave)) - CByte(4)
				cOctave = CByte(Clamp(cOctave, 1, 3))
				cDuration = CByte(ParseString(sTemp, "cdefgabp.#", 1))
				cDuration = CByte(IIf(cDuration < 1, cDefDuration, cDuration))
				cDuration = CByte(IIf(cDuration > 16, 1, IIf(cDuration > 8, 2, IIf(cDuration > 4, 3, IIf(cDuration > 2, 4, IIf(cDuration > 1, 5, IIf(cDuration >= 0, 6, 0)))))))
				bIsDot = sTemp.IndexOf("."c) >= 0 And CStr(sNote) <> "p"

				RTP.AddNote(CStr(sNote), bIsSharp, cOctave, cDuration, bIsDot)
			Loop While sTemp <> vbNullString

		Catch

			iUser = ErrorDialog(ErrorToString() & " when parsing (" & sTemp & ")")
			If iUser = System.Windows.Forms.DialogResult.Retry Then
				' Do something for retry
			ElseIf iUser = System.Windows.Forms.DialogResult.Ignore Then
				' Do something for ignore
			End If
		End Try
	End Sub
End Class