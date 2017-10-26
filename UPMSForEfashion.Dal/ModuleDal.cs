using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Dal
{
    public class ModuleDal : DbContextDal
    {
        public readonly static ModuleDal Instance = new ModuleDal();
        public List<module> List(Expression<Func<module, bool>> exp)
        {
            return entity.module.Where(exp).ToList();
        }

        public module Get(Expression<Func<module, bool>> exp)
        {
            return entity.module.SingleOrDefault(exp);
        }

        public void Submit(module model)
        {
            model.IsDeleted = false;
            model.UpdateTime = DateTime.Now;
            if (model.ID == 0)
            {
                entity.module.Add(model);
            }
            else
            {
                entity.Entry<module>(model).State = System.Data.Entity.EntityState.Modified;
            }
            entity.SaveChanges();
        }

        public bool IsHaveModel(Expression<Func<module, bool>> exp)
        {
            var result = Get(exp);
            return result != null && result.ID > 0;
        }
    }
}
