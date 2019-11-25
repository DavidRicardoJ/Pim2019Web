using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pim2019WEB.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }

        public bool ValidarLogin(Login login)
        {
            if (login.Email.Equals("admin@admin.com") && login.Senha.Equals("admin"))
            {
                return true;
            }
            else return false;
        }
    }
}
