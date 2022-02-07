using System.Collections.Generic;
using System.Linq;
using bookshop.Models;
using System.Web.Mvc;

namespace bookshop.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Product
        QuanLyBanSachEntities _db;
        public ProductsController()
        {
           _db = new QuanLyBanSachEntities();
        }

        public ActionResult Index()
        {
            //List<Sach> listSach = _db.Saches.ToList();
            //ViewData["listSach"] = listSach; 

            ViewData["listSach"] = (List<Sach>)_db.Saches.ToList();

            return View();
        }
    }
}