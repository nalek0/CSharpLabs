using DataDomenLevel.data;
using System;

namespace DataDomenLevel.api
{
    class DatabaseApiException : Exception
    {
        public DatabaseApiException() { }

        public DatabaseApiException(string message) : base(message) { }

        public DatabaseApiException(string message, Exception inner) : base(message, inner) { }
    }
}
