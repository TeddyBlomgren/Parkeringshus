using Parkeringshus;
using System;

public class Parkeringsfunktion
{
    private object[] platser;
    private int maxPlatser = 15;

    public Parkeringsfunktion()
    {
        platser = new object[maxPlatser];
    }

    public bool Parkera(IFordon fordon)
    {
        if (fordon is Motorcykel)
        {
            for (int i = 0; i < maxPlatser; i++)
            {
                if (platser[i] is List<Motorcykel> mcLista && mcLista.Count < 2)
                {
                    mcLista.Add((Motorcykel)fordon);
                    NyhetsFlöde.LäggTillLogg($"Fordonet {fordon.RegNr} ({fordon.GetType().Name}) har parkerats på plats {i + 1} tillsammans med en annan motorcykel.");
                    return true;
                }
            }
            for (int i = 0; i < maxPlatser; i++)
            {
                if (platser[i] == null)
                {
                    platser[i] = new List<Motorcykel> { (Motorcykel)fordon };
                    NyhetsFlöde.LäggTillLogg($"Fordonet {fordon.RegNr} ({fordon.GetType().Name})  har parkerats på plats {i + 1}.");
                    return true;
                }
            }
            return false;
        }
        int behövdaPlatser = (int)Math.Ceiling(FordonPlats(fordon));
        for (int i = 0; i <= maxPlatser - behövdaPlatser; i++)
        {
            if (ÄrPlatserLediga(i, behövdaPlatser))
            {
                for (int j = 0; j < behövdaPlatser; j++)
                {
                    platser[i + j] = fordon;
                }

                int startPlats = i + 1;
                int slutPlats = i + behövdaPlatser;

                NyhetsFlöde.LäggTillLogg($"Fordonet {fordon.RegNr} ({fordon.GetType().Name}) har parkerats på platser {startPlats} till {slutPlats}.");
                return true;
            }
        }
        NyhetsFlöde.LäggTillLogg("Det finns ingen plats för detta fordon.");
        return false;
    }
    public bool CheckaUtFordon(string regNr)
    {
        for (int i = 0; i < maxPlatser; i++)
        {
            if (platser[i] is List<Motorcykel> mcLista)
            {
                var motorcykel = mcLista.FirstOrDefault(mc => mc.RegNr == regNr);
                if (motorcykel != null)
                {
                    mcLista.Remove(motorcykel);
                    if (mcLista.Count == 0)
                    {
                        platser[i] = null;
                    }
                    NyhetsFlöde.LäggTillLogg($"Motorcykel med  {regNr} har checkats ut.");
                    return true;
                }
            }
            else if (platser[i] is IFordon fordon && fordon.RegNr == regNr)
            {
                int behövdaPlatser = (int)Math.Ceiling(FordonPlats(fordon));
                for (int j = 0; j < behövdaPlatser; j++)
                {
                    platser[i + j] = null;
                }

                decimal kostnad = BeräknaKostnad(fordon);
                NyhetsFlöde.LäggTillLogg($"{fordon.GetType().Name} med  {regNr} har checkats ut. Kostnad: {kostnad}kr.");
                return true;
            }
        }

        NyhetsFlöde.LäggTillLogg($"Fordon med {regNr} hittades inte.");
        return false;
    }


    private decimal BeräknaKostnad(IFordon fordon)
    {
        TimeSpan parkeradTid = DateTime.Now - fordon.Incheckningstid;
        decimal kostnad = fordon.Parkeringskostnad(parkeradTid);
        return kostnad;
    }

    private bool ÄrPlatserLediga(int startIndex, int antalPlatser)
    {
        for (int i = startIndex; i < startIndex + antalPlatser; i++)
        {
            if (platser[i] != null)
                return false;
        }
        return true;
    }

    public void Status()
    {
        Console.WriteLine("\n--- Parkeringsstatus ---");

        for (int i = 0; i < maxPlatser; i++)
        {
            if (platser[i] == null)
            {
                Console.WriteLine($"Plats {i + 1}: Ledig");
            }
            else if (platser[i] is List<Motorcykel> mcLista)
            {
                string motorcykelInfo = string.Join(" och ", mcLista.Select(mc => $"RegNr:{mc.RegNr} Färg: {mc.Färg}, {mc.Märke} "));
                Console.WriteLine($"Plats {i + 1}: Motorcyklar - {motorcykelInfo}");
            }
            else if (platser[i] is IFordon fordon)
            {
                string fordonstyp = fordon.GetType().Name;
                string fordonInfo = "";

                if (fordon is Bil bil)
                {
                    fordonInfo = bil.ElBil ? "Elbil" : "";
                }
                else if (fordon is Buss buss)
                {
                    fordonInfo = $"Passagerare: {buss.Passagerare}";
                }

                Console.WriteLine($"Plats {i + 1}: {fordonstyp} -  {fordon.RegNr}, Färg: {fordon.Färg}, {fordonInfo}");
            }
        }

        Console.WriteLine("-------------------------\n");
    }


    public double FordonPlats(IFordon fordon)
    {
        if (fordon is Bil) return 1;
        else if (fordon is Buss) return 2;
        else if (fordon is Motorcykel) return 0.5;
        return 1;
    }
}
