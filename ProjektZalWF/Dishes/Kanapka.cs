using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZalWF
{
    class Kanapka : Dish
    {
        public double Weight { get; set; }
        public int Vege { get; set; }

        public string ToString<T>()
        {
            StringBuilder tmp = new StringBuilder();

            tmp.Append(Name).Append(", ");
            tmp.Append(Price).Append("PLN, ");
            tmp.Append(Weight).Append("g, ");
            if (Vege == 1)
            {
                tmp.Append("Vege");
            }

            return tmp.ToString();
        }

        public override string ToString()
        {
            StringBuilder tmp = new StringBuilder();
            tmp.Append(Id).Append("    ");
            tmp.Append(Name).Append(", ");
            tmp.Append(Price).Append("PLN, ");
            tmp.Append(Weight).Append("g, ");
            if (Vege == 1)
            {
                tmp.Append("Vege");
            }

            return tmp.ToString();
        }
    }
}
