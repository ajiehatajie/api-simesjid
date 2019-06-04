using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ICN.Interface;
using ICN.Paging;
namespace ICN.Model
{
    public class CategoryModel
    {
     
        public string category_id { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string category_name { get; set; }

        public string category_desc { get; set; }
        
        public string category_userid { get; set; }

        [Required]
        public string category_type { get; set; } 

        [Required]
        public string category_color { get; set; }

        public string category_parentid { get; set; }

        [Required]
        public string category_settingid { get; set; }
        //buat sub category 
        public string parent_id { get; set; }
        public string parent_name { get; set; }
    }

    public class CategoryModelOutput : IResponse<CategoryModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }

        public List<LinkInfo> Pagination { get; set; }
        public List<CategoryModel> Data { get; set; }
    }
}
