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
using System.Web;
using System.Net;
using System.IO;

namespace eMed.View
{
    public partial class Sms : DevExpress.XtraEditors.XtraForm
    {
        public Sms()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            try
            {
                WebClient client = new WebClient();
                Stream s = client.OpenRead(string.Format("https://api.clickatell.com/http/sendmsg?user=ngajugodwin&password=fYceHDbCfJMMdf&api_id=3648104&to={0}&text={1}", txtPhone.Text, txtMessage.Text));
                StreamReader reader = new StreamReader(s);
                string result = reader.ReadToEnd();
                MessageBox.Show(result, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}