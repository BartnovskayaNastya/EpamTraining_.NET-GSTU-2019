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

    public class ExistsFigureException : Exception
    {
        public override string Message => "You can't make this figure, becouse she already exists";
        public ExistsFigureException() : base()
        {
        }
    }
}
