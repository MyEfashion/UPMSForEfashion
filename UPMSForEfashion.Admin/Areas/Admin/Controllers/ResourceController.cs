using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPMSForEfashion.Common;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Admin.Areas.Admin.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Admin/Module
        public ActionResult Index(string projectCode = "", int PageIndex = 1, int PageSize = 0)
        {
            if (string.IsNullOrWhiteSpace(projectCode))
            {
                var projectList = Bll.ProjectBll.Instance.List();
                if (projectList != null && projectList.Count() > 0)
                {
                    projectCode = projectList[0].Code;
                }
            }
            var model = Bll.ResourceBll.Instance.List(m => m.ProjectCode == projectCode);
            var result = new ListResult<resource>(model, PageIndex, PageSize, model.Count());
            ViewBag.ProjectCode = projectCode;
            return View(result);
        }

        public ActionResult Create(string projectCode, int parentId = 0)
        {
            return View("Edit", new resource() { ProjectCode = projectCode });
        }

        public ActionResult Edit(int id)
        {
            var model = Bll.ResourceBll.Instance.Get(m => m.ID == id);
            return View(model);
        }

        public string Submit(resource model)
        {
            try
            {
                var result = Bll.ResourceBll.Instance.Get(m => m.ID == model.ID);
                if (model.ID == 0 || (model.ID > 0 && result.Code != model.Code))
                {
                    var isHaveModel = Bll.ResourceBll.Instance.IsHaveModel(m => m.Code == model.Code);
                    if (isHaveModel)
                    {
                        return JsonConvert.SerializeObject(new { data = false, url = "", msg = "已经有编号为" + model.Code + "的数据" });
                    }
                }
                if (model.ID > 0)
                {
                    result.Name = model.Name;
                    result.Code = model.Code;
                    result.Url = model.Url;
                    result.Sort = model.Sort;
                    Bll.ResourceBll.Instance.Submit(result);
                }
                else
                {
                    model.CreateTime = DateTime.Now;
                    Bll.ResourceBll.Instance.Submit(model);
                }
            }
            catch (Exception)
            {
                return JsonConvert.SerializeObject(new { data = false, url = "", msg = "保存出错" });
            }
            var url = Url.Action("Index", new { projectCode = model.ProjectCode });
            var isEdit = model.ID > 0;
            return JsonConvert.SerializeObject(new { data = true, url = url, msg = "保存成功", isEdit = isEdit });
        }
    }
}