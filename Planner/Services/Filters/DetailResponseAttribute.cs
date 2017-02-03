using System;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Services.Filters
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
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