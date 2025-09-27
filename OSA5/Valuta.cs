using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA5
{
    class Valyuta
    {
        public string Naim { get; set; }       
        public double KursEurOtnoshenie { get; set; } 

        public Valyuta(string naim, double kurs)
        {
            Naim = naim;
            KursEurOtnoshenie = kurs;
        }
    }
}