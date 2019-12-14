using System;

namespace BoxExceptions
{
    public class FullBoxException : Exception
    {
        public override string Message => "You can't add this figure, becouse box is full! Remove some of figures and try again";
        public FullBoxException() : base()
        {
        }
    }

    public class EmptyBoxException : Exception
    {
        public override string Message => "Box is empty";
        public EmptyBoxException() : base()
        {
        }
    }

    public class ExistsFigureException : Exception
    {
        public override string Message => "You can't make this figure, becouse she already exists";
        public ExistsFigureException() : base()
        {
        }
    }

    public class InvalidNumberException : Exception
    {
        int number;
        public InvalidNumberException( int number) : base()
        {
            this.number = number;
        }

        public override string Message => "There is no figure by this number. The amount of figures is " + number;
    }

    public class NegativeNumberException : Exception
    {
        public override string Message => "You need to input positive number";
        public NegativeNumberException() : base()
        {
        }
    }
}
