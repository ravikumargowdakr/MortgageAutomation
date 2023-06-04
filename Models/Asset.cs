using System.ComponentModel.DataAnnotations.Schema;

namespace MortgageAutomation.Models
{
    [Table("Asset")]
    public class Asset
    {
        public int Id { get; set; }
        public string AssetType { get; set; }
        public double AssetValue { get; set; }
    }
}
