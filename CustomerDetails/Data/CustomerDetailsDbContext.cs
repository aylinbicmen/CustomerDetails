using CustomerDetails.Data.db;
using Microsoft.EntityFrameworkCore;

namespace CustomerDetails.Data
{
    public class CustomerDetailsDbContext : DbContext
    {
        public CustomerDetailsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        //Dbsets
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }

        //Test verisi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Department
            modelBuilder.Entity<AddressType>()
                        .HasData(
                         new AddressType { Id = 1, Type = "Bireysel" },
                         new AddressType { Id = 2, Type = "Kurumsal" });

            
            modelBuilder.Entity<Customer>()
                        .HasData(
                         new Customer { Id = 1, Name = "Ece", Surname = "Akyürek", Email = "ece.akyurek@gmail.com", Phone = "5322262496", BirthDate = new DateTime(1985,4,29), Address = "Yedi Eylül Mah. Efeler/Aydın", AddressTypeId = 1, IdentityNo = "18015526289", IsActive = true },
                         new Customer { Id = 2, Name = "Atakan", Surname = "Ozansoy", Email = "atakan-ozansoy@gmail.com", Phone = "5333441212", BirthDate = new DateTime(1972, 12, 1), Address = "Kazım Özalp Sok. Kadıköy/İstanbul", AddressTypeId = 2, TaxNo = "5421977337",TaxOffice = "Kadıköy" , IsActive = true },
                         new Customer { Id = 3, Name = "Tuna", Surname = "Yıldırım", Email = "tuna_yildirim@outlook.com", Phone = "5305759862", BirthDate = new DateTime(1996, 9, 11), IsActive = true }
                         );

        }
    }
}
