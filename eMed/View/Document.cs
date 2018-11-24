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
using System.IO;
using eMed.Model;

namespace eMed.View
{
    public partial class Document : DevExpress.XtraEditors.XtraForm
    {
        private qm_tree parentTree;
        private TreeNode parentNode;
        private qm_sop _docxPath;
        public Document(qm_tree parentTree, TreeNode parentNode)
        {
            InitializeComponent();
            this.parentTree = parentTree;
            this.parentNode = parentNode;
        }
        public Document(qm_sop docxPath)
        {
            InitializeComponent();
            _docxPath = docxPath;
            LoadDocument(_docxPath);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName = txtDocumentName.Text;
            string destionationFolder = @"C:\Users\iME\Documents\sop\";
            string pathstring = Path.Combine(destionationFolder, fileName);
            try
            {
                qm_sop sop = new qm_sop();
                sop.filePath = pathstring;
                sop.title = txtDocumentName.Text;
                sop.created_at = DateTime.Now;
                sop.qm_tree_id = parentTree.qm_tree_id;
                if (txtSourceFile.Text == string.Empty || pathstring == string.Empty)
                    MessageBox.Show("Source path and file name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    File.Copy(txtSourceFile.Text, pathstring);
                    using (emedEntities db = new emedEntities())
                    {

                        db.qm_sop.Add(sop);
                        db.SaveChanges();
                        //TreeNode newNode = new TreeNode(sop.title + " - Document");
                        //newNode.Tag = parentTree;
                        //parentNode.Nodes.Add(newNode);
                        MessageBox.Show("Document has been sent for approval", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void pictureBoxUploadDocument_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string sourcePath = txtSourceFile.Text;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pdfViewer1.DocumentFilePath = ofd.FileName;
                txtSourceFile.Text = pdfViewer1.DocumentFilePath;
            }

        }

        private void pictureBoxClearDocument_Click(object sender, EventArgs e)
        {

        }
        private void LoadDocument(qm_sop path)
        {
            pdfViewer1.DocumentFilePath = path.filePath;
            txtDocumentName.Text = path.title;
            txtSourceFile.Text = path.filePath;
             
        }
    }
}