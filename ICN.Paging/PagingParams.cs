using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Paging
{
    public class PagingParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Query { get; set; } = "";
        public string Term { get; set; } = "";
    }
}
