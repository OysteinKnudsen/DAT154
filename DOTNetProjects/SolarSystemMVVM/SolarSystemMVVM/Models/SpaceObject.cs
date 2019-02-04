using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystemMVVM.Models
{
   public class SpaceObject
    {
        public string Name { get; set; }
        public string Orbits { get; set; }
        public int Distance { get; set; }
        public double OrbitalPeriod { get; set; }

        public SpaceObject()
        {
            Name = "Unknown name";
            Orbits = "Unknown orbit";
            Distance = -1;
            OrbitalPeriod = -1;
        }
        public SpaceObject(string name, string orbits, int distance, int orbitalPeriod)
        {
            Name = name;
            Orbits = orbits;
            Distance = distance;
            OrbitalPeriod = orbitalPeriod;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Name: {Name}");
        }

        public override string ToString()
        {
            return $"Name : {Name} | Orbits : {Orbits} | Distance (000) km : {Distance} | Orbital period : {OrbitalPeriod}";
        }

    }
}
