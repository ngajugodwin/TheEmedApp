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

namespace eMed.View
{
    public partial class NewPatient : DevExpress.XtraEditors.XtraForm
    {
        public NewPatient()
        {
            InitializeComponent();
        }

        private void NewPatient_Load(object sender, EventArgs e)
        {
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            TakePhoto tp = new TakePhoto();
            tp.ShowDialog();
        }
        
        public patient GetFilledPatient()
        {
            patient p = new patient();
            // patient.patient_nr = txtPatientNumber.Text.Trim();
            p.affix = txtAffix.Text.Trim();
            p.salutation = comboSalutation.Text.Trim();
            p.lastname = txtSurname.Text.Trim();
            p.firstname = txtFirstName.Text.Trim();
            p.other_name = txtOtherName.Text.Trim();
            p.dob = Convert.ToDateTime(dateTimePickerDOB.Text);
            p.gender = comboSex.Text.Trim();
            p.marital_status = comboMaritalStatus.Text.Trim();
            p.email = txtEmail.Text.Trim();
            p.mobile = txtMobile.Text.Trim();
            p.contact_person = txtContactPerson.Text.Trim();
            p.phone = txtPhone.Text.Trim();
            p.street_address = txtStreet.Text.Trim();
            p.telefax = txtTelefax.Text.Trim();
            p.country = txtCountry.Text.Trim();
            p.town = txtTown.Text.Trim();
            
            //throw validation error here
            return p;
        }
        public void Clear()
        {
            txtFirstName.Text = txtSurname.Text = txtOtherName.Text = txtEmail.Text =
                txtMobile.Text = txtPhone.Text = txtStreet.Text = txtTown.Text = txtTelefax.Text =
                txtCountry.Text = txtPartner.Text = txtAffix.Text = txtContactPerson.Text = string.Empty;
            dateTimePickerDOB.Value = DateTime.Now;
            comboMaritalStatus.SelectedIndex = -1;
            comboSalutation.SelectedIndex = -1;
            comboSex.SelectedIndex = -1;
            comboTitle.SelectedIndex = -1;
        }
    }
}