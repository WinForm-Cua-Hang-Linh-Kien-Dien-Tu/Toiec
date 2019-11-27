using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class usersDAL : DBContext
    {
        public int Add(USERS p)
        {
            int result = 0;
            context.USERS.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(USERS pma)
        {
            int result = 0;
            USERS k = context.USERS.FirstOrDefault(m => m.USERID == pma.USERID);
            if (k != null)
            {
                k.TAIKHOANUSER = pma.TAIKHOANUSER;
                k.MATKHAUUSER = pma.MATKHAUUSER;
                k.NGAYTAO = pma.NGAYTAO;
                k.NGAYBATDAU = pma.NGAYBATDAU;
                k.NGAYKETTHUC = pma.NGAYKETTHUC;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            USERS k = context.USERS.FirstOrDefault(m => m.USERID == pMa);
            context.USERS.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<USERS> GetList()
        {
            List<USERS> list = new List<USERS>();
            list = context.USERS.ToList();
            return list;
        }

        public USERS GetDVByMa(int pMa)
        {
            USERS result = new USERS();
            result = context.USERS.FirstOrDefault(m => m.USERID == pMa);
            return result;
        }

    }
}
