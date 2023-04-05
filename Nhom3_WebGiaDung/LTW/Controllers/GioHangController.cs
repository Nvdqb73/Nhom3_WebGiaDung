using LTW.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTW.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        MyDataDataContext data = new MyDataDataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
  
        
        [HttpPost]
        public ActionResult ThemGioHang(int id)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.Find(n => n.MaSP == id);
            if (sanpham == null)
            {
                sanpham = new GioHang(id);
                lstGioHang.Add(sanpham);
            }
            else
            {
                sanpham.isoluong++;
            }
            return Json(new { success = true, message = "Them Thanh Cong" });
        }

        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(n => n.isoluong);
            }
            return tsl;
        }

        [HttpPost]
        public ActionResult TongSoLuongSanPhamJson()
        {
            int tsl = 0;
            List<GioHang> lstGiohang = Session["GioHang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                tsl = lstGiohang.Count;
            }
            return Json(new { tsl = tsl });
        }

        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Count;
            }
            return tsl;
        }

        private double TongTien()
        {
            double tt = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                tt = lstGiohang.Sum(n => n.dThanhtien);
            }
            return tt;
        }


        public ActionResult GioHang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();
            return View(lstGioHang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();

            return PartialView();
        }


        public ActionResult XoaGioHang(int id)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.MaSP == id);
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.MaSP == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }


        public ActionResult CapNhatGioHang(int id, FormCollection collection)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.MaSP == id);
            if (sanpham != null)
            {
                sanpham.isoluong = int.Parse(collection["txtSoLg"].ToString());
            }
            return RedirectToAction("GioHang");
        }


        public ActionResult XoaTatcaGioHang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return RedirectToAction("GioHang");
        }

        [HttpGet]
        public ActionResult DatHang()
        {
            var m = TongSoLuongSanPham();
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap","NguoiDung");
            }
             else if (m == 0)
            {
                return RedirectToAction("ListSanPham","SanPham");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();
            ViewBag.TrangThai = data.ThanhToans.ToList();
            return View(lstGioHang);
        }
        public ActionResult DatHang(FormCollection collection)
        {
            int status = int.Parse(collection["TrangThai"]);
            DonHang dh = new DonHang();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            SanPham sp = new SanPham();

            List<GioHang> gh = LayGioHang();
            var NgayGiaoHangDuKien = String.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]);
            if(DateTime.Parse(NgayGiaoHangDuKien) < DateTime.Now )
            {
                Response.Write("<script>alert('Inserted successfully!')</script>");
                return RedirectToAction( "GioHang");
            }

            dh.MaKH = kh.MaKH;
            dh.NgayDatHang = DateTime.Now;
            dh.NgayGiaoHangDuKien= DateTime.Parse(NgayGiaoHangDuKien);
            dh.TrangThai = "Chưa giao";
            dh.MaTT = status;

            data.DonHangs.InsertOnSubmit(dh);
           
            data.SubmitChanges();
            foreach (var item in gh)
            {
                ChiTietDonHang ctdh = new ChiTietDonHang();
                ctdh.MaDH = dh.MaDH;
                ctdh.MaSP = item.MaSP;
                ctdh.MaTT = status;
                ctdh.SoLuongMua = item.isoluong;
                ctdh.TongTien = (decimal)item.dThanhtien;
                sp = data.SanPhams.Single(n => n.MaSP == item.MaSP);
                sp.SoLuongTon -= ctdh.SoLuongMua;
                data.SubmitChanges();

                data.ChiTietDonHangs.InsertOnSubmit(ctdh);

            }
            dh.TongTienDonHang = (decimal)TongTien();


            data.SubmitChanges();
            Session["GioHang"] = null;
            return RedirectToAction("XacNhanDonHang", "GioHang");

        }

        public ActionResult XacnhanDonHang()
        {
            return View();
        }
    }
}