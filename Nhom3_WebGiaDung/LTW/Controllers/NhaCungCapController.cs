using LTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTW.Controllers
{
    public class NhaCungCapController : Controller
    {
        // GET: NhaCungCap
        MyDataDataContext data = new MyDataDataContext();
        public List<NCC> SearchByName(string searchString)
        {
            var all_ncc = (from ss in data.NCCs select ss).Where(m =>  m.TenNCC.Contains(searchString)).ToList();
            return all_ncc;
        }
        public ActionResult ListNhaCungCap(string searchString)
        {
            ViewBag.Keyword = searchString;

            var all_ncc = from ncc in data.NCCs select ncc;
            if (searchString != null)
            {
                ViewBag.Keyword = searchString;
                return View(SearchByName(searchString));
            }

            return View(all_ncc);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, NCC ncc )
        {
            var E_TenNCC = collection["TenNCC"];
           
            var E_Email = collection["Email"];
            var E_SDT = collection["SDT"];
            var E_DiaChi = collection["DiaChi"];
           
            if (string.IsNullOrEmpty(E_TenNCC))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                ncc.TenNCC = E_TenNCC.ToString();
                ncc.Email = E_Email.ToString();
                ncc.SDT = E_SDT.ToString();
                ncc.Diachi = E_DiaChi.ToString();
 
                data.NCCs.InsertOnSubmit(ncc);
                data.SubmitChanges();
                return RedirectToAction("ListNhaCungCap");
            }
            return this.Create();
        }

        public ActionResult Detail(int id)
        {
            var D_ncc = data.NCCs.Where(m => m.MaNCC == id).First();
            return View(D_ncc);
        }

        public ActionResult Edit(int id)
        {
            var E_ncc = data.NCCs.First(m => m.MaNCC == id);
            return View(E_ncc);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            var E_NCC = data.NCCs.First(m => m.MaNCC == id);
            var E_TenNCC = collection["TenNCC"];

            var E_Email = collection["Email"];
            var E_SDT = collection["SDT"];
            var E_DiaChi = collection["DiaChi"];
            E_NCC.MaNCC = id;
            if (string.IsNullOrEmpty(E_TenNCC))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_NCC.TenNCC = E_TenNCC;
                E_NCC.Email = E_Email;
                E_NCC.SDT = E_SDT;
                E_NCC.Diachi = E_DiaChi;
                
                UpdateModel(E_NCC);
                data.SubmitChanges();
                return RedirectToAction("ListNhaCungCap");

            }
            return this.Edit(id);

        }

        public ActionResult Delete(int id)
        {
            var D_ncc = data.NCCs.First(m => m.MaNCC == id);
            return View(D_ncc);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_ncc = data.NCCs.Where(m => m.MaNCC == id).FirstOrDefault();
            data.NCCs.DeleteOnSubmit(D_ncc);
            data.SubmitChanges();
            return RedirectToAction("ListNhaCungCap");
        }
    }
}