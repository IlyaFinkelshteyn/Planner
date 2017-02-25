using System;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Services.Exceptions
{
    [Serializable, ExcludeFromCodeCoverage]
    public class IdNotFoundException : Exception
    {
        public IdNotFoundException()
        {
        }

        public IdNotFoundException(string message) : base(message)
        {
        }

        public IdNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected IdNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}