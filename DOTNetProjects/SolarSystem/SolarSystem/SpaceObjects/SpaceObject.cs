using SolarSystem;
using System;
namespace SpaceSim
{
    public class SpaceObject
    {
        private string name;
        private string color;

        //Fields
        protected string _name { get; set; }

        protected string _color { get; set; }

        protected double _radius { get; set; }

        public Coordinates _position { get; set; }

        //Methods

        public SpaceObject(string name, string color, Coordinates position)
        {
            this._name = name;
            this._color = color;
            this._position = position;
        }

        public SpaceObject(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public SpaceObject()
        {
        }

        public virtual void Draw()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Current position: {_position}");
        }

        /// <summary>
        /// Calculates position of space object based on a given time starting from 0.
        /// </summary>
        /// <param name="time"></param>
        /// <returns>Position of the space object at a given time</returns>
        public virtual Coordinates CalculatePosition(double time)
        {
            return new Coordinates();
        }
    }
}
