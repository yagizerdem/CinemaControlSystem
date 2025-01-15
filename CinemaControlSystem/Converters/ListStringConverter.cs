using System.ComponentModel;
using System.Globalization;

namespace CinemaControlSystem.Converters
{
    public class ListStringConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string str)
            {
                return str.Split(',').ToList();
            }
            return base.ConvertFrom(context, culture, value);
        }
    }

}
