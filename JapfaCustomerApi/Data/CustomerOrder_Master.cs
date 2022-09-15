using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JapfaApi.Data
{
    public class CustomerOrder_Master
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
