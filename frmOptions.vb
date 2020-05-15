Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Partial Friend Class frmOptions
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


	Private Sub FrmOptions_Activated(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Activated
		' What does this do?
		'If Not UpgradeHelpers.Gui.ActivateHelper.myActiveForm Is eventSender Then
		'UpgradeHelpers.Gui.ActivateHelper.myActiveForm = eventSender
		'End If
	End Sub

	' Options window implementation

	Private Sub cmdCancel_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdCancel.Click
		Hide()
	End Sub

	Private Sub cmdOK_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdOK.Click
		ApplyOptions()
		Hide()
	End Sub

	'UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://www.mobilize.net/vbtonet/ewis/ewi2080
	Private Sub Form_Load()
		cboStyle.SelectedIndex = 1
		txtAutoBacklight_TextChanged(txtAutoBacklight, New EventArgs())
		txtAutoLED_TextChanged(txtAutoLED, New EventArgs())
		txtAutoVibration_TextChanged(txtAutoVibration, New EventArgs())
		txtRepeat_TextChanged(txtRepeat, New EventArgs())
		txtVolume_TextChanged(txtVolume, New EventArgs())
	End Sub

	Private Sub sldAutoBacklight_Scroll(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles sldAutoBacklight.Scroll
		txtAutoBacklight.Text = CStr(sldAutoBacklight.Value)
	End Sub

	Private Sub sldAutoLED_Scroll(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles sldAutoLED.Scroll
		txtAutoLED.Text = CStr(sldAutoLED.Value)
	End Sub

	Private Sub sldAutoVibration_Scroll(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles sldAutoVibration.Scroll
		txtAutoVibration.Text = CStr(sldAutoVibration.Value)
	End Sub

	Private Sub sldRepeat_Scroll(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles sldRepeat.Scroll
		txtRepeat.Text = CStr(sldRepeat.Value)
	End Sub

	Private Sub sldVolume_Scroll(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles sldVolume.Scroll
		txtVolume.Text = CStr(sldVolume.Value)
	End Sub

	Private ReadOnly isInitializingComponent As Boolean
	Private Sub txtAutoBacklight_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAutoBacklight.TextChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		txtAutoBacklight.Text = CStr(Conversion.Val(txtAutoBacklight.Text))
		sldAutoBacklight.Value = CInt(txtAutoBacklight.Text)
	End Sub

	Private Sub txtAutoLED_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAutoLED.TextChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		txtAutoLED.Text = CStr(Conversion.Val(txtAutoLED.Text))
		sldAutoLED.Value = CInt(txtAutoLED.Text)
	End Sub

	Private Sub txtAutoVibration_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAutoVibration.TextChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		txtAutoVibration.Text = CStr(Conversion.Val(txtAutoVibration.Text))
		sldAutoVibration.Value = CInt(txtAutoVibration.Text)
	End Sub

	Private Sub txtRepeat_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRepeat.TextChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		txtRepeat.Text = CStr(Conversion.Val(txtRepeat.Text))
		sldRepeat.Value = CInt(txtRepeat.Text)
	End Sub

	Public Sub ApplyOptions()
		frmMain.rtPlayer.Optimize = True
		frmMain.rtSE.SetOptions(cboStyle.SelectedIndex, sldRepeat.Value, sldAutoVibration.Value, sldAutoBacklight.Value, sldAutoLED.Value, sldVolume.Value)
	End Sub

	Private Sub txtVolume_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtVolume.TextChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		txtVolume.Text = CStr(Conversion.Val(txtVolume.Text))
		sldVolume.Value = CInt(txtVolume.Text)
	End Sub
	Private Sub Form_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
	End Sub
End Class