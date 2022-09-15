using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JapfaCustomerApi.Model
{

    public class SummaryModel
    {
       
        public int Product_id { get; set; }

        public string ProductName { get; set; }

        public int Value { get; set; }

        public int QTY { get; set; }


    }
}
