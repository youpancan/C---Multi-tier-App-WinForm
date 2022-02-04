using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxAdminApp
{

    public class clsClient
    {
        private string vClientName;
        private string vClientNumber;
        private string vClientPassword;
        private string vRefEmpId;
        private string vClientType;

        public clsClient()
        {
            
        }

        public clsClient(string ClientName, string ClientNumber, string ClientPassword, string ClientType, string RefEmpId)
        {
            this.vClientName = ClientName;
            this.vClientNumber = ClientNumber;
            this.vClientPassword = ClientPassword;
            this.ClientType = ClientType;
            this.vRefEmpId = RefEmpId;
        }

        public string ClientNumber
        {
            get => vClientNumber;
            set => vClientNumber = value;
        }

        public string ClientName
        {
            get => vClientName;
            set => vClientName = value; 
            
        }

        public string ClientPassword
        {
            get => vClientPassword;
            set => vClientPassword = value;
        }

        public string RefEmpId
        {
            get => vRefEmpId;
            set => vRefEmpId = value;
        }

        public string ClientType
        {
            get => vClientType;
            set => vClientType = value;
        }

        public clsListHouse GetAllHouses()
        {
            throw new System.NotImplementedException();
        }

        //public clsListAgent GetAllAgents()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}