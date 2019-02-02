using SpaceSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem.SpaceObjects
{
    public class Asteroid : SpaceObject
    {

        private double _radius { get; set; }


        public Asteroid(string name, string color, Coordinates position) : base(name, color, position) { }

        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }
}
