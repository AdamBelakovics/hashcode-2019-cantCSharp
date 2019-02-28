using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace hascode
{
	class PictureStore
	{
		public List<Picture> HorizontalPictures { get; set; } = new List<Picture>();
		public List<Picture> VerticalPictures { get; set; } = new List<Picture>();
	}
	class InputInterpreter
	{
		public static PictureStore Interpret(string inputPath)
		{
			var picStore = new PictureStore();

			using (StreamReader s = new StreamReader(inputPath))
			{
				var n = int.Parse(s.ReadLine());
				for (int i = 0; i < n; i++)
				{
					var p = new Picture();
					var input = s.ReadLine().Split(' ');
					if (input[0].Equals("V"))
						p.Orientation = Orientation.Vertical;
					else
						p.Orientation = Orientation.Horizontal;

					for (int j = 0; j < int.Parse(input[1]); j++)
						p.Tags.Add(input[2 + j]);

					switch (p.Orientation)
					{
						case Orientation.Horizontal:
							picStore.HorizontalPictures.Add(p);
							break;
						case Orientation.Vertical:
							picStore.VerticalPictures.Add(p);
							break;
						default:
							break;
					}
				}
			}
			return picStore;
		}
	}
}
