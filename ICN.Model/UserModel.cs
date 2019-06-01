using ICN.Interface;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICN.Model
{
    public class UserModel
    {
        public string user_id { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string user_name { get; set; }

        [Required]
        [EmailAddress]
        public string user_email { get; set; }

        public string user_lastname { get; set; }

        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string user_password { get; set; }

        public string user_role { get; set; } = "STAFF";

        public string user_parentid { get; set; } //klo null berarti paling atas

        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string user_phone { get; set; }

        public string user_status { get; set; }

        public DateTime user_email_verified_at { get; set; }

        public string user_token { get; set; }

        public string user_remember_token { get; set; }

        public DateTime user_created { get; set; }
    }

    public class UserModelOutput : IResponse<UserModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }
        public List<LinkInfo> Pagination { get; set; }
        public List<UserModel> Data { get; set; }
    }
}
