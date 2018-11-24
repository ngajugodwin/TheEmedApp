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
    public partial class PreviewInvoice : DevExpress.XtraEditors.XtraForm
    {
        private readonly template _template;
        private readonly bill _billData;
        private readonly List<bill> _patientBill;
        public PreviewInvoice(List<bill> patientBill, bill billData)
        {
            InitializeComponent();
            _patientBill = patientBill;
            _billData = billData;

        }
        public PreviewInvoice(template template)
        {
            InitializeComponent();
            _template = template;
        }

        private template GetTemplate(int id)
        {
            using (emedEntities db = new emedEntities())
            {
                return db.templates.FirstOrDefault(t => t.template_id == id);
            }
        }

        private void PreviewInvoice_Load(object sender, EventArgs e)
        {
            InitDocument();
        }
        private void InitDocument()
        {

            //var result = GetTemplate(_patientBill.Where(a=> a.template.source_document));
            //pdfViewer1.DocumentFilePath = ofd.FileName;
            //txtFilePath.Text = pdfViewer1.DocumentFilePath;

            pdfViewer1.DocumentFilePath = _billData.template.source_document;
        }
        void no()
        {
            
        }
    }
}