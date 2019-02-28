using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hascode
{
	interface ISlide
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
			return Pictures[0].Tags.Union(Pictures[1].Tags) as HashSet<string>;
		}

		public string GetIds()
		{
			return $"{Pictures[0]} {Pictures[1]}";
		}

	}
}
