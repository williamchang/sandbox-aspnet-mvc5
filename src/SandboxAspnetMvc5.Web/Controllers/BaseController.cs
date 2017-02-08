/**
@file
    BaseController.cs
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
        - http://stackoverflow.com/questions/882916/calling-filterattributes-onactionexecuting-before-basecontrollers-onactionexecu
        .
    - Page.Request (HttpRequest URL):
        - HttpContext.Current.Request.RawUrl, HttpContext.Request.Url.PathAndQuery
        - http://timstall.dotnetdevelopersjournal.com/understanding_httprequest_urls.htm
        .
    - Params:
        - http://www.switchonthecode.com/tutorials/csharp-snippet-tutorial-the-params-keyword
        - http://www.myviewstate.net/blog/post/2009/05/21/Passing-Delegates-as-Parameters-in-C.aspx
        .
    - Flags:
        - http://dotnet.org.za/kevint/pages/Flags.aspx
        .
    - Model:
        - Domain Model (Data, DDD)
        - Presentation Model (Web, MVC)
        .
    .
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandboxAspnetMvc5.Web.Controllers {

/// <summary>Base controller (abstract) for all controllers.</summary>
public abstract class BaseController : Controller
{
    public static readonly string ObjectOwner = "SandboxAspnetMvc5";
    public static readonly string ObjectTypeName = "BaseController";
    public static readonly string ObjectTypeNamespace = "SandboxAspnetMvc5.Web.Controllers";
    public static readonly string ObjectTypeFullName = String.Concat(ObjectTypeNamespace, ".", ObjectTypeName);

    /// <summary>Default constructor.</summary>
    public BaseController() : base()
    {
        System.Diagnostics.Debug.WriteLine(String.Format("{0} : Constructor Started", ObjectTypeFullName));
        // Do something.
        System.Diagnostics.Debug.WriteLine(String.Format("{0} : Constructor Ended", ObjectTypeFullName));
    }

    /// <summary>Get database connection string.</summary>
    [NonAction]
    public string GetDatabaseConnectionString(string name = "Default")
    {
        var dbConnectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings[name];
        if(dbConnectionStringSettings != null && !String.IsNullOrEmpty(dbConnectionStringSettings.ConnectionString)) {
            return dbConnectionStringSettings.ConnectionString;
        } else {
            throw new Exception("Missing connecting string in Web.config file.");
        }
    }

#region Utilities

    [NonAction]
    public static string GetSafeValue(string value, string defaultValue)
    {
        if(!String.IsNullOrEmpty(value)) {
            return value;
        } else {
            return defaultValue;
        }
    }

    [NonAction]
    public static string GetSafeValue(string value, string anotherValue, string defaultValue)
    {
        if(!String.IsNullOrEmpty(value)) {
            return value;
        } else if(!String.IsNullOrEmpty(anotherValue)) {
            return anotherValue;
        } else {
            return defaultValue;
        }
    }

    [NonAction]
    public static string GetSetting(string settingName, string defaultValue)
    {
        return GetSafeValue(System.Configuration.ConfigurationManager.AppSettings.Get(settingName), defaultValue);
    }

#endregion

}

}
