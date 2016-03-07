using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;
using System.Resources;

namespace BAL
{
    class GetDBConnection:IDisposable
    {
        public DBManager manager;
        public GetDBConnection(DataProvider dp,string database)
        {
            database = "DB_Huseyin";
            this.manager = new DBManager(DataProvider.SqlServer, string.Concat("CONNECTIONSTRING"));
        }
        public void OpenConnection()
        {
            manager.Open();
        }
        public void CloseConnection()
        {
            manager.Close();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
