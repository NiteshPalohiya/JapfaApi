using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JapfaCustomerApi.Model
{
    public class Product_MasterModel
    {
        [Key]
        public int Productid { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Updatedby { get; set; }

        public DateTime Updateddate { get; set; }
    }
}
