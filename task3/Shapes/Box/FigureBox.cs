using System;
using System.Collections.Generic;
using BoxExceptions;
using Shapes;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using Figures;
using FilmFigures;
using PaperFigures;

namespace Box
{
    public class FigureBox
    {
        /// <summary>
        /// List for figures in box
        /// </summary>
        public List<IFigure> box = new List<IFigure>(20);

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
        public void AddFigure(IFigure figure)
        {
            if (box.Count == 20)
            {
                throw new FullBoxException();
            }

            foreach (IFigure someFigure in box)
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
        public IFigure FindByNumber(int number)
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
        public void ChangeByNumber(int number, IFigure figure)
        {
            CheckException(number);

            box.Insert(number - 1, figure);

        }

        /// <summary>
        /// Method for finding figure similar to anouther figure
        /// </summary>
        /// <param name="figure">Figure for sample</param>
        public IFigure FindFigure(IFigure figure)
        {
            bool flag = false;
            foreach (IFigure someFigure in box)
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
            foreach (IFigure someFigure in box)
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
            foreach (IFigure someFigure in box)
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
            foreach (IFigure someFigure in box)
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
            foreach (IFigure someFigure in box.ToArray())
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
            foreach (IFigure someFigure in box.ToArray())
            {
                if (someFigure is IFilm)
                    box.Remove(someFigure);
            }

        }

        /// <summary>
        /// Method for saving all figures in xml file bu class XmlWriter
        /// </summary>
        /// <param name="figures">List of all figures</param>
        /// <param name="filePath">String with path of file</param>
        public void SaveFigures(List<IFigure> figures, string filePath)
        {
            XmlWriter writer = XmlWriter.Create(filePath);

            writer.WriteStartDocument();
            writer.WriteStartElement("figures");

            foreach (IFigure item in figures)
            {
                writer.WriteStartElement("figure");
                writer.WriteStartElement(IFigure.GetFigureType(item));
                writer.WriteAttributeString("material", IFigure.GetFigureMaterial(item));
                if(item is IPaper)
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
        public List<IFigure> GetFilmFigures()
        {
            List<IFigure> paperFigures = new List<IFigure>();
            foreach (IFigure someFigure in box)
            {
                if (someFigure is IFilm)
                    paperFigures.Add(someFigure);
            }
            return paperFigures;
        }


        /// <summary>
        /// Method for getting figures from xml file
        /// </summary>
        /// <param name="filePath">String with path of file</param>
        /// <returns>List of figures from file</returns>
        public List<IFigure> GetFiguresFromFile(string filePath)
        {
            List<IFigure> figures = new List<IFigure>();
            IFigure figure = null;

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
