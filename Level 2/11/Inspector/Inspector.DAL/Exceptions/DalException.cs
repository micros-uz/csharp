using System;

namespace Inspector.DAL.Exceptions
{
    public class DalException : Exception
    {
        public DalException()
        {
        }

        public DalException(string message)
            :base(message)
        {
        }

        public DalException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
