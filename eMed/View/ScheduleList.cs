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
using System.Data.Entity;
using eMed.View.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Skins;

namespace eMed.View
{
    public partial class ScheduleList : Form
    {
        public ScheduleList()
        {
            InitializeComponent();
        }
       

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            using (emedEntities db = new emedEntities())
            {
                Resource resource = new Resource();
                resource.ResourceName = txtResourceName.Text;
                resource.ResourceID = 8;
                db.Resources.Add(resource);
                db.SaveChanges();
                MessageBox.Show("Saved", "Message");
                Close();
            }
            RefreshList();
        }
        private void RefreshList()
        {
            SchedulerControl.fromSchedulerControl.LoadScheduleList();
        }
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
