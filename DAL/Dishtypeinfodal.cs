using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class Dishtypeinfodal
    {
        public List<DishTypeInfo> Getlist()
        {
            string sql = "select * from dishtypeinfo where disdelete=0";
            DataTable dt = SqlHelper.GetList(sql);
            List<DishTypeInfo> list = new List<DishTypeInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DishTypeInfo() {
                    DId=Convert.ToInt32( row["did"]),
                    DTitle = row["dtitle"].ToString(),
                    DIsDelete=Convert.ToBoolean(row["disdelete"])
                });
            }
            return list;
        }

        public int Upadtelist(DishTypeInfo di)
        {
            string sql = "update dishtypeinfo set dtitle=@title where did=@id";
            SqlParameter[] pms =
            {
                new SqlParameter("@title",di.DTitle),
                new SqlParameter("@id",di.DId)
            };
           return SqlHelper.updatelist(sql, pms);
        }

        public int Addlist(DishTypeInfo di)
        {
            string sql = "insert into dishtypeinfo (dtitle,disdelete) values(@title,0)";
            SqlParameter[] pms =
            {
                new SqlParameter("@title",di.DTitle)
            };
            return SqlHelper.AddList(sql, pms);
        }

        public int DeleteList(DishTypeInfo di)
        {
            string sql = "update dishtypeinfo set disdelete=1 where did=@id";
            SqlParameter[] pms =
            {
                new SqlParameter("@id",di.DId)
            };
            return SqlHelper.updatelist(sql, pms);
        }
    }
}
