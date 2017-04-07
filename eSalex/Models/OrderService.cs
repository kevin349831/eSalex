using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eSalex.Models
{
    /// <summary>
    /// 訂單的服務
    /// </summary>
    public class OrderService
    {
        /// <summary>
        /// 取得DB連線字串
        /// </summary>
        /// <returns></returns>
        public string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }
        /// <summary>
        /// 新增訂單
        /// </summary>
        public void InsertOrder(Models.Order order) { 
        
        }
        /// <summary>
        /// 刪除訂單 BY ID
        /// </summary>
        public void DeleteOrderById(String id) { 
        
        }
        /// <summary>
        /// 更新訂單
        /// </summary>
        public void UpdateOrder(Models.Order order) { 
        
        }
        /// <summary>
        /// 取得訂單
        /// </summary>
        /// <param name="id">訂單ID</param>
        /// <returns></returns>
        public Models.Order GetOrderById(string id){
            Models.Order result = new Order();
            result.CustId = "GSS";
            result.CustName = "test資訊";
            return result;
        }
        /// <summary>
        /// 取得訂單
        /// </summary>
        /// <returns></returns>
        public List<Models.Order> GetOrders(){
            List<Models.Order> result = new List<Order>();
            result.Add(new Order() { CustId = "GSS", CustName = "CCCC", EmpId = 1, EmpName = "王小名", Orderdate = DateTime.Parse("2017/01/01") });
            result.Add(new Order() { CustId = "NPOIS", CustName = "BBBBBB", EmpId = 2, EmpName = "陳大名", Orderdate = DateTime.Parse("2017/01/05") });
            return result;
        }

    }
}