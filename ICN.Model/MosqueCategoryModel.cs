using ICN.Interface;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Model
{
    public class MosqueCategoryModel
    {
        public int category_id { get; set; }

        public string  category_name { get; set; }

        public string category_type { get; set; }
    }


    public class MosqueCategoryModelOutput : IResponse<MosqueCategoryModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }

        public List<LinkInfo> Pagination { get; set; }
        public List<MosqueCategoryModel> Data { get; set; }
    }
}
