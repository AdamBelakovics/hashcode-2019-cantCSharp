using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace hascode
{
	class Slideshow
	{
		public List<ISlide> Slides { get; set; }

		public int Score
		{
			get
			{
				var sum = 0;
				for (var i = 0; i < Slides.Count - 1; i++)
				{
					var first = Slides[i].GetTags();
					var second = Slides[i + 1].GetTags();
					var union = first.Intersect(second).Count();
					var except1 = first.Except(second).Count();
					var except2 = second.Except(first).Count();
					sum += Math.Min(union, Math.Min(except1, except2));
				}
				return sum;
			}
		}

		public void prnintOutputTo(string outputPath)
		{
			using (var sw = new StreamWriter(outputPath))
			{
				sw.WriteLine(Slides.Count);
				foreach (var slide in Slides)
				{
					sw.WriteLine(slide.GetIds());
				}
			}
		}

	}
}
