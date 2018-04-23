namespace MultilineButtonEditExample {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gcProductList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMultiLineButtonEdit1 = new MultilineButtonEditExample.RepositoryItemMultiLineButtonEdit();
            this.colShortDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMultiLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.multiLineButtonEdit1 = new MultilineButtonEditExample.MultiLineButtonEdit();
            this.multiLineButtonEdit2 = new MultilineButtonEditExample.MultiLineButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMultiLineButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiLineButtonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiLineButtonEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcProductList
            // 
            this.gcProductList.DataMember = null;
            this.gcProductList.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcProductList.Location = new System.Drawing.Point(0, 0);
            this.gcProductList.MainView = this.gridView1;
            this.gcProductList.Name = "gcProductList";
            this.gcProductList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMultiLineButtonEdit1});
            this.gcProductList.Size = new System.Drawing.Size(803, 366);
            this.gcProductList.TabIndex = 0;
            this.gcProductList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colShortDescription,
            this.colMultiLineDescription});
            this.gridView1.GridControl = this.gcProductList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            // 
            // colName
            // 
            this.colName.ColumnEdit = this.repositoryItemMultiLineButtonEdit1;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // repositoryItemMultiLineButtonEdit1
            // 
            this.repositoryItemMultiLineButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemMultiLineButtonEdit1.LinesCount = 0;
            this.repositoryItemMultiLineButtonEdit1.Name = "repositoryItemMultiLineButtonEdit1";
            this.repositoryItemMultiLineButtonEdit1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            // 
            // colShortDescription
            // 
            this.colShortDescription.ColumnEdit = this.repositoryItemMultiLineButtonEdit1;
            this.colShortDescription.FieldName = "ShortDescription";
            this.colShortDescription.Name = "colShortDescription";
            this.colShortDescription.Visible = true;
            this.colShortDescription.VisibleIndex = 1;
            // 
            // colMultiLineDescription
            // 
            this.colMultiLineDescription.ColumnEdit = this.repositoryItemMultiLineButtonEdit1;
            this.colMultiLineDescription.FieldName = "MultiLineDescription";
            this.colMultiLineDescription.Name = "colMultiLineDescription";
            this.colMultiLineDescription.Visible = true;
            this.colMultiLineDescription.VisibleIndex = 2;
            // 
            // multiLineButtonEdit1
            // 
            this.multiLineButtonEdit1.EditValue = "This is a first line, a second line, a third line of long description for product" +
    "";
            this.multiLineButtonEdit1.Location = new System.Drawing.Point(12, 372);
            this.multiLineButtonEdit1.Name = "multiLineButtonEdit1";
            this.multiLineButtonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.multiLineButtonEdit1.Properties.LinesCount = 0;
            this.multiLineButtonEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.multiLineButtonEdit1.Size = new System.Drawing.Size(100, 99);
            this.multiLineButtonEdit1.TabIndex = 1;
            // 
            // multiLineButtonEdit2
            // 
            this.multiLineButtonEdit2.EditValue = "This is a short description for product";
            this.multiLineButtonEdit2.Location = new System.Drawing.Point(118, 372);
            this.multiLineButtonEdit2.Name = "multiLineButtonEdit2";
            this.multiLineButtonEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.multiLineButtonEdit2.Properties.LinesCount = 0;
            this.multiLineButtonEdit2.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.multiLineButtonEdit2.Size = new System.Drawing.Size(100, 20);
            this.multiLineButtonEdit2.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 483);
            this.Controls.Add(this.multiLineButtonEdit2);
            this.Controls.Add(this.multiLineButtonEdit1);
            this.Controls.Add(this.gcProductList);
            this.Name = "MainForm";
            this.Text = "Multiline ButtonEdit example";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMultiLineButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiLineButtonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiLineButtonEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private MultiLineButtonEdit multiLineButtonEdit1;
        private MultiLineButtonEdit multiLineButtonEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colShortDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colMultiLineDescription;
        private DevExpress.XtraGrid.GridControl gcProductList;
        private RepositoryItemMultiLineButtonEdit repositoryItemMultiLineButtonEdit1;



    }
}

