using System;
using System.Collections.Generic;

namespace SandboxAspnetMvc5.Web.ViewModels {

public class AdminSystemSettingViewModel
{
    public Guid Id {get;set;}

    public string ApplicationName {get;set;}

    public string Name {get;set;}

    public string Value {get;set;}

    public DateTime DateModified {get;set;}
}

}