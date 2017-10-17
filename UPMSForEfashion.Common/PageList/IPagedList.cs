using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPMSForEfashion.Common
{
    public interface IPagedList
    {
        string Href { get; set; }
        int PageSize { get; set; }
        int PageIndex { get; set; }
        int TotalItemCount { get; set; }
        bool IsLastPage { get;  }
        bool IsFirstPage { get;  }
        bool HasPrePage { get;  }
    }
}
