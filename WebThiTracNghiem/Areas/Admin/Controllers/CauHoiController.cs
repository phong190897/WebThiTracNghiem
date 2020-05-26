using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Areas.Admin.Utils;

namespace WebThiTracNghiem.Areas.Admin.Controllers
{
    [Authorize]
    public class CauHoiController : BaseController
    {
        CauHoiRepository cauHoiRepo = new CauHoiRepository();
        // GET: Admin/CauHoi
        public ActionResult Index()
        {
            var model = cauHoiRepo.GetAllCauHoi();

            return View(model.Data);
        }

        // GET: Admin/CauHoi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CauHoi/Create
        public ActionResult Create()
        {
            LoaiCauHoiRepository loaiCauHoiRepository = new LoaiCauHoiRepository();
            MonRepository monRepository = new MonRepository();
            List<LoaiCauHoiModel> listLoaiCauHoi = loaiCauHoiRepository.GetLoaiCauHoiToDropDownList();
            List<MonModel> listMonThi = monRepository.GetMonThiToDropDownList();

            if (listLoaiCauHoi.Count != 0)
            {
                ViewBag.LoaiCauHoi = listLoaiCauHoi;
            }
            if (listMonThi.Count != 0)
            {
                ViewBag.MonThi = listMonThi;
            }

            return View();
        }

        // POST: Admin/CauHoi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CauHoiModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    var addNewCauHoi = cauHoiRepo.CreateCauHoi(collection);
                    if(addNewCauHoi.CheckStatus())
                        return RedirectToAction("Index", "CauHoi");
                }
                return View();
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CauHoi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/CauHoi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Admin/CauHoi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CauHoi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
