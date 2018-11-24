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
using System.Data.Entity;

namespace eMed.View
{
    public partial class TakeAttendance : DevExpress.XtraEditors.XtraForm
    {
       // private bool isLoaded = false;
        private emedEntities dbHelper;
        public TakeAttendance()
        {
            InitializeComponent();
        }

        private void TakeAttendance_Load(object sender, EventArgs e)
        {
            //   isLoaded = true;
            
            dbHelper = new emedEntities();
           
            LoadUsers();
            //LoadUserTimeRecording(1);
        }
        private void LoadUsers()
        {
            using (emedEntities db = new emedEntities())
            {
                var users = db.users.ToList();
                foreach (var user in users)
                {
                    //comboBox1.Items.Add(user.firstname);
                    toolStripComboSelectUser.Items.Add(user.firstname);
                    //toolStripComboSelectUser.Items.Add(user.firstname + " " + user.lastname);
                }
            }
        }
        private user GetUserTimeRecording(string firstname)
        {
            return dbHelper.users.FirstOrDefault(u => u.firstname == firstname);
        }

        private void toolStripComboSelectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadUserTimeRecording(StartPage._loggedInUser);
            LoadUserAttendance(StartPage._loggedInUser);
        }

        private List<UserAttendanceDTo> GetUserAttendance(user selectedUser, DateTime today)
        {     
            var userAttendance = new List<UserAttendanceDTo>();
            //var today = DateTime.Now.Date;
            using (emedEntities db = new emedEntities())
            {
                userAttendance = (
                    from t in db.time_recording
                        //join td in db.time_recording_details on t.tc_id equals td.tc_id
                    where t.user_id == selectedUser.user_id && t.created_at > today
                    select new UserAttendanceDTo
                    {
                        Id = t.tc_id,
                        DateFrom = t.date_from,
                        DateTo = t.date_to,
                        //Duration = t.time_recording_details.Where(td => td.duration2 == t.date_to),
                    }).ToList();
            }
            return userAttendance;
        }
        void LoadUserAttendance(user selectedUser)
        {
            //var datePicker = new ToolStripControlHost(new DateTimePicker());
            
            var entry = GetUserAttendance(selectedUser, Convert.ToDateTime(dateTimePicker1.Text));
            if (entry.Count == 0)
            {
                //user has not clock in
                btnClockIn.Enabled = true;
                dataGridView1.DataSource = null;
                return;
            }
            else
            {               
                foreach (var item in entry)
                {
                    //if user has clockout, disable the button
                    if (item.DateTo != null)
                    {
                        btnClockOut.Enabled = false;
                    }
                    else
                    {
                        //....... else, user has not clockout
                        btnClockOut.Enabled = true;
                    }

                }
                btnClockIn.Enabled = false;
                dataGridView1.DataSource = entry.ToList();

            }
        }
        /*private void LoadUserTimeRecording(user selectedUser)
        {
            var yesterday = DateTime.Now.Date;
            selectedUser = GetUserTimeRecording(toolStripComboSelectUser.Text);
            var entry = dbHelper.time_recording.Where(t => t.user_id == selectedUser.user_id && t.created_at > yesterday).ToList();
            if(entry.Count == 0)
            {
                btnClockIn.Enabled = true;
                dataGridView1.DataSource = null;
                return;
            }
            else
            {
                btnClockIn.Enabled = false;
                dataGridView1.DataSource = entry.ToList();
            }
        }*/

        private void btnClockIn_Click(object sender, EventArgs e)
        {

            if (toolStripComboSelectUser.Text == string.Empty)
                MessageBox.Show("Please select a user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Convert.ToDateTime(dateTimePicker1.Text) > DateTime.Now)
                MessageBox.Show("This is a future date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                var selectedUser = GetUserTimeRecording(toolStripComboSelectUser.Text);
                using (emedEntities db = new emedEntities())
                {
                    time_recording tr = new time_recording();
                    tr.creator_id = StartPage._loggedInUser.user_id;
                    tr.user_id = selectedUser.user_id;
                    tr.state = 1;
                    tr.created_at = DateTime.Now;
                    tr.date_from = Convert.ToDateTime(dateTimePicker1.Text);
                    tr.trt_id = 1;
                    db.time_recording.Add(tr);
                    db.SaveChanges();
                    btnClockIn.Enabled = false;
                    MessageBox.Show("You have clocked in", "Message");
                    //LoadUserTimeRecording(selectedUser);
                    LoadUserAttendance(selectedUser);
                }
            }
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            //var result = GetUserTimeRecord(new time_recording());
            //if (result == null)
            //    MessageBox.Show("Oops, something went wrong. Contact IT Support", "Error");
            //else
            //{
            //    using (emedEntities db = new emedEntities())
            //    {
            //        var data = db.time_recording.Find(result.tc_id);
            //        data.date_to = DateTime.Now;

            //        db.SaveChanges();
            //        MessageBox.Show("You have successfully clocked out!", "Message");
            //        btnClockOut.Enabled = false;
            //        LoadUserTimeRecording(data.user1);
            //    }
            //}
            Clockout();
        }
        void Clockout()
        {
            var result = GetUserTimeRecord(new time_recording());
            if (result == null)
                MessageBox.Show("No user selected or user not clocked in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                using (emedEntities db = new emedEntities())
                {
                    var data = db.time_recording.Find(result.tc_id);
                    data.date_to = DateTime.Now;
                    TimeSpan hours = (data.date_to - data.date_from).Value;

                    time_recording_details trd = new time_recording_details();
                    trd.tc_id = data.tc_id;
                    trd.user_id = data.user1.user_id;
                    trd.created_at = DateTime.Now;
                    trd.duration2 = (long)hours.TotalMinutes;
                    data.time_recording_details.Add(trd);
                                        
                    db.SaveChanges();
                    MessageBox.Show("You have successfully clocked out!", "Message");
                    LoadUserAttendance(data.user1);
                }
            }
        }
        
        private time_recording GetUserTimeRecord(time_recording tc)
        {
            if (toolStripComboSelectUser.Text == string.Empty)
                return null;
            else if (dataGridView1.DataSource == null)
                return null;
            else
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    tc.tc_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    tc = dbHelper.time_recording.FirstOrDefault(t => t.tc_id == tc.tc_id);
                }
                return tc;
            }
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (toolStripComboSelectUser.Text == "") {  }                
            else {
                var user = GetUserTimeRecording(toolStripComboSelectUser.Text);

                LoadUserAttendance(user);
                MessageBox.Show("value changed");
            }
            //TODO: Test for when user select a previous date
        }
    }
}