using JapfaCustomerApi.Data;
using JapfaCustomerApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JapfaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Place_OrderController : ControllerBase
    {

        private JapfaContext _dbContext;
        public Place_OrderController(JapfaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Get")]

        public IActionResult Place_Order()
        {
            
            var val = _dbContext.Place_Order.Where(x=>x.Status=="Active").ToList();
            return Ok(val);
        }


        [HttpPost("Post")]
        public IActionResult PlaceOrder(Place_OrderModel PModel)
        {
            Place_Order POrder = new Place_Order();
            POrder.Order_id = PModel.Order_id;
            POrder.ProductId = PModel.ProductId;
            POrder.Price = PModel.Price;
            POrder.QTY = PModel.QTY;
            POrder.Value = PModel.Value;
            POrder.Status = "Active";
            POrder.Updatedby = 1;
            POrder.Updateddate = DateTime.Now;
            POrder.CreatedBy = 1;
            POrder.CreatedDate = DateTime.Now;

            _dbContext.Place_Order.Add(POrder);
            _dbContext.SaveChanges();
            return Ok(PModel);
        }

        [HttpGet("searchOrder")]
        public IActionResult searchPlaceOrder(string Name)
        {

            var order =
                   from pm in _dbContext.Product_Master
                   join po in _dbContext.Place_Order on pm.Productid equals po.ProductId
                   where pm.ProductName.StartsWith(Name)
                   select new ProductOrder_Status
                   {
                       ProductName = pm.ProductName,
                       Price = pm.Price,
                       //Status = po.Status,
                       Product_id = pm.Productid,
                       //Order_id = po.Order_id,
                       QTY = po.QTY,
                       Value = po.Value

                   };
            return Ok(order);
        }

    }
}
