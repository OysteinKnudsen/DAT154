using SolarSystem;
using System;
namespace SpaceSim
{
    public class SpaceObject
    {
        //Fields
        private string name { get; set; }

        private string color { get; set; }

        private double radius { get; set; }

        private double orbitalRadius { get; set; } //Assume circular orbits

        private double rotationalPeriod { get; set; } //Length of day

        private Coordinates position { get; set; }

        //Methods

        public SpaceObject(string name, string color)
        {
            this.name = name;
            this.color = color;
        }


        public virtual void Draw()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Color {color}");
        }

        /// <summary>
        /// Calculates position of space object based on a given time starting from 0.
        /// </summary>
        /// <param name="time"></param>
        /// <returns>Position of the space object at a given time</returns>
        public virtual Coordinates CalculatePosition(double time)
        {
            var coordinates = new Coordinates();
            this.position = coordinates;
            return coordinates;
        }
    }
}
