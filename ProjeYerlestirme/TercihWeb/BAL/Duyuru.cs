
namespace BAL
{
    public class Duyuru
    {
        public string DuyuruBasligi { get; set; }
        public string YayinlayanYetkili { get; set; }
        public string DuyuruIcerigi { get; set; }
        public string Tarih { get; set; }

        public override string ToString()
        {
            return this.DuyuruBasligi;
        }
    }
}
