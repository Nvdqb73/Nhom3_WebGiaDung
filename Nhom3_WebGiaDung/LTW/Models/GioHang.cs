using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LTW.Models
{
    public class GioHang
    {
        MyDataDataContext data = new MyDataDataContext();
        public int MaSP { get; set; }

        [Display(Name = "Tên Sản Phẩm ")]
        public string TenSanPham { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string hinh { get; set; }

        [Display(Name = "Giá bán")]
        public Double giaban { get; set; }

        [Display(Name = "số lượng")]
        public int isoluong { get; set; }

        [Display(Name = "Thành tiền")]
        public Double dThanhtien
        {
            get { return isoluong * giaban; }
        }
        public GioHang(int id)
        {
            MaSP = id;
            SanPham sp = data.SanPhams.Single(n => n.MaSP == MaSP);
            TenSanPham = sp.TenSP;
            hinh = sp.Hinh;
            giaban = double.Parse(sp.GiaSP.ToString());
            isoluong = 1;
        }
    }
}