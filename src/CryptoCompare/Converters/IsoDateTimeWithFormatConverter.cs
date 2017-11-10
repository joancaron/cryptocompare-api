using Newtonsoft.Json.Converters;

namespace CryptoCompare
{
    public class IsoDateTimeWithFormatConverter : IsoDateTimeConverter
    {
        public IsoDateTimeWithFormatConverter(string format)
        {
            this.DateTimeFormat = format;
        }
    }
}