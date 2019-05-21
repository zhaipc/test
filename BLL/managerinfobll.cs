using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public  class managerinfobll
    {
        ManagerinfoDal miDal = new ManagerinfoDal();
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public List<Managerinfo> Getlist()
        {
            return miDal.GetList(null);
        }

        public bool Login(Managerinfo mi)
        {
            var list = miDal.GetList(mi);
            if(list.Count>0)
            {
                mi.MType = list[0].MType;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public bool Addlist(Managerinfo mi)
        {
            int r = miDal.Addlist(mi);
            if(r>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool UpdateList(Managerinfo mi)
        {
            int r = miDal.Updatelist(mi);
            if(r>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool dellist(int mi)
        {
            int r = miDal.dellist(mi);
            if(r>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
