using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.DBService;

namespace ERP.DBUlitity.Helper
{
    public class DataMgrHelper : IDataMgr
    {
        public System.Data.DataTable Query(string strCmd)
        {
            return null;
        }

        public bool Execute(string strCmd)
        {
            return false;
        }

        public bool Execute(List<string> strCmd)
        {
            return false;
        }

        public void OpenConnection()
        {
        }

        public void CloseConnection()
        {
        }
    }
}
