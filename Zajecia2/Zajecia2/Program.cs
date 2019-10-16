using System;

namespace Zajecia2
{
    class Car
    {
        public int rok;
        public string marka;
        private string model;
        private int iloscDrzwi;
        private int pojemnoscSilnika;
        public double srednieSpalanie;

        private double ObliczSpalanie(double dlugoscTrasy)
        {

            double spalanie;
            spalanie = (srednieSpalanie * dlugoscTrasy) / 100;
            return spalanie;
        }

        public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa)
        {
            double koszt;
            koszt = ObliczSpalanie(dlugoscTrasy) * cenaPaliwa;
            return koszt;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            string carName = "Moj samochod";

            Car car1 = new Car();
            car1.rok = 1995;
            car1.marka = "Volkswagen Golf III";
            car1.srednieSpalanie = 5.5;

            Car car2 = new Car();
            car2.rok = 1993;
            car2.marka = "FSO Polonez Caro";

            //car1 = car2;

            Console.WriteLine(carName);
            Console.WriteLine(car1.marka + " " + car1.rok);
            Console.WriteLine(car2.marka + " " + car2.rok);

            Console.WriteLine(car1.ObliczKosztPrzejazdu(12.00, 5.34));

            Console.ReadLine();
        }


    }
}
