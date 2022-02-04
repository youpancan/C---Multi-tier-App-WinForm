using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsRemaxAdminApp
{
    public class clsCompany
    {
        private clsListEmployee vEmployees;
        private clsListHouse vHouses;
        private clsListClient vClients;

        public clsCompany()
        {
            throw new System.NotImplementedException();
        }

        public clsCompany(clsListClient Clients, clsListEmployee Employees, clsListHouse Houses)
        {
            throw new System.NotImplementedException();
        }

        //public clslistEmployee Employees
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        //public clslistHouse Houses
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        //public clslistClient Clients
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        public clsListHouse clsListHouse
        {
            get => default;
            set
            {
            }
        }

        public clsListClient clsListClient
        {
            get => default;
            set
            {
            }
        }

        public clsListEmployee clsListEmployee
        {
            get => default;
            set
            {
            }
        }
    }
}