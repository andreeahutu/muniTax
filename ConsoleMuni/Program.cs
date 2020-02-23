using System;
using MunicipalityTax;

namespace ConsoleMuni
{
    class Program
    {
        static void Main(string[] args)
        {
            Municipality vilnius = new Municipality("Vilnius");
            vilnius.AddTax(new Tax(TimePeriod.Yearly, 0.2, new DateTime(2016,1, 1), new DateTime(2016, 12, 31)));
            vilnius.AddTax(new Tax(TimePeriod.Monthly, 0.4, new DateTime(2016, 05, 01), new DateTime(2016, 05, 31)));
            vilnius.AddTax(new Tax(new DateTime(2016, 1, 1), 01));
            vilnius.AddTax(new Tax(new DateTime(2016, 12, 25), 01));

            Console.WriteLine(vilnius.GetTaxForDate(new DateTime(2016, 01, 01)));
            Console.WriteLine(vilnius.GetTaxForDate(new DateTime(2016, 05, 02)));
            Console.WriteLine(vilnius.GetTaxForDate(new DateTime(2016, 07, 10)));
            Console.WriteLine(vilnius.GetTaxForDate(new DateTime(2016, 03, 16)));

        }
    }
}
