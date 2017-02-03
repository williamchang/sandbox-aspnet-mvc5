/**
@file
    UserCredential.cs
@author
    William Chang
@version
    0.1
@date
    - Created: 2015-08-20
    - Modified: 2015-08-26
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

public class UserCredential
{

#region Enumerations

    public enum enumPasswordFormat
    {
        Clear = 1,
        Encrypted = 2,
        Hashed = 3
    }

#endregion

    [Key]
    public virtual Guid Id {get;set;}

    public virtual UserAccount Account {get;set;}

    public virtual string Password {get;set;}

    [Required]
    public virtual enumPasswordFormat PasswordFormat {get;set;}

    public virtual string PasswordSalt {get;set;}

    public virtual string ActivationKey {get;set;}

    public virtual bool IsActivated {get;set;}

    public virtual int FailedAttemptCount {get;set;}

    public virtual DateTime DateFailedAttempt {get;set;}

    public virtual DateTime DateLogin {get;set;}

    public virtual DateTime DatePasswordChanged {get;set;}

    public virtual DateTime DateLockout {get;set;}

    public UserCredential()
    {
        this.Password = String.Empty;
        this.PasswordFormat = enumPasswordFormat.Hashed;
        this.PasswordSalt = String.Empty;
        this.ActivationKey = String.Empty;
        this.IsActivated = false;
        this.FailedAttemptCount = 0;
        this.DateFailedAttempt = DateTime.MinValue;
        this.DateLogin = DateTime.MinValue;
        this.DatePasswordChanged = DateTime.MinValue;
        this.DateLockout = DateTime.MinValue;
    }
}

}
