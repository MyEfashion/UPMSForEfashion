using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Dal
{
    public class RoleDal : DbContextDal
    {
        public readonly static RoleDal Instance = new RoleDal();
        public List<role> List()
        {
            return entity.role.ToList();
        }
    }
}
