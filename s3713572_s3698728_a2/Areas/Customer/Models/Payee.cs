using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s3713572_s3698728_a2.Models
{
    public class Payee
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PayeeID { get; set; }
        [Required, StringLength(50)]
        public string PayeeName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(40)]
        public string City { get; set; }
        [StringLength(20)]
        [RegularExpression("VIC|NSW|QLD|TAS|WA|SA", ErrorMessage = "Wrong state format.")]
        public string State { get; set; }
        [StringLength(10)]
        [RegularExpression(@"^\d{4}$")]
        public string PostCode { get; set; }
        [StringLength(15)]
        [DisplayFormat(DataFormatString = "{61:####-####}")]
        public string Phone { get; set; }
        public virtual List<BillPay> BillPays { get; set; }
        
    }
}
