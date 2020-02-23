using NUnit.Framework;
namespace MunicipalityTax.Tests
{
    [TestFixture]
    public class Tax_ConstructorShould
    {
        //Expected format: period type, municipality name,  taxRate, date \n "+
        //        "where period type should be daily or weekly or monthly or yearly";
        [TestCase(null)]
        [TestCase("")]
        [TestCase("aba")]
        [TestCase("daily, my city, 0.1 ")]
        [TestCase("day, my city, 0.1, 01/01/2000 ")]
        [TestCase("daily, my city, bad tax, 01/01/2000 ")]
        [TestCase("daily, my city, 0.1, bad date ")]
        [TestCase("daily, my city, 0.1, 01/31/2000")]
        public void ConstructorShould_throwExceptionOnBadStringEntry(string entry){
            Assert.That(() => new Tax(entry), 
                Throws.TypeOf<TaxEntryParsingException>());
        }

        [TestCase("daily, my city, 0.1, 31/01/2000")]
        [TestCase("monthly, my city, 0.1, 31/01/2000")]
        [TestCase("yearly, my city, 0.1, 31/01/2000")]
        [TestCase("daily, my city, 0.1, 2000/01/01")]
        [TestCase("weekly, my city, 0.1, 2008-05-01")]
        public void ConstructorShould_parseCorrectlyFormatedEntry(string entry){
            Tax t = new Tax(entry);
            string[] fields = entry.Trim().Split(',');
            Assert.That(StringHelper.cleanupString(fields[1]), Is.EqualTo(t.Name));
            Assert.That(StringHelper.cleanupString(fields[2]), Is.EqualTo(t.Percentage.ToString()));
            
        }

    }
}