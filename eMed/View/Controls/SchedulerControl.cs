using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eMed.Model;
using System.Data.Entity;

namespace eMed.View.Controls
{
    public partial class SchedulerControl : UserControl
    {

        public static SchedulerControl fromSchedulerControl;
        public SchedulerControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ScheduleList sl = new ScheduleList();
            sl.ShowDialog();
        }
        private void SchedulerControl_Load(object sender, EventArgs e)
        {
            LoadScheduleList();
            fromSchedulerControl = this;
        }

        public void LoadScheduleList()
        {
            emedEntities db = new emedEntities();
            dataGridView1.DataSource = db.Resources.ToList();
        }
       

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
        }
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }
        


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

       
    }
}
