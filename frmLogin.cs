using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsRemaxAdminApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        string userName, password;

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            userName = txtName.Text.Trim();
            password = txtPassword.Text.Trim();
         
            OleDbConnection mycon; //try to declarate variable locally possible
            mycon = new OleDbConnection();
            mycon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\sunny\source\repos\420-DA3-AS\prjWinCsRemaxAdminApp\Remax.mdb";
            mycon.Open();

            if (rdobtnAdmin.Checked)
            {
                
                string sql = "SELECT EmpName, EmpPassword FROM Admin WHERE(EmpName = '" + userName + "') and(EmpPassword='" + password + "')";
                OleDbCommand mycmd = new OleDbCommand(sql, mycon);
                OleDbDataReader myRder = mycmd.ExecuteReader();  // if sql command is wrong, will display here     
                if (myRder.HasRows == true)
                {
                    mycon.Close();
                    frmAdmin frmadmin = new frmAdmin();
                    this.Hide();
                    frmadmin.ShowDialog();
                    Application.ExitThread();
                     
                }
                else
                {
                    mycon.Close();
                    MessageBox.Show("UserName or Password not Found,try again");
                    txtPassword.Clear();
                    txtName.Focus();
                }

            }
            else if (rdoBtnAgent.Checked)
            {

                string sqla = "SELECT EmpName, EmpPassword FROM Agent WHERE(EmpName = '" + userName + "') and(EmpPassword='" + password + "')";
                OleDbCommand mycmda = new OleDbCommand(sqla, mycon);
                OleDbDataReader myRdera = mycmda.ExecuteReader();
                if (myRdera.HasRows == true)
                {
                    mycon.Close();
                    frmAgent frmagent = new frmAgent();
                    this.Hide();
                    frmagent.ShowDialog();
                    Application.ExitThread();

                }
                else
                {
                    mycon.Close();
                    MessageBox.Show("UserName or Password not Found,try again");
                    txtPassword.Clear();
                    txtName.Focus();
                }
            }
                    
            else if (rdoBtnClient.Checked)
               {

                    string sqlc = "SELECT EmpName, EmpPassword FROM Client WHERE(EmpName = '" + userName + "') and(EmpPassword='" + password + "')";
                    OleDbCommand mycmdc = new OleDbCommand(sqlc, mycon);
                    OleDbDataReader myRderc = mycmdc.ExecuteReader();
                if (myRderc.HasRows == true)
                {
                    mycon.Close();
                    frmClient frmclient = new frmClient();
                    this.Hide();
                    frmclient.ShowDialog();
                    Application.ExitThread();
                }
                else
                {
                    mycon.Close();
                    MessageBox.Show("UserName or Password not Found,try again");
                    txtPassword.Clear();
                    txtName.Focus();
                }
            }
                              
        }

      
    }
}
