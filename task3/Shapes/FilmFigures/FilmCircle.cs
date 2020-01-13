using System;
using Figures;
using PaperFigures;

namespace FilmFigures
{
    public class FilmCircle : Circle, IFilm
    {
        static readonly Colors color = Colors.Colorless;
        public FilmCircle(params int[] points) : base (points)
        {
        }

        /// <summary>
        /// Constructor for cuting new figure
        /// </summary>
        /// <param name="figure">Result of cutting figure </param>
        /// /// <param name="r">Radius of cutting figure </param>
        /// 
        public FilmCircle(IFigure figure, int r) : base(figure, r)
        {
            if (figure is IPaper)
            {
                throw new Exception("You can't cut paper figure from film figure. Figure should be film!");
            }
        }


    }
}
