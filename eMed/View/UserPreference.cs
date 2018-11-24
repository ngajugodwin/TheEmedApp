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
using System.Data.Entity;
using eMed.View.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Skins;

namespace eMed.View
{
    public partial class UserPreference : Form
    {
        private ButtonEvent buttonEvent;
        private readonly user _loggedInUser;
        public UserPreference()
        {
            InitializeComponent();
        }
        public UserPreference(user loggedInUser, ButtonEvent buttonEvent = ButtonEvent.Edit)
        {
            InitializeComponent();
            this.buttonEvent = buttonEvent;
            _loggedInUser = loggedInUser;
            LoadUserPreferenceToControls(_loggedInUser);
           // LoadCategoryIntoControls(_editCatergoryHelper);
        }
        

        private void LoadUserPreferenceToControls(user user)
        {
            txtFirstName.Text = user.firstname;
            txtLastName.Text = user.lastname;
            txtPassword.Text = user.password;
            txtConfirmPassword.Text = user.confirm_password;
            comboBoxStyle.Text = user.skin_name;
        }

        public bool PaswordChecker(string password, string confirmPassword)
        {
            //Password checker
            password = txtPassword.Text.Trim();
            confirmPassword = txtConfirmPassword.Text.Trim();
            //var controls = new[] { password, confirmPassword };
            bool isMatch = true;
            if (string.IsNullOrWhiteSpace(password) && string.IsNullOrWhiteSpace(confirmPassword) || password != confirmPassword)
                isMatch = false;
            return isMatch;
        }
        private void UpdateUserSetting(user user)
        {
            user.firstname = txtFirstName.Text.Trim();
            user.lastname = txtLastName.Text.Trim();
            user.skin_name = comboBoxStyle.Text.Trim();
            user.password = txtPassword.Text.Trim();
            user.confirm_password = txtConfirmPassword.Text.Trim();
            var passwordValid = PaswordChecker(user.password, user.confirm_password);
            if (!passwordValid)
                MessageBox.Show("Password is not valid or does not match", "Error");
            else
            {
                using (emedEntities db = new emedEntities())
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("User Preference Saved Successfully", "Message");
                    Close();
                    UserLookAndFeel.Default.SetSkinStyle(comboBoxStyle.Text);
                }
            }
           
        }

        private void UserPreference_Load(object sender, EventArgs e)
        {
            foreach (SkinContainer cn in SkinManager.Default.Skins)
            {
                comboBoxStyle.Items.Add(cn.SkinName);
            }
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        { 
            if (buttonEvent == ButtonEvent.Edit)
                UpdateUserSetting(_loggedInUser);            
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
