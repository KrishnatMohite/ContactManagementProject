using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataObject
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]      
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Phone Number Should be of 10 digit.")]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }
        [Required]
        public string Status { get; set; }
        public string StatusDesc { get {  return Status == "A" ? "Active":"Inactive"; } }
    }
}
