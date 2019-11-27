using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class user_KhoaHocDAL : DBContext
    {
        public int Add(USER_KHOAHOC p)
        {
            int result = 0;
            context.USER_KHOAHOC.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(USER_KHOAHOC pma)
        {
            int result = 0;
            USER_KHOAHOC k = context.USER_KHOAHOC.FirstOrDefault(m => m.ID_GIA == pma.ID_GIA
                                                                && m.USERID == pma.USERID);
            if (k != null)
            {
                k.TrangThai = pma.TrangThai;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa, int userID)
        {
            int result = 0;
            USER_KHOAHOC k = context.USER_KHOAHOC.FirstOrDefault(m => m.ID_GIA == pMa
                                                               && m.USERID == userID);
            context.USER_KHOAHOC.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<USER_KHOAHOC> GetList()
        {
            List<USER_KHOAHOC> list = new List<USER_KHOAHOC>();
            list = context.USER_KHOAHOC.ToList();
            return list;
        }

        public USER_KHOAHOC GetDVByMa(int pMa, int userID)
        {
            USER_KHOAHOC result = new USER_KHOAHOC();
            result = context.USER_KHOAHOC.FirstOrDefault(m => m.ID_GIA == pMa
                                                               && m.USERID == userID);
            return result;
        }
    }
}
