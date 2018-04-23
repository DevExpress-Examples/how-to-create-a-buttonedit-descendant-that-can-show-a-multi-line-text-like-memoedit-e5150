Imports Microsoft.VisualBasic
Imports System
Namespace MultilineButtonEditExample
	Partial Public Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gcProductList = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemMultiLineButtonEdit1 = New MultilineButtonEditExample.RepositoryItemMultiLineButtonEdit()
			Me.colShortDescription = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colMultiLineDescription = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.multiLineButtonEdit1 = New MultilineButtonEditExample.MultiLineButtonEdit()
			Me.multiLineButtonEdit2 = New MultilineButtonEditExample.MultiLineButtonEdit()
			CType(Me.gcProductList, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemMultiLineButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.multiLineButtonEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.multiLineButtonEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gcProductList
			' 
			Me.gcProductList.DataMember = Nothing
			Me.gcProductList.Dock = System.Windows.Forms.DockStyle.Top
			Me.gcProductList.Location = New System.Drawing.Point(0, 0)
			Me.gcProductList.MainView = Me.gridView1
			Me.gcProductList.Name = "gcProductList"
			Me.gcProductList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemMultiLineButtonEdit1})
			Me.gcProductList.Size = New System.Drawing.Size(803, 366)
			Me.gcProductList.TabIndex = 0
			Me.gcProductList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colName, Me.colShortDescription, Me.colMultiLineDescription})
			Me.gridView1.GridControl = Me.gcProductList
			Me.gridView1.Name = "gridView1"
			Me.gridView1.OptionsView.RowAutoHeight = True
			Me.gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
			' 
			' colName
			' 
			Me.colName.ColumnEdit = Me.repositoryItemMultiLineButtonEdit1
			Me.colName.FieldName = "Name"
			Me.colName.Name = "colName"
			Me.colName.Visible = True
			Me.colName.VisibleIndex = 0
			' 
			' repositoryItemMultiLineButtonEdit1
			' 
			Me.repositoryItemMultiLineButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.repositoryItemMultiLineButtonEdit1.LinesCount = 0
			Me.repositoryItemMultiLineButtonEdit1.Name = "repositoryItemMultiLineButtonEdit1"
			Me.repositoryItemMultiLineButtonEdit1.ScrollBars = System.Windows.Forms.ScrollBars.None
			' 
			' colShortDescription
			' 
			Me.colShortDescription.ColumnEdit = Me.repositoryItemMultiLineButtonEdit1
			Me.colShortDescription.FieldName = "ShortDescription"
			Me.colShortDescription.Name = "colShortDescription"
			Me.colShortDescription.Visible = True
			Me.colShortDescription.VisibleIndex = 1
			' 
			' colMultiLineDescription
			' 
			Me.colMultiLineDescription.ColumnEdit = Me.repositoryItemMultiLineButtonEdit1
			Me.colMultiLineDescription.FieldName = "MultiLineDescription"
			Me.colMultiLineDescription.Name = "colMultiLineDescription"
			Me.colMultiLineDescription.Visible = True
			Me.colMultiLineDescription.VisibleIndex = 2
			' 
			' multiLineButtonEdit1
			' 
			Me.multiLineButtonEdit1.EditValue = "This is a first line, a second line, a third line of long description for product" & ""
			Me.multiLineButtonEdit1.Location = New System.Drawing.Point(12, 372)
			Me.multiLineButtonEdit1.Name = "multiLineButtonEdit1"
			Me.multiLineButtonEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.multiLineButtonEdit1.Properties.LinesCount = 0
			Me.multiLineButtonEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None
			Me.multiLineButtonEdit1.Size = New System.Drawing.Size(100, 99)
			Me.multiLineButtonEdit1.TabIndex = 1
			' 
			' multiLineButtonEdit2
			' 
			Me.multiLineButtonEdit2.EditValue = "This is a short description for product"
			Me.multiLineButtonEdit2.Location = New System.Drawing.Point(118, 372)
			Me.multiLineButtonEdit2.Name = "multiLineButtonEdit2"
			Me.multiLineButtonEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.multiLineButtonEdit2.Properties.LinesCount = 0
			Me.multiLineButtonEdit2.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None
			Me.multiLineButtonEdit2.Size = New System.Drawing.Size(100, 20)
			Me.multiLineButtonEdit2.TabIndex = 2
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(803, 483)
			Me.Controls.Add(Me.multiLineButtonEdit2)
			Me.Controls.Add(Me.multiLineButtonEdit1)
			Me.Controls.Add(Me.gcProductList)
			Me.Name = "MainForm"
			Me.Text = "Multiline ButtonEdit example"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gcProductList, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemMultiLineButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.multiLineButtonEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.multiLineButtonEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private multiLineButtonEdit1 As MultiLineButtonEdit
		Private multiLineButtonEdit2 As MultiLineButtonEdit
		Private colName As DevExpress.XtraGrid.Columns.GridColumn
		Private colShortDescription As DevExpress.XtraGrid.Columns.GridColumn
		Private colMultiLineDescription As DevExpress.XtraGrid.Columns.GridColumn
		Private gcProductList As DevExpress.XtraGrid.GridControl
		Private repositoryItemMultiLineButtonEdit1 As RepositoryItemMultiLineButtonEdit



	End Class
End Namespace

