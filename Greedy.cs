using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hascode;

namespace hascode
{
    class Greedy : IStrategy
    {
        public Slideshow execute(PictureStore pictureStore)
        {
            var slides = createSlides(pictureStore);
            var orderedSlides = slides.OrderByDescending(s1 => s1.GetTags().Count);
            var result = new Slideshow();
            while(orderedSlides.Count() != 0){

            }
            return new Slideshow();
        }

        public List<ISlide> createSlides(PictureStore store){
            var ss = new List<ISlide>();
            foreach(var pic in store.HorizontalPictures){
                var s = new HorizontalSlide();
                s.Picture = pic;
                ss.Add(s);
            }
            //TODO Horizontal
            return ss;
        }
    }
}