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
   public class Membertypeinfodal
    {
        public List<Membertypeinfo> GetList()
        {
            List<Membertypeinfo> list = new List<Membertypeinfo>();
            string sql = "select * from membertypeinfo where misdelete=0";
            DataTable dataTable = SqlHelper.GetList(sql);
            foreach (DataRow rows in dataTable.Rows)
            {
                list.Add(new Membertypeinfo()
                {
                    Mid = Convert.ToInt32(rows["mid"]),
                    Mtitle = rows["mtitle"].ToString(),
                    Mdiscount=Convert.ToDecimal(rows["mdiscount"]),
                    Misdelete=Convert.ToBoolean(rows["misdelete"])
                } );
            }
            return list;
        }

        public int AddList(Membertypeinfo mi)
        {
            string sql = "insert into membertypeinfo(mtitle,mdiscount,misdelete) values (@title,@discount,0)";
            SqlParameter[] pms=
            {
                new SqlParameter("@title",mi.Mtitle),
                new SqlParameter("@discount",mi.Mdiscount)
            };
           return SqlHelper.AddList(sql, pms);
        }

        public int UpdateList(Membertypeinfo mi)
        {
            string sql = "update membertypeinfo set mtitle=@title,mdiscount=@discount where mid=@id";
            SqlParameter[] pms =
            {
                new SqlParameter("@id",mi.Mid),
                new SqlParameter("@title",mi.Mtitle),
                new SqlParameter(@"discount",mi.Mdiscount)
            };
            return SqlHelper.updatelist(sql, pms);
        }

        public int Deletelist(Membertypeinfo mi)
        {
            string sql = "update membertypeinfo set misdelete=1 where mid=@id";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@id",mi.Mid)
            };
           return SqlHelper.updatelist(sql, pms);
        }
    }
}
