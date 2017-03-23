using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eSalex.Models
{
    public class Order
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 客戶代號
        /// </summary>
        public string CustId { get; set; }
        /// <summary>
        /// 客戶名稱
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 業務(員工代號)
        /// </summary>
        public int EmpId { get; set; }
        /// <summary>
        /// 業務(員工姓名)
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 訂單日期
        /// </summary>
        public DateTime? Orderdate { get; set; }
        /// <summary>
        /// 需要日期
        /// </summary>
        public DateTime? ShippedDate { get; set; }
        /// <summary>
        /// 出貨日期
        /// </summary>
        public int ShipperId { get; set; }
        /// <summary>
        /// 出貨公司名稱
        /// </summary>
        public int ShipName { get; set; }
        /// <summary>
        /// 出貨地址
        /// </summary>
        public string ShipAddress { get; set; }
        /// <summary>
        /// 出貨程式
        /// </summary>
        public string ShipCity { get; set; }
        /// <summary>
        /// 出貨地區
        /// </summary>
        public string ShipRegion { get; set; }
        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string ShipPostalCode { get; set; }
        /// <summary>
        /// 出貨國家
        /// </summary>
        public string ShipCountry { get; set; }
    }
}