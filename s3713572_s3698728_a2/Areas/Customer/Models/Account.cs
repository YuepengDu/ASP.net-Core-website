using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace s3713572_s3698728_a2.Models
{
    public enum AccountType
    {
        Checking = 'C',
        Saving = 'S'
    }
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Account Number")]
        [Required]
        public int AccountNumber { get; set; }

        [Display(Name = "Type")]
        [Required]
        public AccountType AccountType { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
        public virtual List<BillPay> BillPay { get; set; }

    }
}
