using JapfaApi.Data;
using JapfaApi.Model;
using JapfaCustomerApi.Data;
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
    public class UserMaster : ControllerBase
    {
        private JapfaContext _dbContext;
        public UserMaster(JapfaContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("Get")]
        public IActionResult GetUser()
        {
            //var result = _dbContext.User_Master.Where(x => x.Status == "Active").ToList();
            var result = _dbContext.User_Master.Where(x => x.Status == "Active").OrderByDescending(x=>x.Id).ToList();
            //_dbContext.User_Master.OrderByDescending(x => x.FirstName).ToList();
            return Ok(result);
        }

        [HttpPost("Post")]
        public IActionResult InsertUser(User_MasterModel UModel)
        {
            User_Master umaster = new User_Master();

            umaster.Id = UModel.Id;
            umaster.UserName = UModel.UserName;
            umaster.Password = UModel.Password;
            umaster.FirstName = UModel.FirstName;
            umaster.LastName = UModel.LastName;
            umaster.CompanyName = UModel.CompanyName;
            umaster.ContactNo = UModel.ContactNo;
            umaster.Address = UModel.Address;
            umaster.EmailId = UModel.EmailId;
            umaster.GSTNo = UModel.GSTNo;
            umaster.PANNo = UModel.PANNo; ;
            umaster.CustomerId = UModel.CustomerId;
            umaster.UserType = UModel.UserType;
            umaster.VehicleId = UModel.VehicleId;
            umaster.Status = "Active";
            umaster.CreatedBy = 1;
            umaster.CreatedDate = DateTime.Now;
            umaster.UpdatedBy = 1;
            umaster.UpdatedDate = DateTime.Now;

            _dbContext.User_Master.Add(umaster);
            _dbContext.SaveChanges();
            return Ok(UModel);
        }
        [HttpGet("Search")]
        public IActionResult SearchUser(string name)
        {
            User_Master umaster = new User_Master();
            //umaster = _dbContext.User_Master.Where(x => x.FirstName.StartsWith(name)).FirstOrDefault();
            umaster = _dbContext.User_Master.Where(x => x.FirstName == name).FirstOrDefault();
           
            return Ok(umaster);
        }

        [HttpPut("Update/id")]
        public IActionResult UpdateUser(User_MasterModel umodel)
        {
            var value = _dbContext.User_Master.Where(x => x.Id == umodel.Id).FirstOrDefault();
            value.Id = umodel.Id;
            value.UserName = umodel.UserName;
            value.Password = umodel.Password;
            value.FirstName = umodel.FirstName;
            value.LastName = umodel.LastName;
            value.CompanyName = umodel.CompanyName;
            value.ContactNo = umodel.ContactNo;
            value.Address = umodel.Address;
            value.EmailId = umodel.EmailId;
            value.GSTNo = umodel.GSTNo;
            value.PANNo = umodel.PANNo;
            value.CustomerId = umodel.CustomerId;
            value.UserType = "AU";
            value.VehicleId = umodel.VehicleId;
            value.Status = "Active";
            value.CreatedBy = 1;
            value.CreatedDate = DateTime.Now;
            value.UpdatedBy = 1;
            value.UpdatedDate = DateTime.Now;

            _dbContext.Entry(value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();

            return Ok(umodel);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var val = _dbContext.User_Master.Where(x => x.Id == id).FirstOrDefault();
            val.Status = "Delete";
            _dbContext.Entry(val).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return Ok(val);
        }
    }
}
