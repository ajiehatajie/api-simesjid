using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICN.Model
{
    public class RegisterModel
    {
        public string user_id { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string user_name { get; set; }

        [Required]
        [EmailAddress]
        public string user_email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string user_password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("user_password")]
       
        public string user_confirmpassword  { get; set; }

       

        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string mosque_name { get; set; }


        [Required]
       
        public string mosque_type { get; set; }
    }
}
