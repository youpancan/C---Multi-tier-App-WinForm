using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxAdminApp
{
    public class clsHouse
    {
        private string vType;
        private string vNumber;
        private string vOwner;
        private string vRefEmpId;

        public clsHouse()
        {

        }

        public clsHouse(string vOwner, string vRefEmpId, string vNumber, string vType)
        {
            
            this.vOwner = vOwner;
            this.vRefEmpId = vRefEmpId;
            this.vNumber = vNumber;
            this.vType = vType;
        }

       

        public string Number
        {
            get => vNumber;
            set => vNumber = value;
        }

        public string Type
        {
            get => vType;
            set => vType = value;
        }

        public string Owner
        {
            get => vOwner;
            set => vOwner = value;
        }

        public string RefEmpId
        {
            get => vRefEmpId;
            set => vRefEmpId = value;
        }
    }
}