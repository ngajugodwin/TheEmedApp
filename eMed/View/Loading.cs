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

namespace eMed.View
{
    public partial class Loading : DevExpress.XtraEditors.XtraForm
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarControl1.Increment(1);
            
            if (progressBarControl1.Position > 99)
            {
                timer1.Enabled = false;
                this.Close();
                MessageBox.Show("Data Imported Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Import.fromImport.dataGridView1.DataSource = Import.fromImport.LoadData();
                Import.fromImport.ButtonControl();
            }
            
        }
        
    }
}