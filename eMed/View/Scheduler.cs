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
using DevExpress.XtraScheduler;

namespace eMed.View
{
    public partial class Scheduler : DevExpress.XtraEditors.XtraForm
    {
        public Scheduler()
        {
            InitializeComponent();
            schedulerControl1.GroupType = SchedulerGroupType.Resource;

        }

        private void Scheduler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'emedDataSet.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.emedDataSet.Resources);
            // TODO: This line of code loads data into the 'emedDataSet.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.emedDataSet.Appointments);
            // TODO: This line of code loads data into the 'emedDataSet.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.emedDataSet.Resources);
            // TODO: This line of code loads data into the 'emedDataSet.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.emedDataSet.Appointments);

        }
        

        private void schedulerStorage1_AppointmentsChanged_1(object sender, PersistentObjectsEventArgs e)
        {
            appointmentsTableAdapter.Update(emedDataSet);
            emedDataSet.AcceptChanges();
        }

        

        private void schedulerControl1_EditAppointmentFormShowing_1(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            eMed.View.OutlookAppointmentForm form = new eMed.View.OutlookAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm);
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }

        }
    }
}