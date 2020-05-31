using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        TaiKhoanRepository _taiKhoanRepository = new TaiKhoanRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaiKhoanModel taiKhoanModel)
        {
            if(ModelState.IsValid)
            {
                var createTaiKhoan = _taiKhoanRepository.InsertTaiKhoan(taiKhoanModel);

                if (createTaiKhoan.CheckStatus())
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo tài khoản không thành công");
                }    
            }
            return View("Index");
        }
    }
}