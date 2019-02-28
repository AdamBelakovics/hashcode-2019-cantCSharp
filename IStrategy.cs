using System;
using System.Collections.Generic;
using System.Text;
using hascode;

namespace hascode
{
	interface IStrategy {
        Slideshow execute(PictureStore pictureStore);
    }
}