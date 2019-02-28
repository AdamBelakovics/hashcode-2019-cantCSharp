using System.Collections.Generic;

namespace hascode
{
    interface IVerticalMatchingStrategy
    {
        List<ISlide> matchVerticalPictures(List<Picture> verticalPictures);
    }
}