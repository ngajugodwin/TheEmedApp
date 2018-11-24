using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using eMed.View;

namespace eMed
{
    static class Program
    {
        //public static StartPage from;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            /*using (StartPage mainForm = new StartPage(new Model.user()))
            {
                from = mainForm;

                Application.Run(from);

            }
            */
            
        }
    }
}
