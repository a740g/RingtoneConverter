' Ringtone Converter (SE Edition)
' Copyright (c) Samuel Gomes, 2003-2020
' mailto: v_2samg@hotmail.com
'
' The application only generates Sony Ericsson IMY format for now
' Export to more formats can be added later
' Probably we can implement multiple formats someday. :)

Imports Microsoft.VisualBasic
Imports System.Collections.Specialized

Partial Friend Class FrmMain
	Inherits Form

	Private ReadOnly isInitializingComponent As Boolean

	Public Sub New()
		MyBase.New()
		If m_vb6FormDefInstance Is Nothing Then
			If m_InitializingDefInstance Then
				m_vb6FormDefInstance = Me
			Else
				Try
					'For the start-up form, the first instance created is the default instance.
					If Not System.Reflection.Assembly.GetExecutingAssembly().EntryPoint Is Nothing AndAlso System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType Is Me.GetType() Then
						m_vb6FormDefInstance = Me
					End If

				Catch
				End Try
			End If
		End If
		'This call is required by the Windows Form Designer.
		isInitializingComponent = True
		InitializeComponent()
		isInitializingComponent = False
	End Sub

	' A quick and dirty to way to implement an About dialog
	Private Declare Function ShellAbout Lib "shell32" Alias "ShellAboutA" (ByVal hWnd As IntPtr, ByVal szApp As String, ByVal szOtherStuff As String, ByVal hIcon As IntPtr) As Integer

	' The RTTTL ringtone collection file
	Private Const FileRTC As String = "ringtones.rtc"
	' Flag that can be checked when the app is loading the ringtone collection
	Private IsLoading As Boolean = False
	' In-memory ringtone collection
	Private ReadOnly scRingtones As New StringCollection
	' Our global RTTTL object
	Private ReadOnly rtRTTTL As New ClsRingtoneRTTTL
	' Our global Ringtone player object; we will "New" later
	Public WithEvents RtPlayer As ClsRingTonePlayer
	' Out global SE Ringtone converter object
	Public rtSE As New ClsRingtoneSE

	' Converts ringtone data from RTTL to SE IMY
	Public Sub MnuFileConvert_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileConvert.Click
		rtRTTTL.Data = txtSource.Text
		rtRTTTL.ConvertTo(RtPlayer)
		rtSE.ConvertFrom(RtPlayer)
		txtDestination.Text = rtSE.GetData()
	End Sub

	Public Sub MnuFileOptions_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileOptions.Click
		frmOptions.DefInstance.ShowDialog(Me)
	End Sub

	Public Sub MnuHelpAbout_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuHelpAbout.Click
		ShellAbout(Handle,
			 Application.ProductName,
			 FileVersionInfo.GetVersionInfo(Reflection.Assembly.GetExecutingAssembly.Location).LegalCopyright & vbNewLine & "Version " & Application.ProductVersion,
			 Icon.Handle)
	End Sub

	Public Sub MnuFileExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileExit.Click
		Me.Close()
	End Sub

	Public Sub MnuFileProperties_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileProperties.Click
		MessageBox.Show(
			"Ringtone: " & rtRTTTL.Name & Environment.NewLine & "Current List item (" & CStr(cboRingtones.SelectedIndex) & "): " & CStr(cboRingtones.SelectedItem) & Environment.NewLine & "Current Collections item: " & scRingtones(cboRingtones.SelectedIndex),
			My.Application.Info.Title,
			MessageBoxButtons.OK,
			MessageBoxIcon.Information)
	End Sub

	Private Sub CboRingtones_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboRingtones.SelectedIndexChanged
		txtSource.Text = scRingtones(cboRingtones.SelectedIndex)
		rtRTTTL.Data = txtSource.Text
		rtRTTTL.ConvertTo(RtPlayer)
	End Sub

	Public Sub MnuFileRemove_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileRemove.Click
		If MessageBox.Show("Are you sure that you want to remove this ringtone?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then

			Dim iOldPos As Integer = cboRingtones.SelectedIndex

			scRingtones.RemoveAt(iOldPos)
			cboRingtones.Items.RemoveAt(iOldPos)

			If cboRingtones.Items.Count > 0 And iOldPos > 0 Then
				cboRingtones.SelectedIndex = iOldPos - 1
			Else
				cboRingtones.SelectedIndex = 0
			End If

			EnableDisableControls()
		End If
	End Sub

	Public Sub MnuFileExport_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileExport.Click
		Dim iFileExport As Integer

		Dim sExportFile As String = BrowseForFolderDialog(Me, "Select location to export '" & rtSE.Name & "':")
		If sExportFile = vbNullString Then Exit Sub
		If sExportFile.Substring(Math.Max(sExportFile.Length - 1, 0)) <> "\" Then sExportFile &= "\"
		sExportFile = sExportFile & MakeLegalFileName(rtSE.Name) & ".imy"

		Try
			iFileExport = FileSystem.FreeFile()
			FileSystem.FileOpen(iFileExport, sExportFile, OpenMode.Output, OpenAccess.Write)
			FileSystem.PrintLine(iFileExport, txtDestination.Text)
			FileSystem.FileClose(iFileExport)
		Catch
			MessageBox.Show("Failed to export ringtone to file (" & sExportFile & ")!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End Try
	End Sub

	Public Sub MnuFileNew_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileNew.Click
		' Get title from user
		Dim sTitle As String = Trim(InputBox("Enter the ringtone name:", Application.ProductName, "Untitled"))

		If sTitle = vbNullString Then Exit Sub

		txtSource.Text = sTitle & ":d=4,o=5,b=200:"

		' Add the ringtone to the internal list
		Dim lCtr As Integer = cboRingtones.Items.Count

		cboRingtones.Items.Insert(lCtr, sTitle)
		scRingtones.Insert(lCtr, txtSource.Text)

		cboRingtones.SelectedIndex = cboRingtones.Items.Count - 1

		EnableDisableControls()
	End Sub

	Public Sub MnuFileSave_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileSave.Click
		Dim errWriteRTC As Boolean = False
		Dim iFileRTC As Integer
		Dim sRT As String = vbNullString

		Try
			If MessageBox.Show("Are you sure that you want to overwrite the entire ringtone collection?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
				' First update the current ringtone
				scRingtones(cboRingtones.SelectedIndex) = txtSource.Text

				errWriteRTC = True

				iFileRTC = FileSystem.FreeFile()
				FileSystem.FileOpen(iFileRTC, FileRTC, OpenMode.Output, OpenAccess.Write)

				For lCtr As Integer = 0 To cboRingtones.Items.Count - 1
					If LCase(Trim(sRT)) <> LCase(Trim(scRingtones(lCtr))) Then
						FileSystem.PrintLine(iFileRTC, Trim(scRingtones(lCtr)))
					End If
					sRT = scRingtones(lCtr)
				Next

				FileSystem.FileClose(iFileRTC)
			End If
		Catch excep As Exception
			If Not errWriteRTC Then
				Throw excep
			End If

			If errWriteRTC Then
				MessageBox.Show("Failed to save ringtones to the ringtone collection file (" & FileRTC & ")!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If
		End Try
	End Sub

	' This quickly checks what has to be enabled or disabled
	Private Sub EnableDisableControls()
		cboRingtones.Enabled = cboRingtones.Items.Count > 0
		txtSource.Enabled = cboRingtones.Items.Count > 0
		txtDestination.Enabled = cboRingtones.Items.Count > 0
		mnuFileConvert.Enabled = cboRingtones.Items.Count > 0
		mnuPlayPlay.Enabled = cboRingtones.Items.Count > 0
		mnuFileRemove.Enabled = cboRingtones.Items.Count > 0
		mnuFileSave.Enabled = cboRingtones.Items.Count > 0
		mnuPlayStop.Enabled = False
		mnuFileProperties.Enabled = cboRingtones.Items.Count > 0
		mnuFileExport.Enabled = txtDestination.Text <> vbNullString


		tbToolbar_Delete.Enabled = mnuFileRemove.Enabled
		tbToolbar_Save.Enabled = mnuFileSave.Enabled
		tbToolbar_Convert.Enabled = mnuFileConvert.Enabled
		tbToolbar_Play.Enabled = mnuPlayPlay.Enabled
		tbToolbar_Stop.Enabled = mnuPlayStop.Enabled
		tbToolbar_Properties.Enabled = mnuFileProperties.Enabled
		tbToolbar_Export.Enabled = mnuFileExport.Enabled

		TSLabel.Text = "Ready!"
	End Sub

	Public Sub MnuPlayPlay_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuPlayPlay.Click
		mnuPlayPlay.Enabled = False
		tbToolbar_Play.Enabled = mnuPlayPlay.Enabled
		mnuPlayStop.Enabled = True
		tbToolbar_Stop.Enabled = mnuPlayStop.Enabled

		If RtPlayer.FirstNote() Then
			Do
				RtPlayer.Play()
				Application.DoEvents()
			Loop While RtPlayer.NextNote() And mnuPlayStop.Enabled
		End If

		EnableDisableControls()
	End Sub

	Public Sub MnuPlayStop_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuPlayStop.Click
		If mnuPlayStop.Enabled Then
			mnuPlayStop.Enabled = False
			tbToolbar_Stop.Enabled = False
		End If
	End Sub

	Private Sub RtPlayer_Playing(ByVal sNote As String, ByVal fFrequency As Single, ByVal fDuration As Single) Handles RtPlayer.Playing
		If fFrequency = 0 Then
			TSLabel.Text = "Playing (" & sNote & ") silence for " & CStr(fDuration) & "ms..."
		Else
			TSLabel.Text = "Playing (" & sNote & ") " & CStr(fFrequency) & "hz for " & CStr(fDuration) & "ms..."
		End If

		' Refresh the statusbar or we will always be one note behind!
		sbStatus.Refresh()
	End Sub

	Private Sub TbToolbar_ButtonClick(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles tbToolbar_New.Click, tbToolbar_Save.Click, tbToolbar_Delete.Click, tbToolbar_Properties.Click, tbToolbar_Convert.Click, tbToolbar_Export.Click, tbToolbar_Options.Click, tbToolbar_Play.Click, tbToolbar_Stop.Click, tbToolbar_Help.Click
		Dim Button As ToolStripItem = CType(eventSender, ToolStripItem)

		Select Case CStr(Button.Tag)
			Case "New"
				MnuFileNew_Click(eventSender, eventArgs)
			Case "Save"
				MnuFileSave_Click(eventSender, eventArgs)
			Case "Delete"
				MnuFileRemove_Click(eventSender, eventArgs)
			Case "Properties"
				MnuFileProperties_Click(eventSender, eventArgs)
			Case "Convert"
				MnuFileConvert_Click(eventSender, eventArgs)
			Case "Export"
				MnuFileExport_Click(eventSender, eventArgs)
			Case "Options"
				MnuFileOptions_Click(eventSender, eventArgs)
			Case "Play"
				MnuPlayPlay_Click(eventSender, eventArgs)
			Case "Stop"
				MnuPlayStop_Click(eventSender, eventArgs)
			Case "Help"
				MnuHelpAbout_Click(eventSender, eventArgs)
			Case Else
				MessageBox.Show("Toolbar function " & Button.Name & " not implemented!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End Select
	End Sub

	Private Sub TxtDestination_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtDestination.TextChanged
		If isInitializingComponent Then Exit Sub

		mnuFileExport.Enabled = txtDestination.Text <> vbNullString
		tbToolbar_Export.Enabled = mnuFileExport.Enabled
	End Sub

	' Load the RTC file
	Private Sub FrmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		Dim iFileRTC As Integer
		Dim sRingtone As String = vbNullString

		' Initialize the randomizer
		VBMath.Randomize()

		' Create the player objects
		RtPlayer = New ClsRingTonePlayer(Me)

		' Load all ringtones from the ringtone file into the combo
		IsLoading = True

		Try

			cboRingtones.Items.Clear()
			scRingtones.Clear()

			iFileRTC = FileSystem.FreeFile()
			FileSystem.FileOpen(iFileRTC, FileRTC, OpenMode.Input, OpenAccess.Read)

			Do Until FileSystem.EOF(iFileRTC)
				sRingtone = FileSystem.LineInput(iFileRTC)
				cboRingtones.Items.Add(Trim(ParseString(sRingtone, ":", 1)))
				scRingtones.Add(sRingtone)
			Loop

			FileSystem.FileClose(iFileRTC)

			cboRingtones.SelectedIndex = 0
			TxtDestination_TextChanged(txtDestination, e)

		Catch

			MessageBox.Show("Failed to load ringtones from the ringtone collection file (" & FileRTC & ")!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

		End Try

		IsLoading = False
		EnableDisableControls()
	End Sub

	' Stop playback while closing the app
	Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		MnuPlayStop_Click(sender, e)
	End Sub

	Private Sub TxtSource_TextChanged(sender As Object, e As EventArgs) Handles txtSource.TextChanged
		If IsLoading Then Return

		' Add the ringtone to the internal list only if it has changed
		Dim sData As String = scRingtones(cboRingtones.SelectedIndex)

		If sData <> txtSource.Text Then
			scRingtones(cboRingtones.SelectedIndex) = txtSource.Text
			rtRTTTL.Data = txtSource.Text
			rtRTTTL.ConvertTo(RtPlayer)
		End If
	End Sub
End Class