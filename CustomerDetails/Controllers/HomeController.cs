using CustomerDetails.Data;
using CustomerDetails.Data.db;
using CustomerDetails.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CustomerDetails.Controllers
{
    public class HomeController : Controller
    {
        /*
         * Veritabanı için kullanılacak alan
         */
        private readonly CustomerDetailsDbContext _context;

        public HomeController(CustomerDetailsDbContext _context)
        {
            this._context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*
         * Asenkron olarak çalışan All metodu ile tüm müşteriler listelenmek üzere getirilmektedir. 
         * sortOrder parametresi müşterilen adlarına göre yukarıdan aşağı mı yoksa aşağıdan yukarı mı sıralanacağı bilgisini gönderir.
         * searchString parametresi ile kullanıcının yaptığı aramaya göre müşteri adı ve soyadında aranacak değer gönderilir.
         * customers değişkeni içerisinde veritabanında bulunan tüm müşteriler getirilmektedir.
         * Her durumda aktif olarak işaretlenen müşteriler veritabanından getirilmektedir.
         */
        public async Task<IActionResult> All(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            var customers = from c in _context.Customers where c.IsActive == true select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.Name.Contains(searchString) || c.Surname.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(c => c.Name);
                    break;
                default:
                    customers = customers.OrderBy(c => c.Name);
                    break;
            }

            return View(await customers.AsNoTracking().ToListAsync());
        }

        /*
         * Details metodu seçilen bir müşterinin tüm bilgilerini getirir.
         * ViewBag.Customer içerisinde verilen id'ye sahip müşteri bulunmaktadır.
         * id parametresi detayları gösterilecek müşteriye ait.
         */
        public IActionResult Details(int id) 
        {
            ViewBag.Customer = _context.Customers.Include(a => a.AddressType).Where(c => c.Id == id).FirstOrDefault();

            return View();
        }

        /*
         * About metodu projeyi hazırlayan hakkında bilgi içermektedir.
         */
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}