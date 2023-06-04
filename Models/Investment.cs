using System.ComponentModel.DataAnnotations.Schema;

namespace MortgageAutomation.Models
{
    [Table("Investment")]
    public class Investment
    {
        public int Id { get; set; }
        public string InvestmentType { get; set; }
        public double Amount { get; set; }  

    }
}
