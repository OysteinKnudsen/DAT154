using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    public struct Coordinates
    {
        double x { get; set; }
        double y { get; set; }

        public Coordinates (double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }


        
    }
}
