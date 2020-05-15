<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmOptions
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmOptions
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = CreateInstance()
				m_InitializingDefInstance = False
			End If
			Return m_vb6FormDefInstance
		End Get
		Set(ByVal Value As frmOptions)
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region
#Region "Windows Form Designer generated code "

	Public Shared Function CreateInstance() As frmOptions
		Dim theInstance As New frmOptions()
		theInstance.Form_Load()
		Return theInstance
	End Function

	Private visualControls() As String = New String() {"components", "ToolTipMain", "txtVolume", "txtRepeat", "txtAutoLED", "txtAutoBacklight", "txtAutoVibration", "cboStyle", "chkOptimize", "cmdCancel", "cmdOK", "sldAutoLED", "sldAutoBacklight", "sldAutoVibration", "sldRepeat", "sldVolume", "Label6", "Label2", "Label1", "Label3", "Label4", "Label5"} ', "listBoxComboBoxHelper1"}

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTipMain As System.Windows.Forms.ToolTip
	Public WithEvents txtVolume As System.Windows.Forms.TextBox
	Public WithEvents txtRepeat As System.Windows.Forms.TextBox
	Public WithEvents txtAutoLED As System.Windows.Forms.TextBox
	Public WithEvents txtAutoBacklight As System.Windows.Forms.TextBox
	Public WithEvents txtAutoVibration As System.Windows.Forms.TextBox
	Public WithEvents cboStyle As System.Windows.Forms.ComboBox
	Public WithEvents chkOptimize As System.Windows.Forms.CheckBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents sldAutoLED As System.Windows.Forms.TrackBar
	Public WithEvents sldAutoBacklight As System.Windows.Forms.TrackBar
	Public WithEvents sldAutoVibration As System.Windows.Forms.TrackBar
	Public WithEvents sldRepeat As System.Windows.Forms.TrackBar
	Public WithEvents sldVolume As System.Windows.Forms.TrackBar
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	'Public listBoxComboBoxHelper1 As UpgradeHelpers.Gui.ListControlHelper

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	 Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
		Me.ToolTipMain = New System.Windows.Forms.ToolTip(Me.components)
		Me.txtVolume = New System.Windows.Forms.TextBox()
		Me.txtRepeat = New System.Windows.Forms.TextBox()
		Me.txtAutoLED = New System.Windows.Forms.TextBox()
		Me.txtAutoBacklight = New System.Windows.Forms.TextBox()
		Me.txtAutoVibration = New System.Windows.Forms.TextBox()
		Me.cboStyle = New System.Windows.Forms.ComboBox()
		Me.chkOptimize = New System.Windows.Forms.CheckBox()
		Me.cmdCancel = New System.Windows.Forms.Button()
		Me.cmdOK = New System.Windows.Forms.Button()
		Me.sldAutoLED = New System.Windows.Forms.TrackBar()
		Me.sldAutoBacklight = New System.Windows.Forms.TrackBar()
		Me.sldAutoVibration = New System.Windows.Forms.TrackBar()
		Me.sldRepeat = New System.Windows.Forms.TrackBar()
		Me.sldVolume = New System.Windows.Forms.TrackBar()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'Me.listBoxComboBoxHelper1 = New UpgradeHelpers.Gui.ListControlHelper(Me.components)
		'Me.listBoxComboBoxHelper1.BeginInit()
		' 
		'txtVolume
		' 
		Me.txtVolume.AcceptsReturn = True
		Me.txtVolume.AllowDrop = True
		Me.txtVolume.BackColor = System.Drawing.SystemColors.Window
		Me.txtVolume.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtVolume.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtVolume.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
		Me.txtVolume.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtVolume.Location = New System.Drawing.Point(215, 188)
		Me.txtVolume.MaxLength = 0
		Me.txtVolume.Name = "txtVolume"
		Me.txtVolume.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtVolume.Size = New System.Drawing.Size(25, 22)
		Me.txtVolume.TabIndex = 17
		Me.txtVolume.Text = "15"
		' 
		'txtRepeat
		' 
		Me.txtRepeat.AcceptsReturn = True
		Me.txtRepeat.AllowDrop = True
		Me.txtRepeat.BackColor = System.Drawing.SystemColors.Window
		Me.txtRepeat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtRepeat.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRepeat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
		Me.txtRepeat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRepeat.Location = New System.Drawing.Point(215, 71)
		Me.txtRepeat.MaxLength = 0
		Me.txtRepeat.Name = "txtRepeat"
		Me.txtRepeat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRepeat.Size = New System.Drawing.Size(33, 22)
		Me.txtRepeat.TabIndex = 5
		Me.txtRepeat.Text = "4"
		' 
		'txtAutoLED
		' 
		Me.txtAutoLED.AcceptsReturn = True
		Me.txtAutoLED.AllowDrop = True
		Me.txtAutoLED.BackColor = System.Drawing.SystemColors.Window
		Me.txtAutoLED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAutoLED.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAutoLED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
		Me.txtAutoLED.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAutoLED.Location = New System.Drawing.Point(215, 159)
		Me.txtAutoLED.MaxLength = 0
		Me.txtAutoLED.Name = "txtAutoLED"
		Me.txtAutoLED.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAutoLED.Size = New System.Drawing.Size(33, 22)
		Me.txtAutoLED.TabIndex = 14
		Me.txtAutoLED.Text = "2"
		' 
		'txtAutoBacklight
		' 
		Me.txtAutoBacklight.AcceptsReturn = True
		Me.txtAutoBacklight.AllowDrop = True
		Me.txtAutoBacklight.BackColor = System.Drawing.SystemColors.Window
		Me.txtAutoBacklight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAutoBacklight.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAutoBacklight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
		Me.txtAutoBacklight.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAutoBacklight.Location = New System.Drawing.Point(215, 129)
		Me.txtAutoBacklight.MaxLength = 0
		Me.txtAutoBacklight.Name = "txtAutoBacklight"
		Me.txtAutoBacklight.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAutoBacklight.Size = New System.Drawing.Size(33, 22)
		Me.txtAutoBacklight.TabIndex = 11
		Me.txtAutoBacklight.Text = "1"
		' 
		'txtAutoVibration
		' 
		Me.txtAutoVibration.AcceptsReturn = True
		Me.txtAutoVibration.AllowDrop = True
		Me.txtAutoVibration.BackColor = System.Drawing.SystemColors.Window
		Me.txtAutoVibration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAutoVibration.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAutoVibration.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
		Me.txtAutoVibration.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAutoVibration.Location = New System.Drawing.Point(215, 100)
		Me.txtAutoVibration.MaxLength = 0
		Me.txtAutoVibration.Name = "txtAutoVibration"
		Me.txtAutoVibration.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAutoVibration.Size = New System.Drawing.Size(33, 22)
		Me.txtAutoVibration.TabIndex = 8
		Me.txtAutoVibration.Text = "4"
		' 
		'cboStyle
		' 
		Me.cboStyle.AllowDrop = True
		Me.cboStyle.BackColor = System.Drawing.SystemColors.Window
		Me.cboStyle.CausesValidation = True
		Me.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboStyle.Enabled = True
		Me.cboStyle.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboStyle.IntegralHeight = True
		Me.cboStyle.Location = New System.Drawing.Point(104, 42)
		Me.cboStyle.Name = "cboStyle"
		Me.cboStyle.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboStyle.Size = New System.Drawing.Size(77, 21)
		Me.cboStyle.Sorted = False
		Me.cboStyle.TabIndex = 2
		Me.cboStyle.TabStop = True
		Me.cboStyle.Visible = True
		Me.cboStyle.Items.AddRange(New Object() {"Natural", "Continious", "Staccato"})
		' 
		'chkOptimize
		' 
		Me.chkOptimize.AllowDrop = True
		Me.chkOptimize.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkOptimize.BackColor = System.Drawing.SystemColors.Control
		Me.chkOptimize.CausesValidation = True
		Me.chkOptimize.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkOptimize.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkOptimize.Enabled = True
		Me.chkOptimize.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkOptimize.Location = New System.Drawing.Point(12, 12)
		Me.chkOptimize.Name = "chkOptimize"
		Me.chkOptimize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkOptimize.Size = New System.Drawing.Size(109, 17)
		Me.chkOptimize.TabIndex = 0
		Me.chkOptimize.TabStop = True
		Me.chkOptimize.Text = "Optimi&ze Ringtone:"
		Me.chkOptimize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkOptimize.Visible = True
		' 
		'cmdCancel
		' 
		Me.cmdCancel.AllowDrop = True
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Location = New System.Drawing.Point(264, 48)
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.Size = New System.Drawing.Size(81, 33)
		Me.cmdCancel.TabIndex = 19
		Me.cmdCancel.Text = "&Cancel"
		Me.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.cmdCancel.UseVisualStyleBackColor = False
		' 
		'cmdOK
		' 
		Me.cmdOK.AllowDrop = True
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Location = New System.Drawing.Point(264, 8)
		Me.cmdOK.Name = "cmdOK"
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.Size = New System.Drawing.Size(81, 33)
		Me.cmdOK.TabIndex = 18
		Me.cmdOK.Text = "&OK"
		Me.cmdOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.cmdOK.UseVisualStyleBackColor = False
		' 
		'sldAutoLED
		' 
		Me.sldAutoLED.AllowDrop = True
		Me.sldAutoLED.Location = New System.Drawing.Point(104, 159)
		Me.sldAutoLED.Maximum = 255
		Me.sldAutoLED.Name = "sldAutoLED"
		Me.sldAutoLED.Size = New System.Drawing.Size(105, 21)
		Me.sldAutoLED.TabIndex = 13
		Me.sldAutoLED.TickStyle = System.Windows.Forms.TickStyle.None
		' 
		'sldAutoBacklight
		' 
		Me.sldAutoBacklight.AllowDrop = True
		Me.sldAutoBacklight.Location = New System.Drawing.Point(104, 130)
		Me.sldAutoBacklight.Maximum = 255
		Me.sldAutoBacklight.Name = "sldAutoBacklight"
		Me.sldAutoBacklight.Size = New System.Drawing.Size(105, 21)
		Me.sldAutoBacklight.TabIndex = 10
		Me.sldAutoBacklight.TickStyle = System.Windows.Forms.TickStyle.None
		' 
		'sldAutoVibration
		' 
		Me.sldAutoVibration.AllowDrop = True
		Me.sldAutoVibration.Location = New System.Drawing.Point(104, 100)
		Me.sldAutoVibration.Maximum = 255
		Me.sldAutoVibration.Name = "sldAutoVibration"
		Me.sldAutoVibration.Size = New System.Drawing.Size(105, 21)
		Me.sldAutoVibration.TabIndex = 7
		Me.sldAutoVibration.TickStyle = System.Windows.Forms.TickStyle.None
		' 
		'sldRepeat
		' 
		Me.sldRepeat.AllowDrop = True
		Me.sldRepeat.Location = New System.Drawing.Point(104, 71)
		Me.sldRepeat.Maximum = 255
		Me.sldRepeat.Name = "sldRepeat"
		Me.sldRepeat.Size = New System.Drawing.Size(105, 21)
		Me.sldRepeat.TabIndex = 4
		Me.sldRepeat.TickStyle = System.Windows.Forms.TickStyle.None
		' 
		'sldVolume
		' 
		Me.sldVolume.AllowDrop = True
		Me.sldVolume.Location = New System.Drawing.Point(104, 188)
		Me.sldVolume.Maximum = 15
		Me.sldVolume.Minimum = 1
		Me.sldVolume.Name = "sldVolume"
		Me.sldVolume.Size = New System.Drawing.Size(105, 21)
		Me.sldVolume.TabIndex = 16
		Me.sldVolume.TickStyle = System.Windows.Forms.TickStyle.None
		Me.sldVolume.Value = 1
		' 
		'Label6
		' 
		Me.Label6.AllowDrop = True
		Me.Label6.AutoSize = True
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Location = New System.Drawing.Point(64, 192)
		Me.Label6.Name = "Label6"
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.Size = New System.Drawing.Size(38, 13)
		Me.Label6.TabIndex = 15
		Me.Label6.Text = "Volu&me:"
		' 
		'Label2
		' 
		Me.Label2.AllowDrop = True
		Me.Label2.AutoSize = True
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Location = New System.Drawing.Point(64, 75)
		Me.Label2.Name = "Label2"
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.Size = New System.Drawing.Size(38, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "&Repeat:"
		' 
		'Label1
		' 
		Me.Label1.AllowDrop = True
		Me.Label1.AutoSize = True
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Location = New System.Drawing.Point(30, 46)
		Me.Label1.Name = "Label1"
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.Size = New System.Drawing.Size(72, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Ringtone &Style:"
		' 
		'Label3
		' 
		Me.Label3.AllowDrop = True
		Me.Label3.AutoSize = True
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Location = New System.Drawing.Point(33, 104)
		Me.Label3.Name = "Label3"
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.Size = New System.Drawing.Size(69, 13)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "Auto &Vibration:"
		' 
		'Label4
		' 
		Me.Label4.AllowDrop = True
		Me.Label4.AutoSize = True
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Location = New System.Drawing.Point(30, 134)
		Me.Label4.Name = "Label4"
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.Size = New System.Drawing.Size(72, 13)
		Me.Label4.TabIndex = 9
		Me.Label4.Text = "Auto &Backlight:"
		' 
		'Label5
		' 
		Me.Label5.AllowDrop = True
		Me.Label5.AutoSize = True
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Location = New System.Drawing.Point(53, 163)
		Me.Label5.Name = "Label5"
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.Size = New System.Drawing.Size(49, 13)
		Me.Label5.TabIndex = 12
		Me.Label5.Text = "Auto &LED:"
		' 
		'frmOptions
		' 
		Me.AcceptButton = Me.cmdOK
		Me.AllowDrop = True
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6, 13)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton = Me.cmdCancel
		Me.ClientSize = New System.Drawing.Size(357, 222)
		Me.ControlBox = False
		Me.Controls.Add(Me.txtVolume)
		Me.Controls.Add(Me.txtRepeat)
		Me.Controls.Add(Me.txtAutoLED)
		Me.Controls.Add(Me.txtAutoBacklight)
		Me.Controls.Add(Me.txtAutoVibration)
		Me.Controls.Add(Me.cboStyle)
		Me.Controls.Add(Me.chkOptimize)
		Me.Controls.Add(Me.cmdCancel)
		Me.Controls.Add(Me.cmdOK)
		Me.Controls.Add(Me.sldAutoLED)
		Me.Controls.Add(Me.sldAutoBacklight)
		Me.Controls.Add(Me.sldAutoVibration)
		Me.Controls.Add(Me.sldRepeat)
		Me.Controls.Add(Me.sldVolume)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label5)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Location = New System.Drawing.Point(3, 29)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmOptions"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Options"
		'Me.listBoxComboBoxHelper1.SetItemData(Me.cboStyle, New Integer() {0, 0, 0})
		'Me.listBoxComboBoxHelper1.EndInit()
		Me.ResumeLayout(False)
	End Sub
	Sub ReLoadForm(ByVal addEvents As Boolean)
		Form_Load()
		If addEvents Then
			AddHandler MyBase.Closed, AddressOf Me.Form_Closed
			AddHandler Me.Activated, AddressOf Me.FrmOptions_Activated
		End If
	End Sub
#End Region
End Class