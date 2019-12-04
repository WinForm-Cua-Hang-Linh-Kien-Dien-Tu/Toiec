using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class user_BaiGiangDAL : DBContext
    {
        public int Add(USER_BAIGIANG p)
        {
            int result = 0;
            context.USER_BAIGIANG.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(USER_BAIGIANG pma)
        {
            int result = 0;
            USER_BAIGIANG k = context.USER_BAIGIANG.FirstOrDefault(m => m.ID_BAIGIANG == pma.ID_BAIGIANG 
                                                                     && m.USERID == pma.USERID);
            if (k != null)
            {
                k.TRANG_THAI = pma.TRANG_THAI;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa, int userID)
        {
            int result = 0;
            USER_BAIGIANG k = context.USER_BAIGIANG.FirstOrDefault(m => m.ID_BAIGIANG == pMa
                                                                     && m.USERID == userID);
            context.USER_BAIGIANG.Remove(k);
            result = context.SaveChanges();
            return result;
        }

        public List<USER_BAIGIANG> GetList()
        {
            List<USER_BAIGIANG> list = new List<USER_BAIGIANG>();
            list = context.USER_BAIGIANG.ToList();
            return list;
        }

        public List<USER_BAIGIANG> GetList(int id)
        {
            List<USER_BAIGIANG> list = new List<USER_BAIGIANG>();
            list = context.USER_BAIGIANG.Where(m => m.USERID == id).ToList();
            return list;
        }

        public USER_BAIGIANG GetDVByMa(int pMa, int userID)
        {
            USER_BAIGIANG result = new USER_BAIGIANG();
            result = context.USER_BAIGIANG.FirstOrDefault(m => m.ID_BAIGIANG == pMa
                                                                     && m.USERID == userID);
            return result;
        }
    }
}
