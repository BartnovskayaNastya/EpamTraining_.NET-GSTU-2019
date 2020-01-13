using System;
using PaperFigures;
using Figures;
using Shapes;

namespace FilmFigures
{
    class FilmSquare : Square, IFilm
    {
        static readonly Colors color = Colors.Colorless;
        public FilmSquare(params int[] points) : base(points)
        {
        }

        /// <summary>
        /// Constructor for cuting new figure
        /// </summary>
        /// <param name="figure">Result of cutting figure </param>
        /// /// <param name="r">Radius of cutting figure </param>
        /// 
        public FilmSquare(IFigure figure, int size) : base(figure, size)
        {
            if (figure is IPaper)
            {
                throw new Exception("You can't cut film figure from paper figure. Figure should be paper!");
            }
        }
    }
}