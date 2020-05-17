' Ringtone Converter (SE Edition)
' Copyright (c) Samuel Gomes, 2003-2020
' mailto: v_2samg@hotmail.com

Imports Microsoft.VisualBasic

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
	End Sub

	' Options window implementation
	Private Sub CmdCancel_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdCancel.Click
		Hide()
	End Sub

	Private Sub CmdOK_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles cmdOK.Click
		ApplyOptions()
		Hide()
	End Sub

	Private Sub SldAutoBacklight_Scroll(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles sldAutoBacklight.Scroll
		txtAutoBacklight.Text = CStr(sldAutoBacklight.Value)
	End Sub

	Private Sub SldAutoLED_Scroll(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles sldAutoLED.Scroll
		txtAutoLED.Text = CStr(sldAutoLED.Value)
	End Sub

	Private Sub SldAutoVibration_Scroll(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles sldAutoVibration.Scroll
		txtAutoVibration.Text = CStr(sldAutoVibration.Value)
	End Sub

	Private Sub SldRepeat_Scroll(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles sldRepeat.Scroll
		txtRepeat.Text = CStr(sldRepeat.Value)
	End Sub

	Private Sub SldVolume_Scroll(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles sldVolume.Scroll
		txtVolume.Text = CStr(sldVolume.Value)
	End Sub

	Private ReadOnly isInitializingComponent As Boolean
	Private Sub TxtAutoBacklight_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAutoBacklight.TextChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		txtAutoBacklight.Text = CStr(Conversion.Val(txtAutoBacklight.Text))
		sldAutoBacklight.Value = CInt(txtAutoBacklight.Text)
	End Sub

	Private Sub TxtAutoLED_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAutoLED.TextChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		txtAutoLED.Text = CStr(Conversion.Val(txtAutoLED.Text))
		sldAutoLED.Value = CInt(txtAutoLED.Text)
	End Sub

	Private Sub TxtAutoVibration_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtAutoVibration.TextChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		txtAutoVibration.Text = CStr(Conversion.Val(txtAutoVibration.Text))
		sldAutoVibration.Value = CInt(txtAutoVibration.Text)
	End Sub

	Private Sub TxtRepeat_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtRepeat.TextChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		txtRepeat.Text = CStr(Conversion.Val(txtRepeat.Text))
		sldRepeat.Value = CInt(txtRepeat.Text)
	End Sub

	Public Sub ApplyOptions()
		FrmMain.RtPlayer.Optimize = chkOptimize.Checked
		FrmMain.rtSE.SetOptions(cboStyle.SelectedIndex, sldRepeat.Value, sldAutoVibration.Value, sldAutoBacklight.Value, sldAutoLED.Value, sldVolume.Value)
	End Sub

	Private Sub TxtVolume_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles txtVolume.TextChanged
		If isInitializingComponent Then
			Exit Sub
		End If
		txtVolume.Text = CStr(Conversion.Val(txtVolume.Text))
		sldVolume.Value = CInt(txtVolume.Text)
	End Sub

	Private Sub FrmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		cboStyle.SelectedIndex = 1
		TxtAutoBacklight_TextChanged(txtAutoBacklight, New EventArgs())
		TxtAutoLED_TextChanged(txtAutoLED, New EventArgs())
		TxtAutoVibration_TextChanged(txtAutoVibration, New EventArgs())
		TxtRepeat_TextChanged(txtRepeat, New EventArgs())
		TxtVolume_TextChanged(txtVolume, New EventArgs())
	End Sub
End Class