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

        private void CheckException(int number = 3)
        {
            if (box.Count == 0)
            {
                throw new EmptyBoxException();
            }
            if (number > box.Count)
            {
                throw new InvalidNumberException(box.Count);
            }
            if (number <= 0)
            {
                throw new NegativeNumberException();
            }
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
                    throw new ExistsFigureException();
                }
            }

            box.Add(figure);
        }

        public void FindByNumber(int number)
        {
            CheckException(number);

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
            CheckException(index);
            box.RemoveAt(index - 1);

        }

        public void ChangeByNumber(int number, Figure figure)
        {
            CheckException(number);

            box.Insert(number - 1, figure);

        }

        public void FindFigure(Figure figure)
        {
            bool flag = false;
            foreach (Figure someFigure in box)
            {
                if (figure.Equals(someFigure))
                {
                    flag = true;
                    figure.ToString();
                }
            }

            if (flag == false)
                throw new Exception("There is no figure"); 
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
            CheckException();
            double result = 0;
            foreach (Figure someFigure in box)
            {
                result += someFigure.GetP();
            }

            return result;
        }

        public double GetSFigures()
        {
            CheckException();
            double result = 0;
            foreach (Figure someFigure in box)
            {
                result += someFigure.GetS();
            }

            return result;
        }

        public void RemoveAllCircles()
        {
            foreach (Figure someFigure in box.ToArray())
            {
                if(someFigure is Circle)
                    box.Remove(someFigure);
            }

        }

        public void RemoveAllFilmFigures()
        {
            foreach (Figure someFigure in box.ToArray())
            {
                if (someFigure.Material == Material.Film)
                    box.Remove(someFigure);
            }

        }

    }
}
