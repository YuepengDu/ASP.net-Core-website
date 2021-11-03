using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s3713572_s3698728_a2.Models
{
    public enum Period
    {
        Monthly = 'M',
        Quarterly = 'Q',
        Once_Off = 'S'
    }
    public class BillPay
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int BillPayId { get; set; }
        [Display(Name = "Account Number")]
        [Required]
        public int AccountNumber { get; set; }
        [Display(Name = "Type")]
        [Required]
        public int PayeeID  { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }
        [Required]
        public DateTime ScheduleDate { get; set; }
        [Required]
        public Period Period { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
        public bool Block { get; set; }

        public virtual Payee Payee { get; set; }
        public virtual Account Account { get; set; }
    }
}
