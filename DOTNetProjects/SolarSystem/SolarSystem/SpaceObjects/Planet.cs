using SpaceSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SolarSystem.SpaceObjects
{
    public class Planet : SpaceObject
    {
        private string name;
        private Color color;
        private double radius;
        private Coordinates position;
        private string color1;

        //Fields 

        /// <summary>
        /// Radius in km 
        /// </summary>
        public double _radius { get; set; }

        public  double _orbitalRadius { get; set; } //Assume circular orbits

        public  double _rotationalPeriod { get; set; } //Length of day

        public  double _orbitalPeriod { get; set; }

        public Color _color { get; set; }

        private Moon[] moons { get; set; }

        //Constructor
        public Planet(string name, string color, double radius, double orbitalRadius, double orbitalPeriod, Coordinates position) : base(name, color, position) {
            this._radius = radius;
            this._orbitalRadius = Math.Log10(orbitalRadius);
            this._orbitalPeriod = orbitalPeriod;
        }

        public Planet(string name, double radius, Coordinates position)
        {
            this.name = name;
            this.radius = radius;
            this.position = position;
        }
        
        public Planet (double orbitalRadius, double orbitalPeriod, Color color, double radius, Coordinates position)
        {
            
            this._orbitalRadius = orbitalRadius;
            this._orbitalPeriod = orbitalPeriod;
            this._radius = radius;
            this._position = position;
            this._color = color;
        }

        public Planet(string name, string color1, double radius, Coordinates position)
        {
            this.name = name;
            this.color1 = color1;
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
            double speed = Math.Log(totalLength / _orbitalPeriod)/10;
            Coordinates sunCoordinates = new Coordinates(0, 0);
            
            _position.x = sunCoordinates.x + Math.Cos(speed*time) * _orbitalRadius;
            _position.y = sunCoordinates.y + Math.Sin(speed*time) * _orbitalRadius;

            return new Coordinates(_position.x, _position.y);
        } 
    }
}
