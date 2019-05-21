using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class MemberinfoBll
    {
        MemberInfodal md = new MemberInfodal();
        public List<MemberInfo> GetList(MemberInfo mi)
        {
            return md.GetList(mi);
        }

        public bool Addlist(MemberInfo mi)
        {
            return md.AddList(mi) > 0;
        }
        public bool Updatelist(MemberInfo mi)
        {
            return md.Updatelist(mi) > 0;
        }

        public bool Delete(MemberInfo mi)
        {
            return md.Deletelist(mi) > 0;
        }
    }
}
