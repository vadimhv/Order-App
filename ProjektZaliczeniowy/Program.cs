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
            string kanapka;
            do
            {
                Console.WriteLine("Wybierz kanapke: ");
                kanapka = Console.ReadLine();
            } while (int.Parse(kanapka) > listaKanapek.Count);
            string napoj;
            do
            {
                Console.WriteLine("Wybierz napój: ");
                napoj = Console.ReadLine();
            } while (int.Parse(napoj) > listaNapoji.Count);
            string deser;
            do
            {
                Console.WriteLine("Wybierz deser: ");
                deser = Console.ReadLine();
            } while (int.Parse(deser) > listaDeserow.Count);
            string dodatek;
            do
            {
                Console.WriteLine("Wybierz dodatek: ");
                dodatek = Console.ReadLine();
            } while (int.Parse(dodatek) > listaDodatkow.Count);

            Console.WriteLine();
            rep.WyswietlWynik(kanapka, napoj, deser, dodatek);
            Console.WriteLine();
        }
    }
}
