using System;

namespace MyStatusSoftware.Common.Enums
{
    public static class EnumHelper
    {
        public static T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            T val;
            return Enum.TryParse<T>(str,true,out val) ? val : default(T);
        }

        public static T GetEnumValue<T>(int intValue) where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }

            return (T)Enum.ToObject(enumType,intValue);
        }

        public static string GetStringValueEnumUserType(UserType userType)
        {
            string result = string.Empty;
            switch (userType)
            {
                case UserType.SuperAdmin:
                    result = "Super Administrador";
                    break;
                case UserType.Admin:
                    result = "Administrador";
                    break;
                case UserType.Basic:
                    result = "Basico";
                    break;
            }
            return result;
        }
    }
}
