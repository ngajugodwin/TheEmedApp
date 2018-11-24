namespace eMed.View.Controls
{
    partial class ServicesAndCatalogControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddServicesCatalog = new System.Windows.Forms.ToolStripButton();
            this.btnEditServiceCatalog = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteServiceCatalog = new System.Windows.Forms.ToolStripButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dataGridViewService = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnNewService = new System.Windows.Forms.ToolStripButton();
            this.btnServiceEdit = new System.Windows.Forms.ToolStripButton();
            this.btnServiceDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.btnServiceRefresh = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.serviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.service_catalog_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.servicecatalogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.service_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.servicecatalogidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isFavourite = new System.Windows.Forms.DataGridViewImageColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicecatalogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dataGridView1);
            this.panelControl1.Controls.Add(this.toolStrip1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(298, 495);
            this.panelControl1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.service_catalog_id,
            this.name,
            this.active});
            this.dataGridView1.DataSource = this.servicecatalogBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(2, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(294, 466);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddServicesCatalog,
            this.btnEditServiceCatalog,
            this.btnDeleteServiceCatalog});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(294, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddServicesCatalog
            // 
            this.btnAddServicesCatalog.Font = new System.Drawing.Font("Calibri", 9F);
            this.btnAddServicesCatalog.Image = global::eMed.Properties.Resources.add;
            this.btnAddServicesCatalog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddServicesCatalog.Name = "btnAddServicesCatalog";
            this.btnAddServicesCatalog.Size = new System.Drawing.Size(48, 22);
            this.btnAddServicesCatalog.Text = "Add";
            this.btnAddServicesCatalog.Click += new System.EventHandler(this.btnAddServicesCatalog_Click);
            // 
            // btnEditServiceCatalog
            // 
            this.btnEditServiceCatalog.Font = new System.Drawing.Font("Calibri", 9F);
            this.btnEditServiceCatalog.Image = global::eMed.Properties.Resources.edit;
            this.btnEditServiceCatalog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditServiceCatalog.Name = "btnEditServiceCatalog";
            this.btnEditServiceCatalog.Size = new System.Drawing.Size(48, 22);
            this.btnEditServiceCatalog.Text = "Edit";
            this.btnEditServiceCatalog.Click += new System.EventHandler(this.btnEditServiceCatalog_Click);
            // 
            // btnDeleteServiceCatalog
            // 
            this.btnDeleteServiceCatalog.Font = new System.Drawing.Font("Calibri", 9F);
            this.btnDeleteServiceCatalog.Image = global::eMed.Properties.Resources.delete;
            this.btnDeleteServiceCatalog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteServiceCatalog.Name = "btnDeleteServiceCatalog";
            this.btnDeleteServiceCatalog.Size = new System.Drawing.Size(64, 22);
            this.btnDeleteServiceCatalog.Text = "Delete";
            this.btnDeleteServiceCatalog.Click += new System.EventHandler(this.btnDeleteServiceCatalog_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dataGridViewService);
            this.panelControl2.Controls.Add(this.toolStrip2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(298, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(549, 495);
            this.panelControl2.TabIndex = 1;
            // 
            // dataGridViewService
            // 
            this.dataGridViewService.AllowUserToAddRows = false;
            this.dataGridViewService.AllowUserToDeleteRows = false;
            this.dataGridViewService.AllowUserToResizeColumns = false;
            this.dataGridViewService.AllowUserToResizeRows = false;
            this.dataGridViewService.AutoGenerateColumns = false;
            this.dataGridViewService.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewService.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewService.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.service_id,
            this.Picture,
            this.servicecatalogidDataGridViewTextBoxColumn,
            this.isFavourite,
            this.code,
            this.activeDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dataGridViewService.DataSource = this.serviceBindingSource;
            this.dataGridViewService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewService.Location = new System.Drawing.Point(2, 27);
            this.dataGridViewService.MultiSelect = false;
            this.dataGridViewService.Name = "dataGridViewService";
            this.dataGridViewService.ReadOnly = true;
            this.dataGridViewService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewService.Size = new System.Drawing.Size(545, 466);
            this.dataGridViewService.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewService,
            this.btnServiceEdit,
            this.btnServiceDelete,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.btnServiceRefresh});
            this.toolStrip2.Location = new System.Drawing.Point(2, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(545, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnNewService
            // 
            this.btnNewService.Font = new System.Drawing.Font("Calibri", 9F);
            this.btnNewService.Image = global::eMed.Properties.Resources.add;
            this.btnNewService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewService.Name = "btnNewService";
            this.btnNewService.Size = new System.Drawing.Size(92, 22);
            this.btnNewService.Text = "New Service";
            this.btnNewService.Click += new System.EventHandler(this.btnNewService_Click);
            // 
            // btnServiceEdit
            // 
            this.btnServiceEdit.Image = global::eMed.Properties.Resources.edit;
            this.btnServiceEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnServiceEdit.Name = "btnServiceEdit";
            this.btnServiceEdit.Size = new System.Drawing.Size(47, 22);
            this.btnServiceEdit.Text = "Edit";
            this.btnServiceEdit.Click += new System.EventHandler(this.btnServiceEdit_Click);
            // 
            // btnServiceDelete
            // 
            this.btnServiceDelete.Font = new System.Drawing.Font("Calibri", 9F);
            this.btnServiceDelete.Image = global::eMed.Properties.Resources.delete;
            this.btnServiceDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnServiceDelete.Name = "btnServiceDelete";
            this.btnServiceDelete.Size = new System.Drawing.Size(64, 22);
            this.btnServiceDelete.Text = "Delete";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Search";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(120, 25);
            // 
            // btnServiceRefresh
            // 
            this.btnServiceRefresh.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServiceRefresh.Image = global::eMed.Properties.Resources.refresh2;
            this.btnServiceRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnServiceRefresh.Name = "btnServiceRefresh";
            this.btnServiceRefresh.Size = new System.Drawing.Size(69, 22);
            this.btnServiceRefresh.Text = "Refresh";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(298, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 495);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // serviceBindingSource
            // 
            this.serviceBindingSource.DataSource = typeof(eMed.Model.service);
            // 
            // service_catalog_id
            // 
            this.service_catalog_id.DataPropertyName = "service_catalog_id";
            this.service_catalog_id.HeaderText = "service_catalog_id";
            this.service_catalog_id.Name = "service_catalog_id";
            this.service_catalog_id.ReadOnly = true;
            this.service_catalog_id.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 130;
            // 
            // active
            // 
            this.active.DataPropertyName = "active";
            this.active.HeaderText = "Active";
            this.active.Name = "active";
            this.active.ReadOnly = true;
            this.active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.active.Width = 130;
            // 
            // servicecatalogBindingSource
            // 
            this.servicecatalogBindingSource.DataSource = typeof(eMed.Model.service_catalog);
            // 
            // service_id
            // 
            this.service_id.DataPropertyName = "service_id";
            this.service_id.HeaderText = "service_id";
            this.service_id.Name = "service_id";
            this.service_id.ReadOnly = true;
            this.service_id.Visible = false;
            // 
            // Picture
            // 
            this.Picture.DataPropertyName = "Picture";
            this.Picture.HeaderText = "Favourite";
            this.Picture.Name = "Picture";
            this.Picture.ReadOnly = true;
            // 
            // servicecatalogidDataGridViewTextBoxColumn
            // 
            this.servicecatalogidDataGridViewTextBoxColumn.DataPropertyName = "service_catalog_id";
            this.servicecatalogidDataGridViewTextBoxColumn.HeaderText = "service_catalog_id";
            this.servicecatalogidDataGridViewTextBoxColumn.Name = "servicecatalogidDataGridViewTextBoxColumn";
            this.servicecatalogidDataGridViewTextBoxColumn.ReadOnly = true;
            this.servicecatalogidDataGridViewTextBoxColumn.Visible = false;
            // 
            // isFavourite
            // 
            this.isFavourite.DataPropertyName = "isFavourite";
            this.isFavourite.HeaderText = "Favouritee";
            this.isFavourite.Image = global::eMed.Properties.Resources.favourite;
            this.isFavourite.Name = "isFavourite";
            this.isFavourite.ReadOnly = true;
            this.isFavourite.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isFavourite.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isFavourite.Visible = false;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "Code";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // activeDataGridViewTextBoxColumn
            // 
            this.activeDataGridViewTextBoxColumn.DataPropertyName = "active";
            this.activeDataGridViewTextBoxColumn.HeaderText = "Active";
            this.activeDataGridViewTextBoxColumn.Name = "activeDataGridViewTextBoxColumn";
            this.activeDataGridViewTextBoxColumn.ReadOnly = true;
            this.activeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.activeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ServicesAndCatalogControl
            // 
            this.Appearance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ServicesAndCatalogControl";
            this.Size = new System.Drawing.Size(847, 495);
            this.Load += new System.EventHandler(this.ServicesAndCatalogControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicecatalogBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddServicesCatalog;
        private System.Windows.Forms.ToolStripButton btnEditServiceCatalog;
        private System.Windows.Forms.ToolStripButton btnDeleteServiceCatalog;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnNewService;
        private System.Windows.Forms.ToolStripButton btnServiceEdit;
        private System.Windows.Forms.ToolStripButton btnServiceDelete;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton btnServiceRefresh;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn service_catalog_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn active;
        private System.Windows.Forms.BindingSource servicecatalogBindingSource;
        public System.Windows.Forms.DataGridView dataGridViewService;
        private System.Windows.Forms.BindingSource serviceBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn service_id;
        private System.Windows.Forms.DataGridViewImageColumn Picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicecatalogidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn isFavourite;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}
