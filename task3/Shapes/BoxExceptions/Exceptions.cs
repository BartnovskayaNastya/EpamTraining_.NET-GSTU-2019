using System;

namespace BoxExceptions
{
    /// <summary>
    /// Class for catching exception when shape count is greatest than 20
    /// </summary>
    public class FullBoxException : Exception
    {
        public override string Message => "You can't add this figure, becouse box is full! Remove some of figures and try again";
        public FullBoxException() : base()
        {
        }
    }

    /// <summary>
    /// Class for catching exception when shape count is 0
    /// </summary>
    public class EmptyBoxException : Exception
    {
        public override string Message => "Box is empty";
        public EmptyBoxException() : base()
        {
        }
    }

    /// <summary>
    /// Class for catching exception when shape of this type is alrady exists
    /// </summary>
    public class ExistsFigureException : Exception
    {
        public override string Message => "You can't make this figure, becouse she already exists";
        public ExistsFigureException() : base()
        {
        }
    }

    /// <summary>
    /// Class for catching exception when shape of this index is not exists
    /// </summary>
    public class InvalidNumberException : Exception
    {
        int number;
        public InvalidNumberException( int number) : base()
        {
            this.number = number;
        }

        public override string Message => "There is no figure by this number. The amount of figures is " + number;
    }

    /// <summary>
    /// Class for catching exception when input number less than 0
    /// </summary>
    public class NegativeNumberException : Exception
    {
        public override string Message => "You need to input positive number";
        public NegativeNumberException() : base()
        {
        }
    }
}
