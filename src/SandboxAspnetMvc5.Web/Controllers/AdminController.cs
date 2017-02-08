using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandboxAspnetMvc5.Web.Controllers {

public class AdminController : BaseController
{
    new public static readonly string ObjectTypeName = "AdminController";
    new public static readonly string ObjectTypeFullName = String.Concat(ObjectTypeNamespace, ".", ObjectTypeName);

    protected readonly Data.Interfaces.ISystemRepository _repoSystem;
    protected readonly Data.Interfaces.IUserRepository _repoUser;

    /// <summary>Default constructor.</summary>
    public AdminController()
    {
        System.Diagnostics.Debug.WriteLine(String.Format("{0} : Constructor Started", ObjectTypeFullName));
        _repoSystem = new Data.SQLite.Repositories.SystemRepository(GetDatabaseConnectionString("SQLite"));
        _repoUser = new Data.Repositories.UserRepository(GetDatabaseConnectionString());
        System.Diagnostics.Debug.WriteLine(String.Format("{0} : Constructor Ended", ObjectTypeFullName));
    }

    /// <summary>Argument constructor.</summary>
    public AdminController(Data.Interfaces.ISystemRepository repoSystem, Data.Interfaces.IUserRepository repoUser)
    {
        _repoSystem = repoSystem;
        _repoUser = repoUser;
    }

    /// <summary>GET /Admin</summary>
    public ActionResult Index()
    {
        return View();
    }

    /// <summary>GET /Admin/CreateSystemLog</summary>
    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult CreateSystemLog()
    {
        return View(new Data.Entities.SystemLog());
    }

    /// <summary>POST /Admin/CreateSystemLog</summary>
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult CreateSystemLog(Data.Entities.SystemLog formInput)
    {
        if(ModelState.IsValid)
        {
            _repoSystem.CreateLog(new Data.Entities.SystemLog() {
                Id = 0,
                DateCreated = DateTime.Now,
                Thread = formInput.Thread ?? String.Empty,
                Level = formInput.Level ?? String.Empty,
                Logger = formInput.Logger ?? String.Empty,
                Message = formInput.Message ?? String.Empty,
                Exception = formInput.Exception ?? String.Empty
            });
            return RedirectToAction("ViewSystemLog");
        }
        return View();
    }

    /// <summary>GET /Admin/CreateSystemSetting</summary>
    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult CreateSystemSetting()
    {
        return View(new Data.Entities.SystemSetting());
    }

    /// <summary>POST /Admin/CreateSystemSetting</summary>
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult CreateSystemSetting(Data.Entities.SystemSetting formInput)
    {
        if(ModelState.IsValid)
        {
            _repoSystem.CreateSetting(new Data.Entities.SystemSetting() {
                Id = Guid.NewGuid(),
                ApplicationName = formInput.ApplicationName,
                Name = formInput.Name,
                Value = formInput.Value ?? String.Empty,
                DateModified = DateTime.Now
            });
            return RedirectToAction("ViewSystemSetting");
        }
        return View();
    }

    /// <summary>POST /Admin/DeleteSystemLog</summary>
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult DeleteSystemLog(int? id)
    {
        if(id != null) {
            _repoSystem.DeleteLog(id ?? 0);
        } else {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }
        return RedirectToAction("ViewSystemLog");
    }

    /// <summary>POST /Admin/DeleteSystemLogs</summary>
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult DeleteSystemLogs()
    {
        _repoSystem.DeleteLogs();
        return RedirectToAction("ViewSystemLog");
    }

    /// <summary>POST /Admin/DeleteSystemSetting</summary>
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult DeleteSystemSetting(Guid? id)
    {
        if(id != null) {
            _repoSystem.DeleteSetting(id ?? Guid.Empty);
        } else {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }
        return RedirectToAction("ViewSystemSetting");
    }

    /// <summary>GET /Admin/EditSystemLog</summary>
    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult EditSystemLog(int? id)
    {
        if(id != null) {
            var obj1 = _repoSystem.GetLog(id ?? 0);
            if(obj1 != null) {
                return View(obj1);
            } else {
                return HttpNotFound();
            }
        } else {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }
    }

    /// <summary>POST /Admin/EditSystemLog</summary>
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult EditSystemLog(Data.Entities.SystemLog formInput)
    {
        if(ModelState.IsValid)
        {
            _repoSystem.SetLog(new Data.Entities.SystemLog() {
                Id = formInput.Id,
                Thread = formInput.Thread ?? String.Empty,
                Level = formInput.Level ?? String.Empty,
                Logger = formInput.Logger ?? String.Empty,
                Message = formInput.Message ?? String.Empty,
                Exception = formInput.Exception ?? String.Empty
            });
            return RedirectToAction("ViewSystemLog");
        }
        return View(formInput);
    }

    /// <summary>GET /Admin/EditSystemSetting</summary>
    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult EditSystemSetting(Guid? id)
    {
        if(id != null) {
            var obj1 = _repoSystem.GetSetting(id ?? Guid.Empty);
            if(obj1 != null) {
                return View(obj1);
            } else {
                return HttpNotFound();
            }
        } else {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }
    }

    /// <summary>POST /Admin/EditSystemSetting</summary>
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult EditSystemSetting(Data.Entities.SystemSetting formInput)
    {
        if(ModelState.IsValid)
        {
            _repoSystem.SetSetting(new Data.Entities.SystemSetting() {
                Id = formInput.Id,
                ApplicationName = formInput.ApplicationName,
                Name = formInput.Name,
                Value = formInput.Value ?? String.Empty,
                DateModified = DateTime.Now
            });
            return RedirectToAction("ViewSystemSetting");
        }
        return View(formInput);
    }

    /// <summary>GET /Admin/ViewSystemLog</summary>
    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult ViewSystemLog(int? id)
    {
        if(id != null) {
            var obj1 = _repoSystem.GetLog(id ?? 0);
            if(obj1 == null) {
                return HttpNotFound();
            }
            var objs1 = Helpers.CollectionHelper.AsSingleEnumerable<Data.Entities.SystemLog>(obj1).Select(x => new ViewModels.AdminSystemLogViewModel() {
                Id = x.Id,
                DateCreated = x.DateCreated,
                Thread = x.Thread,
                Level = x.Level,
                Logger = x.Logger,
                Message = x.Message,
                Exception = x.Exception
            });
            ViewBag.ViewMode = "details";
            return View(objs1);
        } else {
            var objs1 = _repoSystem.GetLogs().Select(x => new ViewModels.AdminSystemLogViewModel() {
                Id = x.Id,
                DateCreated = x.DateCreated,
                Thread = x.Thread,
                Level = x.Level,
                Logger = x.Logger,
                Message = x.Message,
                Exception = x.Exception
            });
            if(objs1 == null) {
                return HttpNotFound();
            }
            ViewBag.ViewMode = "list";
            return View(objs1);
        }
    }

    /// <summary>GET /Admin/ViewSystemSetting</summary>
    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult ViewSystemSetting(Guid? id)
    {
        if(id != null) {
            var obj1 = _repoSystem.GetSetting(id ?? Guid.Empty);
            if(obj1 == null) {
                return HttpNotFound();
            }
            var objs1 = Helpers.CollectionHelper.AsSingleEnumerable<Data.Entities.SystemSetting>(obj1).Select(x => new ViewModels.AdminSystemSettingViewModel() {
                Id = x.Id,
                ApplicationName = x.ApplicationName,
                Name = x.Name,
                Value = x.Value,
                DateModified = x.DateModified
            });
            ViewBag.Mode = "details";
            return View(objs1);
        } else {
            var objs1 = _repoSystem.GetSettings().Select(x => new ViewModels.AdminSystemSettingViewModel() {
                Id = x.Id,
                ApplicationName = x.ApplicationName,
                Name = x.Name,
                Value = x.Value,
                DateModified = x.DateModified
            });
            if(objs1 == null) {
                return HttpNotFound();
            }
            ViewBag.ViewMode = "list";
            return View(objs1);
        }
    }
}

}