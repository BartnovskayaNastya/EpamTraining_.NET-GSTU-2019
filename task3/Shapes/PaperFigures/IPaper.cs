using System;
using System.Collections.Generic;
using System.Text;
using Figures;

namespace PaperFigures
{
    public interface IPaper
    {
        void setColor(Colors color);
        Colors getColor();
    }


}
