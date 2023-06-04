using System.ComponentModel.DataAnnotations.Schema;

namespace MortgageAutomation.Models
{
    [Table("Address")]
    public class Address
    {
        public int Id { get; set; }
        public string CurrentAddress { get;set; }
        public string PermanentAddress { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
    }
}
