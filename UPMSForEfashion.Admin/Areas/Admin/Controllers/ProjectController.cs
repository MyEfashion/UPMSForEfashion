using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPMSForEfashion.Common;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Admin.Areas.Admin.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Admin/Project
        public ActionResult Index(int PageIndex = 1, int PageSize = 0)
        {
            var model = Bll.UserBll.Instance.UserList();
            var result = new ListResult<user>(model, PageIndex, PageSize, model.Count());
            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "系统创建";
            return View(new project());
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}