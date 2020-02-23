using System;
namespace MunicipalityTax
{
    public class InvalidFilePathException:Exception
    {
        public InvalidFilePathException():base("Invalid file path, please make sure you have the correct path")
        {
        }

        public InvalidFilePathException(string message)
            : base(message)
        {
        }

        public InvalidFilePathException(string message, Exception inner)
            : base(message, inner)
        {
        } 
    }
}