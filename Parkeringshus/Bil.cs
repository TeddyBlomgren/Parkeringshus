using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus
{
    internal class Bil : Fordon
    {
        public bool ElBil { get; set; }
        public override double ParkeringsPlatser => 1;

        public Bil(string regNr, string color, bool elBil) : base(regNr, color)
        {
            ElBil = elBil;
        }
    }
}
