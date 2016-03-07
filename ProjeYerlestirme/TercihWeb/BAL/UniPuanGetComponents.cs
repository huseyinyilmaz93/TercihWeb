using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class UniPuanGetComponents
    {
        GetDBConnection con;
        public UniPuanGetComponents (string databaseName)
	    {
            con = new GetDBConnection(DAL.DataProvider.SqlServer, databaseName);
            con.OpenConnection();
	    }
        ~UniPuanGetComponents()
        {
            con.CloseConnection();
        }
        public List<string> GetUniAdiForDropdown()
        {
            IDataReader idr = con.manager.ExecuteReader(CommandType.Text, "SELECT uniAdi FROM Universite");
            List<string> list = new List<string>();
            list.Add("--Seçiniz--");
            while (idr.Read())
            {
                list.Add(idr.GetString(0));
            }
            return list;
        }
        public List<string> GetFakAdiForDropdown(string uniAdi)
        {
            IDataReader idr = con.manager.ExecuteReader(CommandType.Text, "SELECT DISTINCT fakAdi FROM Fakulte INNER JOIN UniFak ON Fakulte.fakNo = UniFak.fakNo INNER JOIN Universite ON UniFak.uniNo = Universite.uniNo WHERE uniAdi = N'" + uniAdi +"'");
            List<string> list = new List<string>();
            list.Add("--Seçiniz--");
            while (idr.Read())
            {
                list.Add(idr.GetString(0));
            }
            return list;
        }
        public List<string> GetBolAdiForDropdown(string uniAdi,string fakAdi)
        {
            IDataReader idr = con.manager.ExecuteReader(CommandType.Text, "SELECT DISTINCT Bolum.bolAdi FROM Bolum INNER JOIN UniFakBol ON Bolum.bolumKodu = UniFakBol.bolumKodu INNER JOIN Fakulte ON UniFakBol.fakNo = Fakulte.fakNo INNER JOIN Universite ON UniFakBol.uniNo = Universite.uniNo WHERE uniAdi LIKE N'"+uniAdi+"' AND fakAdi LIKE N'"+fakAdi+"'");
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
