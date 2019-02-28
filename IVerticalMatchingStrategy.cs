using System.Collections.Generic;

namespace hascode
{
    interface IVerticalMatchingStrategy
    {
        List<ISlide> MatchVerticalPictures(List<Picture> verticalPictures);
    }
}