using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPMSForEfashion.Common
{
    public class ListResult<T>
    {
        public ListResult(List<T> list, int pageIndex, int pageSize, int totalCount)
        {
            Rows = list;
            PageIndex = pageIndex;
            PageSize = pageSize == 0 ? 20 : pageSize;
            TotalItemCount = totalCount;
        }
        public List<T> Rows { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int PageCount
        {
            get
            {
                var result = TotalItemCount % PageSize;
                if (result > 0)
                {
                    return TotalItemCount / PageSize + 1;
                }
                else
                {
                    return TotalItemCount / PageSize;
                }
            }
        }
    }
}
