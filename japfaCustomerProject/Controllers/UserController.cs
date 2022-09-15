using japfaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace japfaProject.Controllers
{
    public class UserController : Controller
    {
        HttpClient Client = new HttpClient();
        public ActionResult Index2()

        {
            User_Master Umaster = new User_Master();
            //List<User_Master> list = new List<User_Master>();
            Client.BaseAddress = new Uri("https://localhost:44345/api/UserMaster/Get");
            var response = Client.GetAsync(Client.BaseAddress);

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<User_Master>>();
                Umaster.objUser = display.Result;
            }
            return View(Umaster.objUser);
        }
        [HttpGet]
        public ActionResult Details(string FirstName)
        {
            User_Master umaster = null;
            Client.BaseAddress = new Uri("https://localhost:44345/api/UserMaster/Search?name=" + FirstName);
            var rsponse = Client.GetAsync(Client.BaseAddress );
            var test = rsponse.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<User_Master>();
                umaster = display.Result;
            }
            return View(umaster);
        }
        public ActionResult Create()
        {
            //var list = new List<string>() { "Admin", "Production Team", "Dispatch Team", "Delevery Boy" };
            //ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Create(User_Master umaster)
        {
            if (ModelState.IsValid)
            {
                Client.BaseAddress = new Uri("https://localhost:44345/api/UserMaster/Post");
                var val = Client.PostAsJsonAsync(Client.BaseAddress, umaster);
                var test = val.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index2");
                }
            }

            return View();
        }
        
        [HttpGet]
        public ActionResult Edit(string FirstName)
        {
            User_Master Umaster = new User_Master();
            Client.BaseAddress = new Uri("https://localhost:44345/api/UserMaster/Search?name=" + FirstName);
            var val = Client.GetAsync(Client.BaseAddress);
            var test = val.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<User_Master>();
                Umaster = display.Result;
            }
            return View(Umaster);
        }
        [HttpPost]
        public ActionResult Edit(User_Master umaster)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/UserMaster/Update/id");
            var val = Client.PutAsJsonAsync<User_Master>(Client.BaseAddress, umaster);
            var test = val.Result;
            if(test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index2");
            }

            return View("Edit");
        }
       
        public ActionResult Delete(int id)
        {
            User_Master umaster = new User_Master();
            Client.BaseAddress = new Uri("https://localhost:44345/api/UserMaster/Delete");
            var response = Client.PostAsJsonAsync(Client.BaseAddress + "/" + id.ToString(), umaster);
            response.Wait();
            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index2");
            }
            return View("Index2");
        }
    }
}
