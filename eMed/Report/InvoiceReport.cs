using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using eMed.Model;
using System.Collections.Generic;

namespace eMed.Report
{
    public partial class InvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InvoiceReport()
        {
            InitializeComponent();
        }
        public void InitData(string firstname, string lastname, string email, List<temp_service> data)
        {
            patientFirstName.Value = firstname;
            patientLastName.Value = lastname;
            patientEmail.Value = email;
            bindingSource1.DataSource = data;           
        }

    }
}
