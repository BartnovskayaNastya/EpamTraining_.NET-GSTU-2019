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
        public List<Figure> box = new List<Figure>(20);

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


        //private XmlDocument LoadDocument(string filePath)
        //{
        //    XmlDocument document = new XmlDocument();
        //    using (StreamReader stream = new StreamReader(filePath))
        //    {
        //        document.Load(stream);

        //    }
        //    return (document);
        //}

        //private XmlDocument SaveDocument(XmlDocument document, string filePath)
        //{
        //    using (StreamWriter stream = new StreamWriter(filePath))
        //    {
        //        document.Save(stream);
        //    }
        //    return (document);
        //}

        //public void SaveFileStreamWriter(string filePath)
        //{
            
        //}




    }
}
