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
    public partial class CategoryControl : UserControl
    {

        public static CategoryControl fromCategoryControl;

        public CategoryControl()
        {
            InitializeComponent();
            LoadCategory();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category c = new Category(ButtonEvent.Save);
            c.ShowDialog();            
        }



        public void LoadCategory()
        {
            emedEntities db = new emedEntities();
            dataGridViewCategory.DataSource = db.categories.ToList();
        }
                
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditCategory();
        }
        private void EditCategory()
        {
            category category = GetCategoryFromDB(new category());
            if (category != null)
            {
                Category cat = new Category(category, ButtonEvent.Edit);
                cat.headerText.Text = $"Edit Category : {category.name}";
                cat.Show();

            }
        }
        private category GetCategoryFromDB(category category)
        {
            if (dataGridViewCategory.CurrentRow.Index != -1)
            {
                category.category_id = Convert.ToInt32(dataGridViewCategory.CurrentRow.Cells["category_id"].Value);
                using (emedEntities db = new emedEntities())
                {
                    category = db.categories.FirstOrDefault(c => c.category_id == category.category_id);
                }

            }
            return category;
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete(new category());
        }
        private void Delete(category deleteCategory)
        {
            if (dataGridViewCategory.CurrentRow.Index != -1)
            {
                deleteCategory.category_id = Convert.ToInt32(dataGridViewCategory.CurrentRow.Cells["category_id"].Value);
                deleteCategory.name = Convert.ToString(dataGridViewCategory.CurrentRow.Cells["name"].Value);
                if (MessageBox.Show($"Are you sure you want to delete {deleteCategory.name} from the Record?", "Delete Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (emedEntities db = new emedEntities())
                    {
                        var result = db.Entry(deleteCategory);
                        if (result.State == EntityState.Detached)
                            db.categories.Attach(deleteCategory);
                        db.categories.Remove(deleteCategory);
                        db.SaveChanges();
                        MessageBox.Show("Record Deleted Successfully", "Message");
                    }
                    LoadCategory();
                }
            }
        }

        
        private List<category> Search(string name, string acronym)
        {
            using (emedEntities db = new emedEntities())
            {
                return db.categories.Where(c => c.name.Contains(name) || c.acronym.Contains(acronym)).ToList();
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            List<category> category = Search(search, search);

            dataGridViewCategory.DataSource = (category == null) ? MessageBox.Show("Categtory Not Found!") : dataGridViewCategory.DataSource = category.ToList();

        }
        private void CategoryControl_Load(object sender, EventArgs e)
        {
            fromCategoryControl = this;
        }

        private void dataGridViewCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditCategory();
        }
    }
}
