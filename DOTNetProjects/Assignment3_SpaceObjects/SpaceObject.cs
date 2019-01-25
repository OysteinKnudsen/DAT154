using System; 


namespace SpaceSim {
	
	//Start class SpaceObject
	
	public class SpaceObject{
		
		protected String name;
		
		public SpaceObject(String name) {
			this.name = name;		
		}
		
		public virtual void Draw (){
			Console.WriteLine(name);
		}
	} //End class SpaceObject
	
	//Start class Star 
	public class Star : SpaceObject {
		public Star (String name) : base (name) {}
		public override void Draw () {
			Console.Write("Star : " ); 
			base.Draw();
		}
	}// End class Star
	
	//Start class Planet
	public class Planet : SpaceObject {
		public Planet (String name) : base (name) {}
		public override void Draw () {
			Console.Write("Planet : "); 
			base.Draw();
		}
	}  // End class Planet 
	
	//Start class Moon
	public class Moon : SpaceObject {
		public Moon (String name) : base (name) {}
			public override void Draw () {
				Console.Write("Moon : ");
				base.Draw();
			}
	}
	} 
	
