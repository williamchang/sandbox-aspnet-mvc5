/**
@file
    SystemLog.cs
@author
    William Chang
@version
    0.1
@date
    - Created: 2015-08-30
    - Modified: 2015-08-31
    .
@note
    References:
    - General:
        - https://logging.apache.org/log4net/release/config-examples.html
        .
    .
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SandboxAspnetMvc5.Data.Entities {

public class SystemLog
{
    [Key]
    public virtual int Id {get;set;}

    public virtual DateTime DateCreated {get;set;}

    [StringLength(255)]
    public virtual string Thread {get;set;}

    [StringLength(50)]
    public virtual string Level {get;set;}

    [StringLength(255)]
    public virtual string Logger {get;set;}

    public virtual string Message {get;set;}

    public virtual string Exception {get;set;}

    public SystemLog()
    {
        this.Thread = String.Empty;
        this.Level = String.Empty;
        this.Logger = String.Empty;
        this.Message = String.Empty;
        this.Exception = null;
    }
}

}
