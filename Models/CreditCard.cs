using System.ComponentModel.DataAnnotations.Schema;

namespace MortgageAutomation.Models
{
    [Table("CreditCard")]
    public class CreditCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string ExpireyDate { get; set; }
    }
}
