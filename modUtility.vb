' Miscellaneous utility functions
' Copyright (c) Samuel Gomes (Blade), 2003-2004
' mailto: v_2samg@hotmail.com

Imports Microsoft.VisualBasic

Friend Module modUtility

	' Global type definitions
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

	' Win32 Shell About box
	Private Declare Function SHBrowseForFolder Lib "shell32" Alias "SHBrowseForFolderA" (ByRef lpbi As BrowseInfo) As Integer
	Private Declare Function SHGetPathFromIDList Lib "shell32" Alias "SHGetPathFromIDListA" (ByVal pIdList As Integer, ByVal pszPath As String) As Integer
	Private Declare Sub CoTaskMemFree Lib "ole32" (ByVal pv As Integer)

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
		Return CInt(IIf(vVal > vMax, vMax, Math.Max(vMin, vVal)))
	End Function

	' Similar to the C library strbrk() function
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

	' Similar to the C library strspn() function
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

	' The main string parsing workhorse
	Public Function GetToken(ByVal Search As String, ByVal Delim As String) As String
		Dim result As String
		Static SaveStr As String
		Static BegPos As Integer

		If Search <> vbNullString Then
			BegPos = 1
			SaveStr = Search
		End If

		Dim newPos As Integer = StrSpn(SaveStr.Substring(BegPos - 1, Math.Min(Len(SaveStr), SaveStr.Length - (BegPos - 1))), Delim)
		If newPos > 0 Then
			BegPos = newPos + BegPos - 1
		Else
			Return vbNullString
		End If

		newPos = StrBrk(SaveStr.Substring(BegPos - 1, Math.Min(Len(SaveStr), SaveStr.Length - (BegPos - 1))), Delim)
		If newPos > 0 Then
			newPos = BegPos + newPos - 1
		Else
			newPos = Len(SaveStr) + 1
		End If
		result = SaveStr.Substring(BegPos - 1, Math.Min(newPos - BegPos, SaveStr.Length - (BegPos - 1)))
		BegPos = newPos
		Return result
	End Function

	' Just a convenient wrapper over GetToken()
	Public Function ParseString(ByVal UserString As String, ByVal UserToken As String, ByVal SubStringNumber As Integer) As String
		Dim result As String

		If UserString = vbNullString Then
			Return vbNullString
		End If

		result = GetToken(UserString, UserToken)
		If SubStringNumber < 2 Then Return result
		Dim i As Integer = 1
		Do
			result = GetToken(vbNullString, UserToken)
			i += 1
		Loop While i < SubStringNumber
		Return result
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
	Public Function BrowseForFolderDialog(ByVal frmForm As frmMain, Optional ByVal sTitle As String = "Browse For Folder:", Optional ByVal bShowFiles As Boolean = False, Optional ByVal bShowEditBox As Boolean = False) As String
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
			sBuffer = New String(" "c, MAX_PATH)
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

		Return sFName.Trim()
	End Function

End Module