using System;
using System.ComponentModel;
using System.Linq;

namespace Automobile.Proprietarios.Domain.Entities.Enums
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            return value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() is not DescriptionAttribute attribute ? value.ToString() : attribute.Description;
        }
    }
}
