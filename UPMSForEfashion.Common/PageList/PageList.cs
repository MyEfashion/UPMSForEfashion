using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UPMSForEfashion.Common
{
    public class PageList : IPagedList
    {
        public readonly static PageList Instance = new PageList();
        public PageList()
        {

        }
        public PageList(int pageIndex, int pageSize, int totalCount, string url)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItemCount = totalCount;
            Href = url;
        }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalItemCount { get; set; }

        public string Href { get; set; }
        private int _pageCount { get; set; }
        public int PageCount
        {
            get
            {
                if (_pageCount <= 0)
                {
                    _pageCount = SetPageCount();
                }
                return _pageCount;
            }
        }

        public bool HasNextPage { get { return PageIndex < PageCount; } }

        public bool HasPrePage { get { return PageIndex > 1; } }

        public bool IsFirstPage
        {
            get { return PageIndex == 1; }
        }

        public bool IsLastPage
        {
            get
            {
                return PageIndex == PageCount;
            }
        }
        private int SetPageCount()
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
        public const string FirstLink = @"<li><a href='{0}' aria-label='First' ><span aria-hidden='true'>&laquo;&laquo;</span></a></li>";
        public const string PrevLink = @"<li><a href='{0}' aria-label='Previous' ><span aria-hidden='true'>&laquo;</span></a></li>";
        public const string NextLink = @"<li><a href='{0}' aria-label='First' ><span aria-hidden='true'>&raquo;</span></a></li>";
        public const string LastLink = @"<li><a href='{0}' aria-label='Previous' ><span aria-hidden='true'>&raquo;&raquo;</span></a></li>";
        public const string Link = @"<li {1}><a href='{0}'>{2}</a></li>";
        public const int LinkCount = 10;
        public const string JointHref = "?PageIndex={0}&PageSize={1}";

        public string GetFirstLink()
        {
            return string.Format(FirstLink, Href + string.Format(JointHref, 1, PageSize));
        }
        public string GetPrevLink()
        {
            return string.Format(PrevLink, Href + string.Format(JointHref, PageIndex - 1, PageSize));
        }
        public string GetNextLink()
        {
            return string.Format(NextLink, Href + string.Format(JointHref, PageIndex + 1, PageSize));
        }
        public string GetLastLink()
        {
            return string.Format(LastLink, Href + string.Format(JointHref, PageCount, PageSize));
        }
        public string GetLink(int pageIndex)
        {
            if (pageIndex == PageIndex)
            {
                return string.Format(Link, "javascript:void(0);", " class='active' ", pageIndex);
            }
            return string.Format(Link, Href + string.Format(JointHref, pageIndex, PageSize), "", pageIndex);
        }

        public MvcHtmlString GetPage(int pageIndex, int pageSize, int totalCount, string url)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItemCount = totalCount;
            _pageCount = 0;
            Href = url;
            var pageHtml = "";
            if (!IsFirstPage)
            {
                pageHtml += GetFirstLink();
            }
            if (HasPrePage)
            {
                pageHtml += GetPrevLink();
            }
            var result = (pageIndex / LinkCount) * LinkCount;
            var showMaxPageCount = pageIndex + LinkCount / 2 - 1;
            var showMinPageCount = pageIndex - LinkCount / 2;
            if (showMinPageCount <= 0)
            {
                showMinPageCount = 1;
                showMaxPageCount = LinkCount;
            }
            if (showMaxPageCount >= PageCount)
            {
                showMinPageCount = PageCount - 10 + 1;
                if (showMinPageCount <= 0)
                {
                    showMinPageCount = 1;
                }
                for (int i = showMinPageCount; i <= PageCount; i++)
                {
                    pageHtml += GetLink(i);
                }
            }
            else
            {
                for (int i = showMinPageCount; i <= showMaxPageCount; i++)
                {
                    pageHtml += GetLink(i);
                }
            }

            if (HasNextPage)
            {
                pageHtml += GetNextLink();
            }
            if (!IsLastPage)
            {
                pageHtml += GetLastLink();
            }
            return new MvcHtmlString(pageHtml);
        }

    }
}
