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
	Public WithEvents cmdCopy As CodeArchitects.VB6Library.VB6CommandButton
	Public WithEvents ImageList1 As CodeArchitects.VB6Library.VB6ImageList
	Public WithEvents TreeView1 As CodeArchitects.VB6Library.VB6TreeView

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
 		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
		Me.cmdCopy = New CodeArchitects.VB6Library.VB6CommandButton()
		Me.ImageList1 = New CodeArchitects.VB6Library.VB6ImageList()
		Me.TreeView1 = New CodeArchitects.VB6Library.VB6TreeView()
		CType(Me.ImageList1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		' cmdCopy
		'
		Me.cmdCopy.Name = "cmdCopy"
		Me.cmdCopy.Size = New System.Drawing.Size(97, 33)
		Me.cmdCopy.Location = New System.Drawing.Point(336, 8)
		Me.cmdCopy.Caption = "&Copy"
		Me.cmdCopy.TabIndex = 1
		'
		' ImageList1
		'
		Me.ImageList1.Name = "ImageList1"
		Me.ImageList1.ParentForm = Me
		Me.ImageList1.BackColor = FromOleColor6(CInt(-2147483643))
		Me.ImageList1.MaskColor = FromOleColor6(CInt(12632256))
		Me.ImageList1.ImageList.ImageSize = New System.Drawing.Size(13, 13)
		Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
		'
		' TreeView1
		'
		Me.TreeView1.Name = "TreeView1"
		Me.TreeView1.Size = New System.Drawing.Size(313, 353)
		Me.TreeView1.Location = New System.Drawing.Point(8, 8)
		Me.TreeView1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TreeView1.TabIndex = 0
		Me.TreeView1.Indentation = 706
		Me.TreeView1.LineStyle = CodeArchitects.VB6Library.MSComctlLib.TreeLineStyleConstants.tvwRootLines
		Me.TreeView1.Style = CodeArchitects.VB6Library.MSComctlLib.TreeStyleConstants.tvwTreelinesPlusMinusPictureText
		Me.TreeView1.ImageList = ImageList1
		Me.TreeView1.OLEDropMode = CodeArchitects.VB6Library.VBRUN.OLEDropConstants.vbOLEDropManual
		'
		' Form1
		'
		Me.Name = "Form1"
		Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Caption = "Form1"
		Me.StartUpPosition = CodeArchitects.VB6Library.VBRUN.StartUpPositionConstants.vbStartUpWindowsDefault
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ClientSize = New System.Drawing.Size(447, 379)

		Me.Controls.Add(cmdCopy)
		Me.Controls.Add(TreeView1)
		CType(Me.ImageList1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub

#End Region


End Class
