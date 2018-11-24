using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eMed.View.Controls;

namespace eMed.View
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "Add":
                    emptyPanel.Controls.Clear();
                    emptyPanel.Visible = true;
                    UserAccountControl upc = new UserAccountControl();
                    emptyPanel.Controls.Add(upc);
                    //emptyPanel.Dock = DockStyle.Fill;
                    upc.Show();
                    //emptyPanel.Controls.Add(upc);
                    break;
                case "Services and Catalogs":
                    emptyPanel.Controls.Clear();
                    emptyPanel.Visible = true;
                    ServicesAndCatalogControl sacc = new ServicesAndCatalogControl();
                    emptyPanel.Controls.Add(sacc);
                    sacc.Show();
                    break;
                case "Document":
                    emptyPanel.Controls.Clear();
                    emptyPanel.Visible = true;
                    TemplateControl temp = new TemplateControl();
                    emptyPanel.Controls.Add(temp);
                    temp.Show();
                    break;
                case "Categories":
                    emptyPanel.Controls.Clear();
                    emptyPanel.Visible = true;
                    CategoryControl category = new CategoryControl();
                    emptyPanel.Controls.Add(category);
                    category.Show();
                    break;
                case "Schedule List":
                    emptyPanel.Controls.Clear();
                    emptyPanel.Visible = true;
                    SchedulerControl scl = new SchedulerControl();
                    emptyPanel.Controls.Add(scl);
                    scl.Show();
                    break;
                case "General":
                    emptyPanel.Controls.Clear();
                    emptyPanel.Visible = true;
                    MessagingControl msgc = new MessagingControl();
                    emptyPanel.Controls.Add(msgc);
                    msgc.Show();
                    break;
                case "TestTest":
                    emptyPanel.Controls.Clear();
                    emptyPanel.Visible = true;
                    Testing te = new Testing();
                    emptyPanel.Controls.Add(te);
                    te.Show();
                    break;
                default:
                    emptyPanel.Controls.Clear();
                    emptyPanel.Visible = false;
                    break;
            }
        }
    }
}
