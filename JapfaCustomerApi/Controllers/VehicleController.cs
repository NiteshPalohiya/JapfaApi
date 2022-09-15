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
    public class VehicleController : ControllerBase
    {
        private JapfaContext _dbContext;
        public VehicleController(JapfaContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("Get")]
        public IActionResult VehiclMasterGet()
        {
            var result = _dbContext.Vehicle_Master.Where(x=>x.Status=="Active").OrderByDescending(x=>x.Id).ToList();

            return Ok(result);
        }
        [HttpGet("Search")]
        public IActionResult VehicleMasterSearch(int id)
        {
            var val = _dbContext.Vehicle_Master.Where(x => x.Id == id).FirstOrDefault();
            return Ok(val);
        }

        [HttpPost("Vehicle_Master")]
        public IActionResult VehicalMasterPost(Vehicle_MasterModel VMasterModel)
        {
            Vehicle_Master Vmaster = new Vehicle_Master();

            Vmaster.Id = VMasterModel.Id;
            Vmaster.Code = VMasterModel.Name;
            Vmaster.Name = VMasterModel.Name;
            Vmaster.VehicleNo = VMasterModel.VehicleNo;
            Vmaster.VehicleType = VMasterModel.VehicleType;
            Vmaster.VehicleCapacity = VMasterModel.VehicleCapacity;
            //Vmaster.Status = VMasterModel.Status;
            Vmaster.Status = "Active";
            Vmaster.CreatedBy = 1;
            Vmaster.CreatedDate = DateTime.Now;
            Vmaster.UpdatedBy = 1;
            Vmaster.UpdatedDate = DateTime.Now;
            Vmaster.UserId = VMasterModel.UserId;
            _dbContext.Vehicle_Master.Add(Vmaster);

            _dbContext.SaveChanges();
            return Ok(VMasterModel);
        }
        [HttpPut("Update/id")]
        public IActionResult VehicleMasterEdit(Vehicle_MasterModel Vmodel)
        {
            Vehicle_Master Vmaster = new Vehicle_Master();
            var value = _dbContext.Vehicle_Master.Where(x => x.Id == Vmodel.Id).FirstOrDefault();
            value.Id = Vmodel.Id;
            value.Code = Vmodel.Name;
            value.Name = Vmodel.Name;
            value.VehicleNo = Vmodel.VehicleNo;
            value.VehicleType = Vmodel.VehicleType;
            value.VehicleCapacity = Vmodel.VehicleCapacity;
            value.Status = "Active";
            value.CreatedBy = 1;
            value.CreatedDate = DateTime.Now;
            value.UpdatedBy = 1;
            value.UpdatedDate = DateTime.Now;
            value.UserId = Vmodel.UserId;

            _dbContext.Entry(value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return Ok(Vmodel);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult VehicleMasterDelete(int id)
        {
            Vehicle_Master Vmaster = new Vehicle_Master();
            var value = _dbContext.Vehicle_Master.Where(x => x.Id == id).FirstOrDefault();
            //value.Id = Vmodel.Id;
            //value.Code = Vmodel.Name;
            //value.Name = Vmodel.Name;
            //value.VehicleNo = Vmodel.VehicleNo;
            //value.VehicleType = Vmodel.VehicleType;
            //value.VehicleCapacity = Vmodel.VehicleCapacity;
            value.Status = "Delete";
            //value.CreatedBy = 1;
            //value.CreatedDate = DateTime.Now;
            //value.UpdatedBy = 1;
            //value.UpdatedDate = DateTime.Now;
            //value.UserId = Vmodel.UserId;

            _dbContext.Entry(value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return Ok(Vmaster);
        }


        //[HttpDelete("Delete/{id}")]
        //public IActionResult DeleteVehicleMaster(int id)
        //{
        //    var val = _dbContext.Vehicle_Master.FirstOrDefault(x => x.Id == id);
        //    _dbContext.Entry(val).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        //    _dbContext.SaveChanges();
        //    return Ok();
        //}

    }
}
