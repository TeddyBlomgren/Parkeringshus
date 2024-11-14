namespace Parkeringshus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParkeringsHus parkeringshus = new ParkeringsHus();
            Parkeringsfunktion parkeringsfunktion = new Parkeringsfunktion();
            bool running = true;

            Console.WriteLine(" Välkommen till Parkeringhuset");
            while (running)
            {
                Console.Clear();
                
                Console.WriteLine("1. Parkera ett fordon");
                Console.WriteLine("2. Checka ut ett fordon");
                Console.WriteLine("3. Avsluta programmet");

                parkeringsfunktion.Status();
                NyhetsFlöde.VisaLog();
                string val = Console.ReadLine();



                switch (val)
                {
                    case "1":
                        IFordon nyttfordon = Fordonskapare.RandomFordon();
                        if (parkeringsfunktion.Parkera(nyttfordon))
                        {
                        }
                        else
                        {
                        }
                        break;

                    case "2":
                        Console.WriteLine("Ange RegNr på Fordonet du vill checka ut:");
                        string regNr = Console.ReadLine().ToUpper();
                        if (parkeringsfunktion.CheckaUtFordon(regNr))
                        {
                        }
                        else
                        {
                            Console.WriteLine("Fordon med det reg fanns ej.");
                        }
                        break;

                    case "3":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Fel kommando, försök igen.");
                        break;
                }
            }
        }
    }
}
