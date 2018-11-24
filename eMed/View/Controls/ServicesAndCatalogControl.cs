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
    public partial class ServicesAndCatalogControl : DevExpress.XtraEditors.XtraUserControl
    {
        private service_catalog serviceCatalog = new service_catalog();
        private emedEntities dbHelper;
        public static ServicesAndCatalogControl fromServiceCatalogControl;


        //public DataGridView DGV { get; set; }
        public ServicesAndCatalogControl()
        {
            InitializeComponent();
             LoadServiceCatalog();
            dbHelper = new emedEntities();
        }
       

        private void ServicesAndCatalogControl_Load(object sender, EventArgs e)
        {
            fromServiceCatalogControl = this;
            //LoadServiceCatalog();
        }
        private void btnAddServicesCatalog_Click(object sender, EventArgs e)
        {
            //Add New Service Catalog
            ServicesAndCatalog sacc = new ServicesAndCatalog(ButtonEvent.Save);
            sacc.ShowDialog();

        }
        public void LoadServiceCatalog()
        {
            using (emedEntities db = new emedEntities())
            {
                dataGridView1.DataSource = db.service_catalog.ToList();
            }
        }
        
        private void btnEditServiceCatalog_Click(object sender, EventArgs e)
        {
            EditServiceCatalog();
        }
        private void EditServiceCatalog()
        {
            service_catalog serviceCatalog = GetServiceCatalogFromDB();
            if (serviceCatalog != null)
            {
                ServicesAndCatalog sac = new ServicesAndCatalog(serviceCatalog, ButtonEvent.Edit);
                sac.headerText.Text = $"Edit Service Catalog : {serviceCatalog.name}";
                sac.Show();
            }
        }
        private service_catalog GetServiceCatalogFromDB()
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                serviceCatalog.service_catalog_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["service_catalog_id"].Value);
                using (emedEntities db = new emedEntities())
                {
                    serviceCatalog = db.service_catalog.FirstOrDefault(s=> s.service_catalog_id == serviceCatalog.service_catalog_id);
                }

            }
            return serviceCatalog;
        }
        void DeleteServiceRelatedToServiceCatalog()
        {
            service_catalog scat = GetServiceCatalogFromDB();
            var allService = dbHelper.services.Where(s => s.service_catalog_id == scat.service_catalog_id);
            dbHelper.services.RemoveRange(allService);
            dbHelper.SaveChanges();
        }

        private void Delete()
        {
            //Get selected row from user
            //Delete related services in service catalog if any
            //delete service catalog
            if (dataGridView1.CurrentRow.Index != -1)
            {
                serviceCatalog.service_catalog_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["service_catalog_id"].Value);
                serviceCatalog.name = Convert.ToString(dataGridView1.CurrentRow.Cells["name"].Value);
                if (MessageBox.Show($"Are you sure you want to delete {serviceCatalog.name} with its related services?. Proceed with caution", "Delete Service Catalog", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteServiceRelatedToServiceCatalog();
                    using (emedEntities db = new emedEntities())
                    {
                        var result = db.Entry(serviceCatalog);
                        if (result.State == EntityState.Detached)
                            db.service_catalog.Attach(serviceCatalog);
                        db.service_catalog.Remove(serviceCatalog);
                        db.SaveChanges();
                        MessageBox.Show("Service Catalog Deleted Successfully", "Message");
                        
                    }
                    LoadServiceCatalog();
                    RefreshDGVService();
                }
            }
            
        }
       

        private void btnDeleteServiceCatalog_Click(object sender, EventArgs e)
        {
            Delete();
        }

  /***********************Services Section Function*******************************************/
        private void btnNewService_Click(object sender, EventArgs e)
        {
            AddNewService();
        }

        private void AddNewService()
        {
            //Check selected Catalog where user wants to make an entry and add the service
            service_catalog selectedCatalog = GetServiceCatalogFromDB();
            if(selectedCatalog != null)
            {
                Services services = new Services(selectedCatalog, ButtonEvent.Save);
                services.ShowDialog();
            }

                
        }
        private void btnServiceEdit_Click(object sender, EventArgs e)
        {
            service service = GetServiceFromDB(new service());
            if (service != null)
            {
                //MessageBox.Show(service.code);
                Services services = new Services(service, ButtonEvent.Edit);
                services.headerText.Text = $"Edit Service : {service.code}";
                services.ShowDialog();
            }
        }
        private service GetServiceFromDB(service service)
        {
            if(dataGridViewService.CurrentRow.Index != -1)
            {
                service.service_id = Convert.ToInt32(dataGridViewService.CurrentRow.Cells["service_id"].Value);
                using(emedEntities db = new emedEntities())
                {
                    service = db.services.FirstOrDefault(s => s.service_id == service.service_id);
                }
            }
            return service;
        }
     

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            LoadServicesFromServiceCatalogToView();           
        }
        void LoadServicesFromServiceCatalogToView()
        {
            List<service> serviceList = GetServiceFromServiceCatalog();
            if(serviceList != null)
              dataGridViewService.DataSource = serviceList;
        }


        public List<service> GetServiceFromServiceCatalog()
        {
            service_catalog scat = GetServiceCatalogFromDB();
            return dbHelper.services.Where(s => s.service_catalog_id == scat.service_catalog_id).ToList();            
        }
        public void RefreshDGVService()
        {
            List<service> list = GetServiceFromServiceCatalog();
            using (emedEntities db = new emedEntities())
            {
                dataGridViewService.DataSource = list;
            }
        }

        
        //TODO:Validate price in services and also for servicesand Catalog
    }
}
