using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZalWF
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
                            Price = tab[3],
                            Sauce = int.Parse(tab[4]),
                            Volume = int.Parse(tab[2])
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
            ListIteration<Kanapka>(listaKanapek, "Lista kanapek");
            ListIteration<Napoj>(listaNapoji, "Lista napoji");
            ListIteration<Deser>(listaDeserow, "Lista deserow");
            ListIteration<Dodatek>(listaDodatkow, "Lista dodatkow");
        }
        public void ListIteration<T>(List<T> list, string titleName)
        {
            Console.WriteLine(titleName);
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        string kanapka;
        string napoj;
        string deser;
        string dodatek;

        public void GetOrderData(List<Deser> listaDeserow, List<Kanapka> listaKanapek, List<Napoj> listaNapoji, List<Dodatek> listaDodatkow)
        {
            do
            {
               Console.WriteLine("Wybierz kanapke: ");
               kanapka = Console.ReadLine();
            } while (int.Parse(kanapka) > listaKanapek.Count);
            do
            {
                Console.WriteLine("Wybierz napój: ");
                napoj = Console.ReadLine();
            } while (int.Parse(napoj) > listaNapoji.Count);
            do
            {
                Console.WriteLine("Wybierz deser: ");
                deser = Console.ReadLine();
            } while (int.Parse(deser) > listaDeserow.Count);
            do
            {
                Console.WriteLine("Wybierz dodatek: ");
                dodatek = Console.ReadLine();
            } while (int.Parse(dodatek) > listaDodatkow.Count);
        }

        public void WyswietlWynik()
        {
            Repozytorium rep = new Repozytorium();
            List<Deser> listaDeserow = rep.PobierzDesery();
            List<Kanapka> listaKanapek = rep.PobierzKanapki();
            List<Napoj> listaNapoji = rep.PobierzNapoj();
            List<Dodatek> listaDodatkow = rep.PobierzDodatki();

            Kanapka sandwich = listaKanapek[int.Parse(kanapka) - 1];
            Napoj drink = listaNapoji[int.Parse(napoj) - 1];
            Deser dessert = listaDeserow[int.Parse(deser) - 1];
            Dodatek addons = listaDodatkow[int.Parse(dodatek) - 1];

            Console.WriteLine("Podsumowanie zamówienia:");
            Console.Write("Kanapka: ");
            Console.WriteLine(sandwich.ToString<Kanapka>());
            Console.Write("Napój: ");
            Console.WriteLine(drink.ToString<Napoj>());
            Console.Write("Deser: ");
            Console.WriteLine(dessert.ToString<Deser>());
            Console.Write("Dodatek: ");
            Console.WriteLine(addons.ToString<Dodatek>());
            Console.WriteLine("Podsumowanie:");

            Console.Write("Do zapłaty razem: ");
            Console.WriteLine(double.Parse(sandwich.Price.Replace('.', ','))
                + double.Parse(drink.Price.Replace('.', ','))
                + double.Parse(dessert.Price.Replace('.', ','))
                + double.Parse(addons.Price.Replace('.', ',')) + " zł");
        }

    }
}
