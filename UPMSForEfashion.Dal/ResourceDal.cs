using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Dal
{
    public class ResourceDal : DbContextDal
    {
        public readonly static ResourceDal Instance = new ResourceDal();
        public List<resource> List(Expression<Func<resource, bool>> exp)
        {
            return entity.resource.Where(exp).ToList();
        }


        public resource Get(Expression<Func<resource, bool>> exp)
        {
            return entity.resource.SingleOrDefault(exp);
        }

        public void Submit(resource model)
        {
            model.IsDeleted = false;
            model.UpdateTime = DateTime.Now;
            if (model.ID == 0)
            {
                entity.resource.Add(model);
            }
            else
            {
                entity.Entry<resource>(model).State = System.Data.Entity.EntityState.Modified;
            }
            entity.SaveChanges();
        }

        public bool IsHaveModel(Expression<Func<resource, bool>> exp)
        {
            var result = Get(exp);
            return result != null && result.ID > 0;
        }
    }
}
