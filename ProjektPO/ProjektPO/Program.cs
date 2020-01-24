using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    abstract class Pracownik
    {
        protected int id;
        protected string imie;
        protected string nazwisko;
    }

    class Sprzedawca: Pracownik
    {
        List<Fakturka> listaFaktur;
        int utarg;
        public Sprzedawca(int id, string imie, string nazwisko)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.listaFaktur = new List<Fakturka>();
            this.utarg = 0;
        }
        public void DodajFakture(Fakturka faktura)
        {
            this.listaFaktur.Add(faktura);
            this.utarg = this.utarg + faktura.Kwota();
        }
        public string ImieNazwisko()
        {
            string wynik = this.imie + " " + this.nazwisko;
            return wynik;
        }
    }

    class Klient: Pracownik
    {
        List<Fakturka> listaFaktur;
        int należność;
        public Klient(int id, string imie, string nazwisko)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.listaFaktur = new List<Fakturka>();
            this.należność = 0;
        }
        public string ImieNazwisko()
        {
            string wynik = this.imie + " " + this.nazwisko;
            return wynik;
        }
        public void DodajFakture(Fakturka faktura)
        {
            this.listaFaktur.Add(faktura);
            this.należność = this.należność + faktura.Kwota();
        }
    }
    class Fakturka
    {
        int numer;
        Produkt produkt;
        int ilosc;
        int kwota;
        Klient klient;
        Sprzedawca sprzedawca;

        public Fakturka(int numer, Produkt produkt, int ilosc, Klient klient, Sprzedawca sprzedawca)
        {
            this.numer = numer;
            this.produkt = produkt;
            this.ilosc = ilosc;
            this.klient = klient;
            this.sprzedawca = sprzedawca;
            this.kwota = produkt.Cena() * this.ilosc;
        }
        public void WyswietlDaneFaktury()
        {
            Console.WriteLine("Dane faktury: ");
            Console.WriteLine("Faktura Nr: " + this.numer + ", Klient: " + this.klient.ImieNazwisko() + ", Sprzedawca: " + this.sprzedawca.ImieNazwisko());
            Console.WriteLine("Produkt: " + this.produkt.Nazwa() + ", Ilosc: " + this.ilosc + ", Naleznosc: " + this.kwota);
            Console.WriteLine();

        }
        public int NumerFaktury()
        {
            return this.numer;
        }
        public int Kwota()
        {
            return this.kwota;
        }
    }
    class Produkt
    {
        int idProduktu;
        string nazwa;
        int cena;

        public Produkt(int id, string nazwa, int cena)
        {
            this.idProduktu = id;
            this.nazwa = nazwa;
            this.cena = cena;
        }
        public string Nazwa()
        {
            return this.nazwa;
        }
        public int Cena()
        {
            return this.cena;
        }
    }

    class Magazyn
    {
        Dictionary<Produkt, int> Stan;
        string nazwa;

        public Magazyn(string nazwa)
        {
            this.nazwa = nazwa;
            Stan = new Dictionary<Produkt, int>();
        }

        public void DodajNaStan(Produkt produkt, int ilosc)
        {
            if (this.Stan.ContainsKey(produkt) == false)
                this.Stan.Add(produkt, ilosc);
            else
                this.Stan[produkt] = this.Stan[produkt] + ilosc;
        }

        public void UsunZeStanu(Produkt produkt, int ilosc)
        {
            this.Stan[produkt] = this.Stan[produkt] - ilosc;
        }

        public void WyswietlStan()
        {
            foreach (var k in this.Stan)
                Console.WriteLine("Produkt: " + k.Key.Nazwa() + ", Ilosc: " + k.Value);
            Console.WriteLine();

        }
    }

    class Sklepik
    {
        string nazwa;
        Magazyn magazyn;
        List<Fakturka> listaFaktur;
        List<Pracownik> listaPracownikow;
        int zarobek;

        public Sklepik(string nazwa, Magazyn magazyn)
        {
            this.nazwa = nazwa;
            this.magazyn = magazyn;
            this.listaFaktur = new List<Fakturka>();
            this.listaPracownikow = new List<Pracownik>();
            this.zarobek = 0;
        }

        public void Dostawa(Produkt produkt, int ilosc)
        {
            this.magazyn.DodajNaStan(produkt, ilosc);
        }

        public void Sprzedaz(Sprzedawca sprzedawca, Klient klient, Produkt produkt, int ilosc, int numerFakturki)
        {
            Fakturka faktura = new Fakturka(numerFakturki, produkt, ilosc, klient, sprzedawca);
            this.listaFaktur.Add(faktura);
            sprzedawca.DodajFakture(faktura);
            klient.DodajFakture(faktura);
            this.magazyn.UsunZeStanu(produkt, ilosc);
            this.zarobek = this.zarobek + faktura.Kwota();
        }
        public void WyswietlZarobek()
        {
            Console.WriteLine("Firma zarobiła: " + this.zarobek);
            Console.WriteLine();

        }

        public void WyswietlDaneFaktury(int numerFak)
        {
            foreach(var f in this.listaFaktur)
            {
                if (f.NumerFaktury() == numerFak)
                {
                    f.WyswietlDaneFaktury();
                }
            }
        }

        public void WyswietlStan()
        {
            Console.WriteLine("Magazyn: ");
            this.magazyn.WyswietlStan();
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sprzedawca Janusz = new Sprzedawca(0, "Janusz", "Pipkowski");
            Klient Pioter = new Klient(1, "Pioter", "Cwelarczyk");
            Magazyn Chamond = new Magazyn("Chamond");
            Produkt Chleb = new Produkt(0, "Chleb", 2);
            Produkt Piwo = new Produkt(1, "Piwo", 6);

            Sklepik Guwbu = new Sklepik("Guwbu", Chamond);
            Guwbu.Dostawa(Chleb, 10);
            Guwbu.Dostawa(Piwo, 120);
            Guwbu.WyswietlStan();
            Guwbu.Sprzedaz(Janusz, Pioter, Piwo, 81, 001);
            Guwbu.WyswietlDaneFaktury(001);
            Guwbu.WyswietlStan();
            Guwbu.WyswietlZarobek();

            Console.ReadKey();
        }
    }
}
