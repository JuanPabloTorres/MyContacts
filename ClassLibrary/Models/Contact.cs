using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    class Contact
    {

        public int ContactId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public DateTime LastUpdateUserName { get; set; }

    }
}
