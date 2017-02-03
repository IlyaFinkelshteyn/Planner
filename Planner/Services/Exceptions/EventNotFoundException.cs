﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Services.Exceptions
{
    [Serializable, ExcludeFromCodeCoverage]
    public class EventNotFoundException : Exception
    {
        public EventNotFoundException()
        {
        }

        public EventNotFoundException(string message) : base(message)
        {
        }

        public EventNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected EventNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}