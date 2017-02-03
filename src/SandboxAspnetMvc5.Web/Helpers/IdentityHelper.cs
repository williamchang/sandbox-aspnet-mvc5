/**
@file
    IdentityHelper.cs
@author
    William Chang
@version
    0.1
@date
    - Created: 2010-02-17
    - Modified: 2015-09-08
    .
@note
    References:
    - General:
        - Nothing.
        .
    .
*/

using System;

namespace SandboxAspnetMvc5.Web.Helpers {

public static class IdentityHelper
{
    /// <summary>Convert string to string representation that is encoded with base-64 digits.</summary>
    /// <remarks>Extension method.</remarks>
    public static string ToBase64(this string value)
    {
        if(!String.IsNullOrEmpty(value)) {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value));
        } else {
            return null;
        }
    }

    /// <summary>Convert string (from request form) to nullable guid.</summary>
    /// <remarks>Extension method.</remarks>
    public static Guid? ToGuid(this string value)
    {
        if(!String.IsNullOrEmpty(value)) {
            return new Guid(value);
        } else {
            return null;
        }
    }

    /// <summary>Convert string representation that is encoded with base-64 digits to string.</summary>
    /// <remarks>Extension method.</remarks>
    public static string ToStringFromBase64(this string value)
    {
        if(!String.IsNullOrEmpty(value)) {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(value));
        } else {
            return null;
        }
    }
}

}
