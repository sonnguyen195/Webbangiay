using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbansach.Models;
using PagedList;
using PagedList.Mvc;

namespace Webbansach.Controllers
{
    public class ShoeStoreController : Controller
    {
        // GET: BookStore
        //Tao doi tuong data chưa dữ liệu từ model dbQLBansach đã tạo. 
        dbQLBansachDataContext data = new dbQLBansachDataContext();

        // Ham lay n quyen sach moi
        private List<SACH> Layspmoi(int count)
        {
            //Sắp xếp sách theo ngày cập nhật, sau đó lấy top @count 
            return data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index(int? page)
        {
            int pagesize = 6;
            int pagenum = page ?? 1;
            //Lấy top 5 Album bán chạy nhất
            var sachmoi = Layspmoi(15);
            return View(sachmoi.ToPagedList(pagenum, pagesize));
        }
        public ActionResult Brands()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult Nhasanxuat()
        {
            var nhaxuatban = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(nhaxuatban);
        }
        public ActionResult Sptheobrand(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult SptheoNSX(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach);
        }
        public ActionResult Chitietsp(int id)
        {
            var sach = from s in data.SACHes where s.Masach == id select s;
            return View(sach.Single());
        }
    }
}