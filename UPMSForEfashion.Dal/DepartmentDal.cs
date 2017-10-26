using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Dal
{
    public class DepartmentDal : DbContextDal
    {
        public readonly static DepartmentDal Instance = new DepartmentDal();
        public List<department> List()
        {
            return entity.department.ToList();
        }
    }
}
