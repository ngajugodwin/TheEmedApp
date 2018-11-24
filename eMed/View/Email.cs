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
using System.Net.Mail;
using System.Net;
using eMed.View.Controls;
using eMed.Model;
using eMed.SchedulerSet;

namespace eMed.View
{
    public partial class Email : DevExpress.XtraEditors.XtraForm
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;
        public static Email fromEmail;
        private readonly string _patientName;
        private EmailButton sendEmail;
        private readonly string _response;
        public Email(string patientName, EmailButton sendEmail = EmailButton.SendAutoEmail)
        {
            InitializeComponent();
            _patientName = patientName;
            this.sendEmail = sendEmail;
        }
        public Email(string patientName, string response)
        {
            InitializeComponent();
            _response = response;
        }
        public Email()
        {
            InitializeComponent();
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(_response == "Yes")
            {
                //SendAutoEmail();
                MessageBox.Show("niceee");
            }
            else if(sendEmail == EmailButton.SendManualEmail)
            {
                SendManualEmail();
            }

           
        }
        private void SendManualEmail()
        {
            try
            {
                login = new NetworkCredential(MessagingControl.fromMsgControl.usernamee, MessagingControl.fromMsgControl.password);
                client = new SmtpClient(MessagingControl.fromMsgControl.serverAddress);
                client.Port = Convert.ToInt32(MessagingControl.fromMsgControl.portNumber);
                client.EnableSsl = (MessagingControl.fromMsgControl.security == 1) ? client.EnableSsl = true : client.EnableSsl = false;
                client.Credentials = login;
                msg = new MailMessage { From = new MailAddress(MessagingControl.fromMsgControl.usernamee + MessagingControl.fromMsgControl.serverAddress.Replace("smtp.", "@"), "Godwinn", Encoding.UTF8) };
                msg.To.Add(new MailAddress(txtTo.Text));
                if (!string.IsNullOrEmpty(txtCC.Text))
                    msg.To.Add(new MailAddress(txtCC.Text));
                msg.Subject = txtSubject.Text;
                msg.Body = txtMessage.Text;
                msg.BodyEncoding = Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.Normal;
                msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.SendCompleted += new SendCompletedEventHandler(SendCompleteCallBack);
                string userState = "Sending....";
                client.SendAsync(msg, userState);
                Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static void SendCompleteCallBack(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canceled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}",e.UserState, e.Error.Message), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Message sent successfully!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(MessagingControl.fromMsgControl.txtUsername.Text);
        }

        private void Email_Load(object sender, EventArgs e)
        {
            fromEmail = this;
            txtMessage.Text = _patientName;
        }
        public void SendAutoEmail(string response)
        {
           // user user = FetchPatient(_patientName);
            //MessageBox.Show(user.firstname);
            if(response == "Yes")
                btnSendEmail.PerformClick();
            
            //if (user == null)
            //    MessageBox.Show("A patient name is required to send an email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else
            //{
            //    txtTo.Text =  user.email;
            //    txtMessage.Text = "Appointment has been booked";
            //    txtSubject.Text = "New Appointment2";
            //    btnSend.PerformClick();
            //    MessageBox.Show("Auto Email has been sent");
               // btnSend.Click += BtnSend_Click;
            //MyBtn.Click += new EventHandler(FireClickEvent); 
            //}
            //btnSend.Click += new EventHandler(FireClickEvent);
           
        }
        

        private user FetchPatient(string patientFullName)
        {
            string fullName = patientFullName;
            var names = fullName.Split(' ');
            string firstName = names[0];
            //string lastName = names[1];
            using (emedEntities db = new emedEntities())
            {
                return db.users.FirstOrDefault(u=> u.firstname == firstName);
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
            //btnSend.PerformClick();
        }
    }
}