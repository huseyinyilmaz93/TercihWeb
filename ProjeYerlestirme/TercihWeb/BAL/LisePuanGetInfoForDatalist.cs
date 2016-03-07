using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class LisePuanGetInfoForDatalist
    {
        GetDBConnection con;
        public LisePuanGetInfoForDatalist (string databaseName)
	    {
            con = new GetDBConnection(DAL.DataProvider.SqlServer, databaseName);
            con.OpenConnection();
	    }
        ~LisePuanGetInfoForDatalist()
        {
            con.CloseConnection();
        }
        /*
          parametreler[0] = Fen Lisesi
          parametreler[1] = Anadolu Lisesi
          parametreler[2] = Sosyal Bilimler Lisesi
          parametreler[3] = Mesleki ve Teknik Anadolu Lisesi
          parametreler[4] = Anadolu İmam Hatip Lisesi
          parametreler[5] = İl
          parametreler[6] = İlce
          parametreler[7] = Alt sınır
          parametreler[8] = Üst sınır
       */
        public DataTable GetList(string[] parametreler)
        {
            IDataReader idr = null;

            string strCommand = null;
            strCommand = string.Concat( TamArama() , "  WHERE ");
            
            string temp = strCommand;
            if (parametreler[5] != null) strCommand = string.Concat(strCommand, " ilAdi = N'", parametreler[5], "' AND");
            if (parametreler[6] != null) strCommand = string.Concat(strCommand, " ilceAdi = N'", parametreler[6], "' AND");
            if (parametreler[7] != null) strCommand = string.Concat(strCommand, " tabanPuani >= ", parametreler[7], " AND");
            if (parametreler[8] != null) strCommand = string.Concat(strCommand, " tabanPuani <= ", parametreler[8], " AND");

            strCommand = string.Concat(strCommand, " (");
            if (parametreler[0] != null) strCommand = string.Concat(strCommand, " turAdi = N'", parametreler[0], "'    OR");
            if (parametreler[1] != null) strCommand = string.Concat(strCommand, " turAdi = N'", parametreler[1], "'    OR");
            if (parametreler[2] != null) strCommand = string.Concat(strCommand, " turAdi = N'", parametreler[2], "'    OR");
            if (parametreler[3] != null) strCommand = string.Concat(strCommand, " turAdi = N'", parametreler[3], "'    OR");
            if (parametreler[4] != null) strCommand = string.Concat(strCommand, " turAdi = N'", parametreler[4], "'    OR");

            if (string.Concat(temp," (").Equals(strCommand)) strCommand = TamArama();
            else
	        {
                    strCommand = strCommand.Substring(0,strCommand.Length-5);
                    if (strCommand.IndexOf('(') > -1) strCommand = string.Concat(strCommand, " )");
            }

            strCommand = string.Concat(strCommand, " ORDER BY tabanPuani DESC");
            idr = con.manager.ExecuteReader(CommandType.Text, strCommand);
            DataTable dt = new DataTable();
            dt.Columns.Add("İl", typeof(string));
            dt.Columns.Add("İlçe", typeof(string));
            dt.Columns.Add("Lise Adı", typeof(string));
            dt.Columns.Add("Lise Türü", typeof(string));
            dt.Columns.Add("Yabancı Dil", typeof(string));
            dt.Columns.Add("Taban Puan", typeof(string));

            while (idr.Read())
            {
                dt.Rows.Add(idr[0], idr[1], idr[2], idr[3], idr[4], idr[5]);
            }

            return dt;
        }

        protected string TamArama()
        {
            return string.Concat(" SELECT Il.ilAdi,Ilce.ilceAdi,Okul.okulAdi,OkulTuru.turAdi,YabanciDil.dilAdi,Okul.tabanPuani ",
                        " FROM Okul INNER JOIN Iletisim ON Iletisim.iletNo = Okul.iletNo ",
                            " INNER JOIN Ilce ON Iletisim.ilceNo = Ilce.ilceNo ",
                                " INNER JOIN Il ON Il.ilNo = Iletisim.ilNo ",
                                    " INNER JOIN OkulTuru ON OkulTuru.turNo = Okul.turNo ",
                                        " INNER JOIN YabanciDil ON YabanciDil.dilNo = Okul.dilNo ");
        }
        
    }
}
