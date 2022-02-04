using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinCsRemaxAdminApp
{
    class clsAdmin
    {
        private int vadminId;
        private string vadminName;
        private string vadminPassword;

        public clsAdmin()
        {
            
        }

        public clsAdmin(int adminId, string adminName, string adminPassword)
        {
            this.vadminId = adminId;
            this.vadminName = adminName;
            this.vadminPassword = adminPassword;
        }

       public int AdminId
        {
            get => vadminId;
            set => vadminId = value;
        }


        public string AdminName

        {
            get => vadminName;
            set => vadminName = value;
        }

        public string AdminPassword
        {
            get => vadminPassword;
            set => vadminPassword = value;
        }



    }
}
