
using System;
namespace MunicipalityTax
{
    public class AccessErrorException : Exception
    {
        public AccessErrorException():base("We do not have permissions to read the file")
        {
        }
        public AccessErrorException(string message)
            : base(message)
        {
        }
        public AccessErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}