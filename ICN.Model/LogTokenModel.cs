using System;
using System.Collections.Generic;
using System.Text;

namespace ICN.Model
{
    public class LogTokenModel
    {
        public string token_id { get; set; }
        public string token_name { get; set; }
        public string token_userid { get; set; }
        public string token_revoked { get; set; }
        public string token_refresh { get; set; }
        public DateTime token_created { get; set; }
    }


}
