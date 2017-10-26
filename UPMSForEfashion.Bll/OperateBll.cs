using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPMSForEfashion.Dal;
using UPMSForEfashion.Model;

namespace UPMSForEfashion.Bll
{
    public class OperateBll
    {
        public readonly static OperateBll Instance = new OperateBll();

        public List<operate> List()
        {
            return OperateDal.Instance.List();
        }
    }
}
