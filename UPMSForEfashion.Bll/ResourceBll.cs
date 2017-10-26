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
    public class ResourceBll
    {
        public readonly static ResourceBll Instance = new ResourceBll();

        public List<resource> List(Expression<Func<resource, bool>> exp)
        {
            return ResourceDal.Instance.List(exp);
        }

        public resource Get(Expression<Func<resource, bool>> exp)
        {
            return ResourceDal.Instance.Get(exp);
        }

        public void Submit(resource model)
        {
            ResourceDal.Instance.Submit(model);
        }

        public bool IsHaveModel(Expression<Func<resource, bool>> exp)
        {
            return ResourceDal.Instance.IsHaveModel(exp);
        }
    }
}
