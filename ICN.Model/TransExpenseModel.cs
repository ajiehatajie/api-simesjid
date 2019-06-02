using ICN.Generic;
using ICN.Interface;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICN.Model
{
    public class TransExpenseModel
    {
        [Required]
        public string expense_id { get; set; }


        [Required]
        [StringLength(35, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string expense_name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        public decimal expense_amount { get; set; }

        public string expense_ref { get; set; }

        [Required]
        public DateTime expense_date { get; set; }

        [Required]
        public string expense_accountid { get; set; }

        [Required]
        public string expense_categoryid { get; set; }

        [Required]
        public string expense_subcategoryid { get; set; }

        public string expense_note { get; set; }

        public string expense_pictureid { get; set; }

        public DateTime expense_created { get; set; }

        [Required]
        public string expense_settingid { get; set; }

        public DateTime expense_updated { get; set; }

        public string expense_created_by { get; set; }

        public string expense_updated_by { get; set; }

        public string expense_amount_rupiah
        {
           get
            {
                return GlobalFunction.Terbilang(Convert.ToInt32(expense_amount));
            }
            

        }
    }

    public class TransExpenseModelOutput : IResponse<TransExpenseModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }

        public List<LinkInfo> Pagination { get; set; }
        public List<TransExpenseModel> Data { get; set; }
    }
}
