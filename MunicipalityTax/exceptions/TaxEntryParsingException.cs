using System;
namespace MunicipalityTax
{
    public class TaxEntryParsingException : Exception
    {
        public TaxEntryParsingException() : base("Error parsing a tax entry. Expected format: period type, municipality name,  taxRate, date \n " +
                "where period type should be daily or weekly or monthly or yearly")
        {
        }
        public TaxEntryParsingException(string message)
            : base(message)
        {
        }
        public TaxEntryParsingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}