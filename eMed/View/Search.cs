using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eMed.Properties;
using eMed.Model;
using eMed.SchedulerSet;

namespace eMed.View
{
    public partial class Search : DevExpress.XtraEditors.XtraForm
    {
        private readonly List<patient> _currentPatient;
        private ButtonEventSearch buttonEvent;
        private ButtonEventSearch buttonEventAppt;

        //public Search(ButtonEvent buttonEvent = ButtonEvent.ApptSearch)
        //{
        //    InitializeComponent();
        //    this.buttonEvent = buttonEvent;
        //}

        public Search(List<patient> currentPatient, string searchData, ButtonEventSearch buttonEvent = ButtonEventSearch.SearchPatient)
        {
            //Constructor: 

            InitializeComponent();
            this.buttonEvent = buttonEvent;
            _currentPatient = currentPatient;
            LoadSearchData(_currentPatient, searchData);
        }

        //Default constructor
        public Search(ButtonEventSearch buttonEventAppt = ButtonEventSearch.ApptSearch)
        {
            InitializeComponent();
            this.buttonEventAppt = buttonEventAppt;
        }

        private void SearchResultCount() { lblSearchResult.Text = "Search Result: " + Convert.ToString(dataGridView1.RowCount); }

        
        private void LoadSearchData(List<patient> patient, string search)
        {
            //Render the search data

            txtSearch.Text = search;
            dataGridView1.DataSource = patient.ToList();
            SearchResultCount();
            
        }


        //Validate data from DB to check null or if record exist and return result
        public List<patient> PatientSearch(string search, ButtonEventSearch buttonEvent = ButtonEventSearch.SearchPatient)
        {
            this.buttonEvent = buttonEvent;
            var patient = GetPatientFromDB(search, search);
            if (string.IsNullOrWhiteSpace(search) || patient.Count == 0)
            {
                MessageBox.Show("Patient record does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.DataSource = null;
                SearchResultCount();
                return null;
            }
            else
                LoadSearchData(patient, search);
            return patient;

        }


        //Get Patient from the database using firstname and lastname
        private static List<patient> GetPatientFromDB(string firstname, string lastname)
        {
            var patient = (dynamic)null;
            try
            {
                using (var dbHelper = new emedEntities())
                {
                    patient = dbHelper.patients.Where(p => p.firstname.Contains(firstname) || p.lastname.Contains(lastname)).ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return patient;
        }

        //Refresh search data
        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            PatientSearch(search);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddToRecentSearchPatient()
        {
            patient patient = GetSelectedPatient(new patient());
            using (emedEntities db = new emedEntities())
            {
                temp_search temp = new temp_search();
                temp.patient_id = patient.patient_id;
                temp.user_id = StartPage._loggedInUser.user_id;
                temp.created_at = DateTime.Now;
                db.temp_search.Add(temp);
                db.SaveChanges();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (buttonEventAppt == ButtonEventSearch.ApptSearch)
               AssignPatientToAppointment();

            else if (buttonEvent == ButtonEventSearch.SearchPatient)
            {
                LoadSelectedPatient();
                StartPage.fromStartPage.patientDashControl.Visible = true;
                StartPage.fromStartPage.ribbonControl1.SelectedPage = StartPage.fromStartPage.patientDashControl;
                AddToRecentSearchPatient();
            }
            //AddToRecentSearchPatient();
        }
        private void AssignPatientToAppointment()
        {
            
            var patient = GetSelectedPatient(new patient());
            if (patient == null)
                MessageBox.Show("Error trying to assign patient. Please, contact IT Support", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Close();
                OutlookAppointmentForm.fromOutlookApptForm.txtPatient.Text = patient.firstname +" "+ patient.lastname;
            }
        }
        private void LoadSelectedPatient()
        {

            patient patient = GetSelectedPatient(new patient());
            if (patient == null)
            {
                MessageBox.Show("cannot load data");
            }
            else
            {
                Close();
                PatientDashboard pd = new PatientDashboard(patient);
                TabPage tabpage = new TabPage();
                tabpage.Text = pd.Text = $"Record Card {patient.lastname} {patient.firstname}";
                StartPage.fromStartPage.tabControl1.TabPages.Add(tabpage);
                //Program.from.tabControl1.TabPages.Add(tabpage);
                pd.TopLevel = false;
                pd.Parent = tabpage;
                pd.Dock = DockStyle.Fill;
                StartPage.fromStartPage.tabControl1.SelectedTab = tabpage;
                //Program.from.tabControl1.SelectedTab = tabpage;
                pd.Show();

            }
        }
        public patient GetSelectedPatient(patient selectPatient)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                //selectUser.patient_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["patient_id"].Value);
                selectPatient.patient_id = (int)dataGridView1.CurrentRow.Cells["patient_id"].Value;

                using (emedEntities db = new emedEntities())
                {
                    selectPatient = db.patients.FirstOrDefault(p => p.patient_id == selectPatient.patient_id);
                }
            }
            return selectPatient;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
