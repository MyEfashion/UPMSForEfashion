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
    public class ModuleBll
    {
        public readonly static ModuleBll Instance = new ModuleBll();

        public List<module> List(Expression<Func<module, bool>> exp)
        {
            return ModuleDal.Instance.List(exp);
        }

        public module Get(Expression<Func<module, bool>> exp)
        {
            return ModuleDal.Instance.Get(exp);
        }

        public void Submit(module model)
        {
            ModuleDal.Instance.Submit(model);
        }

        public bool IsHaveModel(Expression<Func<module, bool>> exp)
        {
            return ModuleDal.Instance.IsHaveModel(exp);
        }
    }
}
