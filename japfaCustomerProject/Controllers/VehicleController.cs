using japfaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace japfaProject.Controllers
{
    public class VehicleController : Controller
    {
        HttpClient Client = new HttpClient();
        public ActionResult Index()
        {
            Vehicle_Master Vmaster = new Vehicle_Master();
            Client.BaseAddress = new Uri("https://localhost:44345/api/Vehicle/Get");
            var response = Client.GetAsync(Client.BaseAddress);
            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Vehicle_Master>>();
                Vmaster.objVehicle = display.Result;
            }
            return View(Vmaster.objVehicle);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Vehicle_Master master = null;
            Client.BaseAddress = new Uri("https://localhost:44345/api/Vehicle/Search?id=" + id.ToString());
            var respone = Client.GetAsync(Client.BaseAddress);
           // respone.Wait();
            var test = respone.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Vehicle_Master>();
                master = display.Result;
            }
                                
            return View(master);
        }

        
        public ActionResult Create()
        {
            var list = new List<string>() { "Truck", "Pickup", "Mini Truck" };
            ViewBag.list = list;

            //var list2 = new List<string>() { "Admin", "Production Team", "Dispatch Team","Delevery Team" };
            //ViewBag.list2 = list2;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vehicle_Master vmaster)
        {
           //if(ModelState.IsValid)
           // {
                Client.BaseAddress = new Uri("https://localhost:44345/api/Vehicle/Vehicle_Master");
                var Response = Client.PostAsJsonAsync(Client.BaseAddress, vmaster);
              
                var test = Response.Result;

                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            //}
             
            return View();
              
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var list2 = new List<string>() { "Truck", "Pickup", "Mini Truck" };
            ViewBag.list2 = list2;
            Vehicle_Master vmaster = new Vehicle_Master();
            Client.BaseAddress = new Uri("https://localhost:44345/api/Vehicle/Search?id=" + id.ToString());
            var response = Client.GetAsync(Client.BaseAddress);
            response.Wait();

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Vehicle_Master>();
                vmaster = display.Result;

            }
            return View(vmaster);
        }
        [HttpPost]
        public ActionResult Edit(Vehicle_Master Vmaster)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/Vehicle/Update/id");
            var response = Client.PutAsJsonAsync<Vehicle_Master>(Client.BaseAddress, Vmaster);

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
       
        public ActionResult DeleteConfirmed(int id)
        {
            //HttpClient client = new HttpClient();
            Vehicle_Master vmaster = new Vehicle_Master();
            Client.BaseAddress = new Uri("https://localhost:44345/api/Vehicle/Delete");
            var response = Client.PostAsJsonAsync(Client.BaseAddress + "/" + id.ToString(), vmaster);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return Json(new { success = false, responseText = "Success" });
            }
            return Json(new { success = false, responseText = "Success" });

        }

        //public ActionResult Delete(int Id)
        //{
        //    Vehicle_Master v = new Vehicle_Master();
        //    //HttpClient client = new HttpClient();
        //    Client.BaseAddress = new Uri("https://localhost:44345/api/Vehicle_Master/Search?id=" + Id.ToString());
        //    var response = Client.GetAsync(Client.BaseAddress );
        //    response.Wait();
        //    var test = response.Result;
        //    if (test.IsSuccessStatusCode)
        //    {
        //        var display = test.Content.ReadAsAsync<Vehicle_Master>();
        //        display.Wait();
        //        v = display.Result;
        //    }
        //    return View(v);

        //}

    }
}
