using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookshop.Models;

namespace bookshop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index()
        {

            var listSach = db.Saches;

            return View(listSach);
        }
    }
}