' --------------------------------------------------------------------------------
' Code generated automatically by Code Architects' VB Migration Partner
' --------------------------------------------------------------------------------

Option Strict Off      ' Code migrated from VB6 has Option Strict disabled by default

Friend Class Form3

	'-----------------------------------------------------------------------------------------------------
	'All codes are copyright by Philip V. Naparan 2004
	'
	'Website: www.naparansoft.cjb.net,www.philipnaparan.cjb.net,www.philipnaparan.com(under construction)
	'E-mail Address: philipnaparan@yahoo.com
	'Contact #: 639186443161
	'----------------------------------------------------------------------------------------------------

	Public f_n As Integer
	
	Private s1 As Integer
	Private s2 As Integer
	
	Private Sub Combo1_Click() Handles Combo1.Click
		On Error Resume Next 
		Text1.SelFontSize = Combo1.Text
	End Sub

	Private Sub Form_Load() Handles MyBase.Load
		s1 = -1
		s2 = -1
		
		Text1.Top = Frame1.Height - 120
		Text1.Left = 0
		
		Dim i As Short
		Combo1.AddItem(9)
		For i = 10 To 90 Step 2
			Combo1.AddItem(i)
		Next
		Combo1.ListIndex = 0
	End Sub

	Private Sub Form_QueryUnload(ByRef Cancel As Short, ByRef UnloadMode As Short) Handles MyBase.QueryUnload
		Dim rep As Short
		If UnloadMode = 0 Then  '0 mode used if the form unloaded by pressing x button
			rep = MsgBox6("Are you sure you want to cancel adding of new file?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Code Library version 1.1")
			If rep = MsgBoxResult.No Then 
				Cancel = 1
			End If
		End If
	End Sub

	Private Sub Form_Resize() Handles MyBase.Resize
		On Error Resume Next 
		Frame1.Width = Me.Width - 160
		
		Text1.Width = Me.Width - 130
		Text1.Height = (Me.Height - 400) - Text1.Top
	End Sub

	Private Sub Form_Unload(ByRef Cancel As Short) Handles MyBase.Unload
		f_n = 0
	End Sub

	Private Sub Text1_DblClick() Handles Text1.DblClick
		Call highlight_focus(Text1)
	End Sub

	Private Sub Text1_GotFocus() Handles Text1.GotFocus
		If s1 <> -1 And s2 <> -1 Then 
			Text1.SelStart = s1
			Text1.SelLength = s2
		End If
	End Sub

	Private Sub Text1_LostFocus() Handles Text1.LostFocus
		If Len6(Text1.Text) > 0 Then 
			s1 = Text1.SelStart
			s2 = Text1.SelLength
		End If
	End Sub

	Private Sub Text2_GotFocus() Handles Text2.GotFocus
		Call highlight_focus(Text2)
	End Sub

	Private Sub Text2_KeyPress(ByRef KeyAscii As Short) Handles Text2.KeyPress
		If KeyAscii = 39 Then  KeyAscii = 0
	End Sub

	Private Sub Toolbar1_ButtonClick(ByVal Button As VB6Button) Handles Toolbar1.ButtonClick
		On Error Resume Next 
		If is_empty(Text2) = True Then  Exit Sub
		'////////////////////////////
		Dim tmp As String = Text2.Text
		
		Call remove_some_txt(tmp)
		Text2.Text = tmp
		tmp = ""
		'/////////////////////////////
		If is_empty(Text1) = True Then  Exit Sub
		If if_file_exist("tblFiles", "Where FolderNo =" & f_n & " and Title ='" & Text2.Text & "'", cn) = True Then  Text2.SetFocus(): Exit Sub

		With rs_files
			.AddNew() 'if_file_exist
			.Fields(0).Value = Text2.Text
			.Fields(1).Value = Text1.TextRTF
			.Fields(3).Value = f_n
			.Update()
		End With
		MsgBox6("New file has been successfully created.", MsgBoxStyle.Information, "Code Library version 1.1")
		FRM_UPDATE_REC.seconds = 3
		Unload6(Me)
		FRM_UPDATE_REC.Show(VBRUN.FormShowConstants.vbModal)
		rs_files.Requery()
		Form1.reload_files()
	End Sub

	Private Sub Toolbar2_ButtonClick(ByVal Button As VB6Button) Handles Toolbar2.ButtonClick
		On Error Resume Next 
		Select Case Button.Index
		Case 1: Text1.SelBold = True
		Case 2: Text1.SelItalic = True
		Case 3: Text1.SelUnderline = True
		Case 4: Text1.SelBold = False
			Text1.SelItalic = False
			Text1.SelUnderline = False
		Case 6
			CommonDialog1.ShowColor()
			Text1.SelColor = ToOleColor6(CommonDialog1.Color)
		End Select
	End Sub

End Class