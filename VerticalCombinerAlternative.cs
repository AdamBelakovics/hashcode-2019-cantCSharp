using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace hascode
{
	class VerticalCombinerAlternative : IVerticalMatchingStrategy
	{
		public List<ISlide> MatchVerticalPictures(List<Picture> verticalPictures)
		{
			var s = new List<ISlide>();
			var sorted = verticalPictures.OrderBy(p => p.Tags.Count).ToList();
			if (sorted.Count() % 2 != 0)
				sorted.RemoveAt(0);

			for (var index = 0; index < sorted.Count / 2; index++)
			{
				s.Add(new VerticalSlide()
				{
					Pictures = new List<Picture>()
					{
						sorted[index],
						sorted[sorted.Count-index-1]
					}
				});
			}

			return s;
		}
	}
}
