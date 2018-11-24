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
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using eMed.SchedulerSet;
using eMed.View.Controls;
using DevExpress.XtraEditors;

namespace eMed.View
{
    public partial class StartPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly user _authenticatedUser;
        public static user _loggedInUser;
        private readonly Search _search;
        public static StartPage fromStartPage;
        private NewPatient newPatient = new NewPatient();
        private emedEntities db;
        emedEntities dbHelper = new emedEntities();
        private MessagingControl msControl;

        //Favourite/QM Panel  
        int indexOfPanel;
        List<PanelControl> panelList = new List<PanelControl>();

        public StartPage()
        {

        }
        public StartPage(user authenticatedUser)
        {
            InitializeComponent();
            db = new emedEntities();
            _authenticatedUser = authenticatedUser;
            LoadUserPreference(_authenticatedUser);
            msControl = new MessagingControl();

            //barHeaderCurrentUser.Caption = _authenticatedUser.username;
        }

        public StartPage(Search search)
        {
            //Constuctor 2: Initialize component

            InitializeComponent();
            this._search = search;
        }
        private void StartPage_Load(object sender, EventArgs e)
        {
            fromStartPage = this;
            _loggedInUser = _authenticatedUser;
            LoadRecentSearchPatient();
            InitPanel();
            LoadTempSearch();
        }

        private void LoadUserPreference(user authenticatedUser)
        {
            //Load Authenticated User Preference and Default Settings

            //TODO: Load more user settings
            barHeaderCurrentUser.Caption = authenticatedUser.firstname;
            UserLookAndFeel.Default.SetSkinStyle(authenticatedUser.skin_name);

            //foreach (var item in recent_patient)
            //{
            //    patientName2 = item.patient.patient_id;
            //}

        }
        private void barButtonSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string data = string.Empty;
            var search = new Search(ButtonEventSearch.SearchPatient);
            search.ShowDialog();
        }
        private void LoadRecentSearchPatient()
        {
            //var recentPatient = GetRecentPatientBasedOnId(_authenticatedUser.user_id);
            //foreach (var item in recentPatient)
            //{
            //    dataGridViewRecentOpenPatient.DataSource= item.users.ToList();
            //}
            //label3.Text = recentPatient;
            //dataGridViewRecentOpenPatient.DataSource = recentPatient;
            var result = TestData(_authenticatedUser.user_id);
            dataGridViewRecentOpenPatient.DataSource = result.ToList();


        }

        List<DepartmentDto> TestData(int userId)
        {
            List<DepartmentDto> result;
            using (var db = new emedEntities())
            {
                result = db.departments.Where(t => t.user_detail.Any(x => x.user_id == 4)).Select(t => new DepartmentDto
                {

                    department_id = t.department_id,
                    department_name = t.department_name,
                    user_id = t.user_detail.Where(a => a.user_id == userId).FirstOrDefault().user_id,
                    firstname = t.user_detail.Where(a => a.user_id == userId).FirstOrDefault().user.firstname,
                    lastname = t.user_detail.Where(a => a.user_id == userId).FirstOrDefault().user.lastname
                }).ToList();
            }
            return result;

        }
        private void dataGridViewRecentOpenPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var patient = OpenRecentlySelectedPatient(new patient());
            if (patient == null)
            {
                MessageBox.Show("cannot load data");
                return;

            }
            else
            {
                PatientDashboard pd = new PatientDashboard(patient);
                TabPage tabpage = new TabPage();
                tabpage.Text = pd.Text = $"Record Card {patient.lastname} {patient.firstname}";
                tabControl1.TabPages.Add(tabpage);
                pd.TopLevel = false;
                pd.Parent = tabpage;
                pd.Dock = DockStyle.Fill;
                StartPage.fromStartPage.tabControl1.SelectedTab = tabpage;
                pd.Show();

            }

        }
        private patient OpenRecentlySelectedPatient(patient selectedPatient)
        {
            if (dataGridViewRecentOpenPatient.CurrentRow.Index != -1)
            {
                selectedPatient.patient_id = Convert.ToInt32(dataGridViewRecentOpenPatient.CurrentRow.Cells["Id"].Value);
                using (emedEntities db = new emedEntities())
                {
                    selectedPatient = db.patients.FirstOrDefault(p => p.patient_id == selectedPatient.patient_id);
                }
            }
            return selectedPatient;
        }
        private void LoadTempSearch()
        {
           var result =  GetRecentPatientBasedOnId(_authenticatedUser.user_id);
           
            dataGridViewRecentOpenPatient.DataSource = result.Take(8).ToList();
        }
        
        private List<TempSearchDto> GetRecentPatientBasedOnId(int userId)
        {
            var tempSearch = new List<TempSearchDto>();
            using (emedEntities db = new emedEntities())
            {
                tempSearch = (
                     from ts in db.temp_search
                     join p in db.patients on ts.patient_id equals p.patient_id
                     where ts.user_id == userId
                     orderby ts.created_at descending
                     select new TempSearchDto 
                     {
                         Id = ts.patient_id,
                         PatientName = p.firstname +" "+ p.lastname
                     }).ToList();

            }
            return tempSearch;
        }

        private List<patient> SearchPatient(string search)
        {
            //Composition Implementation (StartPage Has-a Search Function): Search Function reside in Search Class
            //return the search result gotten from implementation class

            return _search.PatientSearch(search);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtPatientSearch.Text.Trim();
            StartPage sp = new StartPage(new Search());
            var result = sp.SearchPatient(search);
            if (result != null)
            {
                var s = new Search(result, search, ButtonEventSearch.SearchPatient);
                txtPatientSearch.Clear();
                s.ShowDialog();
            }
        }

        /**********************Back Stage View Section**********************/
        private void StartPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    if (MessageBox.Show("Are you sure you want to exit?",
                                        "Exit Application",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    break;
            }
            */
        }

        private void btnNavigation_Click(object sender, EventArgs e)
        {
            Options option = new Options();
            TabPage tabpage = new TabPage();
            tabpage.Text = option.Text;
            tabControl1.TabPages.Add(tabpage);
            option.TopLevel = false;
            option.Parent = tabpage;
            option.Show();
            option.Dock = DockStyle.Fill;
            tabControl1.SelectedTab = tabpage;
        }

        private void backstageViewButtonItem3_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            Options option = new Options();
            TabPage tabpage = new TabPage();
            tabpage.Text = option.Text;
            tabControl1.TabPages.Add(tabpage);
            option.TopLevel = false;
            option.Parent = tabpage;
            option.Show();
            option.Dock = DockStyle.Fill;
            tabControl1.SelectedTab = tabpage;
        }

        private void backstageViewButtonSwitchUser_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }

        private void backstageViewButtonChangeUser_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            Close();
            Login login = new Login();
            login.ShowDialog();
        }

        /***************Start User Preference Settings****************/
        private void backstageViewButtonExit_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            Application.Exit();
        }


        private void lblUserSettings_Click_1(object sender, EventArgs e)
        {
            UserPreference upf = new UserPreference(_loggedInUser);
            upf.ShowDialog();
        }
        private void lblUserSettings_MouseHover_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void lblUserSettings_MouseEnter_1(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.Hand;
            lblUserSettings.Font = new Font(lblUserSettings.Font.Name, lblUserSettings.Font.SizeInPoints, FontStyle.Underline);
        }

        private void lblUserSettings_MouseLeave_1(object sender, EventArgs e)
        {
            lblUserSettings.Font = new Font(lblUserSettings.Font.Name, lblUserSettings.Font.SizeInPoints, FontStyle.Regular);
        }

        /***************End User Preference Settings****************/

        /***************Start Bar Button Controls*********************/
        private void barButtonInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PatientDashboard.fromPatientDash.OpenInvoice();
        }

        private void barButtonNewPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewPatient newPatient = new NewPatient();
            TabPage tabpage = new TabPage();
            tabpage.Text = newPatient.Text;
            tabControl1.TabPages.Add(tabpage);
            newPatient.TopLevel = false;
            newPatient.Parent = tabpage;
            newPatient.Show();
            newPatient.Dock = DockStyle.Fill;
            tabControl1.SelectedTab = tabpage;
            patientControl.Visible = true;
            ribbonControl1.SelectedPage = patientControl;
        }
        private void SaveNewPatient()
        {

            patient p = newPatient.GetFilledPatient();

            if (p == null)
                MessageBox.Show("User Cannot be Added", "System Error");
            else
            {
                dbHelper.patients.Add(p);
                dbHelper.SaveChanges();
                MessageBox.Show("Patient has been added Successfully", "Message");
            }
            newPatient.Clear();


        }

        private void barButtonPatientSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveNewPatient();
        }

        private void barButtonScheduler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Scheduler scheduler = new Scheduler();
            TabPage tabpage = new TabPage();
            tabpage.Text = scheduler.Text;
            tabControl1.TabPages.Add(tabpage);
            scheduler.TopLevel = false;
            scheduler.Parent = tabpage;
            scheduler.Show();
            scheduler.Dock = DockStyle.Fill;
            tabControl1.SelectedTab = tabpage;
            //ribbonControl1.SelectedPage = patientControl;
        }

        private void barButtonAttendance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TakeAttendance attendance = new TakeAttendance();
            attendance.Text = "Timerecording";
            attendance.ShowDialog();
        }

        private void barButtonSendEmail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Email sendEmail = new Email();
            sendEmail.ShowDialog();
        }

        private void barButtonSendSMS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sms sendSms = new Sms();
            sendSms.ShowDialog();
        }

        /***************End Bar Button Controls*********************/
        //private UCApplication.UserControls.UCForm1 ucForm1;



        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(msControl.usernamee);

        }

        /*************Quality Management System QMS Section************/
        private void InitPanel()
        {
            panelList.Add(panelFavourite);
            panelList.Add(panelQMS);
        }

        private void btnFav_Click(object sender, EventArgs e)
        {
            if (indexOfPanel > 0)
                panelList[--indexOfPanel].BringToFront();
            treeViewQMS.Nodes.Clear();
        }

        private void btnQM_Click(object sender, EventArgs e)
        {
            if (indexOfPanel < panelList.Count - 1)
                panelList[++indexOfPanel].BringToFront();            
            PopulateTree();
        }

        public void PopulateTree()
        {
            treeViewQMS.Nodes.Clear();
            using (emedEntities db = new emedEntities())
            {
                var q = (from i in db.qm_tree
                         select i);

                TreeNode treeNode = new TreeNode("QualityManagementSystem");
                treeViewQMS.Nodes.Add(treeNode);
                this.treeViewQMS.SelectedNode = this.treeViewQMS.Nodes[0];

                foreach (var item in q)
                {
                    if (item.isChild.Value)
                    {
                        continue;
                    }
                    List<TreeNode> childNodes = new List<TreeNode>();
                    ReadChild(item, childNodes, q.ToList(), null);
                    TreeNode nodes = new TreeNode(item.title, childNodes.ToArray());
                    nodes.Tag = item;
                    treeNode.Nodes.Add(nodes);
                }
            }
        }
        private void ReadChild(qm_tree item, List<TreeNode> childNodes, List<qm_tree> items, Tree tree)
        {
            emedEntities db = new emedEntities();
            if (item != null && item.childs != null)
            {
                foreach (string n in item.childs.Split(','))
                {
                    qm_tree current_tree = items.FirstOrDefault(t => t.title == n);
                    List<TreeNode> current_childNodes = new List<TreeNode>();

                    if (current_tree == null)
                        continue;
                   
                    List<qm_sop> documentInNode = db.qm_sop.Where(sop => sop.qm_tree_id == current_tree.qm_tree_id && sop.status.Value == 1).ToList();
                    ReadDocument(documentInNode, current_childNodes);
                    ReadChild(current_tree, current_childNodes, items, null);
                    TreeNode temp = new TreeNode(n, current_childNodes.ToArray());
                    string parentIcon = @"C:\Users\iME\Documents\MyProj\FinalProject\Icons\folder_open.png";
                    registerIcon(parentIcon);
                    temp.ImageKey = parentIcon;
                    temp.Tag = current_tree;
                    childNodes.Add(temp);
                }
            }
        }
       
        public void ReadDocument(List<qm_sop> doc, List<TreeNode> items)
        {
            doc.ForEach(document =>
            {
                TreeNode newNode = new TreeNode(document.title + " - Document");
                newNode.Tag = document;
                //any icon for test ??
                //change this to doucment.imagePath later on
                String documentIconPath = @"C:\Users\iME\Documents\MyProj\FinalProject\Icons\invoice.png";
                registerIcon(documentIconPath);
                newNode.ImageKey = documentIconPath;
                items.Add(newNode);
            });
        }

        private string registerIcon(string iconPath)
        {
            if (treeViewQMS.ImageList == null)
            {
                treeViewQMS.ImageList = new ImageList();
            }
            
            if (iconPath != null)
            {
                treeViewQMS.ImageList.Images.Add(iconPath,Image.FromFile(iconPath));
            }
            
            return iconPath;
        }
        
        private void treeViewQMS_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripQM.Show(Cursor.Position);
            }
        }
        public Object getSelectedTree()
        {
            return treeViewQMS.SelectedNode.Tag;
        }


        public String getSelectedNodeID()
        {
            if (getSelectedTree() == null) return "";
            try
            {
                return ((qm_tree)getSelectedTree()).qm_tree_id + "";
            }
            catch
            {
               return ((qm_sop)getSelectedTree()).qm_sop_id + "";
            }
        }
        public bool isDocument()
        {
            if (getSelectedNodeID() == "")
            {
                return false;
            }
            try
            {
                qm_sop obj_test = ((qm_sop)getSelectedTree());
                return true;
            }
            catch
            {
                return false;
            }
        }
        //that part?? (document is qm_sop and folder is qm_tree)
        //yup.... ok, so go back 
        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDocument())
            {
                
                //some message here
                MessageBox.Show("Oops, a document cannot have a child", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            qm_tree newTree = new qm_tree();
            Folder an = new Folder(treeViewQMS.SelectedNode, newTree);
            an.ShowDialog();
            TreeNode underNameNode = new TreeNode(Folder.fromAddFolder.txtFolderName.Text);
            underNameNode.Tag = newTree;
            treeViewQMS.SelectedNode.Nodes.Add(underNameNode);
        }

        private void createDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDocument())
            {
                MessageBox.Show("Oops, a document cannot have a child", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Document at = new Document(((qm_tree)getSelectedTree()), treeViewQMS.SelectedNode);
            //at.ShowDialog();

            Document at = new Document(((qm_tree)getSelectedTree()), treeViewQMS.SelectedNode);
            TabPage tabpage = new TabPage();
            tabpage.Text = "New Document";
            tabControl1.TabPages.Add(tabpage);
            at.TopLevel = false;
            at.Parent = tabpage;
            at.Dock = DockStyle.Fill;
            tabControl1.SelectedTab = tabpage;
            at.Show();
        }

       

        private void treeViewQMS_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                var obj = ConvertObjectToType();
                Document dc = new Document(obj);
                TabPage tabpage = new TabPage();
                tabpage.Text = "New Document";
                tabControl1.TabPages.Add(tabpage);
                dc.TopLevel = false;
                dc.Parent = tabpage;
                dc.Dock = DockStyle.Fill;
                tabControl1.SelectedTab = tabpage;
                dc.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
        private qm_sop ConvertObjectToType()
        {
            
                var obj = treeViewQMS.SelectedNode.Tag;
                qm_sop typed = (qm_sop)obj;
                return typed;
        }
      

        private void editDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //edit document button
            //i dont understand your logic of folder and document so you have to do that yourself 

        }
        private void deleteDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete document button
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this document?", "Delete Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    qm_sop currentSop = (qm_sop)treeViewQMS.SelectedNode.Tag;
                    if (currentSop.GetType() == typeof(qm_tree))
                    {
                        return;
                    }
                    else if (currentSop == null)
                    {
                        MessageBox.Show("Oops, something went wrong", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var data = db.qm_sop.FirstOrDefault(q => q.qm_sop_id == currentSop.qm_sop_id);
                    db.qm_sop.Remove(data);
                    db.SaveChanges();
                    MessageBox.Show("Document deleted successfully", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Selected item is not a document", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PopulateTree();
            }

        }
        private void editFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //edit folder button
            //get qm_tree like you've seen in the download

            //save changes

            //reload the tree (slow algorithm but the most simple)
        }

        private void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete folder button
            try
            {
                qm_tree currentTree = (qm_tree)treeViewQMS.SelectedNode.Tag;
                if (currentTree.GetType() == typeof(qm_sop))
                   return;               

                else if (currentTree == null)
                {
                    MessageBox.Show("Oops, something went wrong", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // treeViewQMS.Nodes.Remove(treeViewQMS.SelectedNode);
                db.qm_tree.Remove(db.qm_tree.FirstOrDefault(qm_tree => qm_tree.qm_tree_id == currentTree.qm_tree_id));
                db.SaveChanges();
                MessageBox.Show("Folder is deleted successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Selected item is not a folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                PopulateTree();
            }
            
        }

        /*Close tab control section*/
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (tabControl1.SelectedTab == tabPage1)
                    return;
                else
                    contextMenuStripTabControl.Show(Cursor.Position);
            }

        }

        private void closeSelectedTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            tabControl1.SelectedIndex = tabControl1.TabCount - 1;
        }

        private void closeTabsToTheRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pagenumber = (tabControl1.SelectedIndex + 1);

            if (tabControl1.TabCount > 1)
            {
                TabControl.TabPageCollection tabcoll = tabControl1.TabPages;
                foreach (TabPage tabpage in tabcoll)
                {
                    tabControl1.SelectedTab = tabpage;

                    int testb = tabControl1.TabCount;

                    if (pagenumber < (tabControl1.SelectedIndex + 1))
                    {
                        // closeToolStripMenuItem_Click(sender, e);

                        tabControl1.TabPages.Remove(tabpage);
                    }
                }
            }
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Email sent");
           
        }

        private void btnQMSearch_Click(object sender, EventArgs e)
        {
            string title = txtQMSearch.Text.Trim();
            var result = SearchDocument(title);
            if (result == null)
                MessageBox.Show("No document was found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

            }
        }
        private qm_sop SearchDocument(string title)
        {
            using (emedEntities db = new emedEntities())
            {
               return db.qm_sop.FirstOrDefault(q=> q.title == title);
            }
        }
    }
}
