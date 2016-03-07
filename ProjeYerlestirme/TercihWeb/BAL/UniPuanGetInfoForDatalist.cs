using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public enum VeriCekme
    {
        Bos,
        SadeceUniversite,SadeceFakulte,SadeceBolum,UniVeFak,UniVeBol,FakVeBol,UniVeBolVeFak,
        SadeceUniversitePuanla, SadeceFakultePuanla, SadeceBolumPuanla, UniVeFakPuanla, UniVeBolPuanla, FakVeBolPuanla, UniVeBolumVeFakultePuanla
    }
    public class UniPuanGetInfoForDatalist
    {
        GetDBConnection con;
        public UniPuanGetInfoForDatalist (string databaseName)
	    {
            con = new GetDBConnection(DAL.DataProvider.SqlServer, databaseName);
            con.OpenConnection();
	    }
        ~UniPuanGetInfoForDatalist()
        {
            con.CloseConnection();
        }
        /*
         * parametre[0] = uniAdi
         * parametre[1] = fakAdi
         * parametre[2] = bolAdi
         * parametre[3] = altSınır (Puan)
         * parametre[4] = ustSınır (Puan)
         * */
        public DataTable GetList(string[] parametreler,VeriCekme yontem)
        {
            IDataReader idr = null;

            switch (yontem)
            {
                case VeriCekme.Bos: idr = Bos();
                    break;
                case VeriCekme.SadeceUniversite: idr = SadeceUniversite(parametreler);
                    break;
                case VeriCekme.SadeceBolum: idr = SadeceBolum(parametreler);
                    break;
                case VeriCekme.UniVeFak: idr = UniVeFak(parametreler);
                    break;
                case VeriCekme.UniVeBolVeFak: idr = UniVeFakVeBol(parametreler);
                    break;
                case VeriCekme.SadeceBolumPuanla: idr = SadeceBolumPuanla(parametreler);
                    break;
                default: idr = null;
                    break;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Bölüm Kodu", typeof(string));
            dt.Columns.Add("Üniversite Adı", typeof(string));
            dt.Columns.Add("Fakülte Adı", typeof(string));
            dt.Columns.Add("Bölüm Adı", typeof(string));
            dt.Columns.Add("Puan Türü", typeof(string));
            dt.Columns.Add("Kontenjan", typeof(int));
            dt.Columns.Add("Yerleşen", typeof(int));
            dt.Columns.Add("En Yüksek Puan (Okul Birincisi)", typeof(string));
            dt.Columns.Add("En Küçük Puan (Okul Birincisi)", typeof(string));
            dt.Columns.Add("En Yüksek Puan", typeof(string));
            dt.Columns.Add("En Küçük Puan", typeof(string));

            while (idr.Read())
            {
                dt.Rows.Add(idr[0], idr[1], idr[2], idr[3], idr[4], idr[5], idr[6], idr[7], idr[8], idr[9], idr[10]);
            }
            return dt;
        }


        /*
         * parametre[0] = uniAdi
         * parametre[1] = fakAdi
         * parametre[2] = bolAdi
         * parametre[3] = altSınır (Puan)
         * parametre[4] = ustSınır (Puan)
         * */
        private IDataReader SadeceUniversite(string[] parametreler)
        {
            return con.manager.ExecuteReader(CommandType.Text, string.Concat("SELECT Bolum.bolumKodu,uniAdi,fakAdi,bolAdi,puanTuru,kontenjan,yerlesen,oEnYuksekPuan,oEnKucukPuan,enYuksekPuan,enKucukPuan ",
                                                                    "FROM Universite INNER JOIN UniFakBol ON Universite.uniNo = UniFakBol.uniNo ",
                                                                        "INNER JOIN Fakulte ON Fakulte.fakNo = UniFakBol.fakNo ",
                                                                            "INNER JOIN Bolum ON Bolum.bolumKodu = UniFakBol.bolumKodu ",
                                                                             "WHERE uniAdi like N'", parametreler[0], "' ORDER BY enKucukPuan DESC"));
        }
        private IDataReader UniVeFak(string[] parametreler)
        {
            return con.manager.ExecuteReader(CommandType.Text, string.Concat("SELECT Bolum.bolumKodu,uniAdi,fakAdi,bolAdi,puanTuru,kontenjan,yerlesen,oEnYuksekPuan,oEnKucukPuan,enYuksekPuan,enKucukPuan ",
                                                                     "FROM Universite INNER JOIN UniFakBol ON Universite.uniNo = UniFakBol.uniNo ",
                                                                         "INNER JOIN Fakulte ON Fakulte.fakNo = UniFakBol.fakNo ",
                                                                             "INNER JOIN Bolum ON Bolum.bolumKodu = UniFakBol.bolumKodu ",
                                                                              "WHERE uniAdi like N'", parametreler[0], "' AND fakAdi LIKE N'", parametreler[1], "' ORDER BY enKucukPuan DESC"));
        }
        private IDataReader UniVeFakVeBol(string[] parametreler)
        {
            return con.manager.ExecuteReader(CommandType.Text, string.Concat("SELECT Bolum.bolumKodu,uniAdi,fakAdi,bolAdi,puanTuru,kontenjan,yerlesen,oEnYuksekPuan,oEnKucukPuan,enYuksekPuan,enKucukPuan ",
                                                                    "FROM Universite INNER JOIN UniFakBol ON Universite.uniNo = UniFakBol.uniNo ",
                                                                        "INNER JOIN Fakulte ON Fakulte.fakNo = UniFakBol.fakNo ",
                                                                            "INNER JOIN Bolum ON Bolum.bolumKodu = UniFakBol.bolumKodu ",
                                                                             "WHERE uniAdi LIKE N'", parametreler[0], "' AND fakAdi LIKE N'",
                                                                             parametreler[1], "' AND Bolum.bolAdi LIKE N'", parametreler[2], "' ORDER BY enKucukPuan DESC"));
        }
        private IDataReader SadeceBolum(string[] parametreler)
        {

            return con.manager.ExecuteReader(CommandType.Text, string.Concat("SELECT Bolum.bolumKodu,uniAdi,fakAdi,bolAdi,puanTuru,kontenjan,yerlesen,oEnYuksekPuan,oEnKucukPuan,enYuksekPuan,enKucukPuan ",
                                    "FROM Universite INNER JOIN UniFakBol ON Universite.uniNo = UniFakBol.uniNo ",
                                        "INNER JOIN Fakulte ON Fakulte.fakNo = UniFakBol.fakNo ",
                                            "INNER JOIN Bolum ON Bolum.bolumKodu = UniFakBol.bolumKodu ",
                                             "WHERE bolAdi like N'%", parametreler[2], "%' ORDER BY enKucukPuan DESC"));
        }
        private IDataReader SadeceBolumPuanla(string[] parametreler)
        {
            return con.manager.ExecuteReader(CommandType.Text, string.Concat("SELECT Bolum.bolumKodu,uniAdi,fakAdi,bolAdi,puanTuru,kontenjan,yerlesen,oEnYuksekPuan,oEnKucukPuan,enYuksekPuan,enKucukPuan ",
                                    "FROM Universite INNER JOIN UniFakBol ON Universite.uniNo = UniFakBol.uniNo ",
                                        "INNER JOIN Fakulte ON Fakulte.fakNo = UniFakBol.fakNo ",
                                            "INNER JOIN Bolum ON Bolum.bolumKodu = UniFakBol.bolumKodu ",
                                             "WHERE bolAdi like N'%", parametreler[2], "%' AND enKucukPuan >= '", parametreler[3], "' AND enKucukPuan <= '", parametreler[4], "' ORDER BY enKucukPuan DESC"));
        }
        private IDataReader Bos()
        {
            return con.manager.ExecuteReader(CommandType.Text, string.Concat("SELECT Bolum.bolumKodu,uniAdi,fakAdi,bolAdi,puanTuru,kontenjan,yerlesen,oEnYuksekPuan,oEnKucukPuan,enYuksekPuan,enKucukPuan ",
                                                                                "FROM Universite INNER JOIN UniFakBol ON Universite.uniNo = UniFakBol.uniNo ",
                                                                                    "INNER JOIN Fakulte ON Fakulte.fakNo = UniFakBol.fakNo ",
                                                                        "INNER JOIN Bolum ON Bolum.bolumKodu = UniFakBol.bolumKodu ORDER BY enKucukPuan DESC"));
        }



        
    }
}
