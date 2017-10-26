using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Dal;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Bll
{
    public class RoleBll
    {
        public readonly static RoleBll Instance = new RoleBll();

        public List<role> List()
        {
            return RoleDal.Instance.List();
        }
    }
}
