using System;
using System.Collections.Generic;
using SpaceSim;

class Astronomy {
	
	public static void Main () {
		
		List <SpaceObject> SolarSystem = new List <SpaceObject> {
			new Star ("Sun"),
			new Planet ("Mercury"), 
			new Planet ("Venus"),
			new Moon ("The moon")
		};
		
		foreach (SpaceObject obj in SolarSystem) {
			obj.Draw();
		}
		Console.ReadLine();
	}
}