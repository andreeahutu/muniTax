using System;
namespace MunicipalityTax
{
    public class TaxDay {
        static readonly DateTime START_DATE = new DateTime(1800, 1,1).Date;
        public static int getDayIndex(DateTime date){
             TimeSpan span = date - TaxDay.START_DATE;
             return span.Days;
        }
        public int DayIndex {get;} 
        public double TaxRate {get;}
        public TimePeriod TaxType {get;}
        
        public TaxDay ( double taxRate, TimePeriod taxType, DateTime date){
            this.TaxRate = taxRate;
            this.TaxType = taxType;
            TimeSpan span = date.Date - TaxDay.START_DATE;
            this.DayIndex = span.Days;
        }
    }
}