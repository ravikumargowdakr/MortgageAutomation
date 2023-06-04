using System.ComponentModel.DataAnnotations.Schema;

namespace MortgageAutomation.Models
{
    [Table("Income")]
    public class Income
    {
        public int Id { get; set; }
        public string PrimaryIncomeType { get; set; }
        public double PrimaryIncome { get; set; }
        public string SecondaryIncomeType { get; set; }
        public double SecondaryIncome { get; set; }
        public string DocumentNumber { get; set; }
    }
}
