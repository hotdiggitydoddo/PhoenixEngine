using System;

namespace Phoenix.Core
{
	public abstract class Feature
	{
		public abstract bool IsValid();
	}

	public class Room : Feature 
	{
		public override bool IsValid ()
		{
			throw new NotImplementedException ();
		}

		public Room CreateRandomAt(int x, int y, int dx, int dy, int minWidth, int maxWidth, int minHeight, int maxHeight)
		{

		}
	}

}

