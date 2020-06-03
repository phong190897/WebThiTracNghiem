using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Data;

namespace WebThiTracNghiem.Areas.Admin.Controllers
{
    public class BaiThiController : BaseController
    {
        // GET: Admin/BaiThi
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/BaiThi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/BaiThi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BaiThi/Create
        [HttpPost]
        public ActionResult Create(BaiThiModel baiThiModel)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/BaiThi/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Admin/BaiThi/Edit/5
        [HttpPost]
        public ActionResult Edit(BaiThiModel baiThiModel)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Admin/BaiThi/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
