using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace japfaProject.Models
{
    public class User_Master
    {

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }


        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }


        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        public string CompanyName { get; set; }


        [Required(ErrorMessage = "Contact Number is Required")]
        public string ContactNo { get; set; }


        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }


        [Required(ErrorMessage = "EmailId is Required")]
        //[EmailAddress]
        public string EmailId { get; set; }
        public string GSTNo { get; set; }
        public string PANNo { get; set; }
        public int CustomerId { get; set; }
        public string UserType { get; set; }
        public int VehicleId { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        //public IEnumerable<anyUserType> UserType { get; set; }

        public List<User_Master> objUser { get; set; }
    }
}
