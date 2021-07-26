using Library.Models;
using MyContacts.APIManager;
using MyContacts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyContacts.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {

            var newLogin = new LoginViewModel();


            return View(newLogin);
        }

        [HttpPost]

        public ActionResult Index(LoginViewModel loginViewModel)
        {


            if (ModelState.IsValid)
            {


                var API = new ContactAPIManager();

                var result = API.CheckUsername(loginViewModel.Username);

                if (result)
                {

                    Session["username"] = loginViewModel.Username;
                    FormsAuthentication.SetAuthCookie(loginViewModel.Username, false);
                    return RedirectToAction("Index", "Contact");
                }
                else
                {

                    ModelState.AddModelError("", "Invalid Username...!");
                    return View(loginViewModel);
                }

            }
            else
            {
                return View(loginViewModel);
            }




        }


        public ActionResult Exit()
        {

            Session["username"] = null; //it's my session variable

            Session.Clear();

            Session.Abandon();

            FormsAuthentication.SignOut();

            return View("Index");
        }



        [HttpPost]
        public ActionResult RegisterNew(ContactViewModel contactViewModel)
        {
            var ContactAPIManager = new ContactAPIManager();

            if (ModelState.IsValid)
            {



                var newContact = new Contact()
                {

                    Email = contactViewModel.Email,
                    Fax = contactViewModel.Fax,
                    LastUpdateDate = DateTime.Now,
                    LastUpdateUserName = DateTime.Now,
                    Name = contactViewModel.Name,
                    Notes = contactViewModel.Notes,
                    Phone = contactViewModel.Phone
                };


                var results = ContactAPIManager.AddNewUser(newContact);


                return RedirectToAction("Index");
            }
            else
            {

                return PartialView("_RegisterPartial", contactViewModel);





            }


        }


    }
}