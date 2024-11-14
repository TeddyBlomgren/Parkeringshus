using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus
{
    public static class Fordonskapare

    {
        public static IFordon RandomFordon()
        {
            Random random = new Random();
            string regNr = $"{RandomBokstav(3)}{random.Next(100, 999)}";
            string[] färger = { "Svart", "Vit", "Blå", "Grön", "Gul" };
            string färg = färger[random.Next(färger.Length)];

            int fordonstyp = random.Next(3);
            switch (fordonstyp)
            {
                case 0:
                    bool ärElBil = random.Next(2) == 0;
                    return new Bil(regNr, färg, ärElBil);
                case 1:
                    int passengerCount = random.Next(10, 60);
                    return new Buss(regNr, färg, passengerCount);
                case 2:
                    string[] brands = { "Harley","Ducati",  "Honda","Yamaha"  };
                    string brand = brands[random.Next(brands.Length)];
                    return new Motorcykel(regNr, färg, brand);
                default:
                    return null;
            }
        }
        private static string RandomBokstav(int längd)
        {
            const string alfabetet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            string resultat = "";

            for (int i = 0; i < längd; i++)
            {
                resultat += alfabetet[random.Next(alfabetet.Length)];
            }

            return resultat;
        }
    }
}
