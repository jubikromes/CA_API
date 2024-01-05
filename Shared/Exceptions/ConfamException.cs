

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Shared.Exceptions
{



    internal class ConfamException : Exception
    {
        public ConfamException()
        { }

        public ConfamException(string message)
            : base(message)
        { }

        public ConfamException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}