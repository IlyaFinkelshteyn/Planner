using System;

namespace Planner.Services.Filters
{
    [System.AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    internal sealed class DetailResponseAttribute : Attribute
    {
        // This is a positional argument
        public DetailResponseAttribute(int statusCode)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}