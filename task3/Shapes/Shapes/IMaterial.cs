using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public enum Color
    {
        Black = 0,
        White,
        Pink,
        Blue,
        Green,
        Red,
        Orange,
        Yellow,
        Purple
    }

    public enum Material
    {
        Paper = 0,
        Film
    }

    interface IMaterial
    {
        void Paint(Color color); 
    }
}
