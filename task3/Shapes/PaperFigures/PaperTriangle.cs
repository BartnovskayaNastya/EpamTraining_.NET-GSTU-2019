using System;
using Figures;
using Shapes;

namespace PaperFigures
{
    class PaperTriangle : Triangle, IPaper
    {
        private Colors color;

        public void setColor(Colors color)
        {
            if (color == Colors.Colorless)
            {
                this.color = color;
            }
            else
            {
                throw new Exception("You can't make this. This figure is already has color!");
            }
        }

        public Colors getColor()
        {
            return color;
        }

        public PaperTriangle(params int[] points) : base(points)
        {
        }

        /// <summary>
        /// Constructor for cuting new figure
        /// </summary>
        /// <param name="figure">Result of cutting figure </param>
        /// /// <param name="r">Radius of cutting figure </param>
        /// 
        public PaperTriangle(IFigure figure, int a, int b, int c) : base(figure, a, b, c)
        {
            if (!(figure is IPaper))
            {
                throw new Exception("You can't cut film figure from paper figure. Figure should be paper!");
            }

            else if (figure is IPaper && this.color != ((IPaper)figure).getColor())
            {
                throw new Exception("You can't cut figure with this color");
            }

            this.color = ((IPaper)figure).getColor();
        }
    }
}
