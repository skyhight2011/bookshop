using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookshop.Models;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bookshop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Sach> data = (List<Sach>)db.Saches.ToList();
            ViewData["listData"] = data;
            return View();
        }

        public Models.Response Get()
        {
            int take = Request["take"] == null ? 10 : int.Parse(Request["take"]);
            int skip = Request["skip"] == null ? 0 : int.Parse(Request["skip"]);

            // get all of the records from the employees table in the
            // northwind database.  return them in a collection of user
            // defined model objects for easy serialization. skip and then
            // take the appropriate number of records for paging.
            var listSach = (from e in db.Saches
                             select new Models.Sach(e)).Skip(skip).Take(take).ToArray();

            // returns the generic response object which will contain the
            // employees array and the total count
            return new Models.Response(listSach, db.Saches.Count());
        }

        public ActionResult Update(int MaSach, Sach sach)
        {
            var data = db.Saches.FirstOrDefault(x => x.MaSach == x.MaSach);
            if(data != null)
            {
                data.TenSach = sach.TenSach;
                data.GiaBan = sach.GiaBan;
                data.SoLuongTon = sach.SoLuongTon;
                data.MaNXB = sach.MaNXB;
                data.MaChuDe = sach.MaChuDe;
                data.TenSach = sach.TenSach;
                return RedirectToAction("Read");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int MaSach)
        {
            var data = db.Saches.FirstOrDefault(x => x.MaSach == MaSach);
            if(data != null)
            {
                db.Saches.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Read");
            }
            else
            {
                return View();
            }
        }

    }
}