using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbansach.Models;
namespace Webbansach.Controllers
{
    public class NhaxuatbanController : Controller
    {
        dbQLBansachDataContext data = new dbQLBansachDataContext();
        // 1. Hiện thi danh sách Nhà xuất bản
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(data.NHAXUATBANs.ToList());
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
        public ActionResult Create(NHAXUATBAN nhaxuatban)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                data.NHAXUATBANs.InsertOnSubmit(nhaxuatban);
                data.SubmitChanges();
                return RedirectToAction("Index", "Nhaxuatban");
            }
        }
        //3. Xem chi tiết thông tin 1 Nhà xuất bản
        public ActionResult Details (int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var nhaxuatban = from nxb in data.NHAXUATBANs where nxb.MaNXB == id select nxb;
                return View(nhaxuatban.SingleOrDefault());
            }
        }
        //4. Xóa 1 Nhà xuất bản
        public ActionResult Delete(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var nhaxuatban = from nxb in data.NHAXUATBANs where nxb.MaNXB == id select nxb;
                return View(nhaxuatban.SingleOrDefault());
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                NHAXUATBAN nhaxuatban = data.NHAXUATBANs.SingleOrDefault(n => n.MaNXB==id);
                data.NHAXUATBANs.DeleteOnSubmit(nhaxuatban);
                data.SubmitChanges();
                return RedirectToAction("Index", "Nhaxuatban");
            }
        }
        //5. Điều chỉnh thông tin 1 Nhà xuất bản
        public ActionResult Edit(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var nhaxuatban = from nxb in data.NHAXUATBANs where nxb.MaNXB == id select nxb;
                return View(nhaxuatban.SingleOrDefault());
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
                NHAXUATBAN nhaxuatban = data.NHAXUATBANs.SingleOrDefault(n => n.MaNXB == id);

                UpdateModel(nhaxuatban);
                data.SubmitChanges();
                return RedirectToAction("Index", "Nhaxuatban");
            }
        }
    }
}