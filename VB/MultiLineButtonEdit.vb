Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing
Imports System.Reflection
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Controls
Imports System.ComponentModel
Imports DevExpress.Utils
Imports DevExpress.Utils.Drawing
Imports System.Windows.Forms

Namespace MultilineButtonEditExample

	<UserRepositoryItem("RegisterMultiLineButtonEdit")> _
	Public Class RepositoryItemMultiLineButtonEdit
		Inherits RepositoryItemButtonEdit
		Private _acceptsTab As Boolean
		Private _acceptsReturn As Boolean
		Private _linesCount As Integer
		Private _scrollBars As ScrollBars
		Public Const MultiLineButtonEditName As String = "MultiLineButtonEdit"

		Shared Sub New()
			RegisterMultiLineButtonEdit()
		End Sub

		Public Sub New()
			Me._acceptsTab = False
			Me._acceptsReturn = True
			Me._linesCount = 0
			Me._scrollBars = ScrollBars.None
		End Sub

        <Browsable(False)> _
        Protected Overrides ReadOnly Property UseMaskBox() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property AutoHeight As Boolean
            Get
                Return False
            End Get
            Set(value As Boolean)
                MyBase.AutoHeight = value
            End Set
        End Property


		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return MultiLineButtonEditName
			End Get
		End Property

		Public Shared Sub RegisterMultiLineButtonEdit()
			Dim img As Image = Nothing
						Try
							img = CType(Bitmap.FromStream(System.Reflection.Assembly.GetAssembly(GetType(MultiLineButtonEdit)).GetManifestResourceStream("MultiLineButtonEdit.bmp")), Image)
					  Catch
					  End Try
			  EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(MultiLineButtonEditName, GetType(MultiLineButtonEdit), GetType(RepositoryItemMultiLineButtonEdit), GetType(MultiLineButtonEditViewInfo), New ButtonEditPainter(), True, img, GetType(DevExpress.Accessibility.ButtonEditAccessible)))
		End Sub

		<DefaultValue(False)> _
		Public Property AcceptsTab() As Boolean
			Get
				Return _acceptsTab
			End Get
			Set(ByVal value As Boolean)
				If AcceptsTab = value Then
					Return
				End If
				_acceptsTab = value
				OnPropertiesChanged()
			End Set
		End Property

		<DefaultValue(True)> _
		Public Property AcceptsReturn() As Boolean
			Get
				Return _acceptsReturn
			End Get
			Set(ByVal value As Boolean)
				If AcceptsReturn = value Then
					Return
				End If
				_acceptsReturn = value
				OnPropertiesChanged()
			End Set
		End Property

		<Browsable(False)> _
		Public Property LinesCount() As Integer
			Get
				Return _linesCount
			End Get
			Set(ByVal value As Integer)
				If value < 1 Then
					value = 0
				End If
				If LinesCount = value Then
					Return
				End If
				_linesCount = value
				OnPropertiesChanged()
			End Set
		End Property

		Public Property ScrollBars() As ScrollBars
			Get
				Return _scrollBars
			End Get
			Set(ByVal value As ScrollBars)
				If ScrollBars = value Then
					Return
				End If
				_scrollBars = value
				OnPropertiesChanged()
			End Set
		End Property

		Public Overrides Sub Assign(ByVal item As RepositoryItem)
			Dim source As RepositoryItemMultiLineButtonEdit = TryCast(item, RepositoryItemMultiLineButtonEdit)
			BeginUpdate()
			Try
				MyBase.Assign(item)
				If source Is Nothing Then
					Return
				End If
				Me._acceptsReturn = source.AcceptsReturn
				Me._acceptsTab = source.AcceptsTab
				Me._scrollBars = source.ScrollBars
				Me._linesCount = source.LinesCount
			Finally
				EndUpdate()
			End Try
		End Sub

		Protected Overrides Function NeededKeysContains(ByVal key As Keys) As Boolean
			If AcceptsReturn AndAlso key = Keys.Enter Then
				Return True
			End If
			If AcceptsTab AndAlso key = Keys.Tab Then
				Return True
			End If
			If key = Keys.Up Then
				Return True
			End If
			If key = Keys.Down Then
				Return True
			End If
			Return MyBase.NeededKeysContains(key)
		End Function

		Protected Overrides Function IsNeededKeyCore(ByVal keyData As Keys) As Boolean
			If keyData = (Keys.Enter Or Keys.Control) Then
				Return False
			End If
			Dim res As Boolean = MyBase.IsNeededKeyCore(keyData)
			If res Then
				Return True
			End If
			If keyData = Keys.PageUp OrElse keyData = Keys.PageDown Then
				Return True
			End If
			Return False
		End Function
	End Class

	Public Class MultiLineButtonEditViewInfo
		Inherits ButtonEditViewInfo
		Implements IHeightAdaptable

		Public Sub New(ByVal item As RepositoryItem)
			MyBase.New(item)
		End Sub
		Public Shadows ReadOnly Property Item() As RepositoryItemMultiLineButtonEdit
			Get
				Return TryCast(MyBase.Item, RepositoryItemMultiLineButtonEdit)
			End Get
		End Property

		Private Shared defaultEditTextOptions_Renamed As TextOptions
		Private Shared ReadOnly Property DefaultEditTextOptions() As TextOptions
			Get
				If defaultEditTextOptions_Renamed Is Nothing Then
					defaultEditTextOptions_Renamed = New TextOptions(HorzAlignment.Near, VertAlignment.Top, WordWrap.Wrap, Trimming.None)
				End If
				Return defaultEditTextOptions_Renamed
			End Get
		End Property
		Public Overrides ReadOnly Property DefaultTextOptions() As TextOptions
			Get
				If OwnerEdit IsNot Nothing AndAlso OwnerEdit.InplaceType = InplaceType.Standalone Then
					If Item.ScrollBars = ScrollBars.Horizontal OrElse Item.ScrollBars = ScrollBars.Both Then
						Return New TextOptions(HorzAlignment.Near, VertAlignment.Top, WordWrap.NoWrap, Trimming.None)
					End If
				End If
				Return DefaultEditTextOptions
			End Get
		End Property

		Protected Overrides Sub CalcContentRect(ByVal bounds As Rectangle)
			MyBase.CalcContentRect(bounds)
			Me.fMaskBoxRect = ContentRect
			If Not(TypeOf BorderPainter Is EmptyBorderPainter) Then
				Me.fMaskBoxRect.Inflate(-1, -1)
			End If
		End Sub

		Private Function CalcHeight(ByVal cache As GraphicsCache, ByVal width As Integer) As Integer Implements IHeightAdaptable.CalcHeight
				Dim info As New BorderObjectInfoArgs(cache)
				info.Bounds = New Rectangle(0, 0, ContentRect.Width, 100)
			Dim textRect As Rectangle = BorderPainter.GetObjectClientRectangle(info)
			If Not(TypeOf BorderPainter Is EmptyBorderPainter) AndAlso Not(TypeOf BorderPainter Is InplaceBorderPainter) Then
				textRect.Inflate(-1, -1)
			End If
			Dim text As String = String.Empty
			If Item.LinesCount = 0 Then
				text = DisplayText
				If text IsNot Nothing AndAlso text.Length > 0 Then
					Dim lastChar As Char = text.Chars(text.Length - 1)
					If AscW(lastChar) = 13 OrElse AscW(lastChar) = 10 Then
						text &= "W"
					End If
				End If
			Else
				For i As Integer = 0 To Item.LinesCount - 1
					text &= (If(String.IsNullOrEmpty(text), "", Environment.NewLine)) & "W"
				Next i
			End If
			Dim height As Integer = CalcTextSizeCore(cache, text, textRect.Width).Height + 1
			Return (height + 100 - textRect.Bottom) + 1
		End Function
	End Class

	<ToolboxBitmapAttribute(GetType(MultiLineButtonEdit), "MultiLineButtonEdit.bmp"), ToolboxItem(True), Description("Custom ButtonEdit with multi line support.")> _
	Public Class MultiLineButtonEdit
		Inherits ButtonEdit
		Shared Sub New()
			RepositoryItemMultiLineButtonEdit.RegisterMultiLineButtonEdit()
		End Sub
		Public Sub New()
		End Sub
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemMultiLineButtonEdit.MultiLineButtonEditName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemMultiLineButtonEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemMultiLineButtonEdit)
			End Get
		End Property
		Protected Overrides ReadOnly Property AcceptsReturn() As Boolean
			Get
				Return Properties.AcceptsReturn
			End Get
		End Property
		Protected Overrides ReadOnly Property AcceptsTab() As Boolean
			Get
				Return Properties.AcceptsTab
			End Get
		End Property

		Protected Overrides Sub UpdateMaskBoxProperties(ByVal always As Boolean)
			MyBase.UpdateMaskBoxProperties(always)
			If MaskBox Is Nothing Then
				Return
			End If
			If always OrElse (Not MaskBox.Multiline) Then
				MaskBox.Multiline = True
			End If
			If always OrElse (Not MaskBox.WordWrap) Then
				MaskBox.WordWrap = True
			End If
			If always OrElse Properties.AcceptsTab <> MaskBox.AcceptsTab Then
				MaskBox.AcceptsTab = Properties.AcceptsTab
			End If
			If always OrElse Properties.AcceptsReturn <> MaskBox.AcceptsReturn Then
				MaskBox.AcceptsReturn = Properties.AcceptsReturn
			End If
			If always OrElse Properties.ScrollBars <> MaskBox.ScrollBars Then
				MaskBox.ScrollBars = Properties.ScrollBars
			End If
		End Sub

		Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
			Dim result As Boolean = MyBase.IsInputKey(keyData)
			If result Then
				Return True
			End If
			If Properties.AcceptsReturn AndAlso keyData = Keys.Enter Then
				Return True
			End If
			If Properties.AcceptsTab AndAlso keyData = Keys.Tab Then
				Return True
			End If
			Return result
		End Function
	End Class
End Namespace
