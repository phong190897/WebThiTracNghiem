using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebThiTracNghiem.Areas.Admin.Code;
using WebThiTracNghiem.Areas.Admin.Models;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {

            if(Membership.ValidateUser(model.TenTaiKhoan, model.MatKhau) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.TenTaiKhoan, true);
                return RedirectToAction("Index", "Home");
            }    
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}