namespace eMed.View
{
    partial class TakePhoto
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
            this.pictureBoxCapture = new System.Windows.Forms.PictureBox();
            this.comboCameraDevice = new System.Windows.Forms.ComboBox();
            this.comboResolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCapture
            // 
            this.pictureBoxCapture.Location = new System.Drawing.Point(41, 115);
            this.pictureBoxCapture.Name = "pictureBoxCapture";
            this.pictureBoxCapture.Size = new System.Drawing.Size(190, 134);
            this.pictureBoxCapture.TabIndex = 0;
            this.pictureBoxCapture.TabStop = false;
            // 
            // comboCameraDevice
            // 
            this.comboCameraDevice.FormattingEnabled = true;
            this.comboCameraDevice.Location = new System.Drawing.Point(115, 23);
            this.comboCameraDevice.Name = "comboCameraDevice";
            this.comboCameraDevice.Size = new System.Drawing.Size(173, 21);
            this.comboCameraDevice.TabIndex = 1;
            this.comboCameraDevice.SelectedIndexChanged += new System.EventHandler(this.comboCameraDevice_SelectedIndexChanged);
            // 
            // comboResolution
            // 
            this.comboResolution.FormattingEnabled = true;
            this.comboResolution.Location = new System.Drawing.Point(115, 62);
            this.comboResolution.Name = "comboResolution";
            this.comboResolution.Size = new System.Drawing.Size(173, 21);
            this.comboResolution.TabIndex = 1;
            this.comboResolution.SelectedIndexChanged += new System.EventHandler(this.comboResolution_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Camera Devices";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resolution";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(259, 171);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TakePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 284);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboResolution);
            this.Controls.Add(this.comboCameraDevice);
            this.Controls.Add(this.pictureBoxCapture);
            this.Name = "TakePhoto";
            this.Text = "TakePhoto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TakePhoto_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCapture;
        private System.Windows.Forms.ComboBox comboCameraDevice;
        private System.Windows.Forms.ComboBox comboResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
    }
}