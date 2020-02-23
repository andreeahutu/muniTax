using System;
using MunicipalityTax;

namespace ConsoleMuni
{
    class Program
    {
        static void Main(string[] args)
        {
            MunicipalityTaxService service = new MunicipalityTaxService();
            service.ScheduleYearlyTax("Vilnius", 0.2, new DateTime(2016,5, 5) );
            service.ScheduleMonthlyTax("Vilnius", 0.4, new DateTime(2016,5, 5));
            service.ScheduleDailyTax("vilnius", 0.1, new DateTime(2016, 1, 1));
            service.ScheduleDailyTax("Vilnius", 0.1, new DateTime(2016, 12, 25) );
          
            Console.WriteLine(service.GetTax("Vilnius", new DateTime(2016, 01, 01)));
            Console.WriteLine(service.GetTax("vilnius", new DateTime(2016, 05, 02)));
            Console.WriteLine(service.GetTax("Vilnius", new DateTime(2016, 07, 10)));
            Console.WriteLine(service.GetTax("Vilnius", new DateTime(2016, 03, 16)));

        }
    }
}
