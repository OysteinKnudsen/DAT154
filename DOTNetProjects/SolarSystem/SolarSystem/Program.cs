using System;
using System.Collections.Generic;
using SpaceSim;
using SolarSystem.SpaceObjects;
using SolarSystem;

class Astronomy
{
    public static void Main()
    {
        List<SpaceObject> solarSystem = new List<SpaceObject>

        //From nasa.gov: 
        // Planets, comets, asteroids and other objects in the solar system orbit the sun.
 {
         new Star("Sun", "Yellow", new Coordinates(0,0)),
         new Planet("Mercury" , "Gray", 2439.7, 60000000, 87.8, new Coordinates(60000000,0 ))

 };
        double numberOfDays = 0;
        while (numberOfDays < 100)
        {
            foreach (SpaceObject obj in solarSystem)
            {
                obj.Draw();
                obj.CalculatePosition(numberOfDays);
            }
            numberOfDays += 21.75;

        }


    }
}
