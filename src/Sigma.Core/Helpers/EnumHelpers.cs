#region License
//-----------------------------------------------------------------------
// <copyright file="EnumHelpers.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
#endregion

namespace Sigma.Core.Helpers
{
    public class EnumHelpers
    {
        /// <summary>
        /// Returns a strongly typed enumeration field for given enum type
        /// </summary>
        public static T GetEnumType<T>(Int32 value)
        {
            return (T)Enum.Parse(typeof(T), value.ToString());
        }
        /// <summary>
        /// Returns a strongly typed enumeration field for given enum type
        /// </summary>
        public static T GetEnumType<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        /// <summary>
        /// Returns an integer value corresponding to the given enumeration field for a given enum type.
        /// </summary>
        public static Int32 GetEnumValue<T>(T enumField)
        {
            return Convert.ToInt32(enumField);
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        public static IEnumerable<T> GetEnumValue<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// Reads the description attribute for the given enum field and returns its string representation
        /// </summary>
        public static String GetEnumFieldDescription(Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
        /// <summary>
        /// Gets list of enum fields for the given enum type
        /// </summary>
        public static List<string> GetFieldsFromEnum<T>()
        {
            return Enum.GetNames(typeof(T)).ToList<string>();
        }
        /// <summary>
        /// Returns an enum filed for the given enum description
        /// </summary>
        public static T GetEnumTypeFromDescription<T>(string desc)
        {
            Type enumType = typeof(T);
            string[] names = Enum.GetNames(enumType);
            foreach (string name in names)
            {
                if (GetEnumFieldDescription((Enum)Enum.Parse(enumType, name)).Equals(desc))
                {
                    return (T)Enum.Parse(enumType, name);
                }
            }
            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }
        /// <summary>
        /// Convert enum to enum
        /// </summary>
        public static T EnumToEnum<T, U>(U enumArg)
        {
            if (!typeof(T).IsEnum) throw new Exception("This method only takes enumerations.");
            if (!typeof(U).IsEnum) throw new Exception("This method only takes enumerations.");
            try
            {
                return (T)Enum.ToObject(typeof(T), enumArg);
            }
            catch
            {
                throw new Exception
                (string.Format("Error converting enumeration {0} value {1} to enumeration {2} ",
                 enumArg.ToString(),
                 typeof(U).ToString(),
                 typeof(T).ToString()));
            }
        }

    }
}
