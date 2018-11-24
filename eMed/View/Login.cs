using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eMed.Model;

namespace eMed.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private user Authenticate(string username, string password)
        {
            using (emedEntities db = new emedEntities())
            {
                return db.users.FirstOrDefault(u => u.username == username && u.password == password);
            }
        }
        public void LoginUser()
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                user user = Authenticate(username, password);
                if (user == null)
                    MessageBox.Show("Invalid Credentials", "Error");
                else if(user.isActive == 0)
                {
                    MessageBox.Show("Your profile is inactive. Please, contact IT Support", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    StartPage sp = new StartPage(user);
                    sp.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginUser();
        }
    }
}
