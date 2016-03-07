using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatabaseInfo
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> list = PdfRead();
            SqlConnection con = DatabaseConnect();
            foreach (var item in list)
            {
                //Console.WriteLine("#"+item);
                bool transaction = AnalysingString(item);
                if (transaction) DecomposeToElement(item, con); else continue;
            }
            con.Close();
            Console.WriteLine("İşlem tamamlandı!");
            Console.Read();
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

        public static void DecomposeToElement(string text, SqlConnection sqlConnection)
        {
            bool pTuruFlag=false;
            bool countryExist = true;
            int index = 0;
            string puanTuru = "";
            string yerlesen = "";
            string kontenjan = "";
            string enYuksekPuan = "";
            string enKucukPuan = "";
            string oEnYuksekPuan = "";
            string oEnKucukPuan = "";
            string il = "";
            string univAdi = "";
            string bolKodu = text.Substring(0,9);
            string fakAdi = "";
            string bolAdi = "";
            text = text.Substring(10);
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    index = (i-1);
                    break;
                }
                if (text[i] == '/')
                {
                    countryExist = false;
                    index = i;
                    break;
                }
            }
            univAdi = text.Substring(0,index);
            text = (countryExist)? text.Substring(index+2 ): text.Substring(index+1 );
            
            //Console.WriteLine(text);

            if (countryExist)
            {
                int countryIndex = 0;
                for (int i = 0; i < text.Length ; i++)
                {
                    if (text[i] == ')')
                    {
                        countryIndex = i;
                        break;
                    }
                }
                il = text.Substring(0, countryIndex);
                text = text.Substring(countryIndex+2);
            }
            else
            {
                int countryIndex = 0;
                for (int i = 0; ; i++)
                {
                    if (univAdi[i] == ' ')
                    {
                        countryIndex = i;
                        break;
                    }
                }
                il = univAdi.Substring(0, countryIndex);
                
            }

            //------------reverse
            Regex numeric = new Regex("[0-9]");
            // Okul birincisi puanı hesaplama
            if (text[text.Length - 1] == '-')
            {
                oEnKucukPuan = "---"; oEnYuksekPuan = "---";
                text = text.Substring(0, text.Length - 8);
            }
            else
            {
                oEnYuksekPuan = text.Substring(text.Length - 9);
                oEnKucukPuan = text.Substring(text.Length-19,9);
                text = text.Substring(0, text.Length - 20);
            }

            // Puan türü hesaplama
            if (text[text.Length - 1] == '-')
            {
                enYuksekPuan = "---"; enKucukPuan = "---";
                text = text.Substring(0, text.Length - 8);
            }
            else
            {
                enYuksekPuan = text.Substring(text.Length - 9);
                enKucukPuan = text.Substring(text.Length - 19, 9);
                text = text.Substring(0, text.Length - 20);
            }
            //Console.WriteLine(text);
            //Yerlesen
            for (int i = text.Length-1; i > 0; i--)
            {
                if (text[i] == ' ') break;
                else  yerlesen = text[i] + yerlesen ; 
                text = text.Substring(0,text.Length - 1);
            }
            text = text.Substring(0, text.Length - 1);
            //Kontenjan
            for (int i = text.Length - 1; i > 0; i--)
            {
                if (text[i] == ' ') break;
                else kontenjan = text[i] + kontenjan;
                text = text.Substring(0, text.Length - 1);
            }
            text = text.Substring(0, text.Length - 1);

            //Puan Turu

            for (int i = 0; i < text.Length; i++) //puan turu olmayan
            {
                if(text[i]=='('&& text[i+1]=='A' && text[i+2]=='ç' &&text[i+3] == 'ı' && text[i+4] =='k') 
                {
                    pTuruFlag = true;
                }
            }
            if (pTuruFlag) //puan turu olmayanlar
            { puanTuru = ""; }
            else  //puan Turu olanlar
            {  
                for (int i = text.Length - 1; i > 0; i--)
                {
                    if (text[i] == ' ') break;
                    else puanTuru = text[i] + puanTuru;
                    text = text.Substring(0, text.Length - 1);
                }
            }
            if(text.Length != 0)
                text = text.Substring(0, text.Length - 1);
            //Fakulte ve bolum Adi farklı olanlar
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '/')
                {
                    fakAdi = text.Substring(0, i);
                    bolAdi = text.Substring(i + 1);
                    text = "";
                }                
            }
            //Fakulte ve bolum adı aynı olanlar
            for (int i = 0; i < text.Length; i++)
            {
                try
                {
                    if (text[i] == ' ' && text[i + 1] == 'F' && text[i + 2] == 'a' && text[i + 3] == 'k')
                    {
                        fakAdi = text;
                        bolAdi = text.Substring(0, i);
                    }
                }
                catch (IndexOutOfRangeException)
                { }
                
            }
            SaveToDatabase(sqlConnection, univAdi, fakAdi, bolAdi, bolKodu, il, puanTuru, kontenjan, yerlesen,
                           enKucukPuan, enYuksekPuan, oEnKucukPuan, oEnYuksekPuan);
        }

        public static void SaveToDatabase(SqlConnection sqlConnection,string uniAdi,
            string fakAdi,string bolAdi, string bolKodu,string il,string puanTuru,string Kontenjan,
            string Yerlesen, string EnKucukPuan, string EnYuksekPuan, string OEnKucukPuan,
            string OEnYuksekPuan)
        {
            int kontenjan = Convert.ToInt32(Kontenjan);
            int yerlesen = Convert.ToInt32(Yerlesen);
            double enKucukPuan = EnKucukPuan.Equals("---") ? 0.00 : Convert.ToDouble(EnKucukPuan);
            double enYuksekPuan = EnYuksekPuan.Equals("---") ? 0.00 : Convert.ToDouble(EnYuksekPuan);
            double oEnKucukPuan = OEnKucukPuan.Equals("---") ? 0.00 : Convert.ToDouble(OEnKucukPuan);
            double oEnYuksekPuan = OEnYuksekPuan.Equals("---") ? 0.00: Convert.ToDouble(OEnYuksekPuan);

            /*
             *  @uniAdi NVARCHAR(200) = NULL,
                @fakAdi NVARCHAR(200) = NULL,
                @bolAdi NVARCHAR(200) = NULL,
                @il NVARCHAR(20) = NULL,
                @bolumKodu NVARCHAR(20) = NULL,
                @puanTuru NVARCHAR(10) = NULL,
                @kontenjan INT,
                @yerlesen INT,
                @enKucukPuan REAL,
                @enYuksekPuan REAL,
                @oEnKucukPuan REAL,
                @oEnYuksekPuan REAL
             * */

            if (uniAdi == "ADIYAMAN ÜNİVERSİTESİ" && bolAdi == "Sanat Tarihi")
            {
                Console.WriteLine();
            }

            SqlCommand command = new SqlCommand("Kaydet",sqlConnection) {CommandType = System.Data.CommandType.StoredProcedure};
            command.Parameters.Add("@uniAdi", System.Data.SqlDbType.NVarChar).Value = uniAdi;
            command.Parameters.Add("@fakAdi", System.Data.SqlDbType.NVarChar).Value = fakAdi;
            command.Parameters.Add("@bolAdi", System.Data.SqlDbType.NVarChar).Value = bolAdi;
            command.Parameters.Add("@il", System.Data.SqlDbType.NVarChar).Value = il;   
            command.Parameters.Add("@bolumKodu", System.Data.SqlDbType.NVarChar).Value = bolKodu;
            command.Parameters.Add("@puanTuru", System.Data.SqlDbType.NVarChar).Value = puanTuru;
            command.Parameters.Add("@kontenjan", System.Data.SqlDbType.Int).Value = kontenjan;
            command.Parameters.Add("@yerlesen", System.Data.SqlDbType.Int).Value = yerlesen;
            command.Parameters.Add("@enKucukPuan", System.Data.SqlDbType.Real).Value = enKucukPuan;
            command.Parameters.Add("@enYuksekPuan", System.Data.SqlDbType.Real).Value = enYuksekPuan;
            command.Parameters.Add("@oEnKucukPuan", System.Data.SqlDbType.Real).Value = oEnKucukPuan;
            command.Parameters.Add("@oEnYuksekPuan", System.Data.SqlDbType.Real).Value = oEnYuksekPuan;

            command.ExecuteNonQuery();



        }

        public static bool AnalysingString(string text)
        {
            Regex regex = new Regex("^[0-9]{9}");
            if (text.Length < 9) return false;
            //Console.WriteLine(regex.IsMatch(text) + "#####" + ((text.Length > 68)? text.Substring(0,68): ""));
            return regex.IsMatch(text);
        }

        public static List<string> PdfRead()
        {
            List<string> list = new List<string>();
            PdfReader reader = new PdfReader("../../2015yerlestirme.pdf");
            int intPageNum = reader.NumberOfPages;
            string[] words;
            string line;
            string text;

            for (int i = 1; i <= intPageNum; i++)
            {
                text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());

                words = text.Split('\n');
                for (int j = 0, len = words.Length; j < len; j++)
                {
                    line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
                    list.Add(line);
                }
            }

            return list;
        }
    }

    public static class StrSonaEkle
    {
        public static string SonaEkle(this string sabit, string eklenecek)
        {
            return string.Concat(eklenecek, sabit);
        }
    }
}
