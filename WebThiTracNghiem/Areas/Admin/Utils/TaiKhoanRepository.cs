using Newtonsoft.Json;
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
    public class TaiKhoanRepository
    {
        public bool login(string userName, string password)
        {
            var apiResponse = CoreRepo.GetApiResponse<TaiKhoan>(Constance.Constance.UrlApi, "TaiKhoan/GetTaiKhoanById/" + userName);

            if (apiResponse.Status == (int)HttpStatusCode.NotFound)
                return false;

            return true;
        }
    }
}