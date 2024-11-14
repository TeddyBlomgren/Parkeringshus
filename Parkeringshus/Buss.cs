using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus
{
    public class Buss : Fordon
    {
        public int Passagerare { get; set; }
        public override double ParkeringsPlatser => 2;

        public Buss (string regNr, string färg, int  passagerare) : base (regNr, färg)
        {
            Passagerare = passagerare;
        }

    }
}
