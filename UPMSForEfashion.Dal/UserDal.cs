using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Dal
{
    public class UserDal : DbContextDal
    {
        public readonly static UserDal Instance = new UserDal();
        public List<user> List()
        {
            return entity.user.ToList();
        }
    }
}
