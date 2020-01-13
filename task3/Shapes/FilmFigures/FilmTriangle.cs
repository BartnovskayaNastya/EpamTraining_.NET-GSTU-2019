using System;
using PaperFigures;
using Figures;
using Shapes;

namespace FilmFigures
{
    class FilmTriangle : Triangle, IFilm
    {
        static readonly Colors color = Colors.Colorless;
        public FilmTriangle(params int[] points) : base(points)
        {
        }

        /// <summary>
        /// Constructor for cuting new figure
        /// </summary>
        /// <param name="figure">Result of cutting figure </param>
        /// /// <param name="r">Radius of cutting figure </param>
        /// 
        public FilmTriangle(IFigure figure, int a, int b, int c) : base(figure, a, b, c)
        {
            if (figure is IPaper)
            {
                throw new Exception("You can't cut film figure from paper figure. Figure should be paper!");
            }
        }
    }
}
