using System;
using NUnit.Framework;
using MunicipalityTax;

namespace MunicipalityTax.Tests
{
    public class MunicipalityTax_AddTaxShould
    {
        [Test]
        public void AddTax_1()
        {
            Municipality vilnius = new Municipality("Vilnius");
            vilnius.AddTax(new Tax(TimePeriod.Yearly, 0.2, new DateTime(2016,1, 1), new DateTime(2016, 12, 31)));
            
            Assert.That(vilnius.GetTax(new DateTime(2016, 1,1)), Is.EqualTo(0.2));
        }

        [Test]
        public void AddTaxShould_OverrideYearlyWithMonthlyTax()
        {
            Municipality vilnius = new Municipality("Vilnius");
            vilnius.AddTax(new Tax(TimePeriod.Yearly, 0.2, new DateTime(2016,1, 1), new DateTime(2016, 12, 31)));
            vilnius.AddTax(new Tax(TimePeriod.Monthly, 0.4, new DateTime(2016, 05, 01), new DateTime(2016, 05, 31)));
            
            Assert.That(vilnius.GetTax(new DateTime(2016, 05,05)), Is.EqualTo(0.4));
        }

        [Test]
        public void AddTaxShould_NOTOverrideMonthlyWithYearlyTax()
        {
            Municipality vilnius = new Municipality("Vilnius");
            vilnius.AddTax(new Tax(TimePeriod.Monthly, 0.4, new DateTime(2016, 05, 01), new DateTime(2016, 05, 31)));
            vilnius.AddTax(new Tax(TimePeriod.Yearly, 0.2, new DateTime(2016,1, 1), new DateTime(2016, 12, 31)));
            
            Assert.That(vilnius.GetTax(new DateTime(2016, 05,05)), Is.EqualTo(0.4));
        }

           [Test]
        public void AddTaxShould_OverrideMonthlyWithMonthlyTax()
        {
            Municipality vilnius = new Municipality("Vilnius");
            vilnius.AddTax(new Tax(TimePeriod.Monthly, 0.4, new DateTime(2016, 05, 01), new DateTime(2016, 05, 31)));
            vilnius.AddTax(new Tax(TimePeriod.Monthly, 0.2, new DateTime(2016,1, 1), new DateTime(2016, 12, 31)));
            
            Assert.That(vilnius.GetTax(new DateTime(2016, 05,05)), Is.EqualTo(0.2));
        }




    }
}