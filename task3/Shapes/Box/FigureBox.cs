using System;
using System.Collections.Generic;
using BoxExceptions;
using Shapes;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace Box
{
    public class FigureBox
    {
        /// <summary>
        /// List for figures in box
        /// </summary>
        public List<Figure> box = new List<Figure>(20);

        /// <summary>
        /// Constructor for box
        /// </summary>
        public FigureBox()
        {
        }

        public  int GetCount()
        {
            return box.Count;
        }
        /// <summary>
        /// Method for cheaking exception
        /// </summary>
        /// <param name="number">Optional parametr for methods of FindByNumber and RemoveByIndex</param>
        private void CheckException(int number)
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

        /// <summary>
        /// Method for adding figure in box
        /// </summary>
        /// <param name="figure">Type of figure for adding</param>
        public void AddFigure(Figure figure)
        {
            if (box.Count == 20)
            {
                throw new FullBoxException();
            }

            foreach (Figure someFigure in box)
            {
                if (someFigure.Equals(figure))
                {
                    throw new ExistsFigureException();
                }
            }

            box.Add(figure);
        }

        /// <summary>
        /// Method for finding figure by number
        /// </summary>
        /// <param name="number">Number of figure for finding figure by number</param>
        public Figure FindByNumber(int number)
        {
            CheckException(number);

            for (int i = 0; i < box.Count; i++)
            {
                if (i == number - 1)
                {
                   return box[i];
                }
            }
            return null;

        }

        /// <summary>
        /// Method for removing figure by number
        /// </summary>
        /// <param name="index">Number of figure for removing figure by number</param>
        public void RemoveByIndex(int index)
        {
            CheckException(index);
            box.RemoveAt(index - 1);

        }

        /// <summary>
        /// Method for changing figure by number
        /// </summary>
        /// <param name="number">Number of figure for changing</param>
        /// <param name="figure">Figure for changing</param>
        public void ChangeByNumber(int number, Figure figure)
        {
            CheckException(number);

            box.Insert(number - 1, figure);

        }

        /// <summary>
        /// Method for finding figure similar to anouther figure
        /// </summary>
        /// <param name="figure">Figure for sample</param>
        public Figure FindFigure(Figure figure)
        {
            bool flag = false;
            foreach (Figure someFigure in box)
            {
                if (figure.Equals(someFigure))
                {
                    flag = true;
                    return figure;
                }
            }
            if (flag == false)
                throw new Exception("There is no figure");
            return null;
        }

        /// <summary>
        /// Method for showing exists figures
        /// </summary>
        public void ShowExistsFigures()
        {
            foreach (Figure someFigure in box)
            {
                someFigure.ToString();
            }
        }

        /// <summary>
        /// Method for getting sum of all figures by perimetr
        /// </summary>
        /// <returns>Sum of all figures by perimetr</returns>
        public double GetPFigures()
        {
            if(box.Count < 1)
            {
                throw new Exception("There is no figures in box");
            }

            double result = 0;
            foreach (Figure someFigure in box)
            {
                result += someFigure.GetP();
            }

            return result;
        }

        /// <summary>
        /// Method for getting sum of all figures by square
        /// </summary>
        /// <returns>Sum of all figures by square</returns>
        public double GetSFigures()
        {
            if (box.Count < 1)
            {
                throw new Exception("There is no figures in box");
            }

            double result = 0;
            foreach (Figure someFigure in box)
            {
                result += someFigure.GetS();
            }

            return result;
        }

        /// <summary>
        /// Method for removing all circles
        /// </summary>
        public void RemoveAllCircles()
        {
            bool find = false;
            foreach (Figure someFigure in box.ToArray())
            {
                if(someFigure is Circle)
                {
                    box.Remove(someFigure);
                    find = true;
                }
                    
            }

            if(find == false)
            {
                throw new Exception("There is no Circles in box");
            }

        }

        /// <summary>
        /// Method for removing all film figures
        /// </summary>
        public void RemoveAllFilmFigures()
        {
            foreach (Figure someFigure in box.ToArray())
            {
                if (someFigure.Material == Material.Film)
                    box.Remove(someFigure);
            }

        }

        /// <summary>
        /// Method for saving all figures in xml file bu class XmlWriter
        /// </summary>
        /// <param name="figures">List of all figures</param>
        /// <param name="filePath">String with path of file</param>
        public void SaveFigures(List<Figure> figures, string filePath)
        {
            XmlWriter writer = XmlWriter.Create(filePath);

            writer.WriteStartDocument();
            writer.WriteStartElement("figures");

            foreach (Figure item in figures)
            {
                writer.WriteStartElement("figure");
                writer.WriteStartElement(Figure.GetFigureType(item));
                writer.WriteAttributeString("material", Figure.GetFigureMaterial(item));
                if(item.Material == Material.Paper && item.isPainted == true)
                {
                    writer.WriteAttributeString("color", item.Color.ToString());
                }
                writer.WriteEndElement();

            }
            writer.WriteEndDocument();
            writer.Close();
        }


        /// <summary>
        /// Method for getting all film figures to have opotunity to save this type of figures in file
        /// </summary>
        /// <returns>List of film figures</returns>
        public List<Figure> GetFilmFigures()
        {
            List<Figure> paperFigures = new List<Figure>();
            foreach (Figure someFigure in box)
            {
                if (someFigure.Material == Material.Film)
                    paperFigures.Add(someFigure);
            }
            return paperFigures;
        }


        /// <summary>
        /// Method for getting figures from xml file
        /// </summary>
        /// <param name="filePath">String with path of file</param>
        /// <returns>List of figures from file</returns>
        public List<Figure> GetFiguresFromFile(string filePath)
        {
            List<Figure> figures = new List<Figure>();
            Figure figure = null;

            XmlReader reader = XmlReader.Create(filePath);
            while (reader.Read())
            {
                if((reader.NodeType == XmlNodeType.Element) && ((reader.Name == "Circle") || (reader.Name == "Triangle") || (reader.Name == "Rectangle") || (reader.Name == "Square")))
                {
                    if (reader.HasAttributes)
                    {
                        figure.Material = (Material)Enum.Parse(typeof(Material), reader.GetAttribute("material"));
                        reader.MoveToNextAttribute();
                        if(reader.Name == "color")
                        {
                            figure.Color = (Color)Enum.Parse(typeof(Color), reader.GetAttribute("color"));
                        }
                    }
                }

                figures.Add(figure);
            }

            return figures;
        }


    }
}
