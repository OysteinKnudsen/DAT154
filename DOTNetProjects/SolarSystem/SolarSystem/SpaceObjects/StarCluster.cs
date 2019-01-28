using SpaceSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem.SpaceObjects
{
    public class StarCluster : SpaceObject
    {
        public StarCluster(String name, string color) : base(name, color) { }

        public override void Draw()
        {
            Console.Write("Star cluster : ");
            base.Draw();
        }
    }
}
