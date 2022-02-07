using bookshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace bookshop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLogin User)
        {
            if (ModelState.IsValid)
            {
                var _db = new QuanLyBanSachEntities();
                var result = _db.AccountLogins.Where(item => item.UserName.Equals(User.UserName) && item.Password.Equals(User.Password)).FirstOrDefault();
                if (result!= null)
                {
                    Session["UserID"] = result.UserId.ToString();
                    Session["UserName"] = result.UserName.ToString();
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login failed !!!");

                }
            }
            return View("Index");
        }

    }
}