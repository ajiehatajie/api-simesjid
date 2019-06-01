using ICN.Paging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICN.Model
{
    public class AccessModel
    {
        [Required]
        public string access_id { get; set; }

        [Required]
        public string access_roleid { get; set; }

        [Required]
        public string access_userid { get; set; }
        public DateTime access_created { get; set; }
    }

    public class AccessModelOutput
    {
        public Dictionary<string, object> CustomField
        {
            get;
            set;
        }
        public List<LinkInfo> Pagination { get; set; }
        public List<AccessModel> Data { get; set; }
    }
}
