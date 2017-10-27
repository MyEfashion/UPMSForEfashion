using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Dal;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Bll
{
    public class DepartmentBll
    {
        public readonly static DepartmentBll Instance = new DepartmentBll();

        public List<department> List()
        {
            return DepartmentDal.Instance.List();
        }
    }
}
