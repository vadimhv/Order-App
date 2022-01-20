using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZalWF
{
    class Deser : Dish
    {

        public double Weight { get; set; }
        public int Calories { get; set; }

        public string ToString<T>()
        {
            StringBuilder tmp = new StringBuilder();

            tmp.Append(Name).Append(", ");
            tmp.Append(Price).Append("PLN, ");
            tmp.Append(Weight).Append("g, ");
            tmp.Append("Cal.").Append(Calories);

            return tmp.ToString();
        }

        public override string ToString()
        {
            StringBuilder tmp = new StringBuilder();
            tmp.Append(Id).Append("    ");
            tmp.Append(Name).Append(", ");
            tmp.Append(Price).Append("PLN, ");
            tmp.Append(Weight).Append("g, ");
            tmp.Append("Cal.").Append(Calories);

            return tmp.ToString();
        }

    }
}
