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
using System.IO;
using System.Data.Entity;
using eMed.View.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Skins;

namespace eMed.View
{
    public partial class UserAccount : Form
    {
        int active = 0; //to track if user is active or not
        emedEntities db;
        private readonly user _editUserHelper;
        private ButtonEvent buttonEvent;

        public UserAccount()
        {
            InitializeComponent();
            
        }

        public UserAccount(ButtonEvent buttonEvent = ButtonEvent.Save)
        {
            InitializeComponent();
            this.buttonEvent = buttonEvent;
        }

        public UserAccount(user editUserHelper, ButtonEvent buttonEvent = ButtonEvent.Edit)
        {
            InitializeComponent();
            _editUserHelper = editUserHelper;
            LoadUserToControls(_editUserHelper);
            this.buttonEvent = buttonEvent;
            //this is where to load the userdept;
        }
        private void UserAccount_Load(object sender, EventArgs e)
        {
            foreach (SkinContainer cn in SkinManager.Default.Skins)
            {
                comboBoxStyle.Items.Add(cn.SkinName);
            }
            //LoadUserDept(_editUserHelper.user_id);
            db = new emedEntities();
            LoadUserDept();
        }

        private byte[] ConvertPicture(string sPath)
        {
            byte[] img = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fs = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)numBytes);

            return img;
        }

        //Fields Validation
        private bool ValidateFields()
        {
            string salutation = comboBoxSalutaion.Text.Trim();
            string lastname = txtSurname.Text.Trim();
            string firstname = txtFirstName.Text.Trim();
            string sex = comboBoxSex.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            var controls = new[] { lastname, firstname };

            bool isValid = true;

            foreach (var control in controls.Where(e => string.IsNullOrWhiteSpace(e)))
            {
                isValid = false;
                break;
            }
            return isValid;
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
       

        private void LoadUserDept()
        {
            using (emedEntities db = new emedEntities())
            {
                var result = db.departments.ToList();
                foreach (var item in result)
                {
                    checkedListBox1.Items.Add(new CheckListBoxItem()
                    {
                        //Tag = Convert.ToInt32(item.user_detail.SingleOrDefault(u => u.user_id == id)),
                        Tag = item.department_id,
                        Text = item.department_name
                    });

                }
            }

        }

        //Save New User Implementation
        private void SaveNewUser()
        {
            user newUser = new user();
            newUser.salutation = comboBoxSalutaion.Text.Trim();
            newUser.firstname = txtFirstName.Text.Trim();
            newUser.lastname = txtSurname.Text.Trim();
            newUser.other_name = txtOtherName.Text.Trim();
            newUser.affix = comboBoxAffix.Text.Trim();
            newUser.sex = comboBoxSex.Text.Trim();
            newUser.email = txtEmail.Text.Trim();
            newUser.doctor = txtDoctor.Text.Trim();
            newUser.username = txtUsername.Text.Trim();
            newUser.acronym = txtAcronym.Text.Trim();
            newUser.password = txtPassword.Text.Trim();
            newUser.confirm_password = txtConfirmPassword.Text.Trim();
            newUser.image = (userPictureBox.ImageLocation != null) ? ConvertPicture(userPictureBox.ImageLocation) : newUser.image;
            newUser.isActive = (checkBoxActive.Checked) ? active + 1 : active;
            foreach (var item in checkedListBox1.CheckedItems)
            {
                CheckListBoxItem citem = (CheckListBoxItem)item;
                user_detail user_Detail = new user_detail();

                user_Detail.department_id = citem.Tag;
                newUser.user_detail.Add(user_Detail);
            }
            bool validationResult = ValidateFields();
            bool chkPassword = PaswordChecker(newUser.password, newUser.confirm_password);
            if (!validationResult)
                MessageBox.Show("Enter Required Fields!", "Error");
            else if (!chkPassword)
                MessageBox.Show("Password is not valid or does not match", "Error");
            else
            {
                
                using (emedEntities db = new emedEntities())
                {
                    db.users.Add(newUser);
                    db.SaveChanges();
                    MessageBox.Show("New User Added Successfully!", "Message");
                    Close();
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (buttonEvent == ButtonEvent.Save)
                SaveNewUser();
            else if (buttonEvent == ButtonEvent.Edit)
                UpdateUser();
            RefreshData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        //Load Data :TODO
        private void RefreshData()
        {

            emedEntities db = new emedEntities();
            List<user> users = db.users.ToList();
            UserAccountControl.fromUserAccountControl.dataGridView1.DataSource = users;
            
        }
        
        //Update user account        
        private void UpdateUser()
        {
          
            _editUserHelper.skin_name = comboBoxStyle.Text.Trim();
            _editUserHelper.salutation = comboBoxSalutaion.Text.Trim();
            _editUserHelper.firstname = txtFirstName.Text.Trim();
            _editUserHelper.lastname = txtSurname.Text.Trim();
            _editUserHelper.other_name = txtOtherName.Text.Trim();
            _editUserHelper.affix = comboBoxAffix.Text;
            _editUserHelper.sex = comboBoxSex.Text;
            _editUserHelper.email = txtEmail.Text.Trim();
            _editUserHelper.doctor = txtDoctor.Text.Trim();
            _editUserHelper.username = txtUsername.Text.Trim();
            _editUserHelper.acronym = txtAcronym.Text.Trim();
            _editUserHelper.password = txtPassword.Text.Trim();
            _editUserHelper.confirm_password = txtConfirmPassword.Text.Trim();
            _editUserHelper.image = (userPictureBox.ImageLocation != null) ? ConvertPicture(userPictureBox.ImageLocation) : _editUserHelper.image = null;
            _editUserHelper.isActive = (checkBoxActive.Checked) ? active + 1 : active;
            bool validationResult = ValidateFields();
            bool chkPassword = PaswordChecker(_editUserHelper.password, _editUserHelper.confirm_password);
            if (!validationResult)
                MessageBox.Show("Enter Required Fields!", "Error");
            else if (!chkPassword)
                MessageBox.Show("Password is not valid or does not match", "Error");
            else
            {
                using (emedEntities db = new emedEntities())
                {
                    db.Entry(_editUserHelper).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("User Updated Successfully!", "Message");
                    Close();
                }
                RefreshData();
            }
        }

        //Load user info to controls
        private void LoadUserToControls(user editUser)
        {
            comboBoxStyle.Text = editUser.skin_name;
            comboBoxSalutaion.Text = editUser.salutation;
            txtFirstName.Text = editUser.firstname;
            txtSurname.Text = editUser.lastname;
            txtOtherName.Text = editUser.other_name;
            comboBoxAffix.Text = editUser.affix;
            comboBoxSex.Text = editUser.sex;
            txtEmail.Text = editUser.email;
            txtDoctor.Text = editUser.doctor;
            txtUsername.Text = editUser.username;
            txtAcronym.Text = editUser.acronym;
            txtPassword.Text = editUser.password;
            txtConfirmPassword.Text = editUser.confirm_password;
            editUser.isActive = Convert.ToInt32(editUser.isActive == 1 ? checkBoxActive.CheckState = CheckState.Checked : checkBoxActive.CheckState = CheckState.Unchecked);
            //userPictureBox.Image = (editUser.image != null) ? ConvertByteToImage(editUser.image) : userPictureBox.Image;
            if (editUser.image != null)
                userPictureBox.Image = ConvertByteToImage(editUser.image);
        }

        //Convert Byte to ImagePhoto
        private Image ConvertByteToImage(byte[] photo)
        {
            Image image;
            using (MemoryStream ms = new MemoryStream(photo, 0, photo.Length))
            {
                ms.Write(photo, 0, photo.Length);
                image = Image.FromStream(ms, true);

            }
            return image;
        }

        //Get Picture from user computer
        private void GetPicture()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPEG FIles (*.jpg)|*.jpg | PNG Files (*.png)|*.png | All Files (*.*)|*.*";
            ofd.Title = "Add Picture";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                userPictureBox.ImageLocation = ofd.FileName;
            }
        }

        
        private void btnSelect_Click(object sender, EventArgs e)
        {
            GetPicture();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            userPictureBox.Image = null;
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            ChangeText();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            ChangeText();
        }
        public void ChangeText()
        {
            if (buttonEvent == ButtonEvent.Save)
                headerText.Text = "Add New User : " + txtSurname.Text.Trim() + " " + txtFirstName.Text.Trim();
            else
                headerText.Text = "Edit User : " + txtSurname.Text.Trim() + " " + txtFirstName.Text.Trim();
        }

        
        private List<department> Department()
        {            
            using (emedEntities db = new emedEntities())
            {
                return db.departments.ToList();
                
            }
        }
        private List<DepartmentDto> GetDeptByUserId(int userId)
        {
            var userDepartment = new List<DepartmentDto>();
            using (emedEntities db = new emedEntities())
            {
                userDepartment = (
                    from ud in db.user_detail
                    join u in db.users on ud.user_id equals u.user_id
                    join d in db.departments on ud.department_id equals d.department_id
                    where ud.user_id == userId
                    select new DepartmentDto
                    {
                        user_id = u.user_id,
                        department_id = d.department_id

                    }).ToList();
               
            }
            return userDepartment;
        }

        private void LoadUserDept(int id)
        {
            // var result = Department();
            using (emedEntities db = new emedEntities())
            {
                var result = db.departments.ToList();
                foreach (var item in result)
                {
                    checkedListBox1.Items.Add(new CheckListBoxItem()
                    {
                        //Tag = Convert.ToInt32(item.user_detail.SingleOrDefault(u => u.user_id == id)),
                        // Tag = item.user_detail.SingleOrDefault(u => u.user_id == id),
                        Tag= item.department_id,
                        Text = item.department_name
                    });
                    MessageBox.Show(item.department_name);

                }
            }
            
        }
       

    }
}
