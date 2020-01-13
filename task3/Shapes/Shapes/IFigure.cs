using System;
using System.Collections.Generic;
using System.Text;

namespace Figures
{

    public enum Colors
    {
        White,
        Blue,
        Red,
        Black,
        Green,
        Pink,
        Colorless

    }
    /// <summary>
    /// Interfase for figure type
    /// </summary>
    public interface IFigure
    {

        double GetS();
        double GetP();
    }
}
