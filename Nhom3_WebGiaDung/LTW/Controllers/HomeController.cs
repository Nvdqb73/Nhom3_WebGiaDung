using LTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace LTW.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext dt = new MyDataDataContext();


        public List<SanPham> SearchByName(string searchString)
        {
            var all_sach = (from ss in dt.SanPhams select ss).Where(m => m.SoLuongTon > 0 && m.TenSP.Contains(searchString)).ToList();
            return all_sach;
        }
        public ActionResult Index( string searchString)
        {

            ViewBag.Keyword = searchString;
            HomeModel Hm = new HomeModel();

            Hm.listSP = dt.SanPhams.ToList();
            Hm.listLoai = dt.Loais.ToList();
            if (searchString != null)
            {
                ViewBag.Keyword = searchString;
                return View(SearchByName(searchString));
            }

            return View(Hm);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}