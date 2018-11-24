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
using eMed.Properties;

namespace eMed.View
{
    public partial class PatientDashboard : Form
    {
        //private service service;
        private readonly patient _currentPatient;
        bool isLoaded = false;
        private emedEntities dbHelper;
        public static PatientDashboard fromPatientDash;
        //private emedEntities dbHelper = new emedEntities();

        public PatientDashboard( )
        {
            InitializeComponent();
        }
        public PatientDashboard(patient currentPatient)
        {
            InitializeComponent();
            _currentPatient = currentPatient;
            LoadPatient(_currentPatient);
            this.btnRefresh.Image = (Image)(new Bitmap(Resources.refresh2, new Size(32, 32)));
        }
        private void PatientDashboard_Load(object sender, EventArgs e)
        {
            isLoaded = true;
            dbHelper = new emedEntities();
            RefreshCaseNoteGrid();
            fromPatientDash = this;
        }
        private void RefreshCaseNoteGrid()
        {
            dataGridView1.DataSource = 
                LoadCaseNoteBaseOnPatientId(_currentPatient.patient_id);
        }


        protected void LoadPatient(patient p)
        {
            //lblpatientDisplayName.Text = patient.lastname.ToUpper() + " " + patient.firstname;
            Color c = lblPatientDisplayName.ForeColor = GetLabelForeColor(p);
            if (c == null)
                lblPatientDisplayName.Text = _currentPatient.lastname.ToUpper() + " " + _currentPatient.firstname;
            else if (c == Color.Red)
                lblPatientDisplayName.Text = _currentPatient.lastname.ToUpper() + " " + _currentPatient.firstname;
            else
                lblPatientDisplayName.Text = _currentPatient.lastname.ToUpper() + " " + _currentPatient.firstname;
            lblPatientDOB.Text = "DOB: " + _currentPatient.dob.Value.ToShortDateString();
            lblPatientAddress.Text = _currentPatient.street_address;
            lblPatientEmail.Text = "E: " + _currentPatient.email;
            lblPatientHome.Text = "T: " + _currentPatient.mobile;
            lblPatientTelephone.Text = "H: " + _currentPatient.phone;

            if (_currentPatient.image == null)
            {
                if (_currentPatient.gender == "Female")
                    pictureBoxPrimary.Image = Resources.femaleAvartar;
                else
                    pictureBoxPrimary.Image = Resources.maleAvartar;
            }
        }
        private Color GetLabelForeColor(patient p)
        {
            return (p.gender == "Female") ? lblPatientDisplayName.ForeColor = Color.LightPink : lblPatientDisplayName.ForeColor = Color.Blue;
        }

        private void LoadSlidePanelPatientInfo()
        {
            linkLblPatientName.Text = _currentPatient.firstname.ToUpper() + " " + _currentPatient.lastname.ToUpper();
            //lblPatientNumber.Text = "Patient Number: 1234";
            //lblPatientAge.Text = "Age: " + BirthdayCalulator().ToString();
            //lblPatientHeight.Text = "Height: ";
            //lblPatientWeight.Text = "Weight: ";
            //lblPatientBMI.Text = "BMI: ";
        }
        private int BirthdayCalulator()
        {
            DateTime today = DateTime.Now;
            DateTime dob = Convert.ToDateTime(_currentPatient.dob.Value);
            int age = today.Year - dob.Year;
            if (dob.Month > today.Month)
                age--;
            return age;
        }
        

        private void dockPanelPatient_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            dockPanelPatient.ForeColor = Color.Green;
            LoadSlidePanelPatientInfo();
        }

        private List<service_catalog> GetServiceCatalog()
        {
            using(emedEntities db = new emedEntities())
            {
                return db.service_catalog.ToList();
            }
        }
        
        private void dockPanelServices_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            
            List<service_catalog> catalogLists = GetServiceCatalog();
            foreach (var item in catalogLists)
            {
                comboBoxServices.Items.Add(item.name);
            }
        }
        private void dockPanelServices_Collapsed(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            comboBoxServices.Items.Clear();
            dataGridViewServices.DataSource = null;
        }

        private service_catalog GetServiceCatalogName(string serviceCatalogname)
        {
            using (emedEntities db = new emedEntities())
            {
                return db.service_catalog.FirstOrDefault(s => s.name == serviceCatalogname);
            }
        }
        
        private void comboBoxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            //service_catalog data = GetServiceCatalogName(comboBoxServices.Text);
            //List<service> serviceList;
            //if (data != null)
            //{
            //    using(emedEntities db = new emedEntities())
            //    {
            //        serviceList = db.services.Where(s => s.service_catalog_id == data.service_catalog_id).ToList();
            //        dataGridViewServices.DataSource = serviceList;
            //    }
            //}

            if (isLoaded)
            {
                service_catalog data = GetServiceCatalogName(comboBoxServices.Text);
                List<service> serviceList;
                if (data != null)
                {
                    serviceList = dbHelper.services.Where(s => s.service_catalog_id == data.service_catalog_id).ToList();
                    dataGridViewServices.DataSource = serviceList;
                }
            }

        }

        private IEnumerable<service> Search(string name)
        {
            
            using (emedEntities dbHelper = new emedEntities())
            {
                return dbHelper.services.Where(s => s.code.Contains(name)).ToList();
            }

        } 
        private IEnumerable<service> Search2(int favourite = 0)
        {
            
            using(emedEntities db = new emedEntities())
            {
                return db.services.Where(s => s.isFavourite.Value == favourite).ToList();
            }
        }
        private IEnumerable<service> MainSearch(string codeName = "", int favourite = 1)
        {
            //TODO: Use one function to implement search for name and favourite
            List<service> data;
            using(emedEntities dbHelper = new emedEntities())
            {
                data = dbHelper.services.Where(s => s.code == codeName && s.isFavourite.Value == favourite).ToList();
            }
            //var result = Tuple.Create(data);
            return data;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            var result = MainSearch(search);
            if (string.IsNullOrWhiteSpace(search) && comboBoxServices.SelectedItem == null)
                MessageBox.Show("Invalid Data", "Error");
            else
                dataGridViewServices.DataSource = result;     
        }

        private void btnFavourite_Click(object sender, EventArgs e)
        {
            var name = GetServiceCatalogName(comboBoxServices.Text);
            var result = Search2(1);
            if (comboBoxServices.SelectedItem == null)
                MessageBox.Show("Please select a service from the drop down", "Message");
            else
                dataGridViewServices.DataSource = result;            

        }

        private void AddServiceToCart()
        {
            var result = GetSelectedRowService(new service());
            using (emedEntities db = new emedEntities())
            {
                temp_service tempService = new temp_service();
                tempService.creator_id = StartPage._loggedInUser.user_id;
                tempService.patient_id = _currentPatient.patient_id;
                tempService.service_id = result.service_id;
                tempService.quantity = 1;
                tempService.price = result.price;
                db.temp_service.Add(tempService);
                db.SaveChanges();
                
            }
            //CalculateTotalAmountInCart(_currentPatient);
            //SumBillReturnBillID();
            //AddServiceToBillDetails();
            //ClearCart(_currentPatient.patient_id);
            MessageBox.Show("Success");
        }
        
        private decimal? CalculateTotalAmountInCart(patient patient)
        {
            temp_service temp = new temp_service();
            decimal? result = 0M;
            using (emedEntities db = new emedEntities())
            {
                var cartList= db.temp_service
                    .Where(t=> t.patient_id == patient.patient_id).ToList();
                foreach (var item in cartList)
                {
                    result= temp.price * temp.quantity;
                }
            }
            return result;
        }
        private int SumBillReturnBillID()
        {
            var total = CalculateTotalAmountInCart(_currentPatient);
            using(emedEntities db = new emedEntities())
            {
                bill bill = new bill();
                bill.creator_id = StartPage._loggedInUser.user_id;
                bill.bill_date = DateTime.Now;
                bill.bill_nr = "EMED001";
                bill.description = "Total";
                bill.template_id = 2;
                bill.total_amount = total;
                bill.patient_id = _currentPatient.patient_id;
                db.bills.Add(bill);
                db.SaveChanges();
                return bill.bill_id;
            }
        }
        
        private void dataGridViewServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddServiceToCart();
        }

        private void ClearCart(int patient)
        {
            temp_service patientServices = new temp_service() { patient_id = patient };
            using (emedEntities db = new emedEntities())
            {
                db.temp_service.Attach(patientServices);
                db.temp_service.Remove(patientServices);
                db.SaveChanges();
            }
        }
        private service GetSelectedRowService(service service)
        {
            //dataGridViewServices
            if (dataGridViewServices.CurrentRow.Index != -1)
            {
                service.service_id = Convert.ToInt32(dataGridViewServices.CurrentRow.Cells["service_id"].Value);
                using (emedEntities db = new emedEntities())
                {
                    service= db.services.FirstOrDefault(s => s.service_id == service.service_id);
                }
            }
            return service;
        }
 
        private List<CaseNoteDto> LoadCaseNoteBaseOnPatientId(int patientId)
        {
            var patientCaseNote = new List<CaseNoteDto>();
            using (emedEntities db = new emedEntities())
            {
                patientCaseNote = (
                     from c in db.casenotes
                     join u in db.users on c.creator_id equals u.user_id
                     join cat in db.categories on c.category_id equals cat.category_id
                     where c.patient_id == patientId
                     select new CaseNoteDto
                     {
                         CreatedAt = c.created_at,
                         CategoryName = cat.acronym,
                         EntryText = c.entry_text,
                         Attachment = c.attachment,
                         CreatedBy = u.firstname
                     }).ToList();

            }
            return patientCaseNote;
        }
       
        /**************************Invoice**************************************/
        public void OpenInvoice()
        {
            Invoice inc = new Invoice(_currentPatient);
            TabPage tabpage = new TabPage();
            tabpage.Text = inc.Text + ": " + _currentPatient.firstname + " " +_currentPatient.lastname;
            StartPage.fromStartPage.tabControl1.TabPages.Add(tabpage);
            inc.TopLevel = false;
            inc.Parent = tabpage;
            inc.Show();
            inc.Dock = DockStyle.Fill;
            StartPage.fromStartPage.tabControl1.SelectedTab = tabpage;
        }

        
    }
}
