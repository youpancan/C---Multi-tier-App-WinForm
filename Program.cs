using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsRemaxAdminApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());

            //frmLogin frmlogin = new frmLogin();
            //frmlogin.ShowDialog();
            //if(frmlogin.DialogResult ==  DialogResult.OK)
            //{
            //    frmlogin.Dispose();
            //    Application.Run(new  )
            //}


        }
    }
}
