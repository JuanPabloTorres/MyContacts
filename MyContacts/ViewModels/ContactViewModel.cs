using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyContacts.ViewModels
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }


        [Required(ErrorMessage = "Name is not valid!")]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MaxLength(10)]
        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone Number is not valid!")]
        [Required(ErrorMessage = "Phone number is not valid!")]
        public string Phone { get; set; }

        [MaxLength(10)]
        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Fax number is not valid!")]
        [Required(ErrorMessage = "Fax number is not valid!")]
        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]

        [Required(ErrorMessage = "Email is not valid!")]

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [DisplayName("Last Update Date")]
        public DateTime LastUpdateDate { get; set; }

        [DisplayName("Last Update Username")]
        public DateTime LastUpdateUserName { get; set; }

    }
}