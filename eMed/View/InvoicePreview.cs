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
using eMed.Report;

namespace eMed.View
{
    public partial class InvoicePreview : DevExpress.XtraEditors.XtraForm
    {
        public InvoicePreview()
        {
            InitializeComponent();
        }
        public void PrintInvoice(patient patient, List<temp_service> data)
        {
            InvoiceReport report = new InvoiceReport();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;
            report.InitData(patient.firstname, patient.lastname, patient.email, data);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            
        }
       
        private List<PatientCartDto> GetServices()
        {
           var service = new List<PatientCartDto>();
            using (emedEntities db = new emedEntities())
            {

                service = (
                   from t in db.temp_service
                   join s in db.services on t.service_id equals s.service_id
                   where t.patient_id == 33
                   select new PatientCartDto
                   {
                       ServiceDescription = s.description,
                   }).ToList();

            }
            return service;
        }
    }
}