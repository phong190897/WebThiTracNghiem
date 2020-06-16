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
        DeThiRepository _deThiRepo = new DeThiRepository();
        CauHoiRepository _cauHoiRepo = new CauHoiRepository();

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

        public ActionResult ThongTinBaiThi(FormCollection MaMon)
        {
            string mon = MaMon["MaMon"];

            if (!string.IsNullOrEmpty(mon))
            {
                var DeThi = _deThiRepo.GetAllDeThi().Data.Where(m => m.MaMon == mon).ToList();
                var tenMonThi = _monThiRepo.GetMonThiById(mon).Data.FirstOrDefault();

                ViewBag.MonThi = tenMonThi.TenMon;

                return View(DeThi);
            }


            return View();
        }

        public ActionResult LamBaiThi(string ID)
        {
            var model = _deThiRepo.GetDeThiByID(ID);
            ViewBag.MonThi = _monThiRepo.GetMonThiById(model.Data.FirstOrDefault().MaMon).Data.FirstOrDefault().TenMon;

            return View(model.Data.FirstOrDefault());
        }

        public ActionResult BatDau(string ID)
        {
            var model = _deThiRepo.GetDeThiByID(ID).Data.FirstOrDefault();
            List<CauHoiModel> ListCauHoi = new List<CauHoiModel>();
            int i = 1;

            ViewBag.Time = model.ThoiGianLamBai;
            ViewBag.MaDe = model.MaDe;

            if (!string.IsNullOrEmpty(model.Cauhoi))
            {
                var listMaCauHoi = model.Cauhoi.Split(',');

                foreach (var item in listMaCauHoi)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        var cauHoi = _cauHoiRepo.GetCauHoiByID(item).Data.FirstOrDefault();
                        ListCauHoi.Add(new CauHoiModel
                        {
                            MaCauHoi = cauHoi.MaCauHoi,
                            TenCauHoi = i + "/ " + cauHoi.TenCauHoi,
                            A = cauHoi.A,
                            B = cauHoi.B,
                            C = cauHoi.C,
                            D = cauHoi.D,
                            DapAn = cauHoi.DapAn
                        });
                        i++;
                    }
                }
            }

            return View(ListCauHoi);
        }

        public ActionResult NopBai(FormCollection form)
        {
            string maDe = form.Keys[0];
            int diem = 0;
            int soCauDung = 0;
            List<CauHoiModel> ListCauHoi = new List<CauHoiModel>();
            KetQuaBaiThiModel kqBaiThi = new KetQuaBaiThiModel();

            if (!string.IsNullOrEmpty(maDe))
            {
                var model = _deThiRepo.GetDeThiByID(maDe).Data.FirstOrDefault();

                ViewBag.MonThi = _monThiRepo.GetMonThiById(model.MaMon).Data.FirstOrDefault().TenMon;

                if (!string.IsNullOrEmpty(model.Cauhoi))
                {
                    var listMaCauHoi = model.Cauhoi.Split(',');

                    foreach (var item in listMaCauHoi)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            var cauHoi = _cauHoiRepo.GetCauHoiByID(item).Data.FirstOrDefault();
                            ListCauHoi.Add(new CauHoiModel
                            {
                                MaCauHoi = cauHoi.MaCauHoi,
                                TenCauHoi = cauHoi.TenCauHoi,
                                A = cauHoi.A,
                                B = cauHoi.B,
                                C = cauHoi.C,
                                D = cauHoi.D,
                                DapAn = cauHoi.DapAn
                            });
                        }
                    }
                }

                foreach (var item in form.AllKeys)
                {
                    if(item.Contains("answer_"))
                    {
                        string UserAnswer = form[item];
                        string[] maCauHoi = item.Split('_');

                        if(ListCauHoi.Where( m => m.MaCauHoi == maCauHoi[2]).Select(da => da.DapAn).Contains(UserAnswer))
                        {
                            soCauDung++;
                            diem++;
                            ListCauHoi.Where(m => m.MaCauHoi == maCauHoi[2]).FirstOrDefault().DapAnChu = maCauHoi[1];
                        }    
                    }
                }

                kqBaiThi.MaDe = maDe;
                kqBaiThi.ThoiGianLamBai = model.ThoiGianLamBai;
                kqBaiThi.SoCauDung = soCauDung;
                kqBaiThi.Diem = diem;
                kqBaiThi.TongSoCau = ListCauHoi.Count();
                kqBaiThi.CauHois = ListCauHoi;
            }

            return View(kqBaiThi);
        }
    }
}