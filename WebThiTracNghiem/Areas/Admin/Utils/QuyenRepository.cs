﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Models;
using WebThiTracNghiem.Repository;

namespace WebThiTracNghiem.Areas.Admin.Utils
{
    public class QuyenRepository
    {

        public ApiResponse<QuyenModel> GetAllCauHoi()
        {
            var list = CoreRepo.GetApiResponse<QuyenModel>(Constance.Constance.UrlApi, "Quyens/GetAllQuyen/");

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list;

            return list;
        }

    }
}