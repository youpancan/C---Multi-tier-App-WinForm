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
    public partial class frmAgent : Form
    {
        public frmAgent()
        {
            InitializeComponent();
        }

        DataSet myset;
        DataTable tabClient, tabHouse;
        OleDbDataAdapter adpClient,adpHouse; // need to load and update the data employee table,so declare golbal variable
        OleDbConnection mycon;
        int currentposition = 0;
        string mode;





        private void DisplayClient()
        {
            txtClientId.Text = tabClient.Rows[currentposition]["ClientId"].ToString();
            txtClientName.Text = tabClient.Rows[currentposition]["ClientName"].ToString();
            txtClientType.Text = tabClient.Rows[currentposition]["ClientType"].ToString();
            txtRefEmpId.Text = tabClient.Rows[currentposition]["RefEmpId"].ToString();
        }


        private void DisplayHouse()
        {
            txtHouseNumber.Text = tabClient.Rows[currentposition]["HouseNumber"].ToString();
            txtOwner.Text = tabClient.Rows[currentposition]["Owner"].ToString();
            txtHouseType.Text = tabClient.Rows[currentposition]["HouseType"].ToString();
            txtRefEmpId.Text = tabClient.Rows[currentposition]["RefEmpId"].ToString();
        }


        private void btnF_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            DisplayClient();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            if (currentposition < tabClient.Rows.Count - 1)
            {
                currentposition++;
                DisplayClient();
            }
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            if (currentposition > 0)
            {
                currentposition--;
                DisplayClient();
            }
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            currentposition = tabClient.Rows.Count - 1;
            DisplayClient();
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtClientId.Focus();
            txtClientName.Text = txtClientType.Text = txtRefEmpId.Text= "";
            
         
            lbInfo.Text = "---ADDING MODE---";



        }

        private void btnE_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtClientId.Focus();
            lbInfo.Text = "---EDITING MODE---";
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            string name = txtClientName.Text.Trim();
           
    
            string clientId = txtClientId.Text.Trim();
            string clientType = txtClientType.Text.Trim();
            string refEmpid = txtRefEmpId.Text.Trim();
       

            DataRow myrow = (mode == "add") ? tabClient.NewRow() : tabClient.Rows[currentposition];
            myrow["ClientName"] = name;
            myrow["ClientId"] = clientId;
            myrow["ClientType"] = clientType;
            myrow["RefEmpId"] = refEmpid;

            if (mode == "add")
            {
                tabClient.Rows.Add(myrow);

                currentposition = tabClient.Rows.Count - 1;
            }


            //now we need to update (or synchronize) the contents of dataset -> the database
            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(adpClient);
            adpClient.Update(myset, "Employees");
            //update the contents of database -> the dataset
            myset.Tables.Remove("Employees");
            OleDbCommand mycmd = new OleDbCommand("select * FROM Employees", mycon);
            adpClient = new OleDbDataAdapter(mycmd);
            adpClient.Fill(myset, "Employees"); //the dataset name can be changed
            tabClient = myset.Tables["Employees"];

            mode = "";
            DisplayClient();





        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtClientId.Text = txtClientName.Text = txtClientType.Text = txtRefEmpId.Text = "";
        }

        private void btnHouseMgn_Click(object sender, EventArgs e)
        {
            myset = new DataSet();
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\sunny\source\repos\420-DA3-AS\prjWinCsRemaxAdminApp\Remax.mdb");
            mycon.Open();


            //load table employees in the dataset
            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM MontrealHouses", mycon);
            adpClient = new OleDbDataAdapter(mycmd);
            adpClient.Fill(myset, "House");
            tabClient = myset.Tables["House"];
            DisplayHouse();


        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            DisplayHouse();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentposition < tabClient.Rows.Count - 1)
            {
                currentposition++;
                DisplayHouse();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentposition > 0)
            {
                currentposition--;
                DisplayHouse();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentposition = tabClient.Rows.Count - 1;
            DisplayHouse();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtHouseNumber.Focus();
            lbInfo.Text = "---EDITING MODE---";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtHouseNumber.Text = txtOwner.Text = txtRefEmpId.Text = txtHouseType.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tabHouse.Rows[currentposition].Delete();
            //now we need to update (or synchronize) the contents of dataset -> the database

            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(adpHouse);
            adpHouse.Update(myset, "House");

            //update the contents of database -> the dataset
            myset.Tables.Remove("House");
            OleDbCommand mycmd = new OleDbCommand("select * FROM MontrealHouses", mycon);
            adpHouse = new OleDbDataAdapter(mycmd);
            adpHouse.Fill(myset, "House"); //the dataset name can be changed
            tabHouse = myset.Tables["House"];
            currentposition = 0;
            DisplayHouse();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string housenumber = txtHouseNumber.Text.Trim();
            string owner = txtOwner.Text.Trim();
            string houseType = txtHouseType.Text.Trim();
            string refEmpid = txtRefEmpId.Text.Trim();


            DataRow myrow = (mode == "add") ? tabHouse.NewRow() : tabHouse.Rows[currentposition];
            myrow["HouseNumber"] = housenumber;
            myrow["Owner"] = owner;
            myrow["HouseType"] = houseType;
            myrow["RefEmpId"] = refEmpid;

            if (mode == "add")
            {
                tabHouse.Rows.Add(myrow);

                currentposition = tabHouse.Rows.Count - 1;
            }


            //now we need to update (or synchronize) the contents of dataset -> the database
            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(adpClient);
            adpClient.Update(myset, "House");
            //update the contents of database -> the dataset
            myset.Tables.Remove("House");
            OleDbCommand mycmd = new OleDbCommand("select * FROM MontrealHouses", mycon);
            adpClient = new OleDbDataAdapter(mycmd);
            adpClient.Fill(myset, "House"); //the dataset name can be changed
            tabClient = myset.Tables["House"];

            mode = "";
            DisplayHouse();
        }

        private void btnClientMgn_Click(object sender, EventArgs e)
        {
            myset = new DataSet();
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\sunny\source\repos\420-DA3-AS\prjWinCsRemaxAdminApp\Remax.mdb");
            mycon.Open();


            //load table employees in the dataset
            OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Client", mycon);
            adpClient = new OleDbDataAdapter(mycmd);
            adpClient.Fill(myset, "Client");
            tabClient = myset.Tables["Client"];
            DisplayClient();

        }






    }
}
