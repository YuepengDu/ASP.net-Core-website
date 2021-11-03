using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace s3713572_s3698728_a2.Models
{
    public enum TransactionType
    {
        Deposit = 'D',
        Withdraw = 'W',
        Transfer = 'T',
        ServiceCharge = 'S',
        BillPay = 'B'
    };
    public class Transaction
    {

        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }
        [Required, StringLength(1)]
        public TransactionType transactionType{ get; set; }
        [Required]
        public int AccountNumber { get; set; }
        public int DestAccount { get; set; }
        public decimal Amount { get; set; }
        [StringLength(255)]
        public string Comment { get; set; }
        public DateTime ModifyDate { get; set; }
        public virtual Account Account { get; set; }
    }
}
