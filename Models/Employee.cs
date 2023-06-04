using System.ComponentModel.DataAnnotations.Schema;

namespace MortgageAutomation.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeerName { get; set; }
        public string Payslip { get; set; }
        
    }
}
