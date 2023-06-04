using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MortgageAutomation.Models
{
    [Table("Property")]
    public class Property
    {
        [Key] public int AppId { get; set; }
        public double PropertyValue { get; set; }
        public double ExpectedLoan { get; set; }
        public string PropertyAddress { get; set; }
        public int CibilScore { get; set; }
        public string LawyerStatus { get; set; }
        public string DateApplied { get; set; }
    }
}
