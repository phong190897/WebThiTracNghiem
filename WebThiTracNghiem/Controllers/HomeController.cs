using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Controllers;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Controllers
{
    [Authorize]

    public class HomeController : BaseController
    {
        MonRepository _monThiRepo = new MonRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThiThu()
        {
            List<MonModel> listMonThi = _monThiRepo.GetMonThiToDropDownList();
            var monThi = new List<SelectListItem>();

            monThi.AddRange(from a in listMonThi
                            select new SelectListItem
                            {
                                Text = a.TenMon,
                                Value = a.MaMon
                            });

            if (listMonThi.Count != 0)
            {
                ViewBag.MonThi = monThi;
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}