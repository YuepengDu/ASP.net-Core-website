using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAPI.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Display(Name = "Customer Name")]
        [Required, StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(11)]
        public string TFN { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(40)]
        public string City { get; set; }
        [StringLength(20)]
        [RegularExpression("VIC|NSW|QLD|TAS|WA|SA", ErrorMessage = "Wrong state format.")]
        public string State { get; set; }
        [StringLength(10)]
        [MaxLength(4), MinLength(4)]
        public string PostCode { get; set; }
        [StringLength(15)]
        [RegularExpression(@"^[+61][0-9]{8}$",
         ErrorMessage = "Wrong phone format.")]
        public string Phone { get; set; }
        public virtual List<Account> Accounts { get; set; }
        public virtual Login Login { get; set; }
    }
}
