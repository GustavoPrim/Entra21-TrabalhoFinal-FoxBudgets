using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Servico.Extensions
{
    public static class EnumExtension
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<TAttribute>();
        }

        public static string GetDisplayAtrribute(this Enum enumValue) =>
            GetAttribute<DisplayAttribute>(enumValue).Name ?? nameof(enumValue);

        public static int GetValue(this Enum enumValue) =>
            (int)(object)(enumValue);
    }
}
