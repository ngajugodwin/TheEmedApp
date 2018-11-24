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
using System.IO;
using Microsoft.Office.Interop;
using ExcelDataReader;
using eMed.Model;
using eMed.View.Controls;

namespace eMed.View
{
    public partial class Import : DevExpress.XtraEditors.XtraForm
    {
        DataSet result;
        public static Import fromImport;
        emedEntities db = new emedEntities();
        public Import()
        {
            InitializeComponent();
            ButtonControl();
           // db = new emedEntities();
        }

        private void Import_Load(object sender, EventArgs e)
        {
            fromImport = this;
        }
        OpenFileDialog ofd;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true})
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Loading load = new Loading();
                    load.ShowDialog();
                }
            }
        }
        DataTable data;
        public DataTable LoadData()
        {
            FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs);
            result = reader.AsDataSet();
            foreach (DataTable dt in result.Tables)
            {
                data = dt;
                reader.Close();
            }
            return data;             
            
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            ButtonControl();
        }
              
        private void btnImport_Click(object sender, EventArgs e)
        {   
             timer1.Enabled = true;
        }
        public void ButtonControl()
        {
            if(dataGridView1.DataSource == null)
            {
                btnOpen.Enabled = true;
                btnClear.Enabled = false;
                btnImport.Enabled = false;
            }
            else if(dataGridView1.DataSource != null)
            {
                btnClear.Enabled = true;
                btnImport.Enabled = true;
                btnOpen.Enabled = false;
            }

           
        }
        void ImportData()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                user user = new user();
                user.lastname = row.Cells["Column0"].Value.ToString();
                user.firstname = row.Cells["Column1"].Value.ToString();
                user.username = row.Cells["Column2"].Value.ToString();
                user.email = row.Cells["Column3"].Value.ToString();
                user.sex = row.Cells["Column4"].Value.ToString();

                db.users.Add(user);
            }
            db.SaveChanges();
            db.Dispose();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            btnClear.Enabled = false;
            progressBarControl1.Increment(1);
            statusCounter.Text = string.Format("Import is in progress...{0}%", progressBarControl1.Position.ToString());
            if (progressBarControl1.Position > 99)
            {
                ImportData();
                timer1.Enabled = false;
                Close();
                statusCounter.Text = "Import completed";
                MessageBox.Show("Users have been added successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UserAccountControl.fromUserAccountControl.LoadUsers();
            }
        }
       

    }
}