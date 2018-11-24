using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eMed.Model;
using System.Data.Entity;

namespace eMed.View.Controls
{
    public partial class MessagingControl : UserControl
    {
        public static MessagingControl fromMsgControl;
        public string usernamee;
        public string password;
        public int portNumber;
        public string serverAddress;
        public int security;
        public MessagingControl()
        {
            InitializeComponent();
            fromMsgControl = this;
            InitControls();
        }

        private List<messaging> GetMessagingEmailConfig()
        {
            using (emedEntities db = new emedEntities())
            {
                return db.messagings.ToList();
            }

        }
        
        public void InitControls()
        {
            var configuration = GetMessagingEmailConfig();
            dataGridViewEmailConfig.DataSource = configuration;
            foreach (var config in configuration)
            {
                usernamee = config.username;
                password = config.password;
                portNumber = Convert.ToInt32(config.port_nr);
                serverAddress = config.server_address;
                security = Convert.ToInt32(config.sslEnabled);
            }           
        }
        public void RefreshData()
        {
            emedEntities db = new emedEntities();
            List<messaging> msg = db.messagings.ToList();
            dataGridViewEmailConfig.DataSource = msg;
        }
        
        
        public void CheckButtonState()
        {
            var configuration = GetMessagingEmailConfig();
            if (configuration.Count > 0)
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;
        }
        private void MessagingControl_Load(object sender, EventArgs e)
        {
            CheckButtonState();            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmailConfig ec = new EmailConfig(ButtonEvent.Save);
            ec.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditEmailConfig();
        }
        private void EditEmailConfig()
        {
            var msg = GetEmailConfig(new messaging());
            if (msg != null)
            {
                EmailConfig ec = new EmailConfig(msg, ButtonEvent.Edit);
                ec.ShowDialog();
            }
        }
        private messaging GetEmailConfig(messaging msg)
        {
            if (dataGridViewEmailConfig.CurrentRow.Index != -1)
            {
                msg.messaging_id = Convert.ToInt32(dataGridViewEmailConfig.CurrentRow.Cells["messaging_id"].Value);
                using (emedEntities db = new emedEntities())
                {
                    msg = db.messagings.FirstOrDefault(m => m.messaging_id == msg.messaging_id);
                }

            }
            return msg;
        }
        private void Delete(messaging msg)
        {
            if (dataGridViewEmailConfig.CurrentRow.Index != -1)
            {
                msg.messaging_id = Convert.ToInt32(dataGridViewEmailConfig.CurrentRow.Cells["messaging_id"].Value);
                if (MessageBox.Show($"Are you sure you want to delete this record?", "Delete Email Config", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (emedEntities db = new emedEntities())
                    {
                        var result = db.Entry(msg);
                        if (result.State == EntityState.Detached)
                            db.messagings.Attach(msg);
                        db.messagings.Remove(msg);
                        db.SaveChanges();
                        MessageBox.Show("Record Deleted Successfully", "Message");
                    }
                    RefreshData();
                    CheckButtonState();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete(new messaging());
        }
    }
}
