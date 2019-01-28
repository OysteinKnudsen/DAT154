using SpaceSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem.SpaceObjects
{
    public class GalaxyCluster : SpaceObject
    {
        public GalaxyCluster(String name, String color) : base(name, color) { }

        public override void Draw()
        {
            Console.Write("Galaxy cluster : ");
            base.Draw();
        }
    }
}
