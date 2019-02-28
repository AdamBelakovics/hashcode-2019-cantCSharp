using System;
using System.Collections.Generic;
using System.Text;
using hascode;

namespace hascode
{
	class Algorithm {
        public static Slideshow run(/* input, */ IStrategy strategy){
            return strategy.execute(/* input */);
        }
    }
}
