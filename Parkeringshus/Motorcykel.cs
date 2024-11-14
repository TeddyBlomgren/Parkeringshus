using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus
{
    public class Motorcykel : Fordon
    {
        public string Märke { get; private set; }
        public override double ParkeringsPlatser => 0.5;

        public Motorcykel(string regNr, string färg, string märke) : base(regNr, färg)
        {
            Märke = märke;
        }
    }
}
