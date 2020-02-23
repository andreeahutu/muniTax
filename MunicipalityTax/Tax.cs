using System;

namespace MunicipalityTax
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
          //TO DO handle case where start date is after enddate
          //to do maybe i shouy=d have separate Yearly,  Monthly, daily tax
      }
    
      public Tax(DateTime date, double percentage){
          this.Type = TimePeriod.Daily;
          this.Percentage = percentage;
          this.StartDate = date;
          this.EndDate = date;
      }
    }
}