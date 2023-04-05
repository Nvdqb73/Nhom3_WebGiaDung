using LTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTW.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LoaisController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult ListLoai()
        {
            var all_loai = from l in data.Loais select l;
            return View(all_loai);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Loai l)
        {
            var E_TenLoai = collection["TenLoai"];
            var E_Hinh = "/Content/images/" + collection["Hinh"];
            if (string.IsNullOrEmpty(E_TenLoai))
            {
                ViewData["Error"] = "Dien thieu kia!";
            }
            else
            {
                l.TenLoai = E_TenLoai.ToString();
                l.Hinh = E_Hinh.ToString();
                data.Loais.InsertOnSubmit(l);
                data.SubmitChanges();
                return RedirectToAction("ListLoai");
            }
            return this.Create();
        }

        public ActionResult Edit(int id)
        {
            var E_l = data.Loais.First(m => m.MaLoai == id);
            return View(E_l);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            var E_Loai = data.Loais.First(m => m.MaLoai == id);

            var E_TenLoai = collection["TenLoai"];
            var E_Hinh = collection["Hinh"];


            E_Loai.MaLoai = id;
            if (string.IsNullOrEmpty(E_TenLoai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_Loai.TenLoai = E_TenLoai;
                E_Loai.Hinh = E_Hinh;


                UpdateModel(E_Loai);
                data.SubmitChanges();

                return RedirectToAction("ListLoai");

            }
            return this.Edit(id);

        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }

        public ActionResult Detail(int id)
        {
            var D_l = data.Loais.Where(m => m.MaLoai == id).First();
            return View(D_l);
        }

        public ActionResult Delete(int id)
        {
            var D_loai = data.Loais.First(m => m.MaLoai == id);
            return View(D_loai);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_loai = data.Loais.Where(m => m.MaLoai == id).FirstOrDefault();

            data.Loais.DeleteOnSubmit(D_loai);
            data.SubmitChanges();
            return RedirectToAction("ListLoai");
        }
    }
}