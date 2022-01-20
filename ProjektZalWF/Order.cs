using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZalWF
{
    class Order
    {
        public int OrderNumber { get; set; }

        public double OrderPrice { get; set; }
        public string OrderTime { get; set; }

        public Kanapka Sandwitch { get; set; }

        public Napoj Drink { get; set; }

        public Deser Desert { get; set; }
        public Dodatek Addon { get; set; }
    }
}
