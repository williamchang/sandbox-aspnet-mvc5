/**
@file
    EnumerationHelper.cs
@author
    William Chang
@version
    0.2
@date
    - Created: 2009-08-06
    - Modified: 2015-08-28
    .
@note
    References:
    - General:
        - Nothing.
        .
    - Convert enum to string:
        - http://blogs.msdn.com/tims/archive/2004/04/02/106310.aspx
        .
    .
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SandboxAspnetMvc5.Web.Helpers {

public static class EnumerationHelper
{
    /// <summary>Convert string to enum.</summary>
    public static T ToEnum<T>(this string str)
    {
        return (T)Enum.Parse(typeof(T), str, true);
    }

    /// <summary>Convert enum to collection (KeyValuePair properties: Key, Value).</summary>
    /// <remarks>http://stackoverflow.com/questions/553597/binding-an-enum-to-linq-and-selectlistitem</remarks>
    public static IEnumerable<KeyValuePair<string, string>> ToCollection<TEnum>()
    {
        var values = Enum.GetNames(typeof(TEnum)).Select(
            e => new KeyValuePair<string, string>(e, e)
        );
        return values;
    }

    /// <summary>Get the description attribute for one enum value.</summary>
    /// <example>[Description("Content Types")] ContentTypes = 2</example>
    /// <returns>The description attribute of an enum, if any</returns>
    public static string GetDescription(Enum value)
    {
        FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
    }

    /// <summary>Gets a list of key/value pairs for an enum, using the description attribute as value.</summary>
    /// <remarks>http://developcode.blogspot.com/2006/12/dropdownlists-with-enums-as-datasource.html</remarks>
    /// <returns>A list of KeyValuePairs with enum values and descriptions</returns>
    public static List<KeyValuePair<string, string>> GetValuesAndDescription(System.Type enumType)
    {
        List<KeyValuePair<string, string>> kvPairList = new List<KeyValuePair<string, string>>();
        foreach(Enum enumValue in Enum.GetValues(enumType)) {
            kvPairList.Add(new KeyValuePair<string, string>(enumValue.ToString(), GetDescription(enumValue)));
        }
        return kvPairList;
    }
}

}
