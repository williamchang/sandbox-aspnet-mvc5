using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandboxAspnetMvc5.Web.Controllers {

public class UserController : BaseController
{
    /// <summary>GET /User</summary>
    public ActionResult Index()
    {
        return View();
    }

    /// <summary>GET /User/CreateSetting</summary>
    public ActionResult CreateSetting()
    {
        return View();
    }

    /// <summary>GET /User/DeleteSetting</summary>
    public ActionResult DeleteSetting()
    {
        return View();
    }

    /// <summary>GET /User/EditSetting</summary>
    public ActionResult EditSetting()
    {
        return View();
    }

    /// <summary>GET /User/GetSetting</summary>
    public ActionResult GetSetting()
    {
        return View();
    }

    /// <summary>GET /User/ViewSettings</summary>
    public ActionResult ViewSettings()
    {
        return View();
    }
}

}
