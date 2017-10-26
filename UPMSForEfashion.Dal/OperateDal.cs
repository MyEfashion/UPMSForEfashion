using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Dal
{
    public class OperateDal : DbContextDal
    {
        public readonly static OperateDal Instance = new OperateDal();
        public List<operate> List()
        {
            return entity.operate.ToList();
        }
    }
}
