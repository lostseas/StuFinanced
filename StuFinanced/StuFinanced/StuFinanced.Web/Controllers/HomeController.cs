﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StuFinanced.BLL;
using StuFinanced.Common;

namespace StuFinanced.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Download(int pageIndex = 1)
        {
            int totalCount;
            ViewData["listData"] = new BLLDownload().GetListBy(pageIndex, (int)Common.ComFiled.ComEunm.PageCount.首页其他, u => u.D_Name != null, u => u.D_Time, false, out totalCount);
            ViewBag.pageCount = totalCount / ((int)Common.ComFiled.ComEunm.PageCount.首页其他);
            ViewBag.pageIndex = pageIndex;
            return View();
        }
        public ActionResult AboutUS()
        {
            return View();

        }
    }
}
