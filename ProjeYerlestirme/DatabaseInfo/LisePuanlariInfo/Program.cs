using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace LisePuanlariInfo
{
    class Program
    {
        public static void DBBB(string il, double puan)
        {
            SqlConnection sqlConnection = DatabaseConnect();

            SqlCommand command = new SqlCommand("dbo.extra", sqlConnection) 
                { CommandType = System.Data.CommandType.StoredProcedure };
            command.Parameters.Add("@il", System.Data.SqlDbType.NVarChar).Value = il;
            command.Parameters.Add("@puan", System.Data.SqlDbType.Real).Value = puan;

            command.ExecuteNonQuery();

            sqlConnection.Close();
        }
        static void Main(string[] args)
        {
            List<string> iller = IlleriGetir();
            foreach (var item in iller)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(GetContent("http://www.eokulsistem.com/" + item + "-lise-taban-puanlari-ve-yuzdelik-dilimleri/"));
                //Console.WriteLine();
                HtmlNodeCollection table = doc.DocumentNode.SelectNodes("//table//td");

                //DBBB(item,Convert.ToDouble(table[7].InnerText));
                //HtmlNodeCollection rows = table.SelectNodes("//tr");
                string ilIlce = "";
                string il = "";
                string ilce = "";
                string liseAdi = "";
                string puan = "";
                string liseTuru = "";
                string dil = "";
                for (int i = 0; i < table.Count; i++)
                {
                    //Console.WriteLine(table[i].InnerText + "#" + i);
                    switch (i % 4)
                    {
                        case 0: ilIlce = table[i].InnerText; AyirmaIslemi(ref il, ref ilce, ref liseAdi, ilIlce); break;
                        case 1: liseTuru = table[i].InnerText; break;
                        case 2: dil = table[i].InnerText; break;
                        case 3: puan = table[i].InnerText; break;
                        default: break;
                    }
                    if (i % 4 == 0)
                    {

                        SaveToDatabase(il, ilce, liseAdi, liseTuru, dil, puan,table[7].InnerText);
                        Console.WriteLine(il + "#" + ilce + "#" + liseAdi + "#" + liseTuru + "#" + dil + "#" + puan + "#" + i + "#");
                    }
                    //if (i == 22) break;
                }
            }

            Console.WriteLine("İşlem tamamlandı!");
            Console.Read();
        }

        public static List<string> IlleriGetir()
        {
            List<string> iller = new List<string>();

            iller.Add("adana");
            iller.Add("adiyaman");
            iller.Add("afyon");
            iller.Add("agri");
            iller.Add("amasya");
            iller.Add("ankara");
            iller.Add("antalya");
            iller.Add("artvin");
            iller.Add("aydin");
            iller.Add("balikesir");
            iller.Add("bilecik");
            iller.Add("bingol");
            iller.Add("bitlis");
            iller.Add("bolu");
            iller.Add("burdur");
            iller.Add("bursa");
            iller.Add("canakkale");
            iller.Add("cankiri");
            iller.Add("corum");
            iller.Add("denizli");
            iller.Add("diyarbakir");
            iller.Add("edirne");
            iller.Add("elazig");
            iller.Add("erzincan");
            iller.Add("erzurum");
            iller.Add("eskisehir");
            iller.Add("gaziantep");
            iller.Add("giresun");
            iller.Add("gumushane");
            iller.Add("hakkari");
            iller.Add("hatay");
            iller.Add("isparta");
            iller.Add("mersin");
            iller.Add("istanbul");
            iller.Add("izmir");
            iller.Add("kars");
            iller.Add("kastamonu");
            iller.Add("kayseri");
            iller.Add("kirklareli");
            iller.Add("kirsehir");
            iller.Add("kocaeli");
            iller.Add("konya");
            iller.Add("kutahya");
            iller.Add("malatya");
            iller.Add("manisa");
            iller.Add("kahramanmaras");
            iller.Add("mardin");
            iller.Add("mugla");
            iller.Add("mus");
            iller.Add("nevsehir");
            iller.Add("nigde");
            iller.Add("ordu");
            iller.Add("rize");
            iller.Add("sakarya");
            iller.Add("samsun");
            iller.Add("siirt");
            iller.Add("sinop");
            iller.Add("sivas");
            iller.Add("tekirdag");
            iller.Add("tokat");
            iller.Add("trabzon");
            iller.Add("tunceli");
            iller.Add("sanliurfa");
            iller.Add("usak");
            iller.Add("van");
            iller.Add("yozgat");
            iller.Add("zonguldak");
            iller.Add("aksaray");
            iller.Add("bayburt");
            iller.Add("karaman");
            iller.Add("kirikkale");
            iller.Add("batman");
            iller.Add("sirnak");
            iller.Add("bartin");
            iller.Add("ardahan");
            iller.Add("igdir");
            iller.Add("yalova");
            iller.Add("karabuk");
            iller.Add("kilis");
            iller.Add("osmaniye");
            iller.Add("duzce");

            return iller;
        }

        public static SqlConnection DatabaseConnect()
        {
            SqlConnection conn = new SqlConnection(string.Concat("Server=cp.tercihweb.com;Database=DB_Huseyin;User Id=DB_User_Huseyin; ",
"Password=hus123eyin/*-;"));

            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return conn;
        }

        private static void SaveToDatabase(string il, string ilce, string liseAdi, string liseTuru, string dil, string Puan,string tableNode7)
        {
            double puan;
            try
            {
                puan = (Puan.Equals("") ? 0 : Convert.ToDouble(Puan));
            }
            catch (Exception)
            {
                puan = 0;
            }
            if (puan == 0) 
            {
                try
                {
                    puan = Convert.ToDouble(tableNode7);
                }
                catch (Exception)
                {
                    puan = 0;
                }
                 
            }
            SqlConnection sqlConnection = DatabaseConnect();
            /*
                @ilce NVARCHAR(50),
                @okulAdi NVARCHAR(200),
                @tabanPuan REAL,
                @okulTuru NVARCHAR(50),
                @yabanciDil NVARCHAR(50) )
             * 
             * */
            SqlCommand command = new SqlCommand("dbo.LiseKaydet", sqlConnection) { CommandType = System.Data.CommandType.StoredProcedure };
            command.Parameters.Add("@il", System.Data.SqlDbType.NVarChar).Value = il;
            command.Parameters.Add("@ilce", System.Data.SqlDbType.NVarChar).Value = ilce;
            command.Parameters.Add("@okulAdi", System.Data.SqlDbType.NVarChar).Value = liseAdi;
            command.Parameters.Add("@tabanPuan", System.Data.SqlDbType.Real).Value = puan;
            command.Parameters.Add("@okulTuru", System.Data.SqlDbType.NVarChar).Value = liseTuru;
            command.Parameters.Add("@yabanciDil", System.Data.SqlDbType.NVarChar).Value = dil;

            if (dil != "Dil" || liseTuru != "Tür") command.ExecuteNonQuery();
            else
            {
                sqlConnection.Close();
                return;
            }
            sqlConnection.Close();
            

        }
        public static void AyirmaIslemi(ref string il, ref string ilce, ref string liseAdi, string ilIlce)
        {
            //Console.WriteLine(ilIlce);
            if (ilIlce == "" || ilIlce.Length < 20) return;
            for (int i = 0; i < ilIlce.Length; i++)
            {
                if (ilIlce[i] == '\n')
                {
                    liseAdi = ilIlce.Substring(i + 1);                 
                    ilIlce = ilIlce.Substring(0, i);
                    for (int j = 0; j < ilIlce.Length; j++)
                    {
                        if (ilIlce[j] == '/')
                        {
                            il = ilIlce.Substring(0, j-1);
                            ilce = ilIlce.Substring(j+2);
                        }
                    }
                }
            }
        }
        private static string GetContent(string urlAddress)
        {
            Uri url = new Uri(urlAddress);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string html = client.DownloadString(url);
            return html;
        }
    }
}
