using CustomerDetails.Data;
using CustomerDetails.Data.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerDetails.Controllers
{
    public class CustomerController : Controller
    {
        /*
         * Veritabanı için kullanılacak alan
         */
        private readonly CustomerDetailsDbContext _context;

        public CustomerController(CustomerDetailsDbContext _context)
        {
            this._context = _context;
        }
        /*
         * Add metodu müşteri eklemek için kullanılan sayfaya yönlendirme yapmaktadır.
         * ViewBag.AddressTypes içresinde dropdown içerisinde gösterilecek adres tipleri gönderilmektedir.
         */
        public IActionResult Add()
        {
            ViewBag.AddressTypes = _context.AddressTypes.ToList();

            return View();
        }

        /*
         * Add metodunun HttpPost metodu.
         * Kullanıcının eklemek istediği müşteriyi veritabanına ekleyen metottur.
         * Try - catch ile exception kontrol edilerek veritabanına ekleme aşaması kontrol edilmiştir.
         * Ekleme başarılı olursa Shared klasörü içerisinde yer alan Message.cshtml ile başarılı, başarısız olursa başarısız mesajı verilecektir.
         * if kontrolu ile eklenen müşteri için adres girilmişse adres tipinin de seçilmiş olduğu kontrol edilmiştir. 0 olan seçenek seçim yapılmasını söyleyen seçenek olduğu için 
           kontrol bu değer üzerinden yapılmıştır.
         */
        [HttpPost]
        public IActionResult Add(Customer customer) 
        {
            try
            {
                if (customer.AddressTypeId == 0 && customer.Address != null)
                {
                    throw new Exception();
                }
                else
                {
                    _context.Add(customer);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return View("Message", "Müşteriyi Eklerken Bir Hata Oluştu!");
            }

            return View("Message", "Müşteri Başarıyla Eklendi!");
        }

        /*
         * Edit metodu düzenlenmek istenen müşteri bilgilerini düzenleyecek sayfaya yönlendiren metottur.
         * Aldığı id parametresi ile bilgileri düzenlenecek müşteri bilgilerini de sayfaya gönderir.
         * ViewBag.AddressTypes dropdown içerisinde gösterilecek adres tiplerini göndermektedir.
         * ViewBag.Customer düzenlenecek müşteri bilgilerini göndermektedir.
         */
        public IActionResult Edit(int id)
        {
            ViewBag.AddressTypes = _context.AddressTypes.ToList();
            ViewBag.Customer = _context.Customers.Where(c => c.Id == id).FirstOrDefault();

            return View();
        }

        /*
         * Edit metodunun HttpPost metodu
         * customer parametresi ile edğişiklik yapılan müşteri bilgilerini alır.
         * Try - catch ile exception kontrol edilerek veritabanıda değişiklik aşaması kontrol edilmiştir.
         * try- catch içerisinde gelen müşteri üzerindeki değişiklik kontrol edilerek veritabanına gönderilir.
         * Düzenleme başarılı olursa Shared klasörü içerisinde yer alan Message.cshtml ile başarılı, başarısız olursa başarısız mesajı verilecektir.
         */

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            try
            {
                _context.Entry(customer).State = EntityState.Modified;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return View("Message", "Müşteriyi Düzenlerken Bir Hata Oluştu!");
            }

            return View("Message", "Müşteri Başarıyla Düzenlendi!");
        }

        /*
         * Delete metodu aldığı müşteri id parametresi ile bilgileri verilen ve silmek için teyit alınan bir sayfaya yönlendirir.
         */
        public IActionResult Delete(int id)
        {
            ViewBag.Customer = _context.Customers.Where(c => c.Id == id).FirstOrDefault();

            return View();
        }

        /*
         * Delete metodunun HttpPost metodu
         * Kullanıcının silme işlemini onaylamasıyla bu metot silinecek müşteri bilgilerini parametre olarak alır.
         * İlerleyen zamanlarda yapılabilecek değişikler ile müşteri tablosuna bağlı tablolar yaratılabilir. Bu nedenle müşterilerin tamamen silinmesi yerine aktif ya da pasif
           olarak boolean ile kontrol edilmişir.
         * Try - catch ile exception kontrol edilerek veritabanıda değişiklik aşaması kontrol edilmiştir.
         * try- catch içerisinde gelen müşteri üzerindeki değişiklik kontrol edilerek veritabanına gönderilir.
         * İşlem başarılı olursa Shared klasörü içerisinde yer alan Message.cshtml ile başarılı, başarısız olursa başarısız mesajı verilecektir.
         */

        [HttpPost]
        public IActionResult Delete(Customer customer) 
        {
            try
            {
                Customer cus = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);

                cus.IsActive = false;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return View("Message", "Müşteriyi Silerken Bir Hata Oluştu!");
            }

            return View("Message", "Müşteri Başarıyla Silindi!");
        }
    }
}
