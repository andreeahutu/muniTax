using System;
using System.Collections.Generic;

namespace MunicipalityTax
{
    public class Municipality {
        
        public string Name {get;}

        private Dictionary<int, TaxDay> taxDays = new Dictionary<int, TaxDay>();



        public Municipality(String name){
            Name = name;
           taxDays = new Dictionary<int, TaxDay>();
            
        }
        public void AddTax(Tax taxToAdd){
         for(DateTime day = taxToAdd.StartDate.Date; day <= taxToAdd.EndDate.Date; day = day.AddDays(1)){
             TaxDay newTaxDay = new TaxDay(taxToAdd.Percentage, taxToAdd.Type, day);
             int dayIndex = newTaxDay.DayIndex;
             if (taxDays.ContainsKey(dayIndex)){
                 TaxDay existingTaxDay = taxDays[dayIndex];
                 //ex day<month, means it overrides it
                 if (newTaxDay.TaxType <= existingTaxDay.TaxType){
                     taxDays[dayIndex] = newTaxDay;
                     Console.WriteLine( "overwritting day"+ day+"with"+ newTaxDay.TaxRate );
                 }
             } else {
                 taxDays[dayIndex] = newTaxDay;
                 Console.WriteLine( "ionserting day"+ day+"with"+ newTaxDay.TaxRate );
             }

         }

        }

        public double GetTaxForDate( DateTime date){
            int dayIndex = TaxDay.getDayIndex(date);
            if (taxDays.ContainsKey(dayIndex)){
                return taxDays[dayIndex].TaxRate;
            }
            //probably not how i should handle this in the end...
            return 0;
        }
    }
}