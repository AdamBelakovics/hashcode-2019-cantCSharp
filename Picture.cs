using System;
using System.Collections.Generic;
using System.Text;

namespace hascode
{
	enum Orientation
	{
		Horizontal,Vertical
	}
	class Picture
	{
		public int Index { get; set; }
		public Orientation Orientation { get; set; }
		public HashSet<string> Tags { get; set; }
	}
}
