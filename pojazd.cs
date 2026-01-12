using System;

namespace Wypozyczalnia
{
    public abstract class Pojazd
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Kolor { get; set; } // Nowa właściwość
        public decimal CenaZaDzien { get; set; }
        private bool _czyWypozyczony;

        public bool CzyWypozyczony => _czyWypozyczony;

        // Konstruktor przyjmuje kolor i przekazuje go do właściwości
        protected Pojazd(string marka, string model, string kolor, decimal cena)
        {
            Marka = marka;
            Model = model;
            Kolor = kolor;
            CenaZaDzien = cena;
            _czyWypozyczony = false;
        }

        public void ZmienKolor(string nowyKolor) => Kolor = nowyKolor;
        public void Wypozycz() => _czyWypozyczony = true;

        public virtual void WyswietlInfo()
        {
            string status = _czyWypozyczony ? "Zajęty" : "Dostępny";
            Console.WriteLine($"{Marka} {Model} | Kolor: {Kolor} | Cena: {CenaZaDzien}zł | Status: {status}");
        }
    }
}
