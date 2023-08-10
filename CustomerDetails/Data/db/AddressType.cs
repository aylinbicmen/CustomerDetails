using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDetails.Data.db
{
    [Table("AddressTypes", Schema = "Customer")]
    public class AddressType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
