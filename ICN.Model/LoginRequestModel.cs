using ICN.Interface;
using ICN.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICN.Model
{
    public class LoginRequestModel
    {
      
        [JsonProperty("username")]
        [StringLength(8, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [JsonProperty("email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class LoginModelOutput : IResponse<UserModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }

        public List<LinkInfo> Pagination { get; set; }
        public List<UserModel> Data { get; set; }

        public string token { get; set; }
        public string RefreshToken { get; set; }

    }
}
