using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LifeSimulation.Exceptions
{
    internal class InvalidLocationException : Exception
    {
        public InvalidLocationException()
        {
        }

        public InvalidLocationException(string message) : base(message)
        {
        }

        public InvalidLocationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidLocationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
