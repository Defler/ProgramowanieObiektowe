using System;

namespace Zajecia2_2
{
    class produkt
    {
        public string nazwa;
        public string cena;
    }
    class Liczba
    {
        public int l;
        public static int opiszTyp(int a)
        {
            return 11;
        }

        public static int opiszTyp(int a, int b)
        {
            return 22;
        }

        public static int opiszTyp(string tekst)
        {
            return 14;
        }
    }

    class osoba
    {
        public string imie;
        public string nazwisko;
        public int rokUrodzenia;
        public int waga;
        public int wzrost;
        public bool okulary;
        public int plec;
        public int ObliczWiek()
        {
            int wiek = (int)DateTime.Now.Year - rokUrodzenia;
            return wiek;
        }

        public string przedrostek()
        {
            if (plec == 1)
            {
                return "Pan ";
            }
            else return ("Pani ");
            
        }

        public void BMI()
        {
            float wskaznik = waga / ((wzrost * wzrost)/10000);
            Console.WriteLine(wskaznik);
            if (wskaznik > 30) Console.WriteLine("Otylosc");
            else if ((25 < wskaznik) && (wskaznik < 30)) Console.WriteLine("Nadwaga");
            else if ((19 < wskaznik) && (wskaznik < 25)) Console.WriteLine("Waga prawidlowa");
            else Console.WriteLine("Niedowaga");

        }
    }
    class Program
    {
        enum Plec { K, M };
        static void Main(string[] args)
        {
            Liczba liczba = new Liczba();
            liczba.l = 12;
            Console.WriteLine(Liczba.opiszTyp(12,13));

            osoba Dyrektor = new osoba();
            Dyrektor.imie = "Janusz";
            Dyrektor.nazwisko = "Pipkowski";
            Dyrektor.rokUrodzenia = 1990;
            Dyrektor.waga = 115;
            Dyrektor.wzrost = 189;
            Dyrektor.okulary = false;
            Dyrektor.plec = (int)Plec.M;

            Console.WriteLine(Dyrektor.przedrostek() + Dyrektor.imie + " " + Dyrektor.nazwisko);
            Console.WriteLine("Wiek: " + Dyrektor.ObliczWiek());

            osoba Pacjent = new osoba();
            Pacjent.imie = "Grazyna";
            Pacjent.nazwisko = "Kowalska";
            Pacjent.wzrost = 167;
            Pacjent.waga = 145;
            Pacjent.okulary = false;
            Pacjent.plec = (int)Plec.K;

            Console.WriteLine(Pacjent.przedrostek() + Pacjent.imie + " " + Pacjent.nazwisko);
            Pacjent.BMI();



            Console.ReadLine();
        }
    }
}
