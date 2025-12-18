using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.EntityFramework.Extensions
{
    public static class EnumDisplayNameExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            MemberInfo? memberInfo = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault();

            if (memberInfo == null) return enumValue.ToString();

            DisplayAttribute? attribute = memberInfo.GetCustomAttribute<DisplayAttribute>();

            return attribute?.Name ?? enumValue.ToString();
        }
    }
}
