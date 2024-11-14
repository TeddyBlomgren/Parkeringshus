using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus
{
    public class ParkeringsHus
    {

        public IFordon Fordon1 { get; set; }
        public IFordon Fordon2 { get; set; }


        public bool ÄrLedig => Fordon1 == null && Fordon2 == null;


    }

}






