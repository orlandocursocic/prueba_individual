using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace prueba_individual.Exceptions
{
    public class NoEncontradoException : Exception
    {
        public NoEncontradoException()
        {
        }

        public NoEncontradoException(string message) : base(message)
        {
        }

        public NoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}