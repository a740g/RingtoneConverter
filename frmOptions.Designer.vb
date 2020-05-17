<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOptions

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
        Return theInstance
    End Function

    Private visualControls() As String = New String() {"components", "ToolTipMain", "txtVolume", "txtRepeat", "txtAutoLED", "txtAutoBacklight", "txtAutoVibration", "cboStyle", "chkOptimize", "cmdCancel", "cmdOK", "sldAutoLED", "sldAutoBacklight", "sldAutoVibration", "sldRepeat", "sldVolume", "Label6", "Label2", "Label1", "Label3", "Label4", "Label5"}

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
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
        CType(Me.sldAutoLED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldAutoBacklight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldAutoVibration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtVolume
        '
        Me.txtVolume.AcceptsReturn = True
        Me.txtVolume.AllowDrop = True
        Me.txtVolume.BackColor = System.Drawing.SystemColors.Window
        Me.txtVolume.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVolume.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVolume.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVolume.Location = New System.Drawing.Point(215, 188)
        Me.txtVolume.MaxLength = 0
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVolume.Size = New System.Drawing.Size(33, 21)
        Me.txtVolume.TabIndex = 17
        Me.txtVolume.Text = "15"
        '
        'txtRepeat
        '
        Me.txtRepeat.AcceptsReturn = True
        Me.txtRepeat.AllowDrop = True
        Me.txtRepeat.BackColor = System.Drawing.SystemColors.Window
        Me.txtRepeat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRepeat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepeat.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRepeat.Location = New System.Drawing.Point(215, 71)
        Me.txtRepeat.MaxLength = 0
        Me.txtRepeat.Name = "txtRepeat"
        Me.txtRepeat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRepeat.Size = New System.Drawing.Size(33, 21)
        Me.txtRepeat.TabIndex = 5
        Me.txtRepeat.Text = "4"
        '
        'txtAutoLED
        '
        Me.txtAutoLED.AcceptsReturn = True
        Me.txtAutoLED.AllowDrop = True
        Me.txtAutoLED.BackColor = System.Drawing.SystemColors.Window
        Me.txtAutoLED.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAutoLED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutoLED.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAutoLED.Location = New System.Drawing.Point(215, 159)
        Me.txtAutoLED.MaxLength = 0
        Me.txtAutoLED.Name = "txtAutoLED"
        Me.txtAutoLED.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAutoLED.Size = New System.Drawing.Size(33, 21)
        Me.txtAutoLED.TabIndex = 14
        Me.txtAutoLED.Text = "2"
        '
        'txtAutoBacklight
        '
        Me.txtAutoBacklight.AcceptsReturn = True
        Me.txtAutoBacklight.AllowDrop = True
        Me.txtAutoBacklight.BackColor = System.Drawing.SystemColors.Window
        Me.txtAutoBacklight.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAutoBacklight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutoBacklight.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAutoBacklight.Location = New System.Drawing.Point(215, 129)
        Me.txtAutoBacklight.MaxLength = 0
        Me.txtAutoBacklight.Name = "txtAutoBacklight"
        Me.txtAutoBacklight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAutoBacklight.Size = New System.Drawing.Size(33, 21)
        Me.txtAutoBacklight.TabIndex = 11
        Me.txtAutoBacklight.Text = "1"
        '
        'txtAutoVibration
        '
        Me.txtAutoVibration.AcceptsReturn = True
        Me.txtAutoVibration.AllowDrop = True
        Me.txtAutoVibration.BackColor = System.Drawing.SystemColors.Window
        Me.txtAutoVibration.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAutoVibration.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutoVibration.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAutoVibration.Location = New System.Drawing.Point(215, 100)
        Me.txtAutoVibration.MaxLength = 0
        Me.txtAutoVibration.Name = "txtAutoVibration"
        Me.txtAutoVibration.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAutoVibration.Size = New System.Drawing.Size(33, 21)
        Me.txtAutoVibration.TabIndex = 8
        Me.txtAutoVibration.Text = "4"
        '
        'cboStyle
        '
        Me.cboStyle.AllowDrop = True
        Me.cboStyle.BackColor = System.Drawing.SystemColors.Window
        Me.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStyle.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboStyle.Items.AddRange(New Object() {"Natural", "Continious", "Staccato"})
        Me.cboStyle.Location = New System.Drawing.Point(115, 43)
        Me.cboStyle.Name = "cboStyle"
        Me.cboStyle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboStyle.Size = New System.Drawing.Size(133, 21)
        Me.cboStyle.TabIndex = 2
        '
        'chkOptimize
        '
        Me.chkOptimize.AllowDrop = True
        Me.chkOptimize.BackColor = System.Drawing.SystemColors.Control
        Me.chkOptimize.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOptimize.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkOptimize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkOptimize.Location = New System.Drawing.Point(12, 12)
        Me.chkOptimize.Name = "chkOptimize"
        Me.chkOptimize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkOptimize.Size = New System.Drawing.Size(236, 25)
        Me.chkOptimize.TabIndex = 0
        Me.chkOptimize.Text = "Optimi&ze Ringtone:"
        Me.chkOptimize.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.AllowDrop = True
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(254, 51)
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
        Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(254, 12)
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
        Me.sldAutoLED.Location = New System.Drawing.Point(104, 159)
        Me.sldAutoLED.Maximum = 255
        Me.sldAutoLED.Name = "sldAutoLED"
        Me.sldAutoLED.Size = New System.Drawing.Size(105, 45)
        Me.sldAutoLED.TabIndex = 13
        Me.sldAutoLED.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'sldAutoBacklight
        '
        Me.sldAutoBacklight.Location = New System.Drawing.Point(104, 130)
        Me.sldAutoBacklight.Maximum = 255
        Me.sldAutoBacklight.Name = "sldAutoBacklight"
        Me.sldAutoBacklight.Size = New System.Drawing.Size(105, 45)
        Me.sldAutoBacklight.TabIndex = 10
        Me.sldAutoBacklight.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'sldAutoVibration
        '
        Me.sldAutoVibration.Location = New System.Drawing.Point(104, 100)
        Me.sldAutoVibration.Maximum = 255
        Me.sldAutoVibration.Name = "sldAutoVibration"
        Me.sldAutoVibration.Size = New System.Drawing.Size(105, 45)
        Me.sldAutoVibration.TabIndex = 7
        Me.sldAutoVibration.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'sldRepeat
        '
        Me.sldRepeat.Location = New System.Drawing.Point(104, 71)
        Me.sldRepeat.Maximum = 255
        Me.sldRepeat.Name = "sldRepeat"
        Me.sldRepeat.Size = New System.Drawing.Size(105, 45)
        Me.sldRepeat.TabIndex = 4
        Me.sldRepeat.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'sldVolume
        '
        Me.sldVolume.Location = New System.Drawing.Point(104, 188)
        Me.sldVolume.Maximum = 15
        Me.sldVolume.Minimum = 1
        Me.sldVolume.Name = "sldVolume"
        Me.sldVolume.Size = New System.Drawing.Size(105, 45)
        Me.sldVolume.TabIndex = 16
        Me.sldVolume.Value = 1
        '
        'Label6
        '
        Me.Label6.AllowDrop = True
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(64, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Volu&me:"
        '
        'Label2
        '
        Me.Label2.AllowDrop = True
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(64, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "&Repeat:"
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(30, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ringtone &Style:"
        '
        'Label3
        '
        Me.Label3.AllowDrop = True
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(33, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Auto &Vibration:"
        '
        'Label4
        '
        Me.Label4.AllowDrop = True
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(30, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Auto &Backlight:"
        '
        'Label5
        '
        Me.Label5.AllowDrop = True
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(53, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Auto &LED:"
        '
        'frmOptions
        '
        Me.AcceptButton = Me.cmdOK
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(349, 226)
        Me.ControlBox = False
        Me.Controls.Add(Me.sldVolume)
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
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        CType(Me.sldAutoLED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldAutoBacklight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldAutoVibration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

End Class