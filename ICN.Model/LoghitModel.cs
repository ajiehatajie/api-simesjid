using ICN.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Model
{
    public class LoghitModel
    {
        public string log_id { get; set; }
        public string log_ua { get; set; }
        public string log_country { get; set; }
        public string log_source { get; set; }
        public string log_referer { get; set; }
        public string log_url { get; set; }
        public string log_ip { get; set; }
        public string log_os { get; set; }
        public string log_app_version_name { get; set; }
        public string log_app_name { get; set; }
        public DateTime created { get; set; }
    }

    public class LoghitModelOutput
    {
        public Dictionary<string, object> CustomField
        {
            get;
            set;
        }
        public List<LinkInfo> Pagination { get; set; }
        public List<LoghitModel> Data { get; set; }
    }
}
