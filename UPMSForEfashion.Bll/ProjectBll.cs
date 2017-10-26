using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Dal;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Bll
{
    public class ProjectBll
    {
        public readonly static ProjectBll Instance = new ProjectBll();

        public List<project> List()
        {
            return ProjectDal.Instance.List();
        }

        public project Get(Expression<Func<project, bool>> exp)
        {
            return ProjectDal.Instance.Get(exp);
        }

        public void Submit(project model)
        {
            ProjectDal.Instance.Submit(model);
        }

        public bool IsHaveModel(Expression<Func<project, bool>> exp)
        {
            return ProjectDal.Instance.IsHaveModel(exp);
        }
    }
}
