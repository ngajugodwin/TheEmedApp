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
    public partial class TemplateControl : UserControl
    {

        private user user = new user();
        public static UserAccountControl fromUserAccountControl;
        public TemplateControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
                
        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void Delete()
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           
        }
        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

       
    }
}
