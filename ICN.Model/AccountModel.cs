using ICN.Interface;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICN.Model
{
    public class AccountModel
    {
        public string account_id { get; set; }

        [Required]
        public string account_name { get; set; }

        [Required]
        public double account_balance { get; set; }

        public string account_desc { get; set; }

        public string account_userid { get; set; }

        public DateTime account_created { get; set; }

        public string user_name { get; set; }

        public string user_email { get; set; }

    }

    public class AccountModelOutput : IResponse<AccountModel>
    {

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }

        public List<LinkInfo> Pagination { get; set; }
        public List<AccountModel> Data { get; set; }
    }
}
