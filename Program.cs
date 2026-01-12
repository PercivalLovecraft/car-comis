using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace Wypozyczalnia
{
    class Program
    {
        static void Main(string[] args)
        {
       
            List<Pojazd> flota = new List<Pojazd>
            {
                new Car("Toyota", "Supra", "Czarny", 500, 3),
                new Car("Ford", "Focus", "Srebrny", 150, 5),
                new Bike("Yamaha", "MT-07", "Niebieski", 200, false),
                new Bike("BMW", "R1250GS", "Biały", 350, true)
            };

            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("=== KOMIS I WYPOŻYCZALNIA ===");
                Console.WriteLine("1. Lista pojazdów");
                Console.WriteLine("2. Zmień kolor pojazdu");
                Console.WriteLine("3. Usuń pojazd z komisu");
                Console.WriteLine("4. Zapisz i wyjdź");

                string? wybor = Console.ReadLine(); 
                switch (wybor)
                {
                    case "1":
                        foreach (var p in flota.OrderBy(x => x.CenaZaDzien))
                        {
                            p.WyswietlInfo();
                        }
                        Console.WriteLine("\nNaciśnij dowolny klawisz...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Write("Podaj model pojazdu do zmiany koloru: ");
                        string? modModel = Console.ReadLine();
                        var autoDoMalowania = flota.FirstOrDefault(p => p.Model.Equals(modModel, StringComparison.OrdinalIgnoreCase));

                        if (autoDoMalowania != null)
                        {
                            Console.Write("Podaj nowy kolor: ");
                            string nowyK = Console.ReadLine() ?? "Brak"; 
                            autoDoMalowania.ZmienKolor(nowyK);
                            Console.WriteLine("Kolor zmieniony!");
                        }
                        else Console.WriteLine("Nie znaleziono pojazdu.");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Write("Podaj model do usunięcia: ");
                        string? modelDoUsuniecia = Console.ReadLine();
                        var doUsuniecia = flota.FirstOrDefault(p => p.Model.Equals(modelDoUsuniecia, StringComparison.OrdinalIgnoreCase));

                        if (doUsuniecia != null)
                        {
                            flota.Remove(doUsuniecia);
                            Console.WriteLine("Usunięto z bazy.");
                        }
                        else Console.WriteLine("Nie znaleziono pojazdu.");
                        Console.ReadKey();
                        break;

                    case "4":
                        var opcje = new JsonSerializerOptions { WriteIndented = true };
                        string dane = JsonSerializer.Serialize(flota, opcje);
                        File.WriteAllText("flota.json", dane);
                        menu = false;
                        break;
                }
            }
        }
    }
}
