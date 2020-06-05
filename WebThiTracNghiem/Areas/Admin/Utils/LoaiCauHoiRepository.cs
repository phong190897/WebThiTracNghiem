using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Repository;

namespace WebThiTracNghiem.Areas.Admin.Utils
{
    public class LoaiCauHoiRepository
    {
        public List<LoaiCauHoiModel> GetLoaiCauHoiToDropDownList()
        {
            var list = CoreRepo.GetApiResponse<LoaiCauHoiModel>(Constance.Constance.UrlApi, "LoaiCauHoi/GetAllLoaiCauHoi/");

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list.Data;

            return list.Data;
        }
    }
}