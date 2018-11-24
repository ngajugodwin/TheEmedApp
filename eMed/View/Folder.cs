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

namespace eMed.View
{
    public partial class Folder : DevExpress.XtraEditors.XtraForm
    {
        public static Folder fromAddFolder;
        private TreeNode selectedNode;
        private qm_tree tree;
        private emedEntities db = new emedEntities();
        public Folder(TreeNode selectedNode, qm_tree tree)
        {
            InitializeComponent();
            fromAddFolder = this;
            this.selectedNode = selectedNode;
            this.tree = tree;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateFolder();
        }
        private void CreateFolder()
        {
            bool isChildNode = false;
            if (selectedNode.Text.ToLower() != "qualitymanagementsystem" || selectedNode == null)
            {
                qm_tree current_tree = db.qm_tree.FirstOrDefault(tree => tree.title == selectedNode.Text);
                if (current_tree.childs == null)
                {
                    current_tree.childs = txtFolderName.Text;
                }
                else
                {
                    current_tree.childs = current_tree.childs + "," + txtFolderName.Text;
                }
                db.SaveChanges();
                isChildNode = true;
                Close();
            }
            TreeNode node = new TreeNode();
            tree.title = txtFolderName.Text;
            tree.created_at = DateTime.Now;
            tree.creator_id = StartPage._loggedInUser.user_id;
            tree.isChild = isChildNode;
            using (emedEntities db = new emedEntities())
            {
                db.qm_tree.Add(tree);
                db.SaveChanges();
                MessageBox.Show("Added Successfully!");
            }
            Close();
        }
    }
}