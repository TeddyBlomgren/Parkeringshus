using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus
{
    public interface IFordon
    {
        public string RegNr { get; set; }
        public string Färg { get; set; }
        public DateTime Incheckningstid { get; set; } 
        public decimal Parkeringskostnad(TimeSpan parkedTime);
    }

    public abstract class Fordon : IFordon
    {
        public string RegNr { get; set; }
        public string Färg { get; set; }
        
        public DateTime Incheckningstid { get; set; }
        

        protected Fordon(string regNr, string färg)
        {
            RegNr = regNr;
            Färg = färg;
            Incheckningstid = DateTime.Now;
        }

        public abstract double ParkeringsPlatser {  get; }
        public decimal Parkeringskostnad(TimeSpan parkedTime)
        {
            return (decimal)parkedTime.TotalMinutes * 1.5m;
        }
    }
}
