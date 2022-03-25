using System;
using System.ComponentModel;
using System.Linq;

namespace Automobile.Proprietarios.Domain.Entities.Enums
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            DescriptionAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
