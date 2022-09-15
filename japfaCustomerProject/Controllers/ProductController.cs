using japfaCustomerProject.Models;
using japfaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.WebApi;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace japfaCustomerProject.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult index()
        {
            HttpClient Clint = new HttpClient();
            Product_Master Pmaster = new Product_Master();
            Clint.BaseAddress = new Uri("https://localhost:44345/api/Product/Product_Master");
            var response = Clint.GetAsync(Clint.BaseAddress);
            //     response.Wait();


            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var Display = test.Content.ReadAsAsync<List<Product_Master>>();
                //Display.Wait();
                Pmaster.objProductm = Display.Result;
            }
            return View(Pmaster.objProductm);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Product_Master pmaster)
        {
            if(ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44345/api/Product/product_Master");
                var response = client.PostAsJsonAsync<Product_Master>(client.BaseAddress, pmaster);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View("Create");
        }
     

        [HttpGet]
        public ActionResult Details(int id)
        {
            //Product_Master Master = new Product_Master();
            Product_Master Master = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44345/api/Product/Search?id=" + id.ToString());
            var response = client.GetAsync(client.BaseAddress /*+ "/" + id.ToString()*/);
            response.Wait();

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Product_Master>();
                display.Wait();
                Master = display.Result;
            }
            return View(Master);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpClient Clint = new HttpClient();
            Product_Master pmaster = new Product_Master();
            Clint.BaseAddress = new Uri("https://localhost:44345/api/Product/Search?id=" + id.ToString());
            var response = Clint.GetAsync(Clint.BaseAddress  );
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var Display = test.Content.ReadAsAsync<Product_Master>();
                //Display.Wait();
                pmaster = Display.Result;
            }
            return View(pmaster);
        }

        [HttpPost]
        public ActionResult Edit(Product_Master master)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44345/api/Product/Product_Master/id");
            var response = client.PutAsJsonAsync<Product_Master>(client.BaseAddress, master);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Edit");
        }
 
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Master pmaster = new Product_Master();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44345/api/Product/Delete/Id?id=" + id.ToString());
            var response = client.PostAsJsonAsync(client.BaseAddress,pmaster);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Delete");
           
        }

       

    }
}
