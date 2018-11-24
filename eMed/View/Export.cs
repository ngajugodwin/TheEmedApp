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
using System.Threading;
using Microsoft.Office.Interop.Excel;

namespace eMed.View
{
    public partial class Export : DevExpress.XtraEditors.XtraForm
    {
        private readonly List<ExportListDataDto> _userList;
        DataParameter _inputParameter;
        public Export(List<ExportListDataDto> userList)
        {
            InitializeComponent();
            _userList = userList;
        }
        struct DataParameter
        {
            public List<ExportListDataDto> UserList;
            public string FileName { get; set; }
        }
        
        private void Export_Load(object sender, EventArgs e)
        {
            dataGridViewExport.DataSource = _userList;
           
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
                return;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter= "Excel WorkBook|*.xls"})
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _inputParameter.FileName = sfd.FileName;
                    _inputParameter.UserList = dataGridViewExport.DataSource as List<ExportListDataDto>;
                    progressBar1.Minimum = 0;
                    progressBar1.Value = 0;
                    backgroundWorker.RunWorkerAsync(_inputParameter);
                }

            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var list = ((DataParameter)e.Argument).UserList;
            string filename = ((DataParameter)e.Argument).FileName;
            var excel = new Microsoft.Office.Interop.Excel.Application();
            var wb =  excel.Workbooks.Add(XlSheetType.xlWorksheet);
            var ws = (Worksheet)excel.ActiveSheet;
            excel.Visible = false;
            int index = 1;
            int process = list.Count;
            //Columns to be added
            ws.Cells[1, 1] = "EmployeeID";
            ws.Cells[1, 2] = "Firstname";
            ws.Cells[1, 3] = "Lastname";
            ws.Cells[1, 4] = "Username";
            ws.Cells[1, 5] = "Email";
            ws.Cells[1, 6] = "Sex";

            //Loop through the list and assign data to respective columns
            foreach (ExportListDataDto export in list)
            {
                if (!backgroundWorker.CancellationPending)
                {
                    backgroundWorker.ReportProgress(index++ * 100 / process);
                    ws.Cells[index, 1] = export.EmployeeID;
                    ws.Cells[index, 2] = export.Firstname;
                    ws.Cells[index, 3] = export.Lastname;
                    ws.Cells[index, 4] = export.Username;
                    ws.Cells[index, 5] = export.Email;
                    ws.Cells[index, 6] = export.Sex;
                }
            }
            ws.SaveAs(filename, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges);
            excel.Quit();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            statusCounter.Text = string.Format("Processing...{0}", e.ProgressPercentage);
            progressBar1.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error == null)
            {
                Thread.Sleep(100);
                statusCounter.Text = "Your Data has been exported successfully";
                MessageBox.Show("Success Message", "Export Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();

        }
    }
}