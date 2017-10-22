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
    public class ProjectController : Controller
    {
        // GET: Admin/Project
        public ActionResult Index(int PageIndex = 1, int PageSize = 0)
        {
            var model = Bll.ProjectBll.Instance.List();
            var result = new ListResult<project>(model, PageIndex, PageSize, model.Count());
            return View(result);
        }

        public ActionResult Create()
        {
            return View("Edit", new project());
        }

        public ActionResult Edit(int id)
        {
            var model = Bll.ProjectBll.Instance.Get(m => m.ID == id);
            return View(model);
        }

        public string Submit(project model)
        {
            try
            {
                var result = Bll.ProjectBll.Instance.Get(m => m.ID == model.ID);
                if (model.ID == 0 || (model.ID > 0 && result.Code != model.Code))
                {
                    var isHaveModel = Bll.ProjectBll.Instance.IsHaveModel(m => m.Code == model.Code);
                    if (isHaveModel)
                    {
                        return JsonConvert.SerializeObject(new { data = false, url = "", msg = "已经有编号为" + model.Code + "的数据" });
                    }
                }
                if (model.ID > 0)
                {
                    result.Name = model.Name;
                    result.Url = model.Url;
                    result.Sort = model.Sort;
                    result.Comment = model.Comment;
                    Bll.ProjectBll.Instance.Submit(result);
                }
                else
                {
                    model.CreateTime = DateTime.Now;
                    Bll.ProjectBll.Instance.Submit(model);
                }
            }
            catch (Exception)
            {
                return JsonConvert.SerializeObject(new { data = false, url = "", msg = "保存出错" });
            }
            var url = Url.Action("Index");
            var isEdit = model.ID > 0;
            return JsonConvert.SerializeObject(new { data = true, url = url, msg = "保存成功", isEdit = isEdit });
        }
    }
}