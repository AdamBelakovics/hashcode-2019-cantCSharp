using hascode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hascode
{
    class Greedy : IStrategy
    {
        public Slideshow execute(PictureStore pictureStore)
        {
            var slides = createSlides(pictureStore);
            var orderedSlides = new LinkedList<ISlide>(slides.OrderByDescending(s1 => s1.GetTags().Count));
            Slideshow result = new Slideshow() { Slides = orderedSlides.Take(1).ToList() };
            orderedSlides.RemoveFirst();
            while (orderedSlides.Any())
            {
                var prev = result.Slides.Last();
                LinkedListNode<ISlide> bestNode = orderedSlides.First;
                LinkedListNode<ISlide> node = orderedSlides.First;
                var bestScoreSoFar = prev.GetScoreWith(bestNode.Value);
                int ahead = 0;
                while (node != null)
                {
                    if (ahead++ > 50) break;
                    if (node.Value.GetTags().Count / 2 <= bestScoreSoFar) break;
                    var nextNode = node.Next;
                    var score = prev.GetScoreWith(node.Value);
                    if (score > bestScoreSoFar)
                    {
                        bestScoreSoFar = score;
                        bestNode = node;
                    }
                    node = nextNode;
                }
                result.Slides.Add(bestNode.Value);
                orderedSlides.Remove(bestNode);
            }
            return result;
        }

        public List<ISlide> createSlides(PictureStore store)
        {
            var ss = new List<ISlide>();
            foreach (var pic in store.HorizontalPictures)
            {
                var s = new HorizontalSlide();
                s.Picture = pic;
                ss.Add(s);
            }
            //TODO Horizontal
            return ss;
        }
    }
}