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
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }
        DataSet myset;
        DataTable tabHouse, tabAgent;
        OleDbDataAdapter adpHouse;
        OleDbConnection mycon;
        int currentposition = 0;


        private void frmClient_Load(object sender, EventArgs e)
        {
            myset = new DataSet();
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\sunny\source\repos\420-DA3-AS\prjWinCsRemaxAdminApp\Remax.mdb");
            mycon.Open();


            OleDbCommand mycmd = new OleDbCommand("SELECT EmpId, EmpName FROM  Agent", mycon);
            adpHouse = new OleDbDataAdapter(mycmd);
            adpHouse.Fill(myset, "Agent");
            tabAgent = myset.Tables["Agent"];

            //load table employees in the dataset
            mycmd = new OleDbCommand("SELECT * FROM MontrealHouses", mycon);
            adpHouse = new OleDbDataAdapter(mycmd);
            adpHouse.Fill(myset, "MontrealHouses");
            tabHouse = myset.Tables["MontrealHouses"];

            Display();
            FillComboWithAgents();
        }

        private void FillComboWithAgents()
        {

            //databinding version
            cboAgentName.DataSource = tabAgent;
            cboAgentName.DisplayMember = "EmpName";
            cboAgentName.ValueMember = "EmpId";


        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentposition = tabHouse.Rows.Count - 1;
            Display();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            Display();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentposition < tabHouse.Rows.Count - 1)
            {
                currentposition++;
                Display();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentposition > 0)
            {
                currentposition--;
                Display();
            }
        }

        private void Display()
        {
            txtHouseType.Text = tabHouse.Rows[currentposition]["HouseType"].ToString();
            txtHouseNumber.Text = tabHouse.Rows[currentposition]["HouseNumber"].ToString();
           
            String Agentid = tabHouse.Rows[currentposition]["RefEmpId"].ToString();


            cboAgentName.SelectedValue = Agentid;


            lblInfo.Text = "House " + (currentposition + 1) + " on a total of " + tabHouse.Rows.Count;
        }



    }
}
