using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JapfaCustomerApi.Data
{
    public class Place_Order
    {  
        [Key]

        public int Order_id { get; set; }

        //public string ProductName { get; set; }

        public string Price { get; set; }

        public int QTY { get; set; }

        public int Value { get; set; }

        public int ProductId { get; set; }

        public string Status { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Updatedby { get; set; }

        public DateTime Updateddate { get; set; }

       

        

    }
}
