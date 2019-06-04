using ICN.Interface;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Model
{
    public class RoleModel
    {
        public int role_id { get; set; }

        public string role_name { get; set; }

        public string user_id { get; set; }
    }

    public class RoleModelOutput : IResponse<RoleModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }

        public List<LinkInfo> Pagination { get; set; }
        public List<RoleModel> Data { get; set; }

    }
}
