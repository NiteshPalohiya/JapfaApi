using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JapfaApi.Data
{
    public class Vehicle_Master
    {
        [Key]
        public int Id { get; set; }
       
        public string Code { get; set; }
       
        public string Name { get; set; }
        
        public string VehicleNo { get; set; }
        
        public string VehicleType { get; set; }
      
        public string VehicleCapacity { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }

    }
}
