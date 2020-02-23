using System;
using System.IO;
using System.Collections.Generic;
using System.Security;

namespace MunicipalityTax
{
    public class MunicipalityTaxService
    {
        Dictionary<string, Municipality> municipalities;

        public MunicipalityTaxService(){
            municipalities = new Dictionary<string, Municipality>();
        }

        private void AddTaxForMunicipality( Tax taxToAdd, string municipality){
            string municipalityName = StringHelper.cleanupString(municipality);
            
            if (municipalities.ContainsKey(municipalityName)){
                Municipality muni = municipalities[municipalityName];
                muni.AddTax(taxToAdd);
            } else {
                municipalities.Add(municipalityName, new Municipality(municipalityName));
                Municipality muni = municipalities[municipalityName];
                muni.AddTax(taxToAdd);
            }
        }
        private void ScheduleTax(TimePeriod period, string municipalityName, double taxRate, DateTime date){
            string name = StringHelper.cleanupString(municipalityName);
            Tax taxToAdd = new Tax(period, name, taxRate, date);
            AddTaxForMunicipality(taxToAdd, name);
        }
        private void ScheduleTax(string line){
            Tax taxToAdd = new Tax(line);
            AddTaxForMunicipality(taxToAdd, taxToAdd.Name);
        }

        public void ScheduleDailyTax(string municipalityName, double taxRate, DateTime date){
            ScheduleTax(TimePeriod.Daily, municipalityName, taxRate, date);
        }
        public void ScheduleWeeklyTax(string municipalityName,double taxRate, DateTime date){
             ScheduleTax(TimePeriod.Weekly, municipalityName, taxRate, date);
        }
        public void ScheduleMonthlyTax(string municipalityName, double taxRate, DateTime date){
           ScheduleTax(TimePeriod.Monthly, municipalityName, taxRate, date);
        }
        public void ScheduleYearlyTax(string municipalityName, double taxRate, DateTime date){
            ScheduleTax(TimePeriod.Yearly, municipalityName, taxRate, date);
        }

        //TO DO use StreamReader or Async Readall?
        public void ImportMunicipalitiesDataFromFile(string file){
            string[] lines = null;
            try{
                File.ReadAllText (file);
            } catch (Exception e) {
                if(e is ArgumentException || e is ArgumentNullException || 
                e is PathTooLongException ||  e is DirectoryNotFoundException ||
                e is FileNotFoundException || e is NotSupportedException){
                     throw new Exception("Invalid file path, please make sure you have the correct path");
                }
               else  if (e is UnauthorizedAccessException || e is SecurityException ){
                   throw new Exception("File is readonly or we do not have permisions to access it");
               } else {
                   throw new Exception("An error has occured");
               }
            };
            try {
                 foreach(string line in lines){
                ScheduleTax(line);
                }
            } catch (Exception e){
                throw new Exception ("Error parsing the file. Expected format: period type, municipality name,  taxRate, date \n "+
                "where period type should be daily or weekly or monthly or yearly and date is in dd/MM/yyyy format");
            }
           
        }

        public double GetTax(string name, DateTime day){
            string municipalityName = StringHelper.cleanupString(name);
            if (municipalities.ContainsKey(municipalityName)){
                Municipality muni = municipalities[municipalityName];
                return muni.GetTax(day);
            }
            return 0.0;
        }


    }
}