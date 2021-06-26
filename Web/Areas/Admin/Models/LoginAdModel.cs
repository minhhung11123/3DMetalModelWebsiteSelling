using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.Models
{
    public class LoginAdModel
    {
        [Required]
        public string UserName { set; get; }
        public string Password { set; get; }
    }
}