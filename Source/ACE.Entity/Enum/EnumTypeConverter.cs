using System;
using System.ComponentModel;

namespace ACE.Entity.Enum
{
    public class EnumTypeConverter : EnumConverter
    {
        public EnumTypeConverter(Type type)
            : base(type)
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            //Console.WriteLine($"EnumTypeConverter.ConvertTo({culture}, {value}, {destinationType})");

            if (destinationType == typeof(string))
            {
                if (value != null)
                    return $"{(uint)value} - {value}";

                return string.Empty;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
