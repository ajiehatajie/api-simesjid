using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Paging
{
    public class PagingHeader
    {
        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }

        public PagingHeader(int totalItems, int pageNumber, int pageSize, int totalPages)
        {
            this.TotalItems = totalItems;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
        }

        public string ToJson() => JsonConvert.SerializeObject(this,
                                   new JsonSerializerSettings
                                   {
                                       ContractResolver = new CamelCasePropertyNamesContractResolver()
                                   });
    }
}
