using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BluePrint.Common;

namespace App.BluePrint.Users
{
    public class LoginViewModel
    {
        public string TenancyName { get; set; }
        [Required]
        public string UsernameOrEmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public LoginType AuthenticationType { get; set; }
    }
}
