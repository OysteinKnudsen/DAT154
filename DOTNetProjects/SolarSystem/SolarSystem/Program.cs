using System;
using System.Collections.Generic;
using SpaceSim;
using SolarSystem.SpaceObjects;
class Astronomy
{
    public static void Main()
    {
        List<SpaceObject> solarSystem = new List<SpaceObject>

        //From nasa.gov: 
        // Planets, comets, asteroids and other objects in the solar system orbit the sun.
 {
         new Star("Sun", "Yellow"),
         new Star("Sun", "blue"),
         new Planet("Mercury", "Gray"),
         new Planet("Venus", "Blue"),
         new Planet("Terra", "Orange"),
         new Moon("The Moon", "White/Gray"), 
         new DwarfPlanet("Pluto", "Dirty Brown")

 };
        foreach (SpaceObject obj in solarSystem)
        {
            obj.Draw();
        }

        Console.ReadLine();
    }
}
