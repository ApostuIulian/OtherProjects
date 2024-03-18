using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.BL
{
    class Preparat
    {
        public int id { get; set; }
        public string preparat { get; set; }
        public int pret { get; set; }
        public int stoc { get; set; }

        public Preparat(int id, string preparat, int pret, int stoc)
        {
            this.id = id;
            this.preparat = preparat;
            this.pret = pret;
            this.stoc = stoc;
        }
    }
}
