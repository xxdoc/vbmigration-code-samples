<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form18
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
	Public WithEvents Command3 As CodeArchitects.VB6Library.VB6CommandButton
	Public WithEvents ImageList1 As CodeArchitects.VB6Library.VB6ImageList
	Public WithEvents Text2 As CodeArchitects.VB6Library.VB6TextBox
	Public WithEvents Command1 As CodeArchitects.VB6Library.VB6CommandButton
	Public WithEvents Picture1 As CodeArchitects.VB6Library.VB6PictureBox
	Public WithEvents Picture2 As CodeArchitects.VB6Library.VB6PictureBox
	Public WithEvents ListView1 As CodeArchitects.VB6Library.VB6ListView
	Public WithEvents Label2 As CodeArchitects.VB6Library.VB6Label
	Public WithEvents ListView1_Control As System.Windows.Forms.ListView
	Public WithEvents ListView1_Column1 As System.Windows.Forms.ColumnHeader
	Public WithEvents ListView1_Column2 As System.Windows.Forms.ColumnHeader
	Public WithEvents ListView1_Column3 As System.Windows.Forms.ColumnHeader
	Public WithEvents ListView1_Column4 As System.Windows.Forms.ColumnHeader
	Public WithEvents ListView1_Column5 As System.Windows.Forms.ColumnHeader
	Public WithEvents ListView1_Column6 As System.Windows.Forms.ColumnHeader

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
 		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form18))
		Me.Command3 = New CodeArchitects.VB6Library.VB6CommandButton()
		Me.ImageList1 = New CodeArchitects.VB6Library.VB6ImageList()
		Me.Text2 = New CodeArchitects.VB6Library.VB6TextBox()
		Me.Command1 = New CodeArchitects.VB6Library.VB6CommandButton()
		Me.Picture1 = New CodeArchitects.VB6Library.VB6PictureBox()
		Me.Picture2 = New CodeArchitects.VB6Library.VB6PictureBox()
		Me.ListView1 = New CodeArchitects.VB6Library.VB6ListView()
		Me.Label2 = New CodeArchitects.VB6Library.VB6Label()
		Me.ListView1_Control = New System.Windows.Forms.ListView()
		Me.ListView1_Column1 = New System.Windows.Forms.ColumnHeader()
		Me.ListView1_Column2 = New System.Windows.Forms.ColumnHeader()
		Me.ListView1_Column3 = New System.Windows.Forms.ColumnHeader()
		Me.ListView1_Column4 = New System.Windows.Forms.ColumnHeader()
		Me.ListView1_Column5 = New System.Windows.Forms.ColumnHeader()
		Me.ListView1_Column6 = New System.Windows.Forms.ColumnHeader()
		Me.Picture1.SuspendLayout()
		CType(Me.ImageList1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ListView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		' Command3
		'
		Me.Command3.Name = "Command3"
		Me.Command3.Size = New System.Drawing.Size(20, 20)
		Me.Command3.Location = New System.Drawing.Point(232, 8)
		Me.Command3.Picture = CType(resources.GetObject("Command3.Picture"), System.Drawing.Image)
		Me.Command3.Style = CodeArchitects.VB6Library.VBRUN.ButtonConstants.vbButtonGraphical
		Me.Command3.TabIndex = 1
		Me.Command3.BackColor = FromOleColor6(CInt(&H8000000F))
		'
		' ImageList1
		'
		Me.ImageList1.Name = "ImageList1"
		Me.ImageList1.ParentForm = Me
		Me.ImageList1.Name6 = "ImageList1"
		Me.ImageList1.BackColor = FromOleColor6(CInt(-2147483643))
		Me.ImageList1.MaskColor = FromOleColor6(CInt(12632256))
		Me.ImageList1.ImageList.ImageSize = New System.Drawing.Size(16, 16)
		Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
		'
		' Text2
		'
		Me.Text2.Name = "Text2"
		Me.Text2.Size = New System.Drawing.Size(153, 20)
		Me.Text2.Location = New System.Drawing.Point(80, 8)
		Me.Text2.BackColor = FromOleColor6(CInt(&H00E6FFFF))
		Me.Text2.ReadOnly = True
		Me.Text2.TabIndex = 0
		'
		' Command1
		'
		Me.Command1.Name = "Command1"
		Me.Command1.Size = New System.Drawing.Size(81, 23)
		Me.Command1.Location = New System.Drawing.Point(176, 288)
		Me.Command1.Caption = "&Close"
		Me.Command1.TabIndex = 3
		Me.Command1.BackColor = FromOleColor6(CInt(&H8000000F))
		Me.AcceptButton = Me.Command1
		Me.Command1.DialogResult = System.Windows.Forms.DialogResult.None
		'
		' Picture1
		'
		Me.Picture1.Name = "Picture1"
		Me.Picture1.Size = New System.Drawing.Size(249, 2)
		Me.Picture1.Location = New System.Drawing.Point(8, 280)
		Me.Picture1.BackColor = FromOleColor6(CInt(&H80000010))
		Me.Picture1.BorderStyle = CodeArchitects.VB6Library.VB6BorderStyleConstants.None
		Me.Picture1.TabIndex = 4
		Me.Picture1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.Picture1.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		'
		' Picture2
		'
		Me.Picture2.Name = "Picture2"
		Me.Picture2.Size = New System.Drawing.Size(593, 1)
		Me.Picture2.Location = New System.Drawing.Point(0, 1)
		Me.Picture2.BackColor = FromOleColor6(CInt(&H80000014))
		Me.Picture2.BorderStyle = CodeArchitects.VB6Library.VB6BorderStyleConstants.None
		Me.Picture2.TabIndex = 5
		Me.Picture2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.Picture2.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		'
		' ListView1
		'
		Me.ListView1.Name = "ListView1"
		Me.ListView1.Location = New System.Drawing.Point(8, 40)
		Me.ListView1.Icons = ImageList1
		Me.ListView1.SmallIcons = ImageList1
		Me.ListView1.Size = New System.Drawing.Size(2, 2)
		Me.ListView1.ListView = Me.ListView1_Control
		Me.ListView1_Control.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ListView1_Column1, Me.ListView1_Column2, Me.ListView1_Column3, Me.ListView1_Column4, Me.ListView1_Column5, Me.ListView1_Column6})
		'
		' Label2
		'
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(65, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 8)
		Me.Label2.Caption = "Level:"
		Me.Label2.TabIndex = 6
		Me.Label2.AutoSize = False
		Me.Label2.BackColor = FromOleColor6(CInt(&H8000000F))
		'
		' ListView1_Control
		'
		Me.ListView1_Control.Name = "ListView1_Control"
		Me.ListView1_Control.Size = New System.Drawing.Size(249, 238)
		Me.ListView1_Control.Location = New System.Drawing.Point(8, 40)
		Me.ListView1_Control.ShowItemToolTips = True
		Me.ListView1_Control.BackColor = FromOleColor6(CInt(-2147483643))
		Me.ListView1_Control.ForeColor = FromOleColor6(CInt(8388608))
		Me.ListView1_Control.TabIndex = 2
		Me.ListView1_Control.FullRowSelect = True
		Me.ListView1_Control.HideSelection = False
		Me.ListView1_Control.LabelWrap = True
		Me.ListView1_Control.LargeImageList = ImageList1.ImageList
		Me.ListView1_Control.SmallImageList = ImageList1.ImageList
		Me.ListView1_Control.Alignment = System.Windows.Forms.ListViewAlignment.Default
		Me.ListView1_Control.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.ListView1_Control.LabelEdit = False
		Me.ListView1_Control.MultiSelect = False
		Me.ListView1_Control.View = System.Windows.Forms.View.Details
		Me.ListView1_Control.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.ListView1_Control.BackgroundImageTiled = False
		'
		' ListView1_Column1
		'
		Me.ListView1_Column1.Name = "ListView1_Column1"
		Me.ListView1_Column1.Text = "No."
		Me.ListView1_Column1.Width = 53
		'
		' ListView1_Column2
		'
		Me.ListView1_Column2.Name = "ListView1_Column2"
		Me.ListView1_Column2.Text = "sec_no"
		Me.ListView1_Column2.Width = 0
		'
		' ListView1_Column3
		'
		Me.ListView1_Column3.Name = "ListView1_Column3"
		Me.ListView1_Column3.Text = "Section"
		Me.ListView1_Column3.Width = 190
		'
		' ListView1_Column4
		'
		Me.ListView1_Column4.Name = "ListView1_Column4"
		Me.ListView1_Column4.Text = "mina"
		Me.ListView1_Column4.Width = 0
		'
		' ListView1_Column5
		'
		Me.ListView1_Column5.Name = "ListView1_Column5"
		Me.ListView1_Column5.Text = "maxa"
		Me.ListView1_Column5.Width = 0
		'
		' ListView1_Column6
		'
		Me.ListView1_Column6.Name = "ListView1_Column6"
		Me.ListView1_Column6.Text = "allwd"
		Me.ListView1_Column6.Width = 0
		'
		' Form18
		'
		Me.Name = "Form18"
		Me.BorderStyle = CodeArchitects.VB6Library.VBRUN.FormBorderStyleConstants.vbFixedSingle
		Me.Caption = "Select Section"
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaxButton = False
		Me.MDIChild = -1
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ClientSize = New System.Drawing.Size(266, 320)

		Me.Controls.Add(Command3)
		Me.Controls.Add(Text2)
		Me.Controls.Add(Command1)
		Me.Controls.Add(Picture1)
		Me.Picture1.Controls.Add(Picture2)
		Me.Controls.Add(ListView1)
		Me.Controls.Add(Label2)
		Me.Controls.Add(ListView1_Control)
		CType(Me.ImageList1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ListView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Picture1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub

#End Region


End Class