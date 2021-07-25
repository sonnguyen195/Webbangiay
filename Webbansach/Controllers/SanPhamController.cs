using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbansach.Models;

namespace Webbansach.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        dbQLBansachDataContext data = new dbQLBansachDataContext();
        // 1. Hiện thi danh sách Nhà xuất bản
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(data.SACHes.ToList());
        }
        //2. Thêm mới 1 Nhà xuất bản
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View();
        }
        [HttpPost]
        public ActionResult Create(SACH sach)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                data.SACHes.InsertOnSubmit(sach);
                data.SubmitChanges();
                return RedirectToAction("Index", "SanPham");
            }
        }
        //3. Xem chi tiết thông tin 1 Nhà xuất bản
        public ActionResult Details(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var sach = from s in data.SACHes where s.Masach == id select s;
                return View(sach.SingleOrDefault());
            }
        }
        //4. Xóa 1 Nhà xuất bản
        public ActionResult Delete(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var sach = from s in data.SACHes where s.Masach == id select s;
                return View(sach.SingleOrDefault());
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                SACH sach = data.SACHes.SingleOrDefault(n => n.Masach == id);
                data.SACHes.DeleteOnSubmit(sach);
                data.SubmitChanges();
                return RedirectToAction("Index", "SanPham");
            }
        }
        //5. Điều chỉnh thông tin 1 Nhà xuất bản
        public ActionResult Edit(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var sach = from s in data.SACHes where s.Masach == id select s;
                return View(sach.SingleOrDefault());
            }
        }
        //Do tên Action trùng tên, nên cần tên bí doanh
        [HttpPost, ActionName("Edit")]
        public ActionResult Xacnhansua(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                SACH sach = data.SACHes.SingleOrDefault(n => n.Masach == id);

                UpdateModel(sach);
                data.SubmitChanges();
                return RedirectToAction("Index", "SanPham");
            }
        }

    }
}