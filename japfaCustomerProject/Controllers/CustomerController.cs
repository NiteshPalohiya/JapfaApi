using japfaCustomerProject.Models;
using japfaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace japfaProject.Controllers
{
    public class CustomerController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Customer_Master> cmaster = new List<Customer_Master>();
            client.BaseAddress = new Uri("https://localhost:44345/api/Customer/Get");
            var response = client.GetAsync(client.BaseAddress);

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var dispaly = test.Content.ReadAsAsync<List<Customer_Master>>();
                cmaster = dispaly.Result;
            }
            return View(cmaster);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer_Master cmaster)
        {
            if(ModelState.IsValid)
            {
                client.BaseAddress = new Uri("https://localhost:44345/api/Customer/Insert");
                var response = client.PostAsJsonAsync(client.BaseAddress, cmaster);

                var test = response.Result;



                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            
            return View();

        }

        [HttpGet]
        public ActionResult Details(string FirstName)
        {
            Customer_Master cmaster = new Customer_Master();
            client.BaseAddress = new Uri("https://localhost:44345/api/Customer/Search?name=" + FirstName);
            var response = client.GetAsync(client.BaseAddress);

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Customer_Master>();
                cmaster = display.Result;
            }
            return View(cmaster);
        }

        [HttpGet]
        public ActionResult Edit(string FirstName)
        {
            Customer_Master cmaster = new Customer_Master();
            client.BaseAddress = new Uri(" https://localhost:44345/api/Customer/Search?name=" + FirstName);
            var response = client.GetAsync(client.BaseAddress);

            var test = response.Result;

            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Customer_Master>();
                cmaster = display.Result; 
            }
            return View(cmaster);
        }

        [HttpPost]
        public ActionResult Edit(Customer_Master cmaster)
        {
            client.BaseAddress = new Uri("https://localhost:44345/api/Customer/Update/id");
            var response = client.PutAsJsonAsync(client.BaseAddress, cmaster);
            var test = response.Result;

            if(test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Customer_Master cmaster = new Customer_Master();
            client.BaseAddress = new Uri("https://localhost:44345/api/Customer/Delete" );
            var val = client.PostAsJsonAsync(client.BaseAddress + "/" + id.ToString(), cmaster);
            var test = val.Result;

            if(test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult GetOrder()
        {
            List<Product_Master> pmaster = new List<Product_Master>();
            ViewBag.list = pmaster;
            client.BaseAddress = new Uri("https://localhost:44345/api/Product/Product_Master");
            var response = client.GetAsync(client.BaseAddress);

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var dispaly = test.Content.ReadAsAsync<List<Product_Master>>();
                pmaster = dispaly.Result;
            }
            

            return View(pmaster);
           
        }

        public ActionResult _PartialView()
        {
            return View();
        }


        [HttpPost]
        public ActionResult _PartialView(Place_Order porder)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44345/api/Product/Place_Order");
                var response = client.PostAsJsonAsync<Place_Order>(client.BaseAddress, porder);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }

            return View();

        }
    }
}
