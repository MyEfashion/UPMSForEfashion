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
    public class ModuleController : Controller
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
            var model = Bll.ModuleBll.Instance.List(m => m.ProjectCode == projectCode);
            var result = new ListResult<module>(model, PageIndex, PageSize, model.Count());
            ViewBag.ProjectCode = projectCode;
            return View(result);
        }

        public ActionResult Create(string projectCode, int parentId = 0)
        {
            return View("Edit", new module() { ParentId = parentId, ProjectCode = projectCode });
        }

        public ActionResult Edit(int id)
        {
            var model = Bll.ModuleBll.Instance.Get(m => m.ID == id);
            return View(model);
        }

        public string Submit(module model)
        {
            try
            {
                var result = Bll.ModuleBll.Instance.Get(m => m.ID == model.ID);
                if (model.ID == 0 || (model.ID > 0 && result.ModuleCode != model.ModuleCode))
                {
                    var isHaveModel = Bll.ModuleBll.Instance.IsHaveModel(m => m.ModuleCode == model.ModuleCode);
                    if (isHaveModel)
                    {
                        return JsonConvert.SerializeObject(new { data = false, url = "", msg = "已经有编号为" + model.ModuleCode + "的数据" });
                    }
                }
                if (model.ID > 0)
                {
                    result.Name = model.Name;
                    result.ModuleCode = model.ModuleCode;
                    result.Sort = model.Sort;
                    Bll.ModuleBll.Instance.Submit(result);
                }
                else
                {
                    if (model.ParentId > 0)
                    {
                        var pModel = Bll.ModuleBll.Instance.Get(m => m.ID == model.ParentId);
                        pModel.IsGroup = true;
                        Bll.ModuleBll.Instance.Submit(pModel);
                    }
                    model.CreateTime = DateTime.Now;
                    Bll.ModuleBll.Instance.Submit(model);
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