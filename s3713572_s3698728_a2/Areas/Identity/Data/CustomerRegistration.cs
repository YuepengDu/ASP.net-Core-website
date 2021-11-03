using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace s3713572_s3698728_a2.Areas.Identity.Data
{
    public class CustomerRegistration : IdentityUser
    {
        [Key, Required, StringLength(8)]
        [DataType(DataType.Text)]
        public string LoginID { get; set; }

        [Required, StringLength(4)]
        [DataType(DataType.Text)]
        public int CustomerID { get; set; }

        [DataType(DataType.Password)]
        [Required, StringLength(64)]
        public string PasswordHashRegistration { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailRegistration { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public DateTime ModifyDate { get; set; }

        [Display(Name = "Customer Name")]
        [Required, StringLength(50)]
        [DataType(DataType.Text)]
        public string CustomerName { get; set; }
        [StringLength(11)]
        [DataType(DataType.Text)]
        public string TFN { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Address { get; set; }
        [StringLength(40)]
        [DataType(DataType.Text)]
        public string City { get; set; }
        [StringLength(20)]
        [DataType(DataType.Text)]
        [RegularExpression("VIC|NSW|QLD|TAS|WA|SA", ErrorMessage = "Wrong state format.")]
        public string State { get; set; }
        [StringLength(10)]
        [DataType(DataType.Text)]
        [MaxLength(4), MinLength(4)]
        public string PostCode { get; set; }
        [Required, StringLength(15)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[61][0-9]{8}$",
         ErrorMessage = "Wrong phone format.")]
        public string Phone { get; set; }
    }
}
