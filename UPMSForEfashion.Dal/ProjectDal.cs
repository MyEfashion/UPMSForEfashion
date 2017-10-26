using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Dal
{
    public class ProjectDal : DbContextDal
    {
        public readonly static ProjectDal Instance = new ProjectDal();
        public List<project> List()
        {
            return entity.project.ToList();
        }

        public project Get(Expression<Func<project, bool>> exp)
        {
            return entity.project.SingleOrDefault(exp);
        }

        public void Submit(project model)
        {
            model.IsDeleted = false;
            model.UpdateTime = DateTime.Now;
            if (model.ID == 0)
            {
                entity.project.Add(model);
            }
            else
            {
                entity.Entry<project>(model).State = System.Data.Entity.EntityState.Modified;
            }
            entity.SaveChanges();
        }

        public bool IsHaveModel(Expression<Func<project, bool>> exp)
        {
            var result = Get(exp);
            return result != null && result.ID > 0;
        }

    }
}
