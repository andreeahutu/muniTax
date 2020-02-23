using System;
using System.Collections.Generic;

namespace MunicipalityTax
{
    public class MunicipalityTaxService
    {
        Dictionary<string, Municipality> municipalities;

        public MunicipalityTaxService(){
            municipalities = new Dictionary<string, Municipality>();
        }

        private string cleanupName(string name){
           //TO DO: deal with cultures.
            return name.Trim().ToLower(System.Globalization.CultureInfo.InvariantCulture);
        }
        private void AddTaxForMunicipality( Tax taxToAdd, string municipality){
            
            string municipalityName = cleanupName(municipality);

            if (municipalities.ContainsKey(municipalityName)){
                Municipality muni = municipalities[municipalityName];
                muni.AddTax(taxToAdd);
            } else {
                municipalities.Add(municipalityName, new Municipality(municipalityName));
                Municipality muni = municipalities[municipalityName];
                muni.AddTax(taxToAdd);
            }
        }
        public void ScheduleDailyTax(string municipalityName, DateTime day, double taxRate){

            Tax taxToAdd = new Tax(TimePeriod.Daily, taxRate, day, day);
            AddTaxForMunicipality(taxToAdd, cleanupName(municipalityName));

        }
        public void ScheduleMonthlyTax(string municipalityName, DateTime date , double taxRate){

            DateTime startDate = new DateTime(date.Year, date.Month, 1);
            DateTime endDate = new DateTime (date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            Tax taxToAdd = new Tax(TimePeriod.Monthly, taxRate, startDate, endDate);

            AddTaxForMunicipality(taxToAdd, cleanupName(municipalityName));
        }
        public void ScheduleYearlyTax(string municipalityName, DateTime date, double taxRate){
            DateTime startDate = new DateTime(date.Year, 1, 1);
            DateTime endDate = new DateTime (date.Year, 12 , 31);
            Tax taxToAdd = new Tax(TimePeriod.Yearly, taxRate, startDate, endDate);

            AddTaxForMunicipality(taxToAdd, cleanupName(municipalityName));
        }

        public void ImportMunicipalitiesDataFromFile(string file){

        }

        public double GetTax(string name, DateTime day){
            string municipalityName = cleanupName(name);
            if (municipalities.ContainsKey(municipalityName)){
                Municipality muni = municipalities[municipalityName];
                return muni.GetTax(day);
            }
            return 0.0;
        }


    }
}