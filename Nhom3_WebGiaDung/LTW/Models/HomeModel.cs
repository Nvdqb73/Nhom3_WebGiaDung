using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTW.Models
{
    public class HomeModel
    {
        public List<SanPham> listSP { get; set; }
        public List<Loai> listLoai { get; set; }
    }
}