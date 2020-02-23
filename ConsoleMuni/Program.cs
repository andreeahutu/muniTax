using System;
using MunicipalityTax;

namespace ConsoleMuni
{
    class Program
    {
        static void Main(string[] args)
        {
            MunicipalityTaxService service = new MunicipalityTaxService();
            service.ScheduleYearlyTax("Vilnius", new DateTime(2016,5, 5), 0.2 );
            service.ScheduleMonthlyTax("Vilnius", new DateTime(2016,5, 5), 0.4);
            service.ScheduleDailyTax("vilnius",new DateTime(2016, 1, 1), 0.1 );
            service.ScheduleDailyTax("Vilnius",new DateTime(2016, 12, 25), 0.1 );
          
            Console.WriteLine(service.GetTax("Vilnius", new DateTime(2016, 01, 01)));
            Console.WriteLine(service.GetTax("vilnius", new DateTime(2016, 05, 02)));
            Console.WriteLine(service.GetTax("Vilnius", new DateTime(2016, 07, 10)));
            Console.WriteLine(service.GetTax("Vilnius", new DateTime(2016, 03, 16)));

        }
    }
}
