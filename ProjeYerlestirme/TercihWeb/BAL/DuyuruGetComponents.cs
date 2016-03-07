using System.Collections.Generic;

namespace BAL
{                    
    public static class DuyuruGetComponents
    {
        public static List<Duyuru> GetDuyuru()
        {
            return new List<Duyuru>() 
            {
                new Duyuru() {
                    DuyuruBasligi = "Üniversitelerde 209.000 boş kontenjan ..",
                    DuyuruIcerigi = "Üniversitelerde yapılan tercihler sonucu 806.000'e yakın öğrenci üniversitelere kayıtlarını yaptırdı. Üniversitelerde ise 209.000 boş kontenjan, ek yerleştirme için açık durumdadır. Ösym'nin takvimine göre ek yerleştirme 17-21 Ağustos tarihleri arasında yapılabilecek. ",
                    Tarih = "17 Ağustos 2015",
                    YayinlayanYetkili = "Admin"
                },
                new Duyuru() {
                
                    DuyuruBasligi = "Teog yerleştirme sonuçları açıklandı .. ",
                    DuyuruIcerigi = "Milli Eğitim Bakanlığı’nın resmi internet adresi olan \"www.sinavlar.gov.tr\" ve \"teog2015.meb.gov.tr\" üzerinden açıklanan TEOG yerleştirme sonuçlarına tıklayıp sizden istenen bilgileri siteye girerek TEOG yerleştirme sonuçlarınızı öğrenebilirsiniz.",
                    Tarih = "14 Ağustos 2015",
                    YayinlayanYetkili = "Admin"
                },
                new Duyuru() {
                
                    DuyuruBasligi = "Üniversiteler kayıt dönemi .. ",
                    DuyuruIcerigi = "Ösym'nin yaptığı yerleştirmeler sonucu üniversitelere yerleşen 850.000'in üzerindeki öğrenciler, yerleştikleri üniversitelere kayıtlarını 3-7 Ağustos tarihleri arasında yapabilirler. Ayrıca ösym bu yıl ilk kez e-devler üzerinden öğrenci kayıtlarının yapılabileceğini açıklamıştı. E-devlet şifresine sahip öğrenciler üniversiteye gitmeden kayıt gerçekleştirebilirler.",
                    Tarih = "3 Ağustos 2015",
                    YayinlayanYetkili = "Admin"
                }
            };
        }

    }
}
