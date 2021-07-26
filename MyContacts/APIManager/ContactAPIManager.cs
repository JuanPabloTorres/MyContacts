using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MyContacts.APIManager
{
    public class ContactAPIManager
    {

        string Baseurl = "https://localhost:44396/api/";


        public bool CheckUsername(string username)
        {

            bool isChecked = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("Contacts?username=" + username);
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<bool>();

                    isChecked = readTask.Result;
                }
                else
                {
                    return false;
                }
            }


            return isChecked;
        }

        public IList<Contact> GetAllContacts()
        {

            IList<Contact> Contacts;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("Contacts");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Contact>>();

                    Contacts = readTask.Result;


                    return Contacts;
                }
                else
                {
                    return Contacts = new List<Contact>();
                }
            }

        }


        public IList<Contact> GetUser(string username)
        {

            IList<Contact> Contacts;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("Contacts/GetUser?username=" + username);
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Contact>>();

                    Contacts = readTask.Result;


                    return Contacts;
                }
                else
                {
                    return Contacts = new List<Contact>();
                }
            }





        }


        public bool AddNewUser(Contact contact)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Contact>("Contacts", contact);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Contact>();

                    if (readTask.Result != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }


        public Contact GetUserById(int userId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //HTTP POST
                var postTask = client.GetAsync("Contacts?id=" + userId);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Contact>();

                    if (readTask.Result != null)
                    {
                        return readTask.Result;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public bool UpdateUser(Contact uptUser)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<Contact>("Contacts?id=" + uptUser.ContactId.ToString(), uptUser);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Contact>();

                    if (readTask.Result != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteUser(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //HTTP POST
                var postTask = client.DeleteAsync("Contacts?id=" + id);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Contact>();

                    if (readTask.Result != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

    }
}