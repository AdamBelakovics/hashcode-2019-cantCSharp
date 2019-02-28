using System;
using System.Collections.Generic;
using System.Text;

namespace hascode
{
	interface ISlide
	{
		List<string> GetTags();
	}

	class HorizontalSlide : ISlide
	{
		public Picture Picture { get; set; }

		public List<string> GetTags()
		{
			return Picture.Tags;
		}
	}

	class VerticalSlide : ISlide
	{
		public List<string> GetTags()
		{
			var tags = new List<string>();
			Pictures.ForEach(p => tags.AddRange(p.Tags));
			return tags;
		}

		public List<Picture> Pictures;
	}
}
