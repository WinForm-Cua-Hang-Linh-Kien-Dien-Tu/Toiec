using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class user_ChuDEDAL : DBContext
    {
        public int Add(USER_CHUDE p)
        {
            int result = 0;
            context.USER_CHUDE.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(USER_CHUDE pma)
        {
            int result = 0;
            USER_CHUDE k = context.USER_CHUDE.FirstOrDefault(m => m.MACHUDE == pma.MACHUDE
                                                                && m.USERID == pma.USERID);
            if (k != null)
            {
                k.TRANGTHAI = pma.TRANGTHAI;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa, int userID)
        {
            int result = 0;
            USER_CHUDE k = context.USER_CHUDE.FirstOrDefault(m => m.MACHUDE == pMa
                                                               && m.USERID == userID);
            context.USER_CHUDE.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<USER_CHUDE> GetList()
        {
            List<USER_CHUDE> list = new List<USER_CHUDE>();
            list = context.USER_CHUDE.ToList();
            return list;
        }

        public USER_CHUDE GetDVByMa(int pMa, int userID)
        {
            USER_CHUDE result = new USER_CHUDE();
            result = context.USER_CHUDE.FirstOrDefault(m => m.MACHUDE == pMa
                                                               && m.USERID == userID);
            return result;
        }
    }
}
