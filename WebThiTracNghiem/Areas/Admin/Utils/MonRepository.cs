using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebThiTracNghiem.Areas.Admin.Data;
using WebThiTracNghiem.Repository;

namespace WebThiTracNghiem.Areas.Admin.Utils
{
    public class MonRepository
    {
        public List<MonModel> GetMonThiToDropDownList()
        {
            var list = CoreRepo.GetApiResponse<MonModel>(Constance.Constance.UrlApi, "MonThi/GetAllMonThi/");

            if (list.Status == (int)HttpStatusCode.NotFound)
                return list.Data;

            return list.Data;
        }
    }
}