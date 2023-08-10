using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDetails.Data.db
{
    [Table("Customers", Schema = "Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Surname { get; set; }
        [Required, MaxLength(80)]
        public string Email { get; set; }
        [Required, MaxLength(15)] //Format: xxx xxx xx xx
        public string Phone { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        [MaxLength(11)]
        public string? IdentityNo { get; set; }
        [MaxLength(10)]
        public string? TaxNo { get; set; }
        [MaxLength(30)]
        public string? TaxOffice { get; set; }
        public bool IsActive { get; set; }

        //Foreign Key
        public int? AddressTypeId { get; set; }
        public AddressType AddressType { get; set; }
    }
}
