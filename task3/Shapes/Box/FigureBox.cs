using System;
using System.Collections.Generic;
using BoxExceptions;
using Shapes;

namespace Box
{
    public class FigureBox
    {
        List<Figure> box = new List<Figure>(20);

        public FigureBox()
        {
        }

        public void AddFigure(Figure figure, Material material)
        {
            if (box.Count == 20)
            {
                throw new FullBoxException();
            }

            foreach (Figure someFigure in box)
            {
                if (figure.Equals(someFigure))
                {
                    throw new Exception("You can't make this figure, becouse she already exists");
                }
            }

            box.Add(figure);
        }

        public void FindByNumber(int number)
        {
            if (number > box.Count)
            {
                throw new Exception("There is no figure by this number. The amount of figures is " + box.Count);
            }
            if (number <= 0)
            {
                throw new Exception("You need to input positive number");
            }

            for (int i = 0; i < box.Count; i++)
            {
                if (i == number - 1)
                {
                    box[i].ToString();
                }
            }

        }

        public void RemoveByIndex(int index)
        {
            if (index > box.Count)
            {
                throw new Exception("There is no figure by this number. The amount of figures is " + box.Count);
            }
            if (index <= 0)
            {
                throw new Exception("You need to input positive number");
            }
            box.RemoveAt(index - 1);

        }

        public void ChangeByNumber(int number, Figure figure)
        {
            if (number > box.Count)
            {
                throw new Exception("There is no figure by this number. The amount of figures is " + box.Count);
            }
            if (number <= 0)
            {
                throw new Exception("You need to input positive number");
            }

            box.Insert(number - 1, figure);

        }

        public void FindFigure(Figure figure)
        {
            foreach (Figure someFigure in box)
            {
                if (figure.Equals(someFigure))
                {
                    figure.ToString();
                }
            }
        }

        public void ShowExistsFigures()
        {
            foreach (Figure someFigure in box)
            {
                someFigure.ToString();
            }
        }

        public double GetPFigures()
        {
            double result = 0;
            foreach (Figure someFigure in box)
            {
                result += someFigure.GetP();
            }

            return result;
        }

        public double GetSFigures()
        {
            double result = 0;
            foreach (Figure someFigure in box)
            {
                result += someFigure.GetS();
            }

            return result;
        }

        public double GetSFigures()
        {
            double result = 0;
            foreach (Figure someFigure in box)
            {
                result += someFigure.GetS();
            }

            return result;
        }

    }
}
