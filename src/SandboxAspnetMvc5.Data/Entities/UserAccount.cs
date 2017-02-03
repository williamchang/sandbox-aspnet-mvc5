/**
@file
    UserAccount.cs
@author
    William Chang
@version
    0.1
@date
    - Created: 2015-08-20
    - Modified: 2015-08-30
    .
@note
    References:
    - General:
        - http://blog.jagregory.com/2009/01/27/i-think-you-mean-a-many-to-one-sir/
        - http://gnschenker.blogspot.com/2007/06/one-to-one-mapping-and-lazy-loading.html
        .
    .
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SandboxAspnetMvc5.Data.Entities {

public class UserAccount
{

#region Enumerations

    public enum enumRole
    {
        Administrator = 1,
        Moderator = 2,
        Member = 3,
        Subscriber = 4,
        Guest = 5
    }

#endregion

    [Key]
    public virtual Guid Id {get;set;}

    [Required(AllowEmptyStrings = false)]
    [StringLength(255, MinimumLength = 1)]
    public virtual string ApplicationName {get;set;}

    [Required(AllowEmptyStrings = false)]
    [StringLength(255, MinimumLength = 1)]
    public virtual string RoleName {get;set;}

    [Required(AllowEmptyStrings = false)]
    [StringLength(64, MinimumLength = 2)]
    public virtual string Alias {get;set;}

    [Required(AllowEmptyStrings = false)]
    [StringLength(96, MinimumLength = 2)]
    public virtual string NameFirst {get;set;}

    [StringLength(64, MinimumLength = 1)]
    public virtual string NameMiddle {get;set;}

    [Required(AllowEmptyStrings = false)]
    [StringLength(64, MinimumLength = 2)]
    public virtual string NameLast {get;set;}

    [Required(AllowEmptyStrings = false)]
    [DataType(DataType.EmailAddress)]
    [StringLength(255, MinimumLength = 1)]
    public virtual string Email {get;set;}

    public virtual string SessionKey {get;set;}

    public virtual DateTime DateSessionCreated {get;set;}

    public virtual DateTime DateActive {get;set;}

    public virtual DateTime DateCreated {get;set;}

    public virtual bool IsAnonymous {get;set;}

    public virtual bool IsDeleted {get;set;}

    public virtual IList<UserCredential> Credentials {get;set;}

    public virtual IList<UserProfile> Profiles {get;set;}

    public virtual IList<UserSetting> Settings {get;set;}

    public UserAccount()
    {
        this.ApplicationName = "DefaultApplication";
        this.NameMiddle = String.Empty;
        this.SessionKey = String.Empty;
        this.DateSessionCreated = DateTime.MinValue;
        this.IsAnonymous = false;
        this.IsDeleted = false;
        this.Credentials = new List<UserCredential>();
        this.Profiles = new List<UserProfile>();
        this.Settings = new List<UserSetting>();
    }

    /// <summary>Get user name (first and last).</summary>
    public virtual string GetName()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append(this.NameFirst);
        if(!String.IsNullOrEmpty(this.NameLast)) {
            sb.Append(" ");
            sb.Append(this.NameLast);
        }
        return sb.ToString();
    }

    /// <summary>Get user name (first, middle, last).</summary>
    public virtual string GetNameLong()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append(this.NameFirst);
        if(!String.IsNullOrEmpty(this.NameMiddle)) {
            sb.Append(" ");
            sb.Append(this.NameMiddle);
        }
        if(!String.IsNullOrEmpty(this.NameLast)) {
            sb.Append(" ");
            sb.Append(this.NameLast);
        }
        return sb.ToString();
    }

    /// <summary>Get address for system mail.</summary>
    public virtual System.Net.Mail.MailAddress GetMailAddress()
    {
        return new System.Net.Mail.MailAddress(this.Email, GetName());
    }
}

}
