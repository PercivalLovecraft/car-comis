using System;

namespace Wypozyczalnia
{
    public class Bike : Pojazd
    {
        public bool CzyMaKufer { get; set; }

        public Bike(string marka, string model, string kolor, decimal cena, bool kufer)
            : base(marka, model, kolor, cena) // Przekazanie koloru do klasy Pojazd
        {
            CzyMaKufer = kufer;
        }

        public override void WyswietlInfo()
        {
            Console.Write("[MOTOCYKL] ");
            base.WyswietlInfo();
        }
    }
}
