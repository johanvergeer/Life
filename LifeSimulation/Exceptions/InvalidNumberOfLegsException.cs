using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LifeSimulation.Exceptions
{
    class InvalidNumberOfLegsException : Exception
    {
        public InvalidNumberOfLegsException()
        {
        }

        public InvalidNumberOfLegsException(string message) : base(message)
        {
        }

        public InvalidNumberOfLegsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidNumberOfLegsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
