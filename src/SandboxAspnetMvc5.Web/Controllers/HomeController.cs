using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandboxAspnetMvc5.Web.Controllers {

public class HomeController : BaseController
{
    /// <summary>GET /Home</summary>
    public ActionResult Index()
    {
        return View();
    }

    /// <summary>GET /Home/About</summary>
    public ActionResult About()
    {
        ViewBag.Message = "Your application description page.";

        return View();
    }

    /// <summary>GET /Home/Contact</summary>
    public ActionResult Contact()
    {
        ViewBag.Message = "Your contact page.";

        return View();
    }

    /// <summary>GET /Home/Sandbox</summary>
    public ActionResult Sandbox()
    {
        System.Text.StringBuilder sbDebug = new System.Text.StringBuilder();

        // References
        // http://www.hanselman.com/blog/ASPNETParamsCollectionVsQueryStringFormsVsRequestindexAndDoubleDecoding.aspx

        sbDebug.AppendFormat("\n<div>\n");
        sbDebug.AppendFormat("Request QueryString Echo : {0}", Helpers.CollectionHelper.HasKey(Request.QueryString, "echo"));
        sbDebug.AppendFormat("\n<br />\n");
        sbDebug.AppendFormat("Request QueryString Echo : {0}", Request.QueryString["echo"] ?? "null");
        sbDebug.AppendFormat("\n<br />\n");
        sbDebug.AppendFormat("Request QueryString Message : {0}", Helpers.CollectionHelper.HasKey(Request.QueryString, "message"));
        sbDebug.AppendFormat("\n<br />\n");
        sbDebug.AppendFormat("Request QueryString Message : {0}", Request.QueryString["message"] ?? "null");
        sbDebug.AppendFormat("\n</div>\n");

        ViewBag.DebugInformation = sbDebug.ToString();

        return View();
    }

    /// <summary>GET /Home/Raw</summary>
    public String Raw()
    {
        return "Raw";
    }
}

}
