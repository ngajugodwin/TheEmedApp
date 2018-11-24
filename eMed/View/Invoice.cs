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
using System.Data.Entity;

namespace eMed.View
{
    public partial class Invoice : DevExpress.XtraEditors.XtraForm
    {

        private readonly patient _curentPatient;
        private emedEntities dbHelper;
        public Invoice(patient currentPatient)
        {
            InitializeComponent();
            _curentPatient = currentPatient;
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            dbHelper = new emedEntities();
            LoadCurrentPatientBills();
            InitTotalBill();
            //CalculateTotalAmountInCart(_curentPatient.patient_id);
        }
        private void LoadCurrentPatientBills()
        {
            dataGridViewCart.DataSource = LoadCartToGridView(_curentPatient.patient_id);
        }
        private List<temp_service> GetCurrentPatientBills(patient patient)
        {
            return dbHelper.temp_service.Where(b => b.patient_id == patient.patient_id).ToList();
            
        }

        private void buttonInvoice_Click(object sender, EventArgs e)
        {
            var patientBills = GetCurrentPatientBills(_curentPatient);
            using (InvoicePreview ip = new InvoicePreview())
            {
                ip.PrintInvoice(_curentPatient, patientBills);
                ip.ShowDialog();
            }
        }

        private void btnTestAnotherInvoice_Click(object sender, EventArgs e)
        {
            
        }
     
        private static List<PatientCartDto> LoadCartToGridView(int patientId)
        {
            var patientCart = new List<PatientCartDto>();
            using (emedEntities db = new emedEntities())
            {
                patientCart = (
                    from t in db.temp_service
                    join u in db.users on t.creator_id equals u.user_id
                    join s in db.services on t.service_id equals s.service_id
                    join sc in db.service_catalog on s.service_catalog_id equals sc.service_catalog_id
                    where t.patient_id == patientId
                    select new PatientCartDto
                    {
                        Id = t.temp_service_id,
                        Code = s.code,
                        ServiceDescription = s.description,
                        ServiceType = sc.name,
                        CreatorName = u.firstname,
                        Price = t.price,
                        Quantity = t.quantity                        
                    }).ToList();
            }
            return patientCart;

        }
      
        private decimal? CalculateTotalAmountInCart(int patientId)
        {
            temp_service temp = new temp_service();
            decimal? total = 0M;
            var cartList =  dbHelper.temp_service
                .Where(t => t.patient_id == patientId).ToList();
            foreach (var item in cartList)
            {
                total += item.price * item.quantity;
            }
            return total;
        }
        private void InitTotalBill()
        {
            var total = CalculateTotalAmountInCart(_curentPatient.patient_id);
            if (total == null)
                MessageBox.Show("No value was returned", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                lblAmountGross.Text = total.Value.ToString();
                lblAmountNet.Text = total.Value.ToString();
            }
            
        }
        private void btnTotal_Click(object sender, EventArgs e)
        {
            var result = CalculateTotalAmountInCart(_curentPatient.patient_id);
            if (result == null)
                MessageBox.Show("No total");
            else
                MessageBox.Show(result.Value.ToString());
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            SaveBillWithDetails();
        }
        private void SaveBillWithDetails()
        {
            var total = CalculateTotalAmountInCart(_curentPatient.patient_id);

            using (emedEntities db = new emedEntities())
            {
                //Create a bill first
                bill bill = new bill();
                bill.creator_id = StartPage._loggedInUser.user_id;
                bill.bill_date = DateTime.Now;
                bill.bill_nr = "BILL001";
                bill.description = "Total";
                bill.template_id = 2;
                bill.total_amount = total;
                bill.patient_id = _curentPatient.patient_id;

                //Loop through the cart to find items relating to patient
                var cartList = db.temp_service
                    .Where(t => t.patient_id == _curentPatient.patient_id).ToList();
                if (cartList.Count == 0)
                {
                    MessageBox.Show("There are no item(s) to create bill for this patient");
                }
                else
                {
                    foreach (var item in cartList)
                    {
                        //Add bill details
                        bill_details bd = new bill_details();
                        bd.service_id = item.service_id;
                        bd.quantity = item.quantity;
                        bd.price = item.price;
                        bd.bill_id = bill.bill_id;
                        bill.bill_details.Add(bd);
                    }
                    db.bills.Add(bill);
                    db.SaveChanges();
                    EmptyCart(_curentPatient.patient_id);
                    MessageBox.Show("New Bill Saved!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        void EmptyCart(int patientID)
        {
            using(emedEntities db = new emedEntities())
            {
                db.temp_service.Where(t => t.patient_id == patientID)
                    .ToList().ForEach(t => db.temp_service.Remove(t));
                db.SaveChanges();
            }
            LoadCurrentPatientBills();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteItemFromCart(new PatientCartDto());
        }
        private void DeleteItemFromCart(PatientCartDto temp)
        {
            if (dataGridViewCart.CurrentRow.Index != -1)
            {
                temp.Id = Convert.ToInt32(dataGridViewCart.CurrentRow.Cells["Id"].Value);
                if (MessageBox.Show($"Are you sure you want to delete from the Cart?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (emedEntities db = new emedEntities())
                    {
                        var deleteService = db.temp_service.Find(temp.Id);
                        db.temp_service.Remove(deleteService);
                        db.SaveChanges();
                        MessageBox.Show("Record Deleted Successfully", "Message");
                        LoadCurrentPatientBills();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var result = EditItemFromCart(new PatientCartDto());
            if (result == null)
                MessageBox.Show("Something went wrong", "Error");
            else
            {
                ServiceCart sc = new ServiceCart(result);
                sc.Text = "Edit Service";
                sc.ShowDialog();
            }
        }
        
        private temp_service EditItemFromCart(PatientCartDto temp)
        {   
            if (dataGridViewCart.CurrentRow.Index != -1)
            {
                temp.Id = Convert.ToInt32(dataGridViewCart.CurrentRow.Cells["Id"].Value);       
            }
            return dbHelper.temp_service.Find(temp.Id);
        }


        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
