using System.ComponentModel.DataAnnotations.Schema;

namespace MortgageAutomation.Models
{
    [Table("IdentityProof")]
    public class IdentityProof
    {
        public int Id { get; set; }
        public string IdentityType { get; set; }
        public string IdentityNumber { get; set; }
    }
}
