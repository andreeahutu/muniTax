using System;

namespace muniTax
{
    public class Tax{
      public TimePeriod Type {get;}
      public Double Percentage {get;}
      public DateTime StartDate {get;}
      public DateTime EndDate {get;} 


      public Tax(TimePeriod type, double percentage, DateTime startDate, DateTime endDate){
          this.Type = type;
          this.Percentage = percentage;
          this.StartDate = startDate.Date;
          this.EndDate = endDate.Date;
      }
      public Tax(DateTime date, double percentage){
          this.Type = TimePeriod.Daily;
          this.Percentage = percentage;
          this.StartDate = date;
          this.EndDate = date;
      }
    }
}