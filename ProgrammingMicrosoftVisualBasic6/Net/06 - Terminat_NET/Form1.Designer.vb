<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form1
	Inherits CodeArchitects.VB6Library.VB6Form

#Region "Static constructor"

' This static constructor ensures that the VB6 support library be initialized before using current class.
Shared Sub New()
	EnsureVB6LibraryInitialization()
End Sub

#End Region

#Region "Windows Form Designer generated code "

	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'Create all controls and control arrays.
		InitializeComponents()
	End Sub

	' This method wraps the call to InitializeComponent, but can be called from base class.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overrides Sub InitializeComponents()
		Me.ObjectIsInitializing = True
		InitializeComponent()
		Me.ObjectIsInitializing = False
	End Sub

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing Then
				If components IsNot Nothing Then components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public WithEvents Command2 As CodeArchitects.VB6Library.VB6CommandButton
	Public WithEvents Command3 As CodeArchitects.VB6Library.VB6CommandButton
	Public WithEvents Text1 As CodeArchitects.VB6Library.VB6TextBox
	Public WithEvents Command1 As CodeArchitects.VB6Library.VB6CommandButton

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.Command2 = New CodeArchitects.VB6Library.VB6CommandButton()
		Me.Command3 = New CodeArchitects.VB6Library.VB6CommandButton()
		Me.Text1 = New CodeArchitects.VB6Library.VB6TextBox()
		Me.Command1 = New CodeArchitects.VB6Library.VB6CommandButton()
		Me.SuspendLayout()
		'
		' Command2
		'
		Me.Command2.Name = "Command2"
		Me.Command2.Size = New System.Drawing.Size(105, 33)
		Me.Command2.Location = New System.Drawing.Point(8, 64)
		Me.Command2.Caption = "Open a temp file"
		Me.Command2.TabIndex = 3
		'
		' Command3
		'
		Me.Command3.Name = "Command3"
		Me.Command3.Size = New System.Drawing.Size(105, 33)
		Me.Command3.Location = New System.Drawing.Point(8, 112)
		Me.Command3.Caption = "Set Mouse Pointer"
		Me.Command3.TabIndex = 2
		'
		' Text1
		'
		Me.Text1.Name = "Text1"
		Me.Text1.Size = New System.Drawing.Size(337, 217)
		Me.Text1.Location = New System.Drawing.Point(128, 16)
		Me.Text1.MultiLine = -1
		Me.Text1.ScrollBars = CodeArchitects.VB6Library.VBRUN.ScrollBarConstants.vbBoth
		Me.Text1.TabIndex = 1
		'
		' Command1
		'
		Me.Command1.Name = "Command1"
		Me.Command1.Size = New System.Drawing.Size(105, 33)
		Me.Command1.Location = New System.Drawing.Point(8, 16)
		Me.Command1.Caption = "Open a file"
		Me.Command1.TabIndex = 0
		'
		' Form1
		'
		Me.Name = "Form1"
		Me.Caption = "Form1"
		Me.StartUpPosition = CodeArchitects.VB6Library.VBRUN.StartUpPositionConstants.vbStartUpWindowsDefault
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ClientSize = New System.Drawing.Size(498, 249)

		Me.Controls.Add(Command2)
		Me.Controls.Add(Command3)
		Me.Controls.Add(Text1)
		Me.Controls.Add(Command1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub

#End Region


End Class
