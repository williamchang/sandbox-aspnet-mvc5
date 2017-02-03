/**
@file
    SystemSetting.cs
@author
    William Chang
@version
    0.1
@date
    - Created: 2015-08-20
    - Modified: 2015-08-31
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

public class SystemSetting
{
    [Key]
    public virtual Guid Id {get;set;}

    [Required(AllowEmptyStrings = false)]
    [StringLength(255, MinimumLength = 1)]
    public virtual string ApplicationName {get;set;}

    [Required(AllowEmptyStrings = false)]
    [StringLength(255, MinimumLength = 1)]
    public virtual string Name {get;set;}

    public virtual string Value {get;set;}

    [Required]
    public virtual DateTime DateModified {get;set;}

    public SystemSetting()
    {
        this.ApplicationName = "DefaultApplication";
        this.Value = String.Empty;
    }
}

}
