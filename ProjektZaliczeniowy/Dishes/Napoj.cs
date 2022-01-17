using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    class Napoj : Dish
    {
        public double Size { get; set; }
        public int Sugar { get; set; }
        public string ToString<T>()
        {
            StringBuilder tmp = new StringBuilder();

            tmp.Append(Name).Append(", ");
            tmp.Append(Price).Append("PLN, ");
            tmp.Append(Size).Append("g, ");
            if (Sugar == 0)
            {
                tmp.Append("SUGARFREE");
            }

            return tmp.ToString();
        }
        public override string ToString()
        {
            StringBuilder tmp = new StringBuilder();
            tmp.Append(Id).Append("    ");
            tmp.Append(Name).Append(", ");
            tmp.Append(Price).Append("PLN, ");
            tmp.Append(Size).Append("g, ");
            if (Sugar == 0)
            {
                tmp.Append("SUGARFREE");
            }

            return tmp.ToString();
        }
    }
}
