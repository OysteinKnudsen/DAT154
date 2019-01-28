using SpaceSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem.SpaceObjects
{
    public class Planet : SpaceObject
    {
        //Fields 
        
        //Constructor
        public Planet(string name, string color) : base(name, color) { }

        //Methods
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }
}
