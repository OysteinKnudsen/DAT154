using SpaceSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem.SpaceObjects
{
    public class Star : SpaceObject
    {
        public Star(string name, string color) : base(name, color) { }
        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }
}
