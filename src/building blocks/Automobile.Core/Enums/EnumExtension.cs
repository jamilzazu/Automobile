using System;
using System.ComponentModel;
using System.Linq;

namespace Automobile.Core.Enums
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            return !(value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() is DescriptionAttribute attribute) ? value.ToString() : attribute.Description;
        }
    }
}
