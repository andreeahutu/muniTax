namespace MunicipalityTax
{
    public class StringHelper
    {
        public static  string cleanupString(string name){
           //TO DO: deal with cultures.
            return name.Trim().ToLower(System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}