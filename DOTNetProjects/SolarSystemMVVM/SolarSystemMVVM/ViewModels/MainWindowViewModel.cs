using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarSystemMVVM.Models;
using SolarSystemMVVM.ViewModels.Commands;
using SolarSystemMVVM.DataProviders;

namespace SolarSystemMVVM.ViewModels
{
    public class MainWindowViewModel
    {

        #region Fields and properties
        public StartSimulationCommand _startSimulationCommand { get; set; }
        public ObservableCollection<SpaceObject> _solarSystem { get; } = new ObservableCollection<SpaceObject>();
        private PlanetsDataProvider _planetsDataProvider = new PlanetsDataProvider();
        private List<SpaceObject> _spaceObjects = new List<SpaceObject>();
        #endregion

        public MainWindowViewModel()
        {
            _spaceObjects = _planetsDataProvider.GetSpaceObjects();
            CreateObservableCollection();
            _startSimulationCommand = new StartSimulationCommand(this);
        }


        #region Methods
        public void StartSimulation()
        {
            Console.WriteLine("Simulation started");
        }

        private void CreateObservableCollection()
        {
            foreach (SpaceObject spaceObject in _spaceObjects)
            {
                _solarSystem.Add(spaceObject);
            }
        }
        #endregion
    }
}
