using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace japfaProject.Models
{
    public class Place_Order
    {
        public List<Place_Order> plist { get; set; }

        [Key]
        public int Order_id { get; set; }

        [Required]
        public int QTY { get; set; }

        public string ProductName { get; set; }

        public int Value { get; set; }

        public int Productid { get; set; }

        public string Status { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Updatedby { get; set; }

        public DateTime Updateddate { get; set; }
        [Required]
       
        
        public string Price { get; set; }


    }

    public class PlaceOrderpost
    {
        public string Order_id { get; set; }
        public string ProductId { get; set; }
        public string Price { get; set; }
        public string QTY { get; set; }

        
    }
   
}
