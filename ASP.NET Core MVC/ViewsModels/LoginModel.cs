using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Login")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
