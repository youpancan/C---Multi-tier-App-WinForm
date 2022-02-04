using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace prjWinCsRemaxAdminApp
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        DataSet myset;
        DataTable tabHouse,tabAgent;
        OleDbDataAdapter adpHouse; // need to load and update the data employee table,so declare golbal variable
        OleDbConnection mycon;
        int currentposition = 0;

        private void btnMontreal_Click(object sender, EventArgs e)
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
            cboAgent.DataSource = tabAgent;
            cboAgent.DisplayMember = "EmpName"; 
            cboAgent.ValueMember = "EmpId";


        }




        private void Display()
        {
            txtHouseId.Text = tabHouse.Rows[currentposition]["HouseNumber"].ToString();      
            txtOwner.Text = tabHouse.Rows[currentposition]["Owner"].ToString();
            txtType.Text = tabHouse.Rows[currentposition]["HouseType"].ToString();
            String Agentid= tabHouse.Rows[currentposition]["RefEmpId"].ToString();


            ////Version databinding with DisplayMember and valueMember        
            //// txtAgent.DataBindings.Add("Text",tabAgent,"EmpName");

            //var agentName = from DataRow myrow in tabAgent.Rows
            //                where myrow.Field<String>("EmpId") == Agentid
            //                select "EmpName";

            //txtAgent.DataBindings.Add("Text", tabAgent, agentName);

            cboAgent.SelectedValue = Agentid;


            lblInfo.Text = "House " + (currentposition + 1) + "on a total of " + tabHouse.Rows.Count;
        }


        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            Display();
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            myset = new DataSet();
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\sunny\source\repos\420-DA3-AS\prjWinCsRemaxAdminApp\Remax.mdb");
            mycon.Open();


            OleDbCommand mycmd = new OleDbCommand("SELECT EmpId, EmpName FROM  Agent", mycon);
            adpHouse = new OleDbDataAdapter(mycmd);
            adpHouse.Fill(myset, "Agent");
            tabAgent = myset.Tables["Agent"];

            //load table employees in the dataset
            mycmd = new OleDbCommand("SELECT * FROM Client", mycon);
            adpHouse = new OleDbDataAdapter(mycmd);
            adpHouse.Fill(myset, "Client");
            tabHouse = myset.Tables["Client"];

            Display();

            cboAgentinClient.DataSource = tabAgent;
            cboAgentinClient.DisplayMember = "EmpName";
            cboAgentinClient.ValueMember = "EmpId";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            Display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentposition < tabHouse.Rows.Count - 1)
            {
                currentposition++;
                Display();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentposition > 0)
            {
                currentposition--;
                Display();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentposition = tabHouse.Rows.Count - 1;
            Display();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchAgent_Click(object sender, EventArgs e)
        {
        
            myset = new DataSet();
            mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\sunny\source\repos\420-DA3-AS\prjWinCsRemaxAdminApp\Remax.mdb");
            mycon.Open();


            OleDbCommand mycmd = new OleDbCommand("SELECT EmpId, EmpName FROM  Agent", mycon);
            adpHouse = new OleDbDataAdapter(mycmd);
            adpHouse.Fill(myset, "Agent");
            tabAgent = myset.Tables["Agent"];

            String AgentId = txtAgentId.Text.Trim().ToString();

            foreach(DataRow myrow in tabAgent.Rows)
            {
                if(AgentId == myrow["EmpId"].ToString())
                {
                    txtAgentName.Text = myrow["EmpName"].ToString();
                }

            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentposition = tabHouse.Rows.Count - 1;
            Display();
        }

      
    }
}
