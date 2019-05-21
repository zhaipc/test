using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MemberInfodal
    {
        //MemberInfo MemberInfo = new MemberInfo();

        public List<MemberInfo> GetList(MemberInfo mi)
        {
            string sql = "select mi. *,mti.mtitle from memberinfo mi" +
                " inner join membertypeinfo mti"+
                " on mi.mtypeid=mti.mid"+
               " where mi.misdelete=0";
            List<SqlParameter> list = new List<SqlParameter>();
            if(!string.IsNullOrEmpty(mi.MName))
            {
                sql += " and mi.mname like @name";
                list.Add(new SqlParameter("@name","%"+mi.MName+"%"));
            }
            if (!string.IsNullOrEmpty(mi.MPhone))
            {
                sql += " and mi.mphone like @phone";
                list.Add(new SqlParameter("@phone", "%" + mi.MPhone + "%"));
            }
            DataTable dataTable = SqlHelper.GetList(sql,list.ToArray());
            List<MemberInfo> infos = new List<MemberInfo>();
            foreach (DataRow row in dataTable.Rows)
            {
                infos.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MName = row["mname"].ToString(),
                    MMoney = Convert.ToDecimal(row["mmoney"]),
                    MPhone=row["mphone"].ToString(),
                    MIsDelete=Convert.ToBoolean( row["misdelete"]),
                    MTypeId=Convert.ToInt32(row["mtypeid"]),
                    TypeTitle=row["mtitle"].ToString()
                });
            }
            return infos;
        }

        public int AddList(MemberInfo mi)
        {
            string sql = "insert into memberinfo (mtypeid,mname,mphone,mmoney,misdelete) values(@tid,@name,@phone,@money,0)";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@tid",mi.MTypeId),
                new SqlParameter("@name",mi.MName),
                new SqlParameter("@phone",mi.MPhone),
                new SqlParameter("@money",mi.MMoney)
            };
            return SqlHelper.AddList(sql, pms);
        }
        public int Updatelist(MemberInfo mi)
        {
            string sql = "update memberinfo set mtypeid=@tid,mname=@name,mphone=@phone,mmoney=@money where mid=@id";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@tid",mi.MTypeId),
                new SqlParameter("@name",mi.MName),
                new SqlParameter("@phone",mi.MPhone),
                new SqlParameter("@money",mi.MMoney),
                new SqlParameter("@id",mi.MId)
            };
            return SqlHelper.updatelist(sql, pms);
        }
        public int Deletelist(MemberInfo mi)
        {
            string sql = "update memberinfo set misdelete=1 where mid=@id";
            SqlParameter[] pms =
            {
                new SqlParameter("@id",mi.MId)
            };
            return SqlHelper.updatelist(sql, pms);
        }


    }
}
