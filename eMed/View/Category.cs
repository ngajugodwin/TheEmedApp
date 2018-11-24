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
    public partial class Category : Form
    {
        int active = 0;
        private ButtonEvent buttonEvent;
        private readonly category _editCatergoryHelper;
        public Category()
        {
            InitializeComponent();
        }
        public Category(ButtonEvent buttonEvent = ButtonEvent.Save)
        {
            InitializeComponent();
            this.buttonEvent = buttonEvent;
        }
        public Category(category editCategory, ButtonEvent buttonEvent = ButtonEvent.Edit)
        {
            InitializeComponent();
            this.buttonEvent = buttonEvent;
            _editCatergoryHelper = editCategory;
            LoadCategoryIntoControls(_editCatergoryHelper);
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
         

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (buttonEvent == ButtonEvent.Save)
                SaveCategory();
            else if (buttonEvent == ButtonEvent.Edit)
                UpdateCategory(_editCatergoryHelper);
            RefreshData();
            
        }
        private bool ValidateFields(string acronym, string name)
        {
            var controls = new[] { acronym, name };
            bool isValid = true;

            foreach (var control in controls.Where(e => string.IsNullOrWhiteSpace(e)))
            {
                isValid = false;
                break;
            }
            return isValid;
        }
        private void SaveCategory()
        {
            using (emedEntities db = new emedEntities())
            {
                category category = new category();
                category.acronym = txtAcroymn.Text.Trim();
                category.creator_id = StartPage._loggedInUser.user_id;
                category.active = (checkBoxActive.Checked) ? active + 1 : active;
                category.description = txtDescription.Text.Trim();
                category.name = txtName.Text.Trim();
                var validationResult = ValidateFields(category.acronym, category.name);
                if (!validationResult)
                    MessageBox.Show("Please enter required fields", "Error");
                else
                {
                    db.categories.Add(category);
                    db.SaveChanges();
                    MessageBox.Show("New Category Added Successfully", "Message");
                    Close();
                }
                
            }

        }

        private void LoadCategoryIntoControls(category category)
        {
            txtAcroymn.Text = category.acronym;
            txtDescription.Text = category.description;
            txtName.Text = category.name;
            category.active = Convert.ToInt32(_editCatergoryHelper.active == 1 ? checkBoxActive.CheckState = CheckState.Checked : checkBoxActive.CheckState = CheckState.Unchecked);

        }

        private void UpdateCategory(category updateCategory)
        {
            updateCategory.name = txtName.Text.Trim();
            updateCategory.description = txtDescription.Text.Trim();
            updateCategory.acronym = txtAcroymn.Text.Trim();
            updateCategory.creator_id =  StartPage._loggedInUser.user_id;
            updateCategory.active = (checkBoxActive.Checked) ? active + 1 : active;
            var validationResult = ValidateFields(updateCategory.acronym, updateCategory.name);
            if (!validationResult)
                MessageBox.Show("Please enter required fields", "Error");
            else
            {
                using (emedEntities db = new emedEntities())
                {
                    db.Entry(updateCategory).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Category Updated Successfully!", "Message");
                    Close();
                }
            }
           
        }
        private void RefreshData()
        {
            CategoryControl.fromCategoryControl.LoadCategory();
        }


    }
}
