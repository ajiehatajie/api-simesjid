using ICN.Interface;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICN.Model
{
    public class SettingModel
    {
        public string setting_id { get; set; }

        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string setting_mosque_name { get; set; }

        public string setting_countries { get; set; }

        public string setting_city { get; set; }

        public string setting_web { get; set; }

        public string setting_phone { get; set; }

        [EmailAddress]
        public string setting_mosque_email { get; set; }

        public string setting_currency { get; set; }

        public string setting_address { get; set; }

        public string setting_languange { get; set; }

        public string setting_geolocation { get; set; }

        public string setting_logo { get; set; }

        public DateTime setting_created { get; set; }

        public DateTime setting_updated { get; set; }

        public string setting_created_by { get; set; }

        public string setting_updated_by { get; set; }
    }

    public class SettingModelOutput : IResponse<SettingModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }

        public List<LinkInfo> Pagination { get; set; }
        public List<SettingModel> Data { get; set; }
    }
}
