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
using DarrenLee.Media;

namespace eMed.View
{
    public partial class TakePhoto : DevExpress.XtraEditors.XtraForm
    {
        int count = 0;
        Camera myCamera = new Camera();
        public TakePhoto()
        {
            InitializeComponent();
            GetInfo();
            myCamera.OnFrameArrived += Cam_OnFrameArrived;
        }
        private void GetInfo()
        {
            var cameraDevices = myCamera.GetCameraSources();
            var cameraResolution = myCamera.GetSupportedResolutions();

            foreach (var d in cameraDevices)
                comboCameraDevice.Items.Add(d);
            foreach (var r in cameraResolution)
                comboResolution.Items.Add(r);

            comboResolution.SelectedIndex = 0;
            comboCameraDevice.SelectedIndex = 0;
        }

        private void Cam_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            pictureBoxCapture.Image = img;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string filename = Application.StartupPath + @"\" + "Picture" + count.ToString();
            myCamera.Capture(pictureBoxCapture.ImageLocation);
            
            //pictureBoxCapture.ImageLocation = filename;
            //userPictureBox.ImageLocation = ofd.FileName;
            //count++;
            MessageBox.Show("Saved");
        }

        private void comboCameraDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCamera.ChangeCamera(comboCameraDevice.SelectedIndex);
        }

        private void comboResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCamera.Start(comboResolution.SelectedIndex);
        }

        private void TakePhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            myCamera.Stop();
        }
    }
}