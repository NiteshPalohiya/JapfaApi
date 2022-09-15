using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace japfaProject.Models
{
    public class Customer_Master
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Company Name is Required")]
        public string CompanyName { get; set; }


        [Required(ErrorMessage = "Email is Required")]
        public string EmailAddress { get; set; }
        public string GSTNo { get; set; }
        public string PanNo { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int TDS { get; set; }
        public string SAPCode { get; set; }
        public string StateCode { get; set; }
        public string Password { get; set; }
    }
}
