using Library.Models;
using MyContacts.APIManager;
using MyContacts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyContacts.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {

            var ContactAPIManager = new ContactAPIManager();

            var results = ContactAPIManager.GetAllContacts();


            return View(results);
        }


        public ActionResult Search(string searchText)
        {

            var ContactAPIManager = new ContactAPIManager();

            if (!string.IsNullOrEmpty(searchText))
            {


                var results = ContactAPIManager.GetUser(searchText);

                if (results.Count > 0)
                {
                    return View("Index", results);

                }
                else
                {

                    return View("Index", ContactAPIManager.GetAllContacts());
                }

            }
            else
            {


                var results = ContactAPIManager.GetAllContacts();

                return View("Index", results);
            }

        }



        public ActionResult AddNew()
        {

            return View(new ContactViewModel());
        }

        [HttpPost]
        public ActionResult AddNew(ContactViewModel contactViewModel)
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
                return PartialView("_AddNewPartial", contactViewModel);

            }


        }



        public ActionResult Edit(string id)
        {
            var ContactAPIManager = new ContactAPIManager();


            int userId = Convert.ToInt32(id);

            var results = ContactAPIManager.GetUserById(userId);


            var contacVm = new ContactViewModel()
            {
                ContactId = results.ContactId,
                Email = results.Email,
                Fax = results.Fax,
                LastUpdateDate = results.LastUpdateDate,
                LastUpdateUserName = results.LastUpdateUserName,
                Name = results.Name,
                Notes = results.Notes,
                Phone = results.Phone
            };

            return PartialView("_EditPartial", contacVm);
            //return View(contacVm);
        }


        [HttpPost]
        public ActionResult Edit(ContactViewModel contactViewModel)
        {
            var ContactAPIManager = new ContactAPIManager();

            if (ModelState.IsValid)
            {



                var uptContact = new Contact()
                {
                    ContactId = contactViewModel.ContactId,
                    Email = contactViewModel.Email,
                    Fax = contactViewModel.Fax,
                    LastUpdateDate = DateTime.Now,
                    LastUpdateUserName = DateTime.Now,
                    Name = contactViewModel.Name,
                    Notes = contactViewModel.Notes,
                    Phone = contactViewModel.Phone
                };


                var results = ContactAPIManager.UpdateUser(uptContact);


                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.Id = contactViewModel.ContactId;

                ViewBag.EditIsNotValid = false;

                ViewBag.EditValue = contactViewModel;


                var results = ContactAPIManager.GetAllContacts();


                return PartialView("_EditPartial", contactViewModel);

                // return View("Index", results);

            }

        }


        public ActionResult Delete(string id)
        {
            var ContactAPIManager = new ContactAPIManager();


            var isDeleted = ContactAPIManager.DeleteUser(id);



            return RedirectToAction("Index");
        }
    }
}