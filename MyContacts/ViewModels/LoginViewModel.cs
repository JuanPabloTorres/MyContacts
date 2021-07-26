using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyContacts
{
    public class LoginViewModel
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is Required!")]
        public string Username { get; set; }
    }
}