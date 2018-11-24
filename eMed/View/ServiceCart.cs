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
using System.Data.Entity;

namespace eMed.View
{
    public partial class ServiceCart : DevExpress.XtraEditors.XtraForm
    {
        private readonly temp_service _editItemFromCart;
        bool isLoaded = false;
        private emedEntities dbHelper;
        List<service> serviceList = new List<service>();
        public ServiceCart()
        {
            InitializeComponent();
        }
        public ServiceCart(temp_service editItemFromCart)
        {
            InitializeComponent();
            _editItemFromCart = editItemFromCart;
        }

        private void ServiceCart_Load(object sender, EventArgs e)
        {
            isLoaded = true;
            dbHelper = new emedEntities();
            InitEditItemToControl();
            LoadServiceCatlog();
        }
        void InitEditItemToControl()
        {
            txtCode.Text = _editItemFromCart.service.code;
            txtPrice.Text = _editItemFromCart.service.price.ToString();
            comboServiceCatalog.Text = _editItemFromCart.service.service_catalog.name;
        }
        private void LoadServiceCatlog()
        {
            using (emedEntities db = new emedEntities())
            {
                var result = db.service_catalog.ToList();
                foreach (var item in result)
                {
                    comboServiceCatalog.Items.Add(item.name);
                }
                
            }
        }
        service_catalog GetServiceCatalogList(string name)
        {
            using (emedEntities db = new emedEntities())
            {
                return db.service_catalog.FirstOrDefault(s => s.name == name);
            }
        }
        private void comboServiceCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = GetServiceCatalogList(comboServiceCatalog.Text);
            Clear();
            if (isLoaded)
            {
                if (result != null)
                {
                    serviceList = dbHelper.services.Where(s => s.service_catalog_id == result.service_catalog_id).ToList();
                    foreach (var item in serviceList)
                    {
                        comboServices.Items.Add(item.description);
                    }
                }
            }
           
        }
        void Clear()
        {
            comboServices.Text = "";
            txtCode.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }

        private void comboServiceCatalog_DropDownClosed(object sender, EventArgs e)
        {
            comboServices.Items.Clear();
        }

        private void comboServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitServicePreview();
        }
        private service InitServicePreview()
        {
            var result = GetServiceNameList(comboServices.Text);
            txtCode.Text = result.code;
            txtPrice.Text = result.price.ToString();
            return result;
        }
        private service GetServiceNameList(string serviceName)
        {
            using (emedEntities db = new emedEntities())
            {
                return db.services.FirstOrDefault(s => s.description == serviceName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateCart(_editItemFromCart);
        }
        void UpdateCart(temp_service tempService)
        {
            var result = InitServicePreview();
            if (comboServices.Text == string.Empty)
            {
                txtCode.Text = string.Empty;
                txtPrice.Text = string.Empty;
                MessageBox.Show("Please select a service from drop down", "Message");
            }
            else
            {
                MessageBox.Show(Convert.ToString(result.service_id));
                using (emedEntities db = new emedEntities())
                {
                    //_editItemFromCart.creator_id = StartPage._loggedInUser.user_id;
                    //_editItemFromCart.service_id = result.service_id;
                    //_editItemFromCart.price = result.price;
                    //db.Entry(tempService).State = EntityState.Modified;
                    //db.SaveChanges();
                    //MessageBox.Show("Service Updated Successfully!", "Message");
                    //Close();

                    var cart = db.temp_service.Find(_editItemFromCart.temp_service_id);
                    cart.creator_id = StartPage._loggedInUser.user_id;
                    cart.service_id = result.service_id;
                    cart.price = result.price;
                    db.SaveChanges();
                    MessageBox.Show("Updated Successfully!", "Message");
                    Close();
                }
            }

        }
    }
}