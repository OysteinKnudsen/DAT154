﻿using System;
using System.Collections.Generic;
using SpaceSim;
class Astronomy
{
    public static void Main()
    {
        List<SpaceObject> solarSystem = new List<SpaceObject>
 {
         new Star("Sun"),
         new Star("Sun"),
         new Planet("Mercury"),
         new Planet("Venus"),
         new Planet("Terra"),
         new Moon("The Moon"), 

 };
        foreach (SpaceObject obj in solarSystem)
        {
            obj.Draw();
        }

        Console.ReadLine();
    }
}