<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmMain
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmMain
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = CreateInstance()
				m_InitializingDefInstance = False
			End If
			Return m_vb6FormDefInstance
		End Get
		Set(ByVal Value As frmMain)
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region
#Region "Windows Form Designer generated code "
	Public Shared Function CreateInstance() As frmMain
		Dim theInstance As New frmMain()
		theInstance.Form_Load()
		Return theInstance
	End Function
	Private visualControls() As String = New String() {"components", "ToolTipMain", "mnuFileNew", "mnuFileSave", "mnuFileRemove", "mnuFileBar1", "mnuFileProperties", "mnuFileBar2", "mnuFileConvert", "mnuFileExport", "mnuFileBar3", "mnuFileOptions", "mnuFileBar4", "mnuFileExit", "mnuFile", "mnuPlayPlay", "mnuPlayStop", "mnuPlay", "mnuHelpAbout", "mnuHelp", "MainMenu1", "txtDestination", "fraSE", "txtSource", "cboRingtones", "fraRTTL", "sbStatus_Panels_Panel1", "sbStatus", "tbToolbar_Buttons_Button1", "tbToolbar_Buttons_Button2", "tbToolbar_Buttons_Button3", "tbToolbar_Buttons_Button4", "tbToolbar_Buttons_Button5", "tbToolbar_Buttons_Button6", "tbToolbar_Buttons_Button7", "tbToolbar_Buttons_Button8", "tbToolbar_Buttons_Button9", "tbToolbar_Buttons_Button10", "tbToolbar_Buttons_Button11", "tbToolbar_Buttons_Button12", "tbToolbar_Buttons_Button13", "tbToolbar_Buttons_Button14", "tbToolbar_Buttons_Button15", "tbToolbar", "imlToolbarIcons"}
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTipMain As System.Windows.Forms.ToolTip
	Public WithEvents mnuFileNew As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFileSave As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFileRemove As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFileBar1 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuFileProperties As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFileBar2 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuFileConvert As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFileExport As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFileBar3 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuFileOptions As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFileBar4 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuPlayPlay As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuPlayStop As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuPlay As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents txtDestination As System.Windows.Forms.TextBox
	Public WithEvents fraSE As System.Windows.Forms.GroupBox
	Public WithEvents txtSource As System.Windows.Forms.TextBox
	Public WithEvents cboRingtones As System.Windows.Forms.ComboBox
	Public WithEvents fraRTTL As System.Windows.Forms.GroupBox
	Public WithEvents sbStatus_Panels_Panel1 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents sbStatus As System.Windows.Forms.StatusStrip
	Public WithEvents tbToolbar_Buttons_Button1 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbToolbar_Buttons_Button2 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbToolbar_Buttons_Button3 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbToolbar_Buttons_Button4 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents tbToolbar_Buttons_Button5 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbToolbar_Buttons_Button6 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents tbToolbar_Buttons_Button7 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbToolbar_Buttons_Button8 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbToolbar_Buttons_Button9 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents tbToolbar_Buttons_Button10 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbToolbar_Buttons_Button11 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents tbToolbar_Buttons_Button12 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbToolbar_Buttons_Button13 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbToolbar_Buttons_Button14 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents tbToolbar_Buttons_Button15 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbToolbar As System.Windows.Forms.ToolStrip
	Public WithEvents imlToolbarIcons As System.Windows.Forms.ImageList
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	 Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolTipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.cboRingtones = New System.Windows.Forms.ComboBox()
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileBar1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileBar2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileConvert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileBar3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileBar4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlay = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlayPlay = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlayStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.fraSE = New System.Windows.Forms.GroupBox()
        Me.fraRTTL = New System.Windows.Forms.GroupBox()
        Me.sbStatus = New System.Windows.Forms.StatusStrip()
        Me.sbStatus_Panels_Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbToolbar = New System.Windows.Forms.ToolStrip()
        Me.imlToolbarIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.tbToolbar_Buttons_Button1 = New System.Windows.Forms.ToolStripButton()
        Me.tbToolbar_Buttons_Button2 = New System.Windows.Forms.ToolStripButton()
        Me.tbToolbar_Buttons_Button3 = New System.Windows.Forms.ToolStripButton()
        Me.tbToolbar_Buttons_Button4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbToolbar_Buttons_Button5 = New System.Windows.Forms.ToolStripButton()
        Me.tbToolbar_Buttons_Button6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbToolbar_Buttons_Button7 = New System.Windows.Forms.ToolStripButton()
        Me.tbToolbar_Buttons_Button8 = New System.Windows.Forms.ToolStripButton()
        Me.tbToolbar_Buttons_Button9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbToolbar_Buttons_Button10 = New System.Windows.Forms.ToolStripButton()
        Me.tbToolbar_Buttons_Button11 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbToolbar_Buttons_Button12 = New System.Windows.Forms.ToolStripButton()
        Me.tbToolbar_Buttons_Button13 = New System.Windows.Forms.ToolStripButton()
        Me.tbToolbar_Buttons_Button14 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbToolbar_Buttons_Button15 = New System.Windows.Forms.ToolStripButton()
        Me.MainMenu1.SuspendLayout()
        Me.fraSE.SuspendLayout()
        Me.fraRTTL.SuspendLayout()
        Me.sbStatus.SuspendLayout()
        Me.tbToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDestination
        '
        Me.txtDestination.AcceptsReturn = True
        Me.txtDestination.AllowDrop = True
        Me.txtDestination.BackColor = System.Drawing.SystemColors.Window
        Me.txtDestination.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDestination.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDestination.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDestination.Location = New System.Drawing.Point(8, 16)
        Me.txtDestination.MaxLength = 0
        Me.txtDestination.Multiline = True
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDestination.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDestination.Size = New System.Drawing.Size(481, 129)
        Me.txtDestination.TabIndex = 6
        Me.ToolTipMain.SetToolTip(Me.txtDestination, "Displays the ringtone in the output format after conversion.")
        '
        'txtSource
        '
        Me.txtSource.AcceptsReturn = True
        Me.txtSource.AllowDrop = True
        Me.txtSource.BackColor = System.Drawing.SystemColors.Window
        Me.txtSource.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSource.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSource.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSource.Location = New System.Drawing.Point(8, 40)
        Me.txtSource.MaxLength = 0
        Me.txtSource.Multiline = True
        Me.txtSource.Name = "txtSource"
        Me.txtSource.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSource.Size = New System.Drawing.Size(481, 105)
        Me.txtSource.TabIndex = 4
        Me.ToolTipMain.SetToolTip(Me.txtSource, "Displays the ringtone in RTTTL format.")
        '
        'cboRingtones
        '
        Me.cboRingtones.AllowDrop = True
        Me.cboRingtones.BackColor = System.Drawing.SystemColors.Window
        Me.cboRingtones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRingtones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboRingtones.Location = New System.Drawing.Point(8, 16)
        Me.cboRingtones.Name = "cboRingtones"
        Me.cboRingtones.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboRingtones.Size = New System.Drawing.Size(481, 21)
        Me.cboRingtones.Sorted = True
        Me.cboRingtones.TabIndex = 3
        Me.ToolTipMain.SetToolTip(Me.cboRingtones, "Select the ringtone you want.")
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuPlay, Me.mnuHelp})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(512, 24)
        Me.MainMenu1.TabIndex = 6
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileNew, Me.mnuFileSave, Me.mnuFileRemove, Me.mnuFileBar1, Me.mnuFileProperties, Me.mnuFileBar2, Me.mnuFileConvert, Me.mnuFileExport, Me.mnuFileBar3, Me.mnuFileOptions, Me.mnuFileBar4, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuFileNew
        '
        Me.mnuFileNew.Name = "mnuFileNew"
        Me.mnuFileNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mnuFileNew.Size = New System.Drawing.Size(141, 22)
        Me.mnuFileNew.Text = "&New"
        '
        'mnuFileSave
        '
        Me.mnuFileSave.Name = "mnuFileSave"
        Me.mnuFileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuFileSave.Size = New System.Drawing.Size(141, 22)
        Me.mnuFileSave.Text = "&Save"
        '
        'mnuFileRemove
        '
        Me.mnuFileRemove.Name = "mnuFileRemove"
        Me.mnuFileRemove.Size = New System.Drawing.Size(141, 22)
        Me.mnuFileRemove.Text = "&Remove..."
        '
        'mnuFileBar1
        '
        Me.mnuFileBar1.AllowDrop = True
        Me.mnuFileBar1.Name = "mnuFileBar1"
        Me.mnuFileBar1.Size = New System.Drawing.Size(138, 6)
        '
        'mnuFileProperties
        '
        Me.mnuFileProperties.Name = "mnuFileProperties"
        Me.mnuFileProperties.Size = New System.Drawing.Size(141, 22)
        Me.mnuFileProperties.Text = "Propert&ies..."
        '
        'mnuFileBar2
        '
        Me.mnuFileBar2.AllowDrop = True
        Me.mnuFileBar2.Name = "mnuFileBar2"
        Me.mnuFileBar2.Size = New System.Drawing.Size(138, 6)
        '
        'mnuFileConvert
        '
        Me.mnuFileConvert.Name = "mnuFileConvert"
        Me.mnuFileConvert.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.mnuFileConvert.Size = New System.Drawing.Size(141, 22)
        Me.mnuFileConvert.Text = "&Convert"
        '
        'mnuFileExport
        '
        Me.mnuFileExport.Name = "mnuFileExport"
        Me.mnuFileExport.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.mnuFileExport.Size = New System.Drawing.Size(141, 22)
        Me.mnuFileExport.Text = "&Export..."
        '
        'mnuFileBar3
        '
        Me.mnuFileBar3.AllowDrop = True
        Me.mnuFileBar3.Name = "mnuFileBar3"
        Me.mnuFileBar3.Size = New System.Drawing.Size(138, 6)
        '
        'mnuFileOptions
        '
        Me.mnuFileOptions.Name = "mnuFileOptions"
        Me.mnuFileOptions.Size = New System.Drawing.Size(141, 22)
        Me.mnuFileOptions.Text = "&Options..."
        '
        'mnuFileBar4
        '
        Me.mnuFileBar4.AllowDrop = True
        Me.mnuFileBar4.Name = "mnuFileBar4"
        Me.mnuFileBar4.Size = New System.Drawing.Size(138, 6)
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(141, 22)
        Me.mnuFileExit.Text = "E&xit"
        '
        'mnuPlay
        '
        Me.mnuPlay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPlayPlay, Me.mnuPlayStop})
        Me.mnuPlay.Name = "mnuPlay"
        Me.mnuPlay.Size = New System.Drawing.Size(41, 20)
        Me.mnuPlay.Text = "&Play"
        '
        'mnuPlayPlay
        '
        Me.mnuPlayPlay.Name = "mnuPlayPlay"
        Me.mnuPlayPlay.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuPlayPlay.Size = New System.Drawing.Size(115, 22)
        Me.mnuPlayPlay.Text = "&Play"
        '
        'mnuPlayStop
        '
        Me.mnuPlayStop.Name = "mnuPlayStop"
        Me.mnuPlayStop.Size = New System.Drawing.Size(115, 22)
        Me.mnuPlayStop.Text = "&Stop"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnuHelp.Text = "&Help"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mnuHelpAbout.Size = New System.Drawing.Size(241, 22)
        Me.mnuHelpAbout.Text = "&About Ringtone Converter..."
        '
        'fraSE
        '
        Me.fraSE.AllowDrop = True
        Me.fraSE.BackColor = System.Drawing.SystemColors.Control
        Me.fraSE.Controls.Add(Me.txtDestination)
        Me.fraSE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraSE.Location = New System.Drawing.Point(8, 224)
        Me.fraSE.Name = "fraSE"
        Me.fraSE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraSE.Size = New System.Drawing.Size(497, 153)
        Me.fraSE.TabIndex = 5
        Me.fraSE.TabStop = False
        Me.fraSE.Text = "&Sony Ericsson Format:"
        '
        'fraRTTL
        '
        Me.fraRTTL.AllowDrop = True
        Me.fraRTTL.BackColor = System.Drawing.SystemColors.Control
        Me.fraRTTL.Controls.Add(Me.txtSource)
        Me.fraRTTL.Controls.Add(Me.cboRingtones)
        Me.fraRTTL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraRTTL.Location = New System.Drawing.Point(8, 56)
        Me.fraRTTL.Name = "fraRTTL"
        Me.fraRTTL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraRTTL.Size = New System.Drawing.Size(497, 153)
        Me.fraRTTL.TabIndex = 2
        Me.fraRTTL.TabStop = False
        Me.fraRTTL.Text = "&RTTTL Format:"
        '
        'sbStatus
        '
        Me.sbStatus.AllowDrop = True
        Me.sbStatus.BackColor = System.Drawing.SystemColors.Control
        Me.sbStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbStatus_Panels_Panel1})
        Me.sbStatus.Location = New System.Drawing.Point(0, 383)
        Me.sbStatus.Name = "sbStatus"
        Me.sbStatus.ShowItemToolTips = True
        Me.sbStatus.Size = New System.Drawing.Size(512, 25)
        Me.sbStatus.TabIndex = 1
        Me.sbStatus.Text = "Ready!"
        '
        'sbStatus_Panels_Panel1
        '
        Me.sbStatus_Panels_Panel1.AutoSize = False
        Me.sbStatus_Panels_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.sbStatus_Panels_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.sbStatus_Panels_Panel1.DoubleClickEnabled = True
        Me.sbStatus_Panels_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.sbStatus_Panels_Panel1.Name = "sbStatus_Panels_Panel1"
        Me.sbStatus_Panels_Panel1.Size = New System.Drawing.Size(96, 25)
        Me.sbStatus_Panels_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbToolbar
        '
        Me.tbToolbar.AllowDrop = True
        Me.tbToolbar.ImageList = Me.imlToolbarIcons
        Me.tbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbToolbar_Buttons_Button1, Me.tbToolbar_Buttons_Button2, Me.tbToolbar_Buttons_Button3, Me.tbToolbar_Buttons_Button4, Me.tbToolbar_Buttons_Button5, Me.tbToolbar_Buttons_Button6, Me.tbToolbar_Buttons_Button7, Me.tbToolbar_Buttons_Button8, Me.tbToolbar_Buttons_Button9, Me.tbToolbar_Buttons_Button10, Me.tbToolbar_Buttons_Button11, Me.tbToolbar_Buttons_Button12, Me.tbToolbar_Buttons_Button13, Me.tbToolbar_Buttons_Button14, Me.tbToolbar_Buttons_Button15})
        Me.tbToolbar.Location = New System.Drawing.Point(0, 24)
        Me.tbToolbar.Name = "tbToolbar"
        Me.tbToolbar.Size = New System.Drawing.Size(512, 25)
        Me.tbToolbar.TabIndex = 0
        '
        'imlToolbarIcons
        '
        Me.imlToolbarIcons.ImageStream = CType(resources.GetObject("imlToolbarIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlToolbarIcons.TransparentColor = System.Drawing.Color.Silver
        Me.imlToolbarIcons.Images.SetKeyName(0, "New")
        Me.imlToolbarIcons.Images.SetKeyName(1, "Options")
        Me.imlToolbarIcons.Images.SetKeyName(2, "Export")
        Me.imlToolbarIcons.Images.SetKeyName(3, "Save")
        Me.imlToolbarIcons.Images.SetKeyName(4, "Delete")
        Me.imlToolbarIcons.Images.SetKeyName(5, "Play")
        Me.imlToolbarIcons.Images.SetKeyName(6, "Stop")
        Me.imlToolbarIcons.Images.SetKeyName(7, "Properties")
        Me.imlToolbarIcons.Images.SetKeyName(8, "Help")
        Me.imlToolbarIcons.Images.SetKeyName(9, "Convert")
        '
        'tbToolbar_Buttons_Button1
        '
        Me.tbToolbar_Buttons_Button1.ImageIndex = 0
        Me.tbToolbar_Buttons_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbToolbar_Buttons_Button1.Name = "tbToolbar_Buttons_Button1"
        Me.tbToolbar_Buttons_Button1.Size = New System.Drawing.Size(23, 22)
        Me.tbToolbar_Buttons_Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbToolbar_Buttons_Button1.ToolTipText = "Creates a new RTTL."
        '
        'tbToolbar_Buttons_Button2
        '
        Me.tbToolbar_Buttons_Button2.ImageIndex = 3
        Me.tbToolbar_Buttons_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbToolbar_Buttons_Button2.Name = "tbToolbar_Buttons_Button2"
        Me.tbToolbar_Buttons_Button2.Size = New System.Drawing.Size(23, 22)
        Me.tbToolbar_Buttons_Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbToolbar_Buttons_Button2.ToolTipText = "Saves the entire RTTL collection."
        '
        'tbToolbar_Buttons_Button3
        '
        Me.tbToolbar_Buttons_Button3.ImageIndex = 4
        Me.tbToolbar_Buttons_Button3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbToolbar_Buttons_Button3.Name = "tbToolbar_Buttons_Button3"
        Me.tbToolbar_Buttons_Button3.Size = New System.Drawing.Size(23, 22)
        Me.tbToolbar_Buttons_Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbToolbar_Buttons_Button3.ToolTipText = "Removes ringtone from the RTTL collection."
        '
        'tbToolbar_Buttons_Button4
        '
        Me.tbToolbar_Buttons_Button4.Name = "tbToolbar_Buttons_Button4"
        Me.tbToolbar_Buttons_Button4.Size = New System.Drawing.Size(6, 25)
        '
        'tbToolbar_Buttons_Button5
        '
        Me.tbToolbar_Buttons_Button5.ImageIndex = 7
        Me.tbToolbar_Buttons_Button5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbToolbar_Buttons_Button5.Name = "tbToolbar_Buttons_Button5"
        Me.tbToolbar_Buttons_Button5.Size = New System.Drawing.Size(23, 22)
        Me.tbToolbar_Buttons_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbToolbar_Buttons_Button5.ToolTipText = "Shows RTTL properties."
        '
        'tbToolbar_Buttons_Button6
        '
        Me.tbToolbar_Buttons_Button6.Name = "tbToolbar_Buttons_Button6"
        Me.tbToolbar_Buttons_Button6.Size = New System.Drawing.Size(6, 25)
        '
        'tbToolbar_Buttons_Button7
        '
        Me.tbToolbar_Buttons_Button7.ImageIndex = 9
        Me.tbToolbar_Buttons_Button7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbToolbar_Buttons_Button7.Name = "tbToolbar_Buttons_Button7"
        Me.tbToolbar_Buttons_Button7.Size = New System.Drawing.Size(23, 22)
        Me.tbToolbar_Buttons_Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbToolbar_Buttons_Button7.ToolTipText = "Converts ringtone to the IMelody (IMY) format."
        '
        'tbToolbar_Buttons_Button8
        '
        Me.tbToolbar_Buttons_Button8.ImageIndex = 2
        Me.tbToolbar_Buttons_Button8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbToolbar_Buttons_Button8.Name = "tbToolbar_Buttons_Button8"
        Me.tbToolbar_Buttons_Button8.Size = New System.Drawing.Size(23, 22)
        Me.tbToolbar_Buttons_Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbToolbar_Buttons_Button8.ToolTipText = "Exports ringtone to an IMelody (IMY) file."
        '
        'tbToolbar_Buttons_Button9
        '
        Me.tbToolbar_Buttons_Button9.Name = "tbToolbar_Buttons_Button9"
        Me.tbToolbar_Buttons_Button9.Size = New System.Drawing.Size(6, 25)
        '
        'tbToolbar_Buttons_Button10
        '
        Me.tbToolbar_Buttons_Button10.ImageIndex = 1
        Me.tbToolbar_Buttons_Button10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbToolbar_Buttons_Button10.Name = "tbToolbar_Buttons_Button10"
        Me.tbToolbar_Buttons_Button10.Size = New System.Drawing.Size(23, 22)
        Me.tbToolbar_Buttons_Button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbToolbar_Buttons_Button10.ToolTipText = "Configures application options."
        '
        'tbToolbar_Buttons_Button11
        '
        Me.tbToolbar_Buttons_Button11.Name = "tbToolbar_Buttons_Button11"
        Me.tbToolbar_Buttons_Button11.Size = New System.Drawing.Size(6, 25)
        '
        'tbToolbar_Buttons_Button12
        '
        Me.tbToolbar_Buttons_Button12.ImageIndex = 5
        Me.tbToolbar_Buttons_Button12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbToolbar_Buttons_Button12.Name = "tbToolbar_Buttons_Button12"
        Me.tbToolbar_Buttons_Button12.Size = New System.Drawing.Size(23, 22)
        Me.tbToolbar_Buttons_Button12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbToolbar_Buttons_Button12.ToolTipText = "Plays the selected ringtone."
        '
        'tbToolbar_Buttons_Button13
        '
        Me.tbToolbar_Buttons_Button13.ImageIndex = 6
        Me.tbToolbar_Buttons_Button13.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbToolbar_Buttons_Button13.Name = "tbToolbar_Buttons_Button13"
        Me.tbToolbar_Buttons_Button13.Size = New System.Drawing.Size(23, 22)
        Me.tbToolbar_Buttons_Button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbToolbar_Buttons_Button13.ToolTipText = "Stops the current ringtone playback."
        '
        'tbToolbar_Buttons_Button14
        '
        Me.tbToolbar_Buttons_Button14.Name = "tbToolbar_Buttons_Button14"
        Me.tbToolbar_Buttons_Button14.Size = New System.Drawing.Size(6, 25)
        '
        'tbToolbar_Buttons_Button15
        '
        Me.tbToolbar_Buttons_Button15.ImageIndex = 8
        Me.tbToolbar_Buttons_Button15.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbToolbar_Buttons_Button15.Name = "tbToolbar_Buttons_Button15"
        Me.tbToolbar_Buttons_Button15.Size = New System.Drawing.Size(23, 22)
        Me.tbToolbar_Buttons_Button15.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tbToolbar_Buttons_Button15.ToolTipText = "Shows application help information."
        '
        'frmMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 408)
        Me.Controls.Add(Me.fraSE)
        Me.Controls.Add(Me.fraRTTL)
        Me.Controls.Add(Me.sbStatus)
        Me.Controls.Add(Me.tbToolbar)
        Me.Controls.Add(Me.MainMenu1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 49)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ringtone Converter"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.fraSE.ResumeLayout(False)
        Me.fraSE.PerformLayout()
        Me.fraRTTL.ResumeLayout(False)
        Me.fraRTTL.PerformLayout()
        Me.sbStatus.ResumeLayout(False)
        Me.sbStatus.PerformLayout()
        Me.tbToolbar.ResumeLayout(False)
        Me.tbToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Sub ReLoadForm(ByVal addEvents As Boolean)
		Form_Load()
		If addEvents Then
			AddHandler MyBase.Closing, AddressOf Me.Form_Closed
			AddHandler Me.Activated, AddressOf Me.FrmMain_Activated
		End If
	End Sub
#End Region
End Class