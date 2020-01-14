using System.Configuration;

namespace RMDesktop.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {
            var rateText = ConfigurationManager.AppSettings["taxRate"];

            if (!decimal.TryParse(rateText, out var output))
            {
                throw new ConfigurationErrorsException("The tax rate is not set up properly.");
            }
            else
            {
                return output;
            }
        }
    }
}