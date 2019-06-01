using ICN.Interface;
using ICN.Paging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICN.Model
{
    public class PictureModel
    {
        [Required]
        public string picture_id { get; set; }

        [Required]
        public string picture_filename { get; set; }

        [Required]
        public string picture_path { get; set; }

        public string picture_created_by { get; set; }

        public DateTime picture_created { get; set; }
    }

    public class PictureModelOutput : IResponse<PictureModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Dictionary<string, object> CustomField { get; set; }

        public List<LinkInfo> Pagination { get; set; }
        public List<PictureModel> Data { get; set; }
    }
}
