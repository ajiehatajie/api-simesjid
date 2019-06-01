using ICN.Interface;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICN.Model
{
    public class TransIncomeModel
    {
        [Required]
        public string income_id { get; set; }

        [Required]
        [StringLength(35, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string income_name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        public decimal income_amount { get; set; }

        public string income_ref { get; set; }

        [Required]
        public DateTime income_date { get; set; }

        [Required]
        public string income_accountid { get; set; }

        [Required]
        public string income_categoryid { get; set; }

        [Required]
        public string income_subcategoryid { get; set; }

        public string income_note { get; set; }

        public string income_pictureid { get; set; }

        [Required]
        public string income_settingid { get; set; }

        public DateTime income_created { get; set; }

        public DateTime income_updated { get; set; }

        public string income_created_by { get; set; }

        public string income_updated_by { get; set; }
    }

    public class TransIncomeModelOutput : IResponse<TransIncomeModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }
        public List<LinkInfo> Pagination { get; set; }
        public List<TransIncomeModel> Data { get; set; }
    }
}
