using ICN.Interface;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICN.Model
{
    public class TreeModel
    {
        public string tree_id { get; set; }

        public string tree_userid { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string tree_jobposition { get; set; }

        public string tree_parentid { get; set; }

        public string tree_settingid { get; set; }

        public string tree_created_by { get; set; }

        public string tree_created { get; set; }
    }

    public class TreeModelOutput : IResponse<TreeModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }

        public List<LinkInfo> Pagination { get; set; }
        public List<TreeModel> Data { get; set; }

    }
}
