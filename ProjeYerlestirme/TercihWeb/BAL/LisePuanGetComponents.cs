using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class LisePuanGetComponents
    {
        GetDBConnection con;
        public LisePuanGetComponents (string databaseName)
	    {
            con = new GetDBConnection(DAL.DataProvider.SqlServer, databaseName);
            con.OpenConnection();
	    }
        ~LisePuanGetComponents()
        {
            con.CloseConnection();
        }
        public List<string> GetLiseTuruForCheckList()
        {
            IDataReader idr = con.manager.ExecuteReader(CommandType.Text, "SELECT turAdi FROM OkulTuru");
            List<string> list = new List<string>();
            while (idr.Read())
            {
                list.Add(idr.GetString(0));
            }
            return list;
        }
        public List<string> GetIlForDropdown()
        {
            IDataReader idr = con.manager.ExecuteReader(CommandType.Text, "SELECT ilAdi FROM Il");
            List<string> list = new List<string>();
            list.Add("--Seçiniz--");
            while (idr.Read())
            {
                list.Add(idr.GetString(0));
            }
            return list;
        }
        public List<string> GetIlceForDropdown(string il)
        {
            IDataReader idr = con.manager.ExecuteReader(CommandType.Text, string.Concat("SELECT ilceAdi FROM Il INNER JOIN Iletisim ON Il.ilNo = Iletisim.ilNo",
	            " INNER JOIN Ilce ON Iletisim.ilceNo = Ilce.ilceNo WHERE Il.ilAdi = N'",il,"'"));
            List<string> list = new List<string>();
            list.Add("--Seçiniz--");
            while (idr.Read())
            {
                list.Add(idr.GetString(0));
            }
            return list;
        }
    }
}
