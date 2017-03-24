﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eSalex.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            //Models.OrderService orderService = new Models.OrderService();
            //var order = orderService.GetOrderById("111");
            //ViewBag.CustId = order.CustId;
            //ViewBag.CustName = order.CustName;
            ViewBag.Desc1 = "I'm ViewBag";
            ViewData["Desc2"] = "I'm ViewData";
            TempData["Desc3"] = "I'm TempData";
            return View();
        }

        public ActionResult Index2(String id)
        {
            ViewBag.id = id;
            return View();

        }
        /// <summary>
        /// 新增訂單的畫面
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertOrder()
        {
            return View();

        }
        /// <summary>
        /// 新增訂單存檔的ACTION
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult InsertOrder(Models.Order order)
        {
            Models.OrderService orderService = new Models.OrderService();
            orderService.InsertOrder(order);
            return View("Index");
        }
        [HttpGet()]
        public JsonResult TestJson()
        {
            ///var result = new Models.Order();
            ///result.CustId = "HAOYU";
            ///result.CustName = "LALLA";

            var result = new Models.Order() { CustId = "SSS", CustName = "BBB" };
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}