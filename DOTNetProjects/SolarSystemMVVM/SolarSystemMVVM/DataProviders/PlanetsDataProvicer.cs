using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarSystemMVVM.Models;

namespace SolarSystemMVVM.DataProviders
{
   public  class PlanetsDataProvider
    {
        private static string _dataPath = "C:\\Code\\School\\" +
            "DAT154 - Systemutvikling og Applikasjonsarkitektur\\" +
            "DOTNetProjects\\" +
            "SolarSystemMVVM\\" +
            "SolarSystemMVVM\\" +
            "Data\\" +
            "PlaneterCSV.csv";

        public PlanetsDataProvider() { }


        public List<SpaceObject> GetSpaceObjects()
        {
            List<SpaceObject> spaceObjects = File.ReadAllLines(_dataPath).Skip(0).Select(s => FromCsv(s)).ToList();
            return spaceObjects;

        }

        public SpaceObject FromCsv(string csvLine)
        {
            string [] values = csvLine.Split(';');
            SpaceObject spaceObject = new SpaceObject();
            try
            {
                spaceObject.Name = values[0];
                spaceObject.Orbits = values[1];
                spaceObject.Distance = Convert.ToInt32(values[2]);
                string orbitalPeriod = values[3];
                spaceObject.OrbitalPeriod = Convert.ToDouble(values[3], System.Globalization.CultureInfo.InvariantCulture);
            } catch (FormatException fe)
            {
                //TODO: Handle exception
            }
            
            return spaceObject;
        }

    }
}
