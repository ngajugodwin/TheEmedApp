using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using eMed.Model;
using eMed.View.Controls;
using System.Data.Entity;

namespace eMed.View
{
    public partial class EmailConfig : DevExpress.XtraEditors.XtraForm
    {
        int isEnabled = 0;
        private readonly messaging _editEmailConfigHelper;
        private ButtonEvent buttonEvent;
        public EmailConfig(ButtonEvent buttonEvent)
        {
            InitializeComponent();
            this.buttonEvent = buttonEvent;
        }
        public EmailConfig(messaging editEmailConfigHelper, ButtonEvent buttonEvent)
        {
            InitializeComponent();
            _editEmailConfigHelper = editEmailConfigHelper;
            this.buttonEvent = ButtonEvent.Edit;
            InitControls(_editEmailConfigHelper);
        }
        private void RefreshData()
        {
            MessagingControl.fromMsgControl.RefreshData();
            MessagingControl.fromMsgControl.CheckButtonState();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (buttonEvent == ButtonEvent.Save)
                SaveEmailConfig();
            else if(buttonEvent == ButtonEvent.Edit)
                EditEmailConfig(_editEmailConfigHelper);
            Close();
        }
        private void SaveEmailConfig()
        {
            try
            {
                using (emedEntities db = new emedEntities())
                {
                    messaging msg = new messaging();
                    msg.username = txtUsername.Text.Trim();
                    msg.password = txtPassword.Text.Trim();
                    msg.port_nr = Convert.ToInt32(txtPortNumber.Text.Trim());
                    msg.sslEnabled = (checkBoxSSL.Checked) ? isEnabled + 1 : isEnabled;
                    msg.server_address = txtServerAddress.Text.Trim();
                    db.messagings.Add(msg);
                    db.SaveChanges();
                    MessageBox.Show("Email Connection String Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitControls(messaging editConfig)
        {
            txtUsername.Text = editConfig.username;
            txtPassword.Text = editConfig.password;
            txtPortNumber.Text = editConfig.port_nr.ToString();
            txtServerAddress.Text = editConfig.server_address;
            editConfig.sslEnabled = Convert.ToInt32(editConfig.sslEnabled == 1 ? checkBoxSSL.CheckState = CheckState.Checked : checkBoxSSL.CheckState = CheckState.Unchecked);
        }
        private void EditEmailConfig(messaging editConfig)
        {
            try
            {
                editConfig.username = txtUsername.Text.Trim();
                editConfig.password = txtPassword.Text.Trim();
                editConfig.port_nr = Convert.ToInt32(txtPortNumber.Text.Trim());
                editConfig.server_address = txtServerAddress.Text.Trim();
                editConfig.sslEnabled = (checkBoxSSL.Checked) ? isEnabled + 1 : isEnabled;

                using (emedEntities db = new emedEntities())
                {
                    db.Entry(editConfig).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Email Config Updated Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                MessagingControl.fromMsgControl.InitControls();
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}