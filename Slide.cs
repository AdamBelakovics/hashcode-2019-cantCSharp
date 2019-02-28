using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hascode
{
	public interface ISlide
	{
		HashSet<string> GetTags();
		string GetIds();
	}

	class HorizontalSlide : ISlide
	{
		public Picture Picture { get; set; }

		public string GetIds()
		{
			return Picture.Index.ToString();
		}

		public HashSet<string> GetTags()
		{
			return Picture.Tags;
		}
	}

	class VerticalSlide : ISlide
	{
		public List<Picture> Pictures = new List<Picture>();
		public HashSet<string> GetTags()
		{
			return new HashSet<string>(Pictures[0].Tags.Union(Pictures[1].Tags));
		}

		public string GetIds()
		{
			return $"{Pictures[0]} {Pictures[1]}";
		}
	}

	public static class SlideExtensions
	{
		public static int GetScoreWith(this ISlide first, ISlide other)
		{
			var sum = 0;

			var union = first.GetTags().Intersect(other.GetTags()).Count();
			var except1 = first.GetTags().Except(other.GetTags()).Count();
			var except2 = other.GetTags().Except(first.GetTags()).Count();
			sum += Math.Min(union, Math.Min(except1, except2));
			return sum;
		}
	}
}
