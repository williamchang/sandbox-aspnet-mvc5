/**
@file
    UserProfile.cs
@author
    William Chang
@version
    0.1
@date
    - Created: 2015-08-20
    - Modified: 2015-08-24
    .
@note
    References:
    - General:
        - Nothing.
        .
    .
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SandboxAspnetMvc5.Data.Entities {

public class UserProfile
{

#region Enumerations

    public enum enumType {
        Custom = 0,
        Notes,
        NameSalutation,
        NameFirst,
        NameMiddle,
        NameLast,
        Occupation,
        CompanyName,
        ContactPhone,
        ContactAddress,
        ContactEmail,
        ContactMessenger,
        ContactWebsite,
        Date,
        Person
    }

#endregion

    [Key]
    public virtual Guid Id {get;set;}

    public virtual UserAccount Account {get;set;}

    [Required]
    public virtual enumType Type {get;set;}

    [Required]
    [Range(0, int.MaxValue)]
    public virtual int Subtype {get;set;}

    [Required]
    public virtual string Label {get;set;}

    public virtual string Value {get;set;}

    [Required]
    public virtual DateTime DateModified {get;set;}

    public UserProfile()
    {
        Subtype = 0;
        Value = String.Empty;
    }

#region Extension Methods

    /// <summary>Get label.</summary>
    public static string GetLabel(enumType type, string custom)
    {
        switch(type) {
            case enumType.Custom:
                return custom;
            case enumType.ContactEmail:
            case enumType.ContactPhone:
            case enumType.ContactAddress:
            case enumType.ContactWebsite:
            case enumType.ContactMessenger:
            case enumType.Date:
            case enumType.Person:
                return custom;
            default:
                return Enum.GetName(typeof(enumType), type);
        }
    }

#endregion

}

}
