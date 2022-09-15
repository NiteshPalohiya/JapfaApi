using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace japfaProject.Models
{
    public class Vehicle_Master
    {
        [Key]
        public int Id { get; set; }

        public string UserType { get; set; }

        public string Code { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Vehicle Number is Required")]
        public string VehicleNo { get; set; }
       
        public string VehicleType { get; set; }
        [Required(ErrorMessage ="VehicleSpace Capacity is Required")]
        public string VehicleCapacity { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }

        //public string User Type { get; set; }
        public List<Vehicle_Master> objVehicle { get; set; }

    }
}
