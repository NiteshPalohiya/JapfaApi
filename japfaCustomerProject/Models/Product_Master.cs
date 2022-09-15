using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace japfaCustomerProject.Models
{
    public class Product_Master
    {
        [Key]
        public int Productid { get; set; }


        [Required(ErrorMessage = "Product Name is Required") ]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Updatedby { get; set; }
        public DateTime Updateddate { get; set; }

        public List<Product_Master> objProductm { get; set; } 
        //public IEnumerable<Product_Master> objPlist { get; set; }

    }
}
