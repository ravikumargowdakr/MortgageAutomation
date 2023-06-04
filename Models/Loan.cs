using System.ComponentModel.DataAnnotations.Schema;

namespace MortgageAutomation.Models
{
    [Table("Loan")]
    public class Loan
    {
        public int Id { get; set; }
        public string LoanType { get; set; }
        public double LoanAmount { get; set; }
    }
}
