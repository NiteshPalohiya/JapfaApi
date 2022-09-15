using JapfaApi.Data;
using JapfaApi.Model;
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
    public class CustomerController : ControllerBase
    {
        private JapfaContext _dbContext;
        public CustomerController(JapfaContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("Get")]
        public IActionResult GetCustomer()
        {
            var value = _dbContext.Customer_Master.Where(x=>x.Status=="Active").OrderByDescending(x=>x.Id).ToList();
            return Ok(value);
        }
        [HttpGet("Search")]
        public IActionResult SearchCustomer(string name)
        {
            var val = _dbContext.Customer_Master.Where(x => x.FirstName.StartsWith(name)).FirstOrDefault();
            return Ok(val);
        }
        [HttpPost("Insert")]
        public IActionResult InsertCustomer(Customer_MasterModel Cmodel)
        {
            Customer_Master Cmaster = new Customer_Master();
            Cmaster.Id = Cmodel.Id;
            Cmaster.FirstName = Cmodel.FirstName;
            Cmaster.LastName = Cmodel.LastName;
            Cmaster.CompanyName = Cmodel.CompanyName;
            Cmaster.EmailAddress = Cmodel.EmailAddress;
            Cmaster.GSTNo = Cmodel.GSTNo;
            Cmaster.PanNo = Cmodel.PanNo;
            Cmaster.ContactNo = Cmodel.ContactNo;
            Cmaster.Address = Cmodel.Address;
            Cmaster.Status = "Active";
            Cmaster.CreatedBy = 1;
            Cmaster.CreatedDate = DateTime.Now;
            Cmaster.UpdatedBy = 1;
            Cmaster.UpdatedDate = DateTime.Now;
            Cmaster.TDS = Cmodel.TDS;
            Cmaster.SAPCode = Cmodel.SAPCode;
            Cmaster.StateCode = Cmodel.StateCode;
            Cmaster.Password = Cmodel.Password;
            _dbContext.Customer_Master.Add(Cmaster);
            _dbContext.SaveChanges();
            return Ok(Cmodel);
        }

        [HttpPut("Update/id")]
        public IActionResult EditCustomer(Customer_MasterModel cmodel)
        {
            var value = _dbContext.Customer_Master.Where(x => x.Id == cmodel.Id).FirstOrDefault();
            value.Id = cmodel.Id;
            value.FirstName = cmodel.FirstName;
            value.LastName = cmodel.LastName;
            value.CompanyName = cmodel.CompanyName;
            value.EmailAddress = cmodel.EmailAddress;
            value.GSTNo = cmodel.GSTNo;
            value.PanNo = cmodel.PanNo;
            value.ContactNo = cmodel.ContactNo;
            value.Address = cmodel.Address;
            value.Status = "Active";
            value.CreatedBy = 1;
            value.CreatedDate = DateTime.Now;
            value.UpdatedBy = 1;
            value.UpdatedDate = DateTime.Now;
            value.TDS = cmodel.TDS;
            value.SAPCode = cmodel.SAPCode;
            value.StateCode = cmodel.StateCode;
            value.Password = cmodel.Password;

            _dbContext.Entry(value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return Ok(cmodel);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var val = _dbContext.Customer_Master.Where(x => x.Id == id).FirstOrDefault();
            val.Status = "Delete";
            _dbContext.Entry(val).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return Ok(val);
        }

       



        [HttpGet("OrderStatus/{Name}")]
        public IActionResult OrderStatus(string Name = "-")
        {
            var order =
                 from pm in _dbContext.Product_Master
                 join po in _dbContext.Place_Order on pm.Productid equals po.ProductId
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

            if (Name != "-")
            {
                order =
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
            }
            return Ok(order);
        }

        [HttpGet("Summary/{id}")]
        public IActionResult Summary(int id)
        {
            var obj = from pm in _dbContext.Product_Master
                      join po in _dbContext.Place_Order on pm.Productid equals po.ProductId
                      where pm.Productid == id
                      select new SummaryModel
                      {
                          Product_id = po.ProductId,
                          ProductName = pm.ProductName,
                          Value = po.Value,
                          QTY = po.QTY
                      };
            return Ok(obj);
        }
    }
}
