namespace eMed.View.Controls
{
    partial class MessagingControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewEmailConfig = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.messagingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.messaging_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portnrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serveraddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sslEnabledDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmailConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messagingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewEmailConfig);
            this.panel1.Location = new System.Drawing.Point(3, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 203);
            this.panel1.TabIndex = 2;
            // 
            // dataGridViewEmailConfig
            // 
            this.dataGridViewEmailConfig.AllowUserToAddRows = false;
            this.dataGridViewEmailConfig.AllowUserToDeleteRows = false;
            this.dataGridViewEmailConfig.AllowUserToResizeColumns = false;
            this.dataGridViewEmailConfig.AllowUserToResizeRows = false;
            this.dataGridViewEmailConfig.AutoGenerateColumns = false;
            this.dataGridViewEmailConfig.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewEmailConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmailConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.messaging_id,
            this.username,
            this.passwordDataGridViewTextBoxColumn,
            this.portnrDataGridViewTextBoxColumn,
            this.serveraddressDataGridViewTextBoxColumn,
            this.sslEnabledDataGridViewTextBoxColumn});
            this.dataGridViewEmailConfig.DataSource = this.messagingBindingSource;
            this.dataGridViewEmailConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEmailConfig.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEmailConfig.Name = "dataGridViewEmailConfig";
            this.dataGridViewEmailConfig.ReadOnly = true;
            this.dataGridViewEmailConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmailConfig.Size = new System.Drawing.Size(726, 203);
            this.dataGridViewEmailConfig.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(735, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(735, 42);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(735, 193);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // messagingBindingSource
            // 
            this.messagingBindingSource.DataSource = typeof(eMed.Model.messaging);
            // 
            // messaging_id
            // 
            this.messaging_id.DataPropertyName = "messaging_id";
            this.messaging_id.HeaderText = "messaging_id";
            this.messaging_id.Name = "messaging_id";
            this.messaging_id.ReadOnly = true;
            this.messaging_id.Visible = false;
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Width = 180;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            this.passwordDataGridViewTextBoxColumn.Visible = false;
            // 
            // portnrDataGridViewTextBoxColumn
            // 
            this.portnrDataGridViewTextBoxColumn.DataPropertyName = "port_nr";
            this.portnrDataGridViewTextBoxColumn.HeaderText = "Port Number";
            this.portnrDataGridViewTextBoxColumn.Name = "portnrDataGridViewTextBoxColumn";
            this.portnrDataGridViewTextBoxColumn.ReadOnly = true;
            this.portnrDataGridViewTextBoxColumn.Width = 150;
            // 
            // serveraddressDataGridViewTextBoxColumn
            // 
            this.serveraddressDataGridViewTextBoxColumn.DataPropertyName = "server_address";
            this.serveraddressDataGridViewTextBoxColumn.HeaderText = "Server Address";
            this.serveraddressDataGridViewTextBoxColumn.Name = "serveraddressDataGridViewTextBoxColumn";
            this.serveraddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.serveraddressDataGridViewTextBoxColumn.Width = 180;
            // 
            // sslEnabledDataGridViewTextBoxColumn
            // 
            this.sslEnabledDataGridViewTextBoxColumn.DataPropertyName = "sslEnabled";
            this.sslEnabledDataGridViewTextBoxColumn.HeaderText = "Enable SSL";
            this.sslEnabledDataGridViewTextBoxColumn.Name = "sslEnabledDataGridViewTextBoxColumn";
            this.sslEnabledDataGridViewTextBoxColumn.ReadOnly = true;
            this.sslEnabledDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sslEnabledDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sslEnabledDataGridViewTextBoxColumn.Width = 180;
            // 
            // MessagingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MessagingControl";
            this.Size = new System.Drawing.Size(847, 495);
            this.Load += new System.EventHandler(this.MessagingControl_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmailConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messagingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dataGridViewEmailConfig;
        private System.Windows.Forms.BindingSource messagingBindingSource;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn messaging_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portnrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serveraddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sslEnabledDataGridViewTextBoxColumn;
    }
}
