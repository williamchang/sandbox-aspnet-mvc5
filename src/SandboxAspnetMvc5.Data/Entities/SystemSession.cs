/**
@file
    SystemSession.cs
@author
    William Chang
@version
    0.1
@date
    - Created: 2015-08-30
    - Modified: 2015-09-01
    .
@note
    References:
    - SessionStateStoreProviderBase:
        - http://www.codeproject.com/Articles/633199/Using-MySQL-Session-State-Provider-for-ASP-NET
        - https://gist.github.com/mrichman/405022
        - https://github.com/xavierjefferson/mysql-web-fixed
        - https://github.com/micahlmartin/SQLiteSessionStateStore
        .
    - ASP.NET vNext:
        - http://benjii.me/2015/07/using-sessions-and-httpcontext-in-aspnet5-and-mvc6/
        - https://github.com/aspnet/Session
        .
    .
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SandboxAspnetMvc5.Data.Entities {

public class SystemSession
{
    [Key]
    [Required(AllowEmptyStrings = false)]
    [StringLength(80, MinimumLength = 1)]
    public virtual string Id {get;set;}

    [Required(AllowEmptyStrings = false)]
    [StringLength(255, MinimumLength = 1)]
    public virtual string ApplicationName {get;set;}

    public virtual DateTime DateCreated {get;set;}

    public virtual DateTime DateExpire {get;set;}

    public virtual DateTime DateLock {get;set;}

    public virtual int LockId {get;set;}

    public virtual int Timeout {get;set;}

    public virtual bool IsLocked {get;set;}

    public virtual string Value {get;set;}

    public virtual int Flag {get;set;}

    [Required]
    public virtual DateTime DateModified {get;set;}

    public SystemSession() {}
}

}
