using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eSalex.Controllers
{
    public class LayoutTestController : Controller
    {
        /// <summary>
        /// 測試主版頁面
        /// </summary>
        /// <returns></returns>
        // GET: LayoutTest
        public ActionResult Index()
        {
            return View();
        }
    }
}