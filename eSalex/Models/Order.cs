using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Order
    {
        /// <summary>
        /// 建構式
        /// </summary>
        public Order()
        {
            var ods = new List<Models.OrderDetails>();
            ods.Add(new OrderDetails() { ProductId = 58 });
            this.OrderDetails = ods;

        }

        /// <summary>
        /// 訂單編號
        /// </summary>

        [DisplayName("訂單編號")]
        [Required()]
        public int OrderId { get; set; }

        /// <summary>
        /// 客戶代號
        /// </summary>
        [MaxLength(3)]
        [DisplayName("客戶代號")]
        public string CustomerID { get; set; }

        /// <summary>
        /// 客戶名稱
        /// </summary>
        [DisplayName("客戶名稱")]
        public string CustName { get; set; }

        /// <summary>
        /// 業務(員工)代號
        /// </summary>
        [DisplayName("負責員工編號")]
        public int EmployeeID { get; set; }

        /// <summary>
        /// 業務(員工姓名)
        /// </summary>
        /// 
        [DisplayName("負責員工名稱")]
        public string EmpName { get; set; }

        /// <summary>
        /// 訂單日期
        /// </summary>
        /// 
        [DisplayName("訂單日期")]
        public DateTime? Orderdate { get; set; }

        /// <summary>
        /// 需要日期
        /// </summary>
        /// 
        [DisplayName("需要日期")]
        public DateTime? RequireDdate { get; set; }

        /// <summary>
        /// 出貨日期
        /// </summary>
        /// 
        [DisplayName("出貨日期")]
        public DateTime? ShippedDate { get; set; }

        /// <summary>
        /// 出貨公司代號
        /// </summary>
        /// 
        [DisplayName("出貨公司代號")]
        public int ShipperId { get; set; }

        /// <summary>
        /// 出貨公司名稱
        /// </summary>
        /// 
        [DisplayName("出貨公司名稱")]
        public string ShipperName { get; set; }

        /// <summary>
        /// 運費
        /// </summary>
        /// 
        [Range(0, double.MaxValue)]
        [DisplayName("運費")]
        public decimal Freight { get; set; }

        /// <summary>
        /// 出貨說明
        /// </summary>
        /// 
        [DisplayName("出貨說明")]
        public string ShipName { get; set; }

        /// <summary>
        /// 出貨地址
        /// </summary>
        /// 
        [DisplayName("出貨地址")]
        public string ShipAddress { get; set; }

        /// <summary>
        /// 出貨城市
        /// </summary>
        /// 
        [DisplayName("出貨城市")]
        public string ShipCity { get; set; }

        /// <summary>
        /// 出貨地區
        /// </summary>
        /// 
        [DisplayName("出貨地區")]
        public string ShipRegion { get; set; }

        /// <summary>
        /// 郵遞區號
        /// </summary>
        /// 
        [DisplayName("郵遞區號")]
        public string ShipPostalCode { get; set; }

        /// <summary>
        /// 出貨國家
        /// </summary>
        /// 
        [DisplayName("出貨國家")]
        public string ShipCountry { get; set; }

        /// <summary>
        /// 訂單明細
        /// </summary>
        public List<OrderDetails> OrderDetails { get; set; }


    }
}