using System;
using System.Collections.Generic;

namespace SandboxAspnetMvc5.Web.ViewModels {

public class AdminSystemLogViewModel
{
    public int Id {get;set;}

    public DateTime DateCreated {get;set;}

    public string Thread {get;set;}

    public string Level {get;set;}

    public string Logger {get;set;}

    public string Message {get;set;}

    public string Exception {get;set;}
}

}