using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
     public class Membertypeinfobll
    {
        Membertypeinfodal md = new Membertypeinfodal();
        public List<Membertypeinfo> GetList()
        {
           return md.GetList();
        }

        public bool AddList(Membertypeinfo mi)
        {
           int s= md.AddList(mi);
            if(s>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateList(Membertypeinfo mi)
        {
            return md.UpdateList(mi) > 0;
        }

        public bool DeleteList(Membertypeinfo mi)
        {
            return md.Deletelist(mi) > 0;
        }
    }
}
