using SpaceSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem.SpaceObjects
{
    public class Comet : SpaceObject
    {
        public Comet(String name, string color) : base(name, color) { }

        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }
}
