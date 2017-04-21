using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class CodeService
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
        /// 取得產品
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetProduct()
        {
            DataTable dt = new DataTable();
            string sql = @"Select Productid As CodeId,Productname As CodeName From Production.Products";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }

        /// <summary>
        /// 取得員工資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetEmp()
        {
            DataTable dt = new DataTable();
            string sql = @"Select EmployeeID As CodeId,Lastname+'-'+Firstname As CodeName FROM HR.Employees";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }

        /// <summary>
        /// 取得客戶資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCustomer()
        {
            DataTable dt = new DataTable();
            string sql = @"Select CustomerID As CodeId,CompanyName As CodeName FROM Sales.Customers";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }

        /// <summary>
        /// Maping 代碼資料
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<SelectListItem> MapCodeData(DataTable dt)
        {
            List<SelectListItem> result = new List<SelectListItem>();

            result.Add(new SelectListItem()
            {
                Text = "",
                Value = ""
            });

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["CodeName"].ToString(),
                    Value = row["CodeId"].ToString()
                });
            }
            return result;
        }
    }
}