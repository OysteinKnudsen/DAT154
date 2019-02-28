using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystemMVVM.Models
{
   public class SpaceObject : INotifyPropertyChanged
    {
        public string _name { get; set; }
        public string _orbits { get; set; }
        public int _distance { get; set; }
        public double _orbitalPeriod { get; set; }
        private double _xPos;
        private double _yPos;
        private double initialXPos;
        private double initialYPos;
        private static Random rand = new Random();
        private int EarthYear = 365;
        private double EarthOrbitRadius = 40;

        public event PropertyChangedEventHandler PropertyChanged;

        #region constructors
        public SpaceObject()
        {
            _name = "Unknown name";
            _orbits = "Unknown orbit";
            _distance = -1;
            _orbitalPeriod = -1;
            _xPos = rand.Next(0, 400);
            _yPos = rand.Next(0, 400);
        }
        public SpaceObject(string name, string orbits, int distance, int orbitalPeriod)
        {
            _name = name;
            _orbits = orbits;
            _distance = distance;
            _orbitalPeriod = orbitalPeriod;
            _xPos = Math.Log(distance);
            _yPos = 0;
            initialXPos = new Random().Next(100,300);
            initialYPos = new Random().Next(100,300);
        }

        #endregion
        #region Getters/Setters
        public string GetName()
        { return _name; }

        public void SetName(string value)
        {
            _name = value;
            OnPropertyChanged("Name");
        }

        public double GetXPos (){ return _xPos; }

        public void SetXPos (int xPos)
        {
            _xPos = xPos;
            OnPropertyChanged("XPos");
        }

        public double GetYPos() { return _yPos; }

        public void SetYPos(int yPos)
        {
            _yPos = yPos;
            OnPropertyChanged("YPos");
        }
        #endregion

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public override string ToString()
        {
            return $"Name : {_name} | Orbits : {_orbits} | Distance (000) km : {_distance} | Orbital period : {_orbitalPeriod}";
        }

        public void UpdatePosition(int days)
        {
            double angle = 2 * Math.PI * days / _orbitalPeriod;
            initialXPos = _distance / 100;
            _xPos = initialXPos + _distance/1000 * Math.Cos(angle);
            _yPos = initialYPos +  _distance/1000 * Math.Sin(angle);
        }

    }
}
