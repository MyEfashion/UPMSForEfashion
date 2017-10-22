using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Dal;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Bll
{
    public class UserBll
    {
        public readonly static UserBll Instance = new UserBll();

        public List<user> List()
        {
            return UserDal.Instance.List();
        }
    }
}
