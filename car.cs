using System;

namespace Wypozyczalnia
{
    public class Car : Pojazd
    {
        public int LiczbaDrzwi { get; set; }

        public Car(string marka, string model, string kolor, decimal cena, int drzwi)
            : base(marka, model, kolor, cena) // Przekazanie koloru do klasy Pojazd
        {
            LiczbaDrzwi = drzwi;
        }

        public override void WyswietlInfo()
        {
            Console.Write("[SAMOCHÓD] ");
            base.WyswietlInfo();
        }
    }
}
