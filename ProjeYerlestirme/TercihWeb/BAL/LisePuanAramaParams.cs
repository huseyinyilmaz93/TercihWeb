using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class LisePuanAramaParams
    {
        public bool tamArama { get; set; }        
        public List<string> liseTurList;
        public string il { get; set; }
        public string ilce { get; set; }
        public double altSinir { get; set; }
        public double ustSinir { get; set; }

        public LisePuanAramaParams()
        {
            tamArama = false;
            liseTurList = new List<string>();
            il = null;
            ilce = null;
        }
        
    }
}
