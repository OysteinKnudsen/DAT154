using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    public class Coordinates
    {
        public double x { get; set; }
        public  double y { get; set; }

        public Coordinates (double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }



    }
}
