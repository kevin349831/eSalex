using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
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
		private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="order"></param>
        /// <returns>訂單編號</returns>
        public int InsertOrder(Models.Order order)
        {
            string sql = @" Insert INTO Sales.Orders
						 (
							CustomerID,EmployeeID,orderdate,requireddate,shippeddate,shipperid,freight,
							shipname,shipaddress,shipcity,shipregion,shippostalcode,shipcountry
						)
						VALUES
						(
							@CustomerID,@EmployeeID,@orderdate,@requireddate,@shippeddate,@shipperid,@freight,
							@shipname,@shipaddress,@shipcity,@shipregion,@shippostalcode,@shipcountry
						)
						Select SCOPE_IDENTITY()
						";
            int orderId;
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@CustomerID", order.CustomerID));
                cmd.Parameters.Add(new SqlParameter("@EmployeeID", order.EmployeeID));
                cmd.Parameters.Add(new SqlParameter("@orderdate", order.Orderdate));
                cmd.Parameters.Add(new SqlParameter("@requireddate", order.RequireDdate));
                cmd.Parameters.Add(new SqlParameter("@shippeddate", order.ShippedDate));
                cmd.Parameters.Add(new SqlParameter("@shipperid", order.ShipperId));
                cmd.Parameters.Add(new SqlParameter("@freight", order.Freight));
                cmd.Parameters.Add(new SqlParameter("@shipname", order.ShipperName));
                cmd.Parameters.Add(new SqlParameter("@shipaddress", order.ShipAddress));
                cmd.Parameters.Add(new SqlParameter("@shipcity", order.ShipCity));
                cmd.Parameters.Add(new SqlParameter("@shipregion", order.ShipRegion));
                cmd.Parameters.Add(new SqlParameter("@shippostalcode", order.ShipPostalCode));
                cmd.Parameters.Add(new SqlParameter("@shipcountry", order.ShipCountry));

                orderId = (int)cmd.ExecuteScalar();
                conn.Close();
            }
            return orderId;

        }
        /// <summary>
        /// 依照Id 取得訂單資料
        /// </summary>
        /// <returns></returns>
        public Models.Order GetOrderById(string orderId)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT 
					A.OrderID,A.CustomerID,B.CompanyName As CustName,
					A.EmployeeID,C.LastName+ C.firstname As EmpName,
					A.Orderdate,A.RequireDdate,A.ShippedDate,
					A.ShipperId,D.CompanyName As ShipperName,A.Freight,
					A.ShipName,A.ShipAddress,A.ShipCity,A.ShipRegion,A.ShipPostalCode,A.ShipCountry
					From Sales.Orders As A 
					INNER JOIN Sales.Customers As B ON A.CustomerID=B.CustomerID
					INNER JOIN HR.Employees As C On A.EmployeeID=C.EmployeeID
					inner JOIN Sales.Shippers As D ON A.ShipperID=D.ShipperID
					Where  A.OrderId=@OrderId";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@OrderId", orderId));

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapOrderDataToList(dt).FirstOrDefault();
        }
        /// <summary>
        /// 依照條件取得訂單資料
        /// </summary>
        /// <returns></returns>
        public List<Models.Order> GetOrderByCondtioin(Models.OrderSearchArg arg)
        {

            DataTable dt = new DataTable();
            string sql = @"SELECT 
					A.OrderId,A.CustomerID,B.Companyname As CustName,
					A.EmployeeID,C.lastname+ C.firstname As EmpName,
					A.Orderdate,A.RequireDdate,A.ShippedDate,
					A.ShipperId,D.companyname As ShipperName,A.Freight,
					A.ShipName,A.ShipAddress,A.ShipCity,A.ShipRegion,A.ShipPostalCode,A.ShipCountry
					From Sales.Orders As A 
					INNER JOIN Sales.Customers As B ON A.CustomerID=B.CustomerID
					INNER JOIN HR.Employees As C On A.EmployeeID=C.EmployeeID
					inner JOIN Sales.Shippers As D ON A.shipperid=D.shipperid
					Where (B.Companyname Like '%' + @CustName + '%' Or @CustName='') And 
						  (A.Orderdate=@Orderdate Or @Orderdate='') ";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@OrderId", arg.OrderId == null ? string.Empty : arg.OrderId));
                cmd.Parameters.Add(new SqlParameter("@CustName", arg.CustName == null ? string.Empty : arg.CustName));
                cmd.Parameters.Add(new SqlParameter("@Orderdate", arg.OrderDate == null ? string.Empty : arg.OrderDate));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }


            return this.MapOrderDataToList(dt);
        }
        /// <summary>
        /// 刪除訂單
        /// </summary>
        public void DeleteOrderById(string orderId)
        {
            try
            {
                string sql = "Delete FROM Sales.Orders Where orderid=@orderid";
                using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@orderid", orderId));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// 更新訂單
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrder(Models.Order order)
        {
            string sql = @"Update 
							Sales.Orders SET 
							CustomerID=@CustomerID,EmployeeID=@EmployeeID,
							orderdate=@orderdate,requireddate=@requireddate,
							shippeddate=@shippeddate,shipperid=@shipperid,
							freight=@freight,shipname=@shipname,
							shipaddress=@shipaddress,shipcity=@shipcity,
							shipregion=@shipregion,shippostalcode=@shippostalcode,
							shipcountry=@shipcountry
							WHERE orderid=@orderid";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@CustomerID", order.CustomerID));
                cmd.Parameters.Add(new SqlParameter("@EmployeeID", order.EmployeeID));
                cmd.Parameters.Add(new SqlParameter("@orderdate", order.Orderdate));
                cmd.Parameters.Add(new SqlParameter("@requireddate", order.RequireDdate));
                cmd.Parameters.Add(new SqlParameter("@shippeddate", order.ShippedDate));
                cmd.Parameters.Add(new SqlParameter("@shipperid", order.ShipperId));
                cmd.Parameters.Add(new SqlParameter("@freight", order.Freight));
                cmd.Parameters.Add(new SqlParameter("@shipname", order.ShipperName));
                cmd.Parameters.Add(new SqlParameter("@shipaddress", order.ShipAddress));
                cmd.Parameters.Add(new SqlParameter("@shipcity", order.ShipCity));
                cmd.Parameters.Add(new SqlParameter("@shipregion", order.ShipRegion));
                cmd.Parameters.Add(new SqlParameter("@shippostalcode", order.ShipPostalCode));
                cmd.Parameters.Add(new SqlParameter("@shipcountry", order.ShipCountry));
                cmd.Parameters.Add(new SqlParameter("@orderid", order.OrderId));
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

        private List<Models.Order> MapOrderDataToList(DataTable orderData)
        {
            List<Models.Order> result = new List<Order>();


            foreach (DataRow row in orderData.Rows)
            {
                result.Add(new Order()
                {
                    CustomerID = row["CustomerID"].ToString(),
                    CustName = row["CustName"].ToString(),
                    EmployeeID = (int)row["EmployeeID"],
                    EmpName = row["EmpName"].ToString(),
                    Freight = (decimal)row["Freight"],
                    Orderdate = row["Orderdate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["Orderdate"],
                    OrderId = (int)row["OrderId"],
                    RequireDdate = row["RequireDdate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["RequireDdate"],
                    ShipAddress = row["ShipAddress"].ToString(),
                    ShipCity = row["ShipCity"].ToString(),
                    ShipCountry = row["ShipCountry"].ToString(),
                    ShipName = row["ShipName"].ToString(),
                    ShippedDate = row["ShippedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["ShippedDate"],
                    ShipperId = (int)row["ShipperId"],
                    ShipperName = row["ShipperName"].ToString(),
                    ShipPostalCode = row["ShipPostalCode"].ToString(),
                    ShipRegion = row["ShipRegion"].ToString()
                });
            }
            return result;
        }
    }
}