using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MortgageAutomation.Models
{
    [Table("PersonalDetails")]
    public class PersonalDetails
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public string ApplicantName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public int Dependencies { get; set; }
    }
}
