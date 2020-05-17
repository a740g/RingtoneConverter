' Miscellaneous utility functions
' Copyright (c) Samuel Gomes, 2003-2020
' mailto: v_2samg@hotmail.com

Imports Microsoft.VisualBasic

Friend Module ModUtility

	' SHBrowseForFolder type
	Private Structure BrowseInfo
		Public hWndOwner As Integer
		Public pIDLRoot As Integer
		Public pszDisplayName As Integer
		Public lpszTitle As String
		Public ulFlags As Integer
		Public lpfnCallback As Integer
		Public lParam As Integer
		Public iImage As Integer
	End Structure

	' SHBrowseForFolder APIs
	Private Declare Function SHBrowseForFolder Lib "shell32" Alias "SHBrowseForFolderA" (ByRef lpbi As BrowseInfo) As Integer
	Private Declare Function SHGetPathFromIDList Lib "shell32" Alias "SHGetPathFromIDListA" (ByVal pIdList As Integer, ByVal pszPath As String) As Integer
	Private Declare Sub CoTaskMemFree Lib "ole32" (ByVal pv As Integer)

	' SHBrowseForFolder constants
	Private Const MAX_PATH As Integer = 260
	Private Const BIF_RETURNONLYFSDIRS As Integer = &H1S ' For finding a folder to start document searching
	Private Const BIF_DONTGOBELOWDOMAIN As Integer = &H2S ' For starting the Find Computer
	Private Const BIF_STATUSTEXT As Integer = &H4S
	Private Const BIF_RETURNFSANCESTORS As Integer = &H8S
	Private Const BIF_EDITBOX As Integer = &H10S
	Private Const BIF_VALIDATE As Integer = &H20S ' insist on valid result (or CANCEL)
	Private Const BIF_BROWSEFORCOMPUTER As Integer = &H1000S ' Browsing for Computers.
	Private Const BIF_BROWSEFORPRINTER As Integer = &H2000S ' Browsing for Printers
	Private Const BIF_BROWSEINCLUDEFILES As Integer = &H4000S ' Browsing for Everything

	' Converts a null-terminated string to a VB string (more of a convenience... trims it)
	Public Function CStrToBStr(ByVal lpszString As String) As String
		lpszString &= vbNullChar
		Return Left(lpszString, InStr(lpszString, vbNullChar) - 1)
	End Function

	' Clamps vVal between vMin and vMax
	Public Function Clamp(ByVal vVal As Integer, ByVal vMin As Integer, ByVal vMax As Integer) As Integer
		' Handle special case :)
		If vMin > vMax Then
			Return Math.Max(Math.Min(vMin, vVal), vMax)
		End If

		Return Math.Max(Math.Min(vMax, vVal), vMin)
	End Function

	' Overload of the above
	Public Function Clamp(ByVal vVal As UInteger, ByVal vMin As UInteger, ByVal vMax As UInteger) As UInteger
		' Handle special case :)
		If vMin > vMax Then
			Return Math.Max(Math.Min(vMin, vVal), vMax)
		End If

		Return Math.Max(Math.Min(vMax, vVal), vMin)
	End Function

	' StrBrk:
	'  Searches InString to find the first character from among those in
	'  Separator. Returns the index of that character. This function can
	'  be used to find the end of a token.
	' Input:
	'  InString = string to search
	'  Separator = characters to search for
	' Output:
	'  StrBrk = index to first match in InString$ or 0 if none match
	Public Function StrBrk(ByVal InString As String, ByVal Separator As String) As Integer
		Dim ln As Integer = Len(InString)
		Dim BegPos As Integer = 1

		Do While InStr(Separator, Mid(InString, BegPos, 1)) = 0
			If BegPos > ln Then
				Return 0
			Else
				BegPos += 1
			End If
		Loop

		Return BegPos
	End Function

	' StrSpn:
	'  Searches InString to find the first character that is not one of
	'  those in Separator. Returns the index of that character. This
	'  function can be used to find the start of a token.
	' Input:
	'  InString = string to search
	'  Separator = characters to search for
	' Output:
	'  StrSpn = index to first nonmatch in InString$ or 0 if all match
	Public Function StrSpn(ByVal InString As String, ByVal Separator As String) As Integer
		Dim ln As Integer = Len(InString)
		Dim BegPos As Integer = 1

		Do While InStr(Separator, Mid(InString, BegPos, 1)) <> 0
			If BegPos > ln Then
				Return 0
			Else
				BegPos += 1
			End If
		Loop

		Return BegPos
	End Function

	' GetToken:
	'  Extracts tokens from a string. A token is a word that is surrounded
	'  by separators, such as spaces or commas. Tokens are extracted and
	'  analyzed when parsing sentences or commands. To use the GetToken
	'  function, pass the string to be parsed on the first call, then pass
	'  a null string on subsequent calls until the function returns a null
	'  to indicate that the entire string has been parsed.
	' Input:
	'  Search = string to search
	'  Delim  = String of separators
	' Output:
	'  GetToken = next token
	Public Function GetToken(ByVal Search As String, ByVal Delim As String) As String
		' These must be static to remeber values from call to call
		Static SaveStr As String = vbNullString
		Static BegPos As Integer = 0

		' If first call, make a copy of the string
		If Search <> vbNullString Then
			BegPos = 1
			SaveStr = Search
		End If

		' Find the start of the next token
		Dim newPos As Integer = StrSpn(Mid(SaveStr, BegPos, Len(SaveStr)), Delim)
		If newPos <> 0 Then
			' Set position to start of token
			BegPos = newPos + BegPos - 1
		Else
			' If no new token, quit and return null
			Return vbNullString
		End If

		' Find end of token
		newPos = StrBrk(Mid(SaveStr, BegPos, Len(SaveStr)), Delim)
		If newPos <> 0 Then
			' Set position to end of token
			newPos = BegPos + newPos - 1
		Else
			' If no end of token, return set to end a value
			newPos = Len(SaveStr) + 1
		End If

		' Cut token out of search string
		Dim sResult As String = Mid(SaveStr, BegPos, newPos - BegPos)
		' Set new starting position
		BegPos = newPos

		Return sResult
	End Function

	' Just a convenient wrapper over GetToken()
	Public Function ParseString(ByVal UserString As String, ByVal UserToken As String, ByVal SubStringNumber As Integer) As String
		Dim i As Integer, sResult As String

		If UserString = vbNullString Then Return vbNullString

		sResult = GetToken(UserString, UserToken)

		If SubStringNumber < 2 Then Return sResult

		For i = 1 To SubStringNumber - 1
			sResult = GetToken(vbNullString, UserToken)
		Next

		Return sResult
	End Function

	' Displays an error dialog
	Public Function ErrorDialog(Optional ByVal sMessage As String = vbNullString, Optional ByVal sErrSrc As String = vbNullString, Optional ByVal sErrApp As String = vbNullString) As DialogResult
		If sMessage = vbNullString Then
			sMessage = ErrorToString()
			If sMessage = vbNullString Then
				sMessage = "Unknown error"
			End If
		End If

		If sErrApp = vbNullString Then
			sErrApp = My.Application.Info.ProductName
			If sErrApp = vbNullString Then
				sErrApp = My.Application.Info.Title
			End If
		End If

		If sErrSrc = vbNullString Then
			sErrSrc = Err().Source
			If sErrSrc = vbNullString Then
				sErrSrc = My.Application.Info.AssemblyName & ".exe"
			End If
		End If

		Return MessageBox.Show("The following error occured in " & sErrApp & " (" & sErrSrc & "):" & Environment.NewLine & Environment.NewLine & sMessage & "!", My.Application.Info.Title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
	End Function

	' Show standard Windows folder picker dialog box
	Public Function BrowseForFolderDialog(ByVal frmForm As FrmMain, Optional ByVal sTitle As String = "Browse For Folder:", Optional ByVal bShowFiles As Boolean = False, Optional ByVal bShowEditBox As Boolean = False) As String
		Dim sResult As String = vbNullString
		Dim sBuffer As String = vbNullString
		Dim tBrowseInfo As BrowseInfo

		' Setup some data
		With tBrowseInfo
			.hWndOwner = frmForm.Handle.ToInt32()
			.lpszTitle = sTitle
			.ulFlags = BIF_RETURNONLYFSDIRS Or BIF_DONTGOBELOWDOMAIN Or CInt(IIf(bShowFiles, BIF_BROWSEINCLUDEFILES, 0)) Or CInt(IIf(bShowEditBox, BIF_EDITBOX, 0))
		End With

		' Finally...
		Dim lpIDList As Integer = SHBrowseForFolder(tBrowseInfo)

		' Yuck!
		If CBool(lpIDList) Then
			sBuffer = Space(MAX_PATH)
			If CBool(SHGetPathFromIDList(lpIDList, sBuffer)) Then
				sResult = CStrToBStr(sBuffer)
			End If
			CoTaskMemFree(lpIDList)
		End If

		Return sResult
	End Function

	' Removes invalid characters from filenames
	Public Function MakeLegalFileName(ByVal sFName As String) As String
		For i As Integer = 1 To Len(sFName)
			If ("\/:*?<>|" & Chr(34).ToString()).IndexOf(sFName.Substring(i - 1, Math.Min(1, sFName.Length - (i - 1)))) >= 0 Then
				Mid(sFName, i, 1) = "_"
			End If
		Next

		Return Trim(sFName)
	End Function

End Module