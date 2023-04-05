using LTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTW.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SanPhamsController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: SanPham

        public List<SanPham> SearchByName(string searchString)
        {
            var all_sp = (from ss in data.SanPhams select ss).Where(m => m.SoLuongTon > 0 && m.TenSP.Contains(searchString)).ToList();
            return all_sp;
        }
        public ActionResult ListSanPham(string searchString)
        {
            ViewBag.Keyword = searchString;

            var all_sanpham = from sp in data.SanPhams select sp;
            if (searchString != null)
            {
                ViewBag.Keyword = searchString;
                return View(SearchByName(searchString));
            }

            return View(all_sanpham);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SanPham sp)
        {
            var E_TenSP = collection["TenSP"];
            var E_Hinh = "/Content/images/" + collection["Hinh"];
            var E_GiaSP = Convert.ToInt32(collection["GiaSP"]);
            var E_SoLuongTon = Convert.ToInt32(collection["SoLuongTon"]);
            var E_MoTa = collection["MoTa"];
            var E_MaLoai = Convert.ToInt32(collection["MaLoai"]);
            var E_NCC = collection["NCC"];
            if (string.IsNullOrEmpty(E_TenSP))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sp.TenSP = E_TenSP.ToString();
                sp.Hinh = E_Hinh.ToString();
                sp.GiaSP = E_GiaSP;
                sp.SoLuongTon = E_SoLuongTon;
                sp.MoTa = E_MoTa.ToString();
                sp.MaLoai = E_MaLoai;
                //sp.NCC = E_NCC.ToString();
                data.SanPhams.InsertOnSubmit(sp);
                data.SubmitChanges();
                return RedirectToAction("ListSanPham");
            }
            return this.Create();
        }

        public ActionResult Detail(int id)
        {
            var D_sach = data.SanPhams.Where(m => m.MaSP == id).First();
            return View(D_sach);
        }

        public ActionResult Edit(int id)
        {
            var E_sp = data.SanPhams.First(m => m.MaSP == id);
            return View(E_sp);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            var E_SP = data.SanPhams.First(m => m.MaSP == id);
            var E_TenSP = collection["TenSP"];
            //var E_Hinh = "/Content/images/"+collection["fileUpload"];
            var E_Hinh = collection["Hinh"];
            var E_GiaSP = Convert.ToInt32(collection["GiaSP"]);
            var E_SoLuongTon = Convert.ToInt32(collection["SoLuongTon"]);
            var E_MoTa = collection["MoTa"];
            var E_MaLoai = Convert.ToInt32(collection["MaLoai"]);
            E_SP.MaSP = id;
            if (string.IsNullOrEmpty(E_TenSP))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_SP.TenSP = E_TenSP;
                E_SP.Hinh = E_Hinh;
                E_SP.GiaSP = E_GiaSP;
                E_SP.SoLuongTon = E_SoLuongTon;
                E_SP.MoTa = E_MoTa;
                E_SP.MaLoai = E_MaLoai;
                UpdateModel(E_SP);
                data.SubmitChanges();
                return RedirectToAction("ListSanPham");

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


        public ActionResult Delete(int id)
        {
            var D_sp = data.SanPhams.First(m => m.MaSP == id);
            return View(D_sp);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sp = data.SanPhams.Where(m => m.MaSP == id).FirstOrDefault();
            data.SanPhams.DeleteOnSubmit(D_sp);
            data.SubmitChanges();
            return RedirectToAction("ListSanPham");
        }

    }
}