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
            return new List<Order>();
        }

    }
}