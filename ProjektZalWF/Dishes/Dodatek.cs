using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZalWF
{
    class Dodatek : Dish
    {
        public int Volume { get; set; }
        public int Sauce { get; set; }

        public string ToString<T>()
        {
            StringBuilder tmp = new StringBuilder();

            tmp.Append(Name).Append(", ");
            tmp.Append(Price).Append("PLN, ");

            return tmp.ToString();
        }
        public override string ToString()
        {
            StringBuilder tmp = new StringBuilder();

            tmp.Append(Id).Append("    ");
            tmp.Append(Name).Append(", ");
            tmp.Append(Price).Append("PLN, ");

            return tmp.ToString();
        }
    }
}
