using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Areas.Admin.Controllers
{
    [Authorize]
    public class QuyenController : BaseController
    {
        QuyenRepository _quyenRepo = new QuyenRepository();

        // GET: Admin/Quyen
        public ActionResult Index()
        {
            var model = _quyenRepo.GetAllQuyen();

            return View(model.Data);
        }

        public ActionResult Create()
        {

            return View();
        }



    }
}