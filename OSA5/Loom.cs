using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA5
{
    class Loom
    {
        public string Nimi { get; set; }
        public string Liik { get; set; }
        public int Vanus { get; set; }

        public Loom(string nimi, string liik, int vanus)
        {
            Nimi = nimi;
            Liik = liik;
            Vanus = vanus;
        }
    }
}