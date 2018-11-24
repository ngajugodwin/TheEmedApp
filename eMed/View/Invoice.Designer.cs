namespace eMed.View
{
    partial class Invoice
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.serviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.servicecatalogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creatorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientCartDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.buttonInvoice = new System.Windows.Forms.Button();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAmountGross = new System.Windows.Forms.Label();
            this.lblAmountNet = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTotal = new System.Windows.Forms.Button();
            this.btnCreateBill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicecatalogBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientCartDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // serviceBindingSource
            // 
            this.serviceBindingSource.DataSource = typeof(eMed.Model.service);
            // 
            // servicecatalogBindingSource
            // 
            this.servicecatalogBindingSource.DataSource = typeof(eMed.Model.service_catalog);
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(5, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(265, 374);
            this.controlContainer1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(111, 99);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(80, 14);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripLabel2,
            this.toolStripComboBox2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(858, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel1.Text = "From";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(19, 22);
            this.toolStripLabel2.Text = "To";
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::eMed.Properties.Resources.refresh2;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 22);
            this.toolStripButton1.Text = "Refresh";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewCart);
            this.panel1.Location = new System.Drawing.Point(7, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 170);
            this.panel1.TabIndex = 1;
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.AutoGenerateColumns = false;
            this.dataGridViewCart.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.Id,
            this.serviceDescriptionDataGridViewTextBoxColumn,
            this.serviceTypeDataGridViewTextBoxColumn,
            this.creatorNameDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.quantityDataGridViewTextBoxColumn});
            this.dataGridViewCart.DataSource = this.patientCartDtoBindingSource;
            this.dataGridViewCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCart.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.Size = new System.Drawing.Size(733, 170);
            this.dataGridViewCart.TabIndex = 0;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // serviceDescriptionDataGridViewTextBoxColumn
            // 
            this.serviceDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ServiceDescription";
            this.serviceDescriptionDataGridViewTextBoxColumn.HeaderText = "Service Description";
            this.serviceDescriptionDataGridViewTextBoxColumn.Name = "serviceDescriptionDataGridViewTextBoxColumn";
            this.serviceDescriptionDataGridViewTextBoxColumn.Width = 160;
            // 
            // serviceTypeDataGridViewTextBoxColumn
            // 
            this.serviceTypeDataGridViewTextBoxColumn.DataPropertyName = "ServiceType";
            this.serviceTypeDataGridViewTextBoxColumn.HeaderText = "Service Type";
            this.serviceTypeDataGridViewTextBoxColumn.Name = "serviceTypeDataGridViewTextBoxColumn";
            // 
            // creatorNameDataGridViewTextBoxColumn
            // 
            this.creatorNameDataGridViewTextBoxColumn.DataPropertyName = "CreatorName";
            this.creatorNameDataGridViewTextBoxColumn.HeaderText = "Entered By";
            this.creatorNameDataGridViewTextBoxColumn.Name = "creatorNameDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn1.HeaderText = "Price";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // patientCartDtoBindingSource
            // 
            this.patientCartDtoBindingSource.DataSource = typeof(eMed.Model.PatientCartDto);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(758, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(758, 61);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 27);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(758, 171);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 27);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // buttonInvoice
            // 
            this.buttonInvoice.Location = new System.Drawing.Point(531, 215);
            this.buttonInvoice.Name = "buttonInvoice";
            this.buttonInvoice.Size = new System.Drawing.Size(182, 23);
            this.buttonInvoice.TabIndex = 3;
            this.buttonInvoice.Text = "Create Invoice";
            this.buttonInvoice.UseVisualStyleBackColor = true;
            this.buttonInvoice.Click += new System.EventHandler(this.buttonInvoice_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.lblAmountGross);
            this.panelControl1.Controls.Add(this.lblAmountNet);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Location = new System.Drawing.Point(7, 287);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(733, 133);
            this.panelControl1.TabIndex = 5;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(569, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "--------------------------------------";
            // 
            // lblAmountGross
            // 
            this.lblAmountGross.AutoSize = true;
            this.lblAmountGross.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblAmountGross.Location = new System.Drawing.Point(619, 73);
            this.lblAmountGross.Name = "lblAmountGross";
            this.lblAmountGross.Size = new System.Drawing.Size(87, 17);
            this.lblAmountGross.TabIndex = 0;
            this.lblAmountGross.Text = "Gross Amount";
            // 
            // lblAmountNet
            // 
            this.lblAmountNet.AutoSize = true;
            this.lblAmountNet.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblAmountNet.Location = new System.Drawing.Point(619, 24);
            this.lblAmountNet.Name = "lblAmountNet";
            this.lblAmountNet.Size = new System.Drawing.Size(77, 17);
            this.lblAmountNet.TabIndex = 0;
            this.lblAmountNet.Text = "Amount Net";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F);
            this.label3.Location = new System.Drawing.Point(425, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gross Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F);
            this.label1.Location = new System.Drawing.Point(425, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount Net";
            // 
            // btnTotal
            // 
            this.btnTotal.Location = new System.Drawing.Point(531, 244);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(75, 23);
            this.btnTotal.TabIndex = 6;
            this.btnTotal.Text = "Total";
            this.btnTotal.UseVisualStyleBackColor = true;
            this.btnTotal.Click += new System.EventHandler(this.btnTotal_Click);
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.Location = new System.Drawing.Point(638, 244);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(75, 23);
            this.btnCreateBill.TabIndex = 7;
            this.btnCreateBill.Text = "Add Bill";
            this.btnCreateBill.UseVisualStyleBackColor = true;
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // Invoice
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 545);
            this.Controls.Add(this.btnCreateBill);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.buttonInvoice);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Invoice";
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.Invoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicecatalogBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientCartDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.BindingSource servicecatalogBindingSource;
        private System.Windows.Forms.BindingSource serviceBindingSource;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn categoryidDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonInvoice;
        private System.Windows.Forms.BindingSource patientCartDtoBindingSource;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAmountGross;
        private System.Windows.Forms.Label lblAmountNet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTotal;
        //private System.Windows.Forms.Button btnCreateBill;
        private System.Windows.Forms.Button btnCreateBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creatorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
    }
}