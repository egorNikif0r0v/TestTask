using System;

namespace ProjectSystem.Application.Common.Exceptions
{
    public class NotFoundCustomersException : Exception
    {
        public NotFoundCustomersException() 
            : base($"Not found Customers")
        {
        }

    }
}
