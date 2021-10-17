using Newtonsoft.Json.Converters;

namespace NHRM_Admin_API.Methods
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }

}