namespace eMed.View.Controls
{
    partial class CategoryControl
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewCategory = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.category_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acronym = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtSearch,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(847, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Calibri", 10F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(240, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::eMed.Properties.Resources.refresh2;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(66, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewCategory);
            this.panel1.Location = new System.Drawing.Point(10, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 376);
            this.panel1.TabIndex = 1;
            // 
            // dataGridViewCategory
            // 
            this.dataGridViewCategory.AllowUserToAddRows = false;
            this.dataGridViewCategory.AllowUserToDeleteRows = false;
            this.dataGridViewCategory.AllowUserToResizeColumns = false;
            this.dataGridViewCategory.AllowUserToResizeRows = false;
            this.dataGridViewCategory.AutoGenerateColumns = false;
            this.dataGridViewCategory.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.category_id,
            this.acronym,
            this.name,
            this.active,
            this.description});
            this.dataGridViewCategory.DataSource = this.categoryBindingSource;
            this.dataGridViewCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCategory.EnableHeadersVisualStyles = false;
            this.dataGridViewCategory.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCategory.MultiSelect = false;
            this.dataGridViewCategory.Name = "dataGridViewCategory";
            this.dataGridViewCategory.ReadOnly = true;
            this.dataGridViewCategory.RowHeadersVisible = false;
            this.dataGridViewCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCategory.Size = new System.Drawing.Size(719, 376);
            this.dataGridViewCategory.TabIndex = 0;
            this.dataGridViewCategory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCategory_CellDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(735, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(735, 64);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(735, 388);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // category_id
            // 
            this.category_id.DataPropertyName = "category_id";
            this.category_id.HeaderText = "category_id";
            this.category_id.Name = "category_id";
            this.category_id.ReadOnly = true;
            this.category_id.Visible = false;
            // 
            // acronym
            // 
            this.acronym.DataPropertyName = "acronym";
            this.acronym.HeaderText = "Acronym";
            this.acronym.Name = "acronym";
            this.acronym.ReadOnly = true;
            this.acronym.Width = 130;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 170;
            // 
            // active
            // 
            this.active.DataPropertyName = "active";
            this.active.HeaderText = "Active";
            this.active.Name = "active";
            this.active.ReadOnly = true;
            this.active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.active.Width = 140;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 280;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(eMed.Model.category);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(eMed.Model.user);
            // 
            // CategoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CategoryControl";
            this.Size = new System.Drawing.Size(847, 460);
            this.Load += new System.EventHandler(this.CategoryControl_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dataGridViewCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn acronym;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn active;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
    }
}
