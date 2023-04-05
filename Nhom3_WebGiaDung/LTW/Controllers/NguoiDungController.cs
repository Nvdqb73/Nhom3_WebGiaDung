using LTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Windows;

namespace LTW.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        MyDataDataContext data = new MyDataDataContext();

        public static bool ValidateVNPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Replace("+84", "0");
            Regex regex = new
            Regex(@"^(0)(86|96|97|98|32|33|34|35|36|37|38|39|91|94|83|84|85|81|82|90|93|70|79|77|76|7
8|92|56|58|99|59|55|87)\d{7}$");
            return regex.IsMatch(phoneNumber);
        }

        public bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KhachHang kh)
        {
            var TenKhachHang = collection["TenKhachHang"];
            var UserName = collection["UserName"];
            var Password = collection["Password"];
            var MatKhauXacNhan = collection["MatKhauXacNhan"];
            var Email = collection["Email"];
            var DiaChi = collection["DiaChi"];
            var SDT = collection["SDT"];
            var RoleID = Convert.ToInt32(collection["RoleID"]);
            var check = data.KhachHangs.Where(n => n.UserName == UserName).Count();




            if (check > 0)
            {
                TempData["Error"] = "Ten dang nhap da ton tai!";
                return this.DangKy();
            }

            else if (String.IsNullOrEmpty(MatKhauXacNhan))
            {
                TempData["NhapMKXN"] = "Phải nhập mật khẩu xác nhận!";
            }

            else if (ValidateEmail(Email) == false)
            {
                TempData["Error"] = "Email khong hop le";
                return this.DangKy();

            }


            else if (ValidateVNPhoneNumber (SDT) == false)
            {
                TempData["Error"] = "So dien thoai ko hop le!";
                return this.DangKy();
            }
                       
            else
            {
                if (!Password.Equals(MatKhauXacNhan))
                {
                    TempData["MatKhauGiongNhau"] = "Mật khẩu và mật khẩu xác nhận phải giống nhau";
                }
                else
                {

                    kh.UserName = UserName;
                    
                    kh.Password = Password;
                    kh.TenKhachHang = TenKhachHang;
                    kh.Email = Email;
                    kh.DiaChi = DiaChi;
                    kh.SDT = SDT;
                    kh.RoleID = RoleID;


                    data.KhachHangs.InsertOnSubmit(kh);
                    data.SubmitChanges();

                    return RedirectToAction("DangNhap");
                }

                
                

            }
            return this.DangKy();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var UserName = collection["UserName"];
            var Password = collection["Password"];
            KhachHang kh = data.KhachHangs.SingleOrDefault(n => n.UserName.Equals(UserName) && n.Password.Equals(Password));
            if (kh != null)
            {
                FormsAuthentication.SetAuthCookie(kh.UserName, false);
                Session["TaiKhoan"] = kh;

                if (kh.RoleID == 1)
                {
                    //Response.Redirect("/Admin/SanPhams/ListSanPham");
                    return Redirect("/Admin/SanPhams/ListSanPham");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            } 
            else
            {
                TempData["Error"] = "Bạn nhập sai tài khoản hoặc mặc mật khẩu!";
            }
            return RedirectToAction("DangNhap");
        }


        public ActionResult DangXuat() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhap", "NguoiDung");
        }
    }
}
