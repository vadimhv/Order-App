using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    class Repozytorium
    {
        public List<Deser> PobierzDesery()
        {
            string nazwaPliku = "dessert.csv";
            List<Deser> lista = new List<Deser>();

            if (File.Exists(nazwaPliku) == false)
            {
                Console.WriteLine("Brak danych. Brak pliku {0}!", nazwaPliku);
                return null;
            }
            using (StreamReader srd = new StreamReader(nazwaPliku))
            {
                string linia = srd.ReadLine();
                string[] tab;
                Deser deser;
                while ((linia = srd.ReadLine()) != null)
                {
                    tab = linia.Split(';');
                    try
                    {
                        deser = new Deser()
                        {
                            Id = int.Parse(tab[0]),
                            Name = tab[1],
                            Price = tab[3],
                            Calories = int.Parse(tab[2]),
                            Weight = double.Parse(tab[4]),
                        };
                        lista.Add(deser);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        foreach (var item in tab)
                        {
                            Console.WriteLine("{0}, ", item);
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                }
            }
            return lista;
        }
        public List<Kanapka> PobierzKanapki()
        {
            string nazwaPliku = "sandwich.csv";
            List<Kanapka> lista = new List<Kanapka>();

            if (File.Exists(nazwaPliku) == false)
            {
                Console.WriteLine("Brak danych. Brak pliku {0}!", nazwaPliku);
                return null;
            }
            using (StreamReader srd = new StreamReader(nazwaPliku))
            {
                string linia = srd.ReadLine();
                string[] tab;
                Kanapka kanapka;
                while ((linia = srd.ReadLine()) != null)
                {
                    tab = linia.Split(';');
                    try
                    {
                        kanapka = new Kanapka()
                        {
                            Id = int.Parse(tab[0]),
                            Name = tab[1],
                            Price = tab[3],
                            Vege = int.Parse(tab[4]),
                            Weight = double.Parse(tab[2]),
                        };
                        lista.Add(kanapka);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        foreach (var item in tab)
                        {
                            Console.WriteLine("{0}, ", item);
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                }
            }
            return lista;
        }
        public List<Napoj> PobierzNapoj()
        {
            string nazwaPliku = "drink.csv";
            List<Napoj> lista = new List<Napoj>();

            if (File.Exists(nazwaPliku) == false)
            {
                Console.WriteLine("Brak danych. Brak pliku {0}!", nazwaPliku);
                return null;
            }
            using (StreamReader srd = new StreamReader(nazwaPliku))
            {
                string linia = srd.ReadLine();
                string[] tab;
                Napoj napoj;
                while ((linia = srd.ReadLine()) != null)
                {
                    tab = linia.Split(';');
                    try
                    {
                        napoj = new Napoj()
                        {
                            Id = int.Parse(tab[0]),
                            Name = tab[1],
                            Price = tab[3],
                            Sugar = int.Parse(tab[4]),
                            Size = double.Parse(tab[2]),
                        };
                        lista.Add(napoj);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        foreach (var item in tab)
                        {
                            Console.WriteLine("{0}, ", item);
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                }
            }
            return lista;
        }
        public List<Dodatek> PobierzDodatki()
        {
            string nazwaPliku = "addon.csv";
            List<Dodatek> lista = new List<Dodatek>();

            if (File.Exists(nazwaPliku) == false)
            {
                Console.WriteLine("Brak danych. Brak pliku {0}!", nazwaPliku);
                return null;
            }
            using (StreamReader srd = new StreamReader(nazwaPliku))
            {
                string linia = srd.ReadLine();
                string[] tab;
                Dodatek dodatek;
                while ((linia = srd.ReadLine()) != null)
                {
                    tab = linia.Split(';');
                    try
                    {
                        dodatek = new Dodatek()
                        {
                            Id = int.Parse(tab[0]),
                            Name = tab[1],
                            Price = tab[3]
                        };
                        lista.Add(dodatek);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        foreach (var item in tab)
                        {
                            Console.WriteLine("{0}, ", item);
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                }
            }
            return lista;
        }

        public void WyswietlListe(List<Deser> listaDeserow, List<Kanapka> listaKanapek, List<Napoj> listaNapoji, List<Dodatek> listaDodatkow)
        {
            Repozytorium rep = new Repozytorium();
            Console.WriteLine("Lista kanapek: ");
            foreach (var item in listaKanapek)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Lista napoji: ");
            foreach (var item in listaNapoji)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Lista deserów: ");
            foreach (var item in listaDeserow)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Lista dodatków: ");
            foreach (var item in listaDodatkow)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void WyswietlWynik(string wybranaKanapka, string wybranyNapoj, string wybranyDeser, string wybranyDodatek)
        {

            Repozytorium rep = new Repozytorium();
            List<Deser> listaDeserow = rep.PobierzDesery();
            List<Kanapka> listaKanapek = rep.PobierzKanapki();
            List<Napoj> listaNapoji = rep.PobierzNapoj();
            List<Dodatek> listaDodatkow = rep.PobierzDodatki();

            Console.WriteLine("Podsumowanie zamówienia:");
            Console.Write("Kanapka: ");
            Console.WriteLine(listaKanapek[int.Parse(wybranaKanapka) - 1].ToString<Kanapka>());
            Console.Write("Napój: ");
            Console.WriteLine(listaNapoji[int.Parse(wybranyNapoj) - 1].ToString<Napoj>());
            Console.Write("Deser: ");
            Console.WriteLine(listaDeserow[int.Parse(wybranyDeser) - 1].ToString<Deser>());
            Console.Write("Dodatek: ");
            Console.WriteLine(listaDodatkow[int.Parse(wybranyDodatek) - 1].ToString<Dodatek>());
            Console.WriteLine("Podsumowanie:");

            Console.Write("Do zapłaty razem: ");
            Console.WriteLine(double.Parse(listaKanapek[int.Parse(wybranaKanapka) - 1].Price.Replace('.', ','))
                + double.Parse(listaNapoji[int.Parse(wybranyNapoj) - 1].Price.Replace('.', ','))
                + double.Parse(listaDeserow[int.Parse(wybranyDeser) - 1].Price.Replace('.', ','))
                + double.Parse(listaDodatkow[int.Parse(wybranyDodatek) - 1].Price.Replace('.', ',')) + " zł");
        }

    }
}
