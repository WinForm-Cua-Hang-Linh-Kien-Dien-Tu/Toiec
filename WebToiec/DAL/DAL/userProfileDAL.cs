using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class userProfileDAL : DBContext
    {
        public int Add(USERS_PROFILE p)
        {
            int result = 0;
            context.USERS_PROFILE.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(USERS_PROFILE pma)
        {
            int result = 0;
            USERS_PROFILE k = context.USERS_PROFILE.FirstOrDefault(m => m.USERID == pma.USERID);
            if (k != null)
            {
                k.HOTEN = pma.HOTEN;
                k.NGAYSINH = pma.NGAYSINH;
                k.GIOITINH = pma.GIOITINH;
                k.NGHENGHIEP = pma.NGHENGHIEP;
                k.NGAYSINH = pma.NGAYSINH;
                k.SDT = pma.SDT;
                k.EMAIL = pma.EMAIL;
                pma.THANHPHO = pma.THANHPHO;
                k.CAPDO = pma.CAPDO;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            USERS_PROFILE k = context.USERS_PROFILE.FirstOrDefault(m => m.USERID == pMa);
            context.USERS_PROFILE.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<USERS_PROFILE> GetList()
        {
            List<USERS_PROFILE> list = new List<USERS_PROFILE>();
            list = context.USERS_PROFILE.ToList();
            return list;
        }

        public USERS_PROFILE GetDVByMa(int pMa)
        {
            USERS_PROFILE result = new USERS_PROFILE();
            result = context.USERS_PROFILE.FirstOrDefault(m => m.USERID == pMa);
            return result;
        }
    }
}
