using JapfaCustomerApi.Data;
using JapfaCustomerApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JapfaCustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private JapfaContext _dbContext;
        public ProductController(JapfaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Product_Master")]
        public ActionResult Product_Master()
        {
            var value = _dbContext.Product_Master.Where(x=>x.Status=="Active").OrderByDescending(x=>x.Productid).ToList();
           
            return Ok(value);
        }

        [HttpGet("Search")]
        public IActionResult searchProduct(int id)
        {
            var emp = _dbContext.Product_Master.Where(model => model.Productid == id).FirstOrDefault();

            return Ok(emp);
        }

        [HttpPost("product_Master")]
        public IActionResult product_Master(Product_MasterModel pmodel)
        {
            Product_Master Pmaster = new Product_Master();
            Pmaster.Productid = pmodel.Productid;
            Pmaster.ProductName = pmodel.ProductName;
            Pmaster.Price = pmodel.Price;
            Pmaster.Status = "Active";
            Pmaster.CreatedBy = 1;
            Pmaster.CreatedDate = DateTime.Now;
            Pmaster.Updatedby = 1;
            Pmaster.Updateddate = DateTime.Now;
            _dbContext.Product_Master.Add(Pmaster);
            _dbContext.SaveChanges();
            
          
            return Ok(pmodel);
        }

        [HttpPut("Product_Master/id")]
        public IActionResult UpdateProduct_Master(Product_MasterModel pmodel)
        {
            Product_Master Pmaster = new Product_Master();
            var customer = _dbContext.Product_Master.Where(x => x.Productid == pmodel.Productid).FirstOrDefault();
            customer.Productid = pmodel.Productid;
            customer.ProductName = pmodel.ProductName;
            customer.Price = pmodel.Price;
            customer.Status = "Active";
            customer.CreatedBy = 1;
            customer.CreatedDate = DateTime.Now;
            customer.Updatedby = 1;
            customer.Updateddate = DateTime.Now;
          
            _dbContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return Ok(pmodel);
        }

        [HttpPost("Delete/Id")]

        public IActionResult Delete(int id)
        {
            Product_Master Pmaster = new Product_Master();
            var customer = _dbContext.Product_Master.Where(x => x.Productid == id).FirstOrDefault();
            customer.Status = "Delete";
          
            _dbContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return Ok(customer);
        }
        //[HttpDelete("DeleteUser/{Id}")]
        //public IActionResult Delete(int Id)
        //{
        //    var users = _dbContext.Product_Master.FirstOrDefault(x => x.Productid == Id);
        //    _dbContext.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        //    _dbContext.SaveChanges();
        //    return Ok();
        //}

     

       
    }
}
