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
using System.Diagnostics;

namespace eMed.View.Controls
{
    public partial class UserAccountControl : UserControl
    {

        private user user = new user();
        public static UserAccountControl fromUserAccountControl;
        public UserAccountControl()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserAccount uac = new UserAccount(ButtonEvent.Save);
            uac.ShowDialog();
        }

        public void LoadUsers()
        {
            emedEntities db = new emedEntities();
            dataGridView1.DataSource = db.users.ToList();
        }
        private void UserAccountControl_Load(object sender, EventArgs e)
        {
            fromUserAccountControl = this;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void EditUser()
        {
            user user = GetUserFromDB();
            if (user != null)
            {
                UserAccount uac = new UserAccount(user, ButtonEvent.Edit);
                uac.headerText.Text = $"Edit User : {user.lastname} {user.firstname}";
                uac.Show();

            }
        }
        private user GetUserFromDB()
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                user.user_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["user_id"].Value);
                using (emedEntities db = new emedEntities())
                {
                    user = db.users.FirstOrDefault(u => u.user_id == user.user_id);
                }

            }
            return user;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void Delete()
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                user.user_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["user_id"].Value);
                user.firstname = Convert.ToString(dataGridView1.CurrentRow.Cells["firstname"].Value);
                user.lastname = Convert.ToString(dataGridView1.CurrentRow.Cells["lastname"].Value);
                if (MessageBox.Show($"Are you sure you want to delete {user.firstname} {user.lastname} from the Record?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (emedEntities db = new emedEntities())
                    {
                        var result = db.Entry(user);
                        if (result.State == EntityState.Detached)
                            db.users.Attach(user);
                        db.users.Remove(user);
                        db.SaveChanges();
                        MessageBox.Show("Record Deleted Successfully", "Message");
                    }
                    LoadUsers();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            List<user> user = Search(search, search);

            dataGridView1.DataSource = (user == null) ? MessageBox.Show("User Not Found!") : dataGridView1.DataSource = user.ToList();

        }
        private List<user> Search(string firstname, string lastname)
        {
            using (emedEntities db = new emedEntities())
            {
                return db.users.Where(u => u.firstname.Contains(firstname) || u.lastname.Contains(lastname)).ToList();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditUser();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var userList = Result();
            if (userList.Count == 0)
                MessageBox.Show("Ooops, something went wrong. Contact IT Support", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Export ex = new Export(userList);
                ex.ShowDialog();
            }
            
        }
        List<ExportListDataDto> Result()
        {
            var userList = new List<ExportListDataDto>();
            using (emedEntities db = new emedEntities())
            {
                userList = (
                     from u in db.users
                     select new ExportListDataDto
                     {
                         Id = u.user_id,
                         EmployeeID = u.emp_id,
                         Username =u.username,
                         Firstname = u.firstname,
                         Lastname = u.lastname,
                         Email = u.email,
                         Sex = u.sex                        
                     }).ToList();

            }
            return userList;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import import = new Import();
            import.ShowDialog();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            ////var view = 
            //if(view != null)
            //{
            //    Process pdfExport = new Process();
            //    pdfExport.StartInfo.FileName = "test";
            //    pdfExport.StartInfo.Arguments = "maindata.pdf";
            //    pdfExport.Start();
            //}
            
        }
    }
}
