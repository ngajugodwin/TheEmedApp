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
    public partial class ServicesAndCatalog : Form
    {
        int active = 0;
        private readonly service_catalog _editServiceCatalog;
        private ButtonEvent buttonEvent;

        public ServicesAndCatalog()
        {
            InitializeComponent();
        }
        public ServicesAndCatalog(ButtonEvent buttonEvent = ButtonEvent.Save)
        {
            InitializeComponent();
            this.buttonEvent = buttonEvent;
        }
       
        private void RefreshGridView()
        {
            ServicesAndCatalogControl.fromServiceCatalogControl.LoadServiceCatalog();
        }
        public ServicesAndCatalog(service_catalog editServiceCatalog, ButtonEvent buttonEvent = ButtonEvent.Edit)
        {
            InitializeComponent();
            _editServiceCatalog = editServiceCatalog;
            LoadServiceCatalogToControl(_editServiceCatalog);
            this.buttonEvent = buttonEvent;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (buttonEvent == ButtonEvent.Save)
                SaveServiceCatalog();
            else if (buttonEvent == ButtonEvent.Edit)
                UpdateServiceCatalog();
            RefreshGridView();          
        }
        private void LoadServiceCatalogToControl(service_catalog serviceCatalog)
        {
            txtName.Text = _editServiceCatalog.name;
            _editServiceCatalog.active = Convert.ToInt32(_editServiceCatalog.active == 1 ? checkBoxActive.CheckState = CheckState.Checked : checkBoxActive.CheckState = CheckState.Unchecked);
            txtDescription.Text = _editServiceCatalog.description;
        }
        private void SaveServiceCatalog()
        {
            
            using(emedEntities db = new emedEntities())
            {
                service_catalog serviceCatalog = new service_catalog();
                serviceCatalog.name = txtName.Text.Trim();
                serviceCatalog.description = txtDescription.Text.Trim();
                serviceCatalog.created_at = DateTime.Now;
                serviceCatalog.creator_id = StartPage._loggedInUser.user_id;
                //serviceCatalog.creator_id = _authenticatedUser.user_id;
                serviceCatalog.active = (checkBoxActive.Checked) ? active + 1 : active;
                db.service_catalog.Add(serviceCatalog);
                db.SaveChanges();
                MessageBox.Show("New Service Catalog Added Succesfully", "Message");
                Close();
            }
        }
        private void UpdateServiceCatalog()
        {
            _editServiceCatalog.name = txtName.Text.Trim();
            _editServiceCatalog.description = txtDescription.Text.Trim();
            _editServiceCatalog.active = (checkBoxActive.Checked) ? active + 1 : active;
            
            using (emedEntities db = new emedEntities())
            {
                db.Entry(_editServiceCatalog).State = EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Service Catalog Updated Successfully!", "Message");
                Close();
            }
        }

    }
}
