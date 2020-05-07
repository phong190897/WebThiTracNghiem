﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Models;
using WebThiTracNghiem.Repository;

namespace WebThiTracNghiem.Areas.Admin.Utils
{
    public class CauHoiRepository
    {
        public ApiResponse<CauHoiModel> GetAllCauHoi()
        {
            var list = CoreRepo.GetApiResponse<CauHoiModel>(Constance.Constance.UrlApi, "CauHoi/GetAllCauHoi/");

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

        public ApiResponse<CauHoiModel> CreateCauHoi(CauHoiModel cauHoiModel)
        {
            string jsonObject = JsonConvert.SerializeObject(cauHoiModel);

            var list = CoreRepo.PostToGetApiResponse<CauHoiModel>(Constance.Constance.UrlApi, "CauHoi/InsertCauHoi/", jsonObject);

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

    }
}