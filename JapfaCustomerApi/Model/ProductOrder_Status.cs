using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JapfaCustomerApi.Model
{
    public class ProductOrder_Status
    {

        public int Product_id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int QTY { get; set; }

        public int Value { get; set; }

        //public int Order_id { get; set; }

        //public string Status { get; set; }
    }
}
