using System;
namespace SpaceSim
{
    public class SpaceObject
    {
        protected String name;
        public SpaceObject(String name)
        {
            this.name = name;
        }
        public virtual void Draw()
        {
            Console.WriteLine(name);
        }
    }
    public class Star : SpaceObject
    {
        public Star(String name) : base(name) { }
        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        public Planet(String name) : base(name) { }
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet (String name ) : base(name) { }

        public override void Draw ()
        {
            Console.Write("Dwarf planet : ");
            base.Draw();
        }
    }

    public class Moon : SpaceObject
    {
        public Moon(String name) : base(name) { }
        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }

    public class Galaxy : SpaceObject {
        public Galaxy (String name) : base(name) { }

        public override void Draw ()
        {
            Console.Write("Galaxy : ");
            base.Draw();
        }
    }

    public class StarCluster : SpaceObject
    {
        public StarCluster (String name ) : base(name) { }

        public override void Draw ()
        {
            Console.Write("Star cluster : ");
            base.Draw();
        }
    }

    public class GalaxyCluster : SpaceObject
    {
        public GalaxyCluster (String name ) : base(name) { }

        public override void Draw ()
        {
            Console.Write("Galaxy cluster : ");
            base.Draw();
        }
    }



}
