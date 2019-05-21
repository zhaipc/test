using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class SqlHelper
    {
        private static readonly string constr = System.Configuration.ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
        /// <summary>
        /// 返回查询的数据表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetList(string sql,params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                //桥接器对象
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                //添加参数
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                //数据表对象
              
                DataTable dataTable = new DataTable();
                //填充数据表
                adapter.Fill(dataTable);
                //返回数据表
                return dataTable;
            }
        }
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="pms">参数</param>
        /// <returns></returns>
        public static int AddList(string sql,params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                if(pms!=null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                return  cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static int updatelist(string sql,params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if(pms!=null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                con.Open();
               return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pms">参数</param>
        /// <returns></returns>
        public static int dellist(string sql,params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if(pms!=null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                con.Open();
              return  cmd.ExecuteNonQuery();
            }
        }
    }
}
