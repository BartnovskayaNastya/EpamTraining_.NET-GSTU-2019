using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    /// <summary>
    /// enum for painting with colors
    /// </summary>
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

    /// <summary>
    /// enum with materials
    /// </summary>
    public enum Material
    {
        Paper = 0,
        Film
    }

    interface IMaterial
    {
        /// <summary>
        /// Method for painting figure
        /// </summary>
        /// <param name="color">Color for painting</param>
        void Paint(Color color); 
    }
}
