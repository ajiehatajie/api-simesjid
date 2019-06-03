using ICN.Interface;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Model
{
    public class PostalModel
    {
        public int id { get; set; }

        public string postal_id { get; set; }

        public string kelurahan { get; set; }

        public string kecamatan { get; set; }

        public string kabupaten { get; set; }

        public string province { get; set; }
    }

    public class PostalModelOutput : IResponse<PostalModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }

        public List<LinkInfo> Pagination { get; set; }
        public List<PostalModel> Data { get; set; }
    }
}
