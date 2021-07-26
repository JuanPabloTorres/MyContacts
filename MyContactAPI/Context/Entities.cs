using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

using Library.Models;





namespace MyContactAPI.Context
{
    public class Entities : DbContext
    {


        public Entities() : base("name=MyContactDb")
        {


        }

        public DbSet<Contact> Contacts { get; set; }




    }
}