using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Common;

namespace DAL
{
     public class ManagerinfoDal
    {
        /// <summary>
        /// 返回查询的数据
        /// </summary>
        /// <returns></returns>
        public  List<Managerinfo> GetList(Managerinfo mi)
        {
          
            List<Managerinfo> list = new List<Managerinfo>();
            List<SqlParameter> pms = new List<SqlParameter>();
            //SqlParameter[] pms=new SqlParameter[2];
            string sql = "select * from managerinfo ";
            if (mi!=null)
            {
                sql += " where Mname= @Mname and MPwd=@MPwd";
               pms.Add( new SqlParameter("Mname", mi.Mname));
                pms.Add(new SqlParameter("MPwd", MD5Helper.GetMD5(mi.Mpwd)));
            }
            DataTable table = SqlHelper.GetList(sql,pms.ToArray());
            foreach (DataRow row in table.Rows)
            {
                list.Add(new Managerinfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    Mname = row["mname"].ToString(),
                    Mpwd = row["mpwd"].ToString(),
                    MType = Convert.ToInt32(row["mtype"])
                });
            }
            return list;
        }
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="mi">数据对象</param>
        /// <returns></returns>
        public int Addlist(Managerinfo mi)
        {
            //string sql = "insert into managerinfo values(@MName,@MPwd,@MType)";
            SqlParameter[] pms =
            {
                new SqlParameter("@MName",mi.Mname),
                new SqlParameter("@MPwd",MD5Helper.GetMD5( mi.Mpwd)),
                new SqlParameter("@MType",mi.MType)
            };
            int s = SqlHelper.AddList("insert into managerinfo values(@MName,@MPwd,@MType)",pms);
            return s;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public int Updatelist(Managerinfo mi)
        {
            string sql = "update managerinfo set Mname=@Mname,";
            if(!mi.Mpwd.Equals("********"))
            {
                sql += "Mpwd=@Mpwd,";
            }
            sql += "Mtype=@Mtype where Mid=@Mid";
            SqlParameter[] pms =
            {
                new SqlParameter("@Mid",mi.MId),
                new SqlParameter("@Mname",mi.Mname),
                new SqlParameter("@Mpwd",MD5Helper.GetMD5(mi.Mpwd)),
                new SqlParameter("@MType",mi.MType)
            };
            int s = SqlHelper.updatelist(sql,pms);
            return s;
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public int dellist(int mi)
        {
            SqlParameter[] pms =
            {
                new SqlParameter("@Mid",mi)
            };
            int q = SqlHelper.dellist("delete from managerinfo where MId=@Mid", pms);
            return q;
        }
    }
}
