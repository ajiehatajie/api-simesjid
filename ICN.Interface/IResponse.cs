using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Interface
{
    public interface IResponse<T>
    {
         bool IsSuccess { get; set; }
         string Message { get; set; }
         int Code { get; set; }

         Dictionary<string, object> CustomField
         {
            get;
            set;
         }

        List<LinkInfo> Pagination { get; set; }
        List<T> Data { get; set; }
    }
}
