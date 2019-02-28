using System;
using System.Collections.Generic;
using System.Text;
using hascode;

namespace hascode
{
    class Greedy : IStrategy
    {
        public Slideshow execute()
        {
            return new Slideshow();
        }
    }
}