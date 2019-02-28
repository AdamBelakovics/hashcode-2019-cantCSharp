using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace hascode
{
	class Checkered : IStrategy
	{
		int SimilarTags(ISlide a, ISlide b)
		{
			return a.GetTags().Intersect(b.GetTags()).Count();
		}
		int DifferentTags(ISlide a, ISlide b)
		{
			return a.GetTags().Except(b.GetTags()).Count() + b.GetTags().Except(a.GetTags()).Count();
		}
		public Slideshow execute(PictureStore pictureStore)
		{
			var ss = new List<ISlide>();
			foreach (var pic in pictureStore.HorizontalPictures)
			{
				ss.Add(new HorizontalSlide() { Picture = pic });
			}
			ss.AddRange(new VerticalCombiner().MatchVerticalPictures(pictureStore.VerticalPictures));

			ss = ss.OrderByDescending(s => s.GetTags().Count).ToList();

			var ssresult = new List<ISlide>()
			{
				ss[0]
			};

			ss.RemoveAt(0);

			var max = 0;
			var maxSlide = ssresult.Last();

			for (int i = 0; i < ss.Count; i++)
			{
				if (ssresult.Last().GetScoreWith(ss[i]) >= max)
				{
					maxSlide = ss[i];
				}
			}

			ssresult.Add(maxSlide);
			ss.Remove(ssresult.Last());

			int count = 80;
			var similarTo1 = ss.OrderBy(s => s.GetScoreWith(ssresult[0])).ThenByDescending(s => s.GetScoreWith(ssresult[1])).ToList();
			var similarTo2 = ss.OrderBy(s => s.GetScoreWith(ssresult[1])).ThenByDescending(s => s.GetScoreWith(ssresult[0])).ToList();

			while (similarTo1.Count() > 0 && similarTo2.Count() > 0)
			{
				if (count == 0)
				{
					count = 80;
					similarTo1 = ss.OrderBy(s => s.GetScoreWith(ssresult[ssresult.Count-2])).ThenByDescending(s => s.GetScoreWith(ssresult[ssresult.Count-1])).ToList();
					similarTo2 = ss.OrderBy(s => s.GetScoreWith(ssresult[ssresult.Count-1])).ThenByDescending(s => s.GetScoreWith(ssresult[ssresult.Count-2])).ToList();
					Console.WriteLine($"{(1-(ss.Count/80000.0))*100}%");
				}


				ssresult.Add(similarTo1[0]);
				similarTo2.Remove(similarTo1[0]);
				ss.Remove(similarTo1[0]);
				similarTo1.RemoveAt(0);

				ssresult.Add(similarTo2[0]);
				similarTo1.Remove(similarTo2[0]);
				ss.Remove(similarTo2[0]);
				similarTo2.RemoveAt(0);

				count--;
			}

			return new Slideshow() { Slides = ssresult };

		}
	}
}
