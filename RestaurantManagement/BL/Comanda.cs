using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.BL
{
    class Comanda
    {
        public int id { get; set; }
        public int idPreparateComanda { get; set; }
        public string dataPlasarii { get; set; }
        public string status { get; set; }
        public int costTotal { get; set; }

        public Comanda(int id, int idPreparateComanda, string dataPlasarii, string status, int costTotal)
        {
            this.id = id;
            this.idPreparateComanda = idPreparateComanda;
            this.dataPlasarii = dataPlasarii;
            this.status = status;
            this.costTotal = costTotal;
        }
    }
}
