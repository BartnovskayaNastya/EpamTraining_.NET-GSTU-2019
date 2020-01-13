using System;
using Figures;
using Shapes;
using PaperFigures;
namespace FilmFigures
{
    class FilmRectangle : Rectangle, IFilm
    {
        static readonly Colors color = Colors.Colorless;
        public FilmRectangle(params int[] points) : base(points)
        {
        }

        /// <summary>
        /// Constructor for cuting new figure
        /// </summary>
        /// <param name="figure">Result of cutting figure </param>
        /// /// <param name="r">Radius of cutting figure </param>
        /// 
        public FilmRectangle(IFigure figure, int a, int b) : base(figure, a, b)
        {
            if (figure is IPaper)
            {
                throw new Exception("You can't cut film figure from paper figure. Figure should be paper!");
            }
        }
    }
}
