using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models
{
    public class Login
    {
        [Key, Required, StringLength(8)]
        public string LoginID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required, StringLength(64)]
        public string PasswordHash { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
        public virtual Customer Customer { get; set; }
        public bool Lock { get; set; }
        public DateTime LockDate { get; set; }
    }
}
