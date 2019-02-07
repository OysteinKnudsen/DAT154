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
        public int _xPos;
        public int _yPos;

        public event PropertyChangedEventHandler PropertyChanged;

        public SpaceObject()
        {
            _name = "Unknown name";
            _orbits = "Unknown orbit";
            _distance = -1;
            _orbitalPeriod = -1;
        }
        public SpaceObject(string name, string orbits, int distance, int orbitalPeriod)
        {
            _name = name;
            _orbits = orbits;
            _distance = distance;
            _orbitalPeriod = orbitalPeriod;
        }

        private void OnPropertyChanged()
        {

        }
        public override string ToString()
        {
            return $"Name : {_name} | Orbits : {_orbits} | Distance (000) km : {_distance} | Orbital period : {_orbitalPeriod}";
        }

    }
}
