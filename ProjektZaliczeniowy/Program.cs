using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    class Program
    {
        static void Main(string[] args)
        {
            Repozytorium rep = new Repozytorium();
            List<Deser> listaDeserow = rep.PobierzDesery();
            List<Kanapka> listaKanapek = rep.PobierzKanapki();
            List<Napoj> listaNapoji = rep.PobierzNapoj();
            List<Dodatek> listaDodatkow = rep.PobierzDodatki();

            Console.WriteLine("Zamawiacz 2022 - wersja konsolowa");
            Console.WriteLine();

            rep.WyswietlListe(listaDeserow, listaKanapek, listaNapoji, listaDodatkow);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----- Złóż zamówienie -----");

            rep.GetOrderData(listaDeserow, listaKanapek, listaNapoji, listaDodatkow);

            Console.WriteLine();

            rep.WyswietlWynik();

            Console.WriteLine();
        }
    }
}
