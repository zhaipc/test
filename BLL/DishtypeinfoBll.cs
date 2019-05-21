using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
   public class DishtypeinfoBll
    {
        Dishtypeinfodal dd = new Dishtypeinfodal();
        public List<DishTypeInfo> Getlist()
        {
            return dd.Getlist();
        }
        public bool Addlist(DishTypeInfo di)
        {
            return dd.Addlist(di) > 0;
        }

        public bool Updatelist(DishTypeInfo di)
        {
            return dd.Upadtelist(di) > 0;
        }

        public bool Deletelist(DishTypeInfo di)
        {
            return dd.DeleteList(di) > 0;
        }
    }
}
