using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem.SpaceObjects
{
    public class DwarfPlanet : Planet
    {
        public DwarfPlanet(string name, string color) : base(name, color) { }

        public override void Draw()
        {
            Console.Write("Dwarf planet : ");
            base.Draw();
        }
    }
}
