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

namespace eMed.View
{
    public partial class Services : Form
    {
        int active = 0;
        private readonly service_catalog _service_catalog;
        private ButtonEvent buttonEvent;
        private readonly service _editServiceHelper;

        public Services()
        {
            InitializeComponent();
        }
        public Services(service editService, ButtonEvent buttonEvent = ButtonEvent.Edit)
        {
            InitializeComponent();
            _editServiceHelper = editService;
            LoadServiceToControl(_editServiceHelper);
        }

        public Services(service_catalog serviceCatalog, ButtonEvent buttonEvent = ButtonEvent.Save)
        {
            InitializeComponent();
            _service_catalog = serviceCatalog;
            this.buttonEvent = buttonEvent;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void RefreshGridView()
        {
            ServicesAndCatalogControl.fromServiceCatalogControl.RefreshDGVService();
        }
     

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (buttonEvent == ButtonEvent.Save)
                SaveService();
            else if (buttonEvent == ButtonEvent.Edit)
                UpdateService();
            
        }
        private void SaveService()
        {
            using (emedEntities db = new emedEntities())
            {
                service service = new service();
                service.code = txtCode.Text.Trim();
                service.created_at = DateTime.Now;
                service.description = txtDescription.Text.Trim();
                service.price = Convert.ToDecimal(txtPrice.Text.Trim());
                service.creator_id = StartPage._loggedInUser.user_id;
                service.service_catalog_id = _service_catalog.service_catalog_id;
                service.active = (checkBoxActive.Checked) ? active + 1 : active;
                service.isFavourite = (checkBoxFavourite.Checked) ? active + 1 : active;
                db.services.Add(service);
                db.SaveChanges();
                MessageBox.Show("New Service Saved", "Message");
                RefreshGridView();
                Close();
            }
        }
        private void LoadServiceToControl(service service)
        {
            txtCode.Text = _editServiceHelper.code;
            txtDescription.Text = _editServiceHelper.description;
            txtPrice.Text = Convert.ToString(_editServiceHelper.price);
        }
        private void UpdateService()
        {
            _editServiceHelper.code = txtCode.Text.Trim();
            _editServiceHelper.description = txtDescription.Text.Trim();
            _editServiceHelper.price = Convert.ToDecimal(txtPrice.Text.Trim());
            _editServiceHelper.isFavourite = (checkBoxFavourite.Checked) ? active + 1 : active;
            _editServiceHelper.active = (checkBoxActive.Checked) ? active + 1 : active;
            using (emedEntities db = new emedEntities())
            {
                db.Entry(_editServiceHelper).State = EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Service Updated Successfully!", "Message");
                Close();
            }
        }
        

    }
}
