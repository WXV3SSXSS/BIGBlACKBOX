using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIGBlACKBOX
{
	internal class Particle
	{
		public double x { get; set; }
		public double y { get; set; }
		public double value { get; set; }

		public Particle(int x, int y)
		{
			this.x = x;	
			this.y = y;
		}
		public Particle()
		{

		}
	}
}
