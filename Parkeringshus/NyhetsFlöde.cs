using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus
{
    public class NyhetsFlöde
    {

        private static List<string> loggar = new List<string>();

        public static void LäggTillLogg(string meddelande)
        {
            loggar.Add($"{meddelande}");
            if (loggar.Count > 10) loggar.RemoveAt(0);
        }

        public static void VisaLog()
        {
            
            Console.WriteLine("\n--- Nyhetsflöde ---");
            foreach (string logg in loggar)
            {
                Console.WriteLine(logg);
            }
            Console.WriteLine("-----------------\n");
        }
    }
}