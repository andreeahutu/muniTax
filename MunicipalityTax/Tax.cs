using System;

namespace MunicipalityTax
{
    public class Tax
    {
        public String Name { get; }
        public TimePeriod Type { get; }
        public Double Percentage { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        private void setupProps (TimePeriod type, string name, double taxRate, DateTime startDate, DateTime endDate){

        }


        public Tax(TimePeriod type, string name, double taxRate, DateTime startDate, DateTime endDate)
        {
            this.Type = type;
            this.Percentage = taxRate;
            this.StartDate = startDate.Date;
            this.EndDate = endDate.Date;
            //TO DO handle case where start date is after enddate
        }
        public Tax(string taxEntryLine)
        {
            //expected format: PeriodType, municipalityName,  taxRate,date in "dd/MM/yyyy" format, 

            string[] inputs = taxEntryLine.Trim().Split(',');         
            if (inputs == null)
            {
                //this tehnically should never be thrown
                throw new Exception("Null string");
            }
        
            if (inputs.Length != 4)
            {
                throw new Exception("Not enough entries per line");
            }
            TimePeriod period=TimePeriod.Daily;
            //TO DO I am sure there is a smarter way to do this 
            //but is probably using reflexion and enum description
            switch (StringHelper.cleanupString(inputs[0]))
            {
                case "daily": 
                    period = TimePeriod.Daily;
                    break;
                case "monthly": 
                    period = TimePeriod.Monthly;
                    break;
                case "weekly":
                    period = TimePeriod.Weekly;
                    break;
                case "yearly":
                    period = TimePeriod.Yearly;
                    break;
                default: 
                    throw new Exception("Bad format");
                    break;
            }
            string name = StringHelper.cleanupString(inputs[1]);
            int taxRate = Int32.Parse(inputs[2]);
            DateTime date = DateTime.ParseExact(inputs[3], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            this.Type = period;
            this.Name = name;
            this.Percentage = taxRate;
            this.StartDate = date;
            this.EndDate = date;
        }
        public Tax(TimePeriod period, string municipalityName, double taxRate, DateTime date){
            string name = StringHelper.cleanupString(municipalityName); 
            DateTime startDate = date;
            DateTime endDate = date;
            switch(period){
                case TimePeriod.Daily:
                    startDate = date;
                    endDate = date;
                    break;
                case TimePeriod.Weekly:
                    break;
                case TimePeriod.Monthly:
                    startDate = new DateTime(date.Year, date.Month, 1);
                    endDate = new DateTime (date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
                    break;
                case TimePeriod.Yearly:
                    startDate = new DateTime(date.Year, 1, 1);
                    endDate = new DateTime (date.Year, 12 , 31);
                    break;
                default:
                    throw new Exception("Bad format");
                    break;
            }
            this.Type = period;
            this.Name = name;
            this.Percentage = taxRate;
            this.StartDate = startDate;
            this.EndDate = endDate;

        }

    }
}