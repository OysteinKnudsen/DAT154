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
        private string name;
        private string color;
        private double radius;
        private Coordinates position;

        //Fields 

        /// <summary>
        /// Radius in km 
        /// </summary>
        private double _radius { get; set; }

        private double _orbitalRadius { get; set; } //Assume circular orbits

        private double _rotationalPeriod { get; set; } //Length of day

        private double _orbitalPeriod { get; set; }

        private Moon[] moons { get; set; }

        //Constructor
        public Planet(string name, string color, double radius, double orbitalRadius, double orbitalPeriod, Coordinates position) : base(name, color, position) {
            this._radius = radius;
            this._orbitalRadius = Math.Log10(orbitalRadius);
            this._orbitalPeriod = orbitalPeriod;
        }

        public Planet(string name, string color, double radius, Coordinates position)
        {
            this.name = name;
            this.color = color;
            this.radius = radius;
            this.position = position;
        }

        //Methods
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
        public override Coordinates CalculatePosition (double time)
        {
            double totalLength = 2 * _orbitalRadius * Math.PI;
            double speed = totalLength / _orbitalPeriod;
            Coordinates sunCoordinates = new Coordinates(0, 0);
            
            _position.x = sunCoordinates.x + Math.Cos(speed*time) * _orbitalRadius;
            _position.y = sunCoordinates.y + Math.Sin(speed*time) * _orbitalRadius;

            return new Coordinates(_position.x, _position.y);
        } 
    }
}
