Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel

Namespace MultilineButtonEditExample
	Partial Public Class MainForm
		Inherits DevExpress.XtraEditors.XtraForm

		Private productList As ProductList

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			productList = New ProductList(20)
			gcProductList.DataSource = productList
		End Sub
	End Class

	Public Class Product
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateShortDescription As String
		Public Property ShortDescription() As String
			Get
				Return privateShortDescription
			End Get
			Set(ByVal value As String)
				privateShortDescription = value
			End Set
		End Property
		Private privateMultiLineDescription As String
		Public Property MultiLineDescription() As String
			Get
				Return privateMultiLineDescription
			End Get
			Set(ByVal value As String)
				privateMultiLineDescription = value
			End Set
		End Property

		Public Sub New(ByVal index As Integer)
			Name = "Name " & index
			ShortDescription = "This is a short description for " & Name
			MultiLineDescription = " This is a first line, " & Constants.vbCrLf & " a second line " & Constants.vbCrLf & ", a third line of long description for " & Name
		End Sub
	End Class

	Public Class ProductList
		Inherits BindingList(Of Product)
		Public Sub New(ByVal count As Integer)
			For i As Integer = 0 To count - 1
				Items.Add(New Product(i))
			Next i
		End Sub
	End Class
End Namespace
