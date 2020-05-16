' Ringtone Converter (SE Edition)
' Copyright (c) Samuel Gomes (Blade), 2003-2005
' mailto: v_2samg@hotmail.com

' Notes:
' The application only generates Nokia composer format (3315 compatible) and Panasonic composer
' format (GD68 compatible) ringtones from standard RTTTL format (as of now). Export to more formats
' may be added later.
' Ok, this is old. :( It only supports Sony Ericsson IMY format now. :)
' BTW, I love Sony Ericsson! :)

Imports Microsoft.VisualBasic
Imports System.Collections.Specialized
Imports System.ComponentModel

Partial Friend Class frmMain
	Inherits Form
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
		ReLoadForm(False)
	End Sub


	Private Sub FrmMain_Activated(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Activated
		' What does this do?
		'If Not UpgradeHelpers.Gui.ActivateHelper.myActiveForm Is eventSender Then
		'UpgradeHelpers.Gui.ActivateHelper.myActiveForm = eventSender
		'End If
	End Sub

	' A quick and dirty to way to implement an About dialog
	Private Declare Function ShellAbout Lib "shell32" Alias "ShellAboutA" (ByVal hWnd As IntPtr,
																		ByVal szApp As String,
																		ByVal szOtherStuff As String,
																		ByVal hIcon As IntPtr) As Integer
	' The RTTTL ringtone collection file
	Private Const FileRTC As String = "\ringtones.rtc"
	' In-memory ringtone collection
	Private colRingtones As New OrderedDictionary
	' Our global RTTTL object
	Private rtRTTTL As New ClsRingtoneRTTTL
	' Our global Ringtone player object
	Public WithEvents RtPlayer As ClsRingTonePlayer
	' Out global SE Ringtone converter object
	Public rtSE As New ClsRingtoneSE


	' Converts ringtone data from RTTL to SE IMY
	Public Sub mnuFileConvert_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileConvert.Click
		rtRTTTL.Data = txtSource.Text
		rtRTTTL.ConvertTo(RtPlayer)
		rtSE.ConvertFrom(RtPlayer)
		txtDestination.Text = rtSE.GetData()
	End Sub

	Public Sub mnuFileOptions_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileOptions.Click
		frmOptions.DefInstance.Show()
	End Sub

	Public Sub mnuHelpAbout_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuHelpAbout.Click
		ShellAbout(Handle,
			 Application.ProductName,
			 FileVersionInfo.GetVersionInfo(Reflection.Assembly.GetExecutingAssembly.Location).LegalCopyright & vbNewLine & "Version " & Application.ProductVersion,
			 Icon.Handle)
	End Sub

	Public Sub mnuFileExit_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileExit.Click
		Me.Close()
	End Sub

	Public Sub mnuFileProperties_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileProperties.Click
		MessageBox.Show("Ringtone: " & rtRTTTL.Name, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
	End Sub

	Private Sub cboRingtones_SelectedIndexChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cboRingtones.SelectedIndexChanged
		txtSource.Text = CStr(colRingtones(CStr(cboRingtones.SelectedIndex)))
		rtRTTTL.Data = txtSource.Text
		rtRTTTL.ConvertTo(RtPlayer)
	End Sub

	Public Sub mnuFileRemove_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileRemove.Click
		If MessageBox.Show("Are you sure that you want to remove this ringtone?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
			colRingtones.Remove(CStr(cboRingtones.SelectedIndex))

			If cboRingtones.Items.Count > 0 Then cboRingtones.SelectedIndex = 0

			EnableDisableControls()
		End If
	End Sub

	Public Sub mnuFileExport_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileExport.Click
		Dim iFileExport As Integer

		Dim sExportFile As String = BrowseForFolderDialog(Me, "Select location to export '" & rtSE.Name & "':")
		If sExportFile = vbNullString Then Exit Sub
		If sExportFile.Substring(Math.Max(sExportFile.Length - 1, 0)) <> "\" Then sExportFile = sExportFile & "\"
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
		Dim sTitle As String = Trim(InputBox("Enter the ringtone name:", vbNullString, "Untitled"))

		If sTitle = vbNullString Then Exit Sub

		txtSource.Text = sTitle & ":d=4,o=5,b=200:"

		' Add the ringtone to the internal list
		Dim lCtr As Integer = cboRingtones.Items.Count
		cboRingtones.Items.Add(sTitle)
		colRingtones.Add(CStr(lCtr), txtSource.Text)

		cboRingtones.SelectedIndex = cboRingtones.Items.Count - 1

		EnableDisableControls()
	End Sub

	Public Sub mnuFileSave_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuFileSave.Click
		Dim errWriteRTC As Boolean = False
		Dim iFileRTC As Integer
		Dim sRT As String = vbNullString

		Try
			If MessageBox.Show("Are you sure that you want to overwrite the entire ringtone collection?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
				' First update the current ringtone
				colRingtones.Remove(CStr(cboRingtones.SelectedIndex))
				colRingtones.Add(CStr(cboRingtones.SelectedIndex), txtSource.Text)

				errWriteRTC = True

				iFileRTC = FileSystem.FreeFile()
				FileSystem.FileOpen(iFileRTC, My.Application.Info.DirectoryPath & FileRTC, OpenMode.Output, OpenAccess.Write)

				For lCtr As Integer = 0 To cboRingtones.Items.Count - 1
					If sRT.Trim().ToLower() <> CStr(colRingtones(CStr(lCtr))).Trim().ToLower() Then
						FileSystem.PrintLine(iFileRTC, CStr(colRingtones(CStr(lCtr))).Trim())
					End If
					sRT = CStr(colRingtones(CStr(lCtr)))
				Next

				FileSystem.FileClose(iFileRTC)
			End If

		Catch excep As Exception
			If Not errWriteRTC Then
				Throw excep
			End If

			If errWriteRTC Then
				MessageBox.Show("Failed to save ringtones to the ringtone collection file (" & My.Application.Info.DirectoryPath & FileRTC & ")!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If
		End Try

	End Sub

	'UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://www.mobilize.net/vbtonet/ewis/ewi2080
	Private Sub Form_Load()
		Dim iFileRTC As Integer
		Dim sRingtone As String = vbNullString
		Dim lCtr As Integer = 0

		' Initialize the randomizer
		VBMath.Randomize()

		' Create the player objects
		RtPlayer = New ClsRingTonePlayer(Me)

		' Load all ringtones from the ringtone file into the combo
		Try

			iFileRTC = FileSystem.FreeFile()
			FileSystem.FileOpen(iFileRTC, My.Application.Info.DirectoryPath & FileRTC, OpenMode.Input, OpenAccess.Read)

			Do Until FileSystem.EOF(iFileRTC)
				sRingtone = FileSystem.LineInput(iFileRTC)
				cboRingtones.Items.Add(ParseString(sRingtone, ":", 1).Trim())
				colRingtones.Add(CStr(lCtr), sRingtone)
				lCtr += 1
			Loop

			FileSystem.FileClose(iFileRTC)

			cboRingtones.SelectedIndex = 0
			TxtDestination_TextChanged(txtDestination, New EventArgs())

			EnableDisableControls()

		Catch

			MessageBox.Show("Failed to load ringtones from the ringtone collection file (" & My.Application.Info.DirectoryPath & FileRTC & ")!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End Try

	End Sub

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

		tbToolbar_Delete.Enabled = mnuFileRemove.Enabled
		tbToolbar_Save.Enabled = mnuFileSave.Enabled
		tbToolbar_Convert.Enabled = mnuFileConvert.Enabled
		tbToolbar_Play.Enabled = mnuPlayPlay.Enabled
		tbToolbar_Stop.Enabled = mnuPlayStop.Enabled
		tbToolbar_Properties.Enabled = mnuFileProperties.Enabled

		TSLabel.Text = "Ready!"
	End Sub

	Private Sub Form_Closed(ByVal eventSender As Object, ByVal eventArgs As CancelEventArgs) Handles MyBase.Closing
		Dim Cancel As Integer = CInt(IIf(eventArgs.Cancel, 1, 0))
		Try
			Cancel = CInt(Not mnuPlayPlay.Enabled)
		Finally
			eventArgs.Cancel = Cancel <> 0
		End Try
	End Sub

	Public Sub mnuPlayPlay_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuPlayPlay.Click
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

	Public Sub mnuPlayStop_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles mnuPlayStop.Click
		mnuPlayStop.Enabled = False
	End Sub

	Private Sub RtPlayer_Playing(ByVal sNote As String, ByVal fFrequency As Single, ByVal fDuration As Single) Handles RtPlayer.Playing
		If fFrequency = 0 Then
			TSLabel.Text = "Playing (" & sNote & ") silence for " & CStr(fDuration) & "ms..."
		Else
			TSLabel.Text = "Playing (" & sNote & ") " & CStr(fFrequency) & "hz for " & CStr(fDuration) & "ms..."
		End If
	End Sub

	Private Sub TbToolbar_ButtonClick(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles tbToolbar_New.Click, tbToolbar_Save.Click, tbToolbar_Delete.Click, tbToolbar_Buttons_Button4.Click, tbToolbar_Properties.Click, tbToolbar_Buttons_Button6.Click, tbToolbar_Convert.Click, tbToolbar_Export.Click, tbToolbar_Buttons_Button9.Click, tbToolbar_Options.Click, tbToolbar_Buttons_Button11.Click, tbToolbar_Play.Click, tbToolbar_Stop.Click, tbToolbar_Buttons_Button14.Click, tbToolbar_Help.Click
		Dim Button As ToolStripItem = CType(eventSender, ToolStripItem)

		Select Case CStr(Button.Tag)
			Case "New"
				MnuFileNew_Click(mnuFileNew, New EventArgs())
			Case "Save"
				mnuFileSave_Click(mnuFileSave, New EventArgs())
			Case "Remove"
				mnuFileRemove_Click(mnuFileRemove, New EventArgs())
			Case "Properties"
				mnuFileProperties_Click(mnuFileProperties, New EventArgs())
			Case "Convert"
				mnuFileConvert_Click(mnuFileConvert, New EventArgs())
			Case "Export"
				mnuFileExport_Click(mnuFileExport, New EventArgs())
			Case "Options"
				mnuFileOptions_Click(mnuFileOptions, New EventArgs())
			Case "Play"
				mnuPlayPlay_Click(mnuPlayPlay, New EventArgs())
			Case "Stop"
				mnuPlayStop_Click(mnuPlayStop, New EventArgs())
			Case "Help"
				mnuHelpAbout_Click(mnuHelpAbout, New EventArgs())
			Case Else
				MessageBox.Show("Toolbar function " & Button.Name & " not implemented!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End Select
	End Sub

	Private ReadOnly isInitializingComponent As Boolean
	Private Sub TxtDestination_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtDestination.TextChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		mnuFileExport.Enabled = txtDestination.Text <> vbNullString
		tbToolbar_Export.Enabled = mnuFileExport.Enabled
	End Sub
End Class