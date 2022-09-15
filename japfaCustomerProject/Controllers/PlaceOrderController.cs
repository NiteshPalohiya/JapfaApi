using japfaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace japfaProject.Controllers
{
    public class PlaceOrderController : Controller
    {
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            List<Place_Order> porder = new List<Place_Order>();
            client.BaseAddress = new Uri("https://localhost:44345/api/Product/Product_Master");
            var response = client.GetAsync(client.BaseAddress);

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var dispaly = test.Content.ReadAsAsync<List<Place_Order>>();
                porder = dispaly.Result;
            }
            return View(porder);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create([FromBody] List<PlaceOrderpost> Porder)
        
        {
            Place_Order obj = new Place_Order();
            ////var model = JsonConvert.DeserializeObject<List<Place_Order>>(Porder);
            for(int i= 0; i < Porder.Count(); i++)
            {
                var pid = Porder[i].ProductId;
                var oid = Porder[i].Order_id;
                var qty = Porder[i].QTY;
                var price = Porder[i].Price;

                //var pid = item.ProductId;
                //var oid = item.Order_id;
                //var qty = item.QTY;
                //var price = item.Price;

                obj.Productid =Convert.ToInt32(pid);
                obj.Order_id =Convert.ToInt32(oid);
                obj.QTY = Convert.ToInt32(qty);
                obj.Price = price;
             
            }

            client.BaseAddress = new Uri("https://localhost:44345/api/Place_Order/Post");
            var response = client.PostAsJsonAsync(client.BaseAddress, Porder);

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Create");
            }

            return Json(Porder);
        }
    }
}
