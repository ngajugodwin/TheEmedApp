namespace eMed.View
{
    partial class Document
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDocumentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.txtSourceFile = new System.Windows.Forms.TextBox();
            this.pictureBoxUploadDocument = new System.Windows.Forms.PictureBox();
            this.pictureBoxClearDocument = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUploadDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClearDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(950, 66);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Ok";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.Location = new System.Drawing.Point(738, 12);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.Size = new System.Drawing.Size(287, 22);
            this.txtDocumentName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(672, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pdfViewer1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 413);
            this.panel2.TabIndex = 4;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(647, 413);
            this.pdfViewer1.TabIndex = 0;
            this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible;
            // 
            // txtSourceFile
            // 
            this.txtSourceFile.Location = new System.Drawing.Point(738, 39);
            this.txtSourceFile.Name = "txtSourceFile";
            this.txtSourceFile.ReadOnly = true;
            this.txtSourceFile.Size = new System.Drawing.Size(287, 22);
            this.txtSourceFile.TabIndex = 1;
            // 
            // pictureBoxUploadDocument
            // 
            this.pictureBoxUploadDocument.Image = global::eMed.Properties.Resources.dotted;
            this.pictureBoxUploadDocument.Location = new System.Drawing.Point(981, 40);
            this.pictureBoxUploadDocument.Name = "pictureBoxUploadDocument";
            this.pictureBoxUploadDocument.Size = new System.Drawing.Size(24, 20);
            this.pictureBoxUploadDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUploadDocument.TabIndex = 6;
            this.pictureBoxUploadDocument.TabStop = false;
            this.pictureBoxUploadDocument.Click += new System.EventHandler(this.pictureBoxUploadDocument_Click);
            // 
            // pictureBoxClearDocument
            // 
            this.pictureBoxClearDocument.Image = global::eMed.Properties.Resources.clearButton2;
            this.pictureBoxClearDocument.Location = new System.Drawing.Point(1005, 40);
            this.pictureBoxClearDocument.Name = "pictureBoxClearDocument";
            this.pictureBoxClearDocument.Size = new System.Drawing.Size(19, 20);
            this.pictureBoxClearDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClearDocument.TabIndex = 7;
            this.pictureBoxClearDocument.TabStop = false;
            this.pictureBoxClearDocument.Click += new System.EventHandler(this.pictureBoxClearDocument_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(672, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select File";
            // 
            // Document
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 475);
            this.Controls.Add(this.pictureBoxClearDocument);
            this.Controls.Add(this.pictureBoxUploadDocument);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSourceFile);
            this.Controls.Add(this.txtDocumentName);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Document";
            this.Text = "Document";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUploadDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClearDocument)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDocumentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private System.Windows.Forms.TextBox txtSourceFile;
        private System.Windows.Forms.PictureBox pictureBoxUploadDocument;
        private System.Windows.Forms.PictureBox pictureBoxClearDocument;
        private System.Windows.Forms.Label label2;
    }
}