using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class adminDAL : DBContext
    {
        public int Add(ADMIN p)
        {
            int result = 0;
            context.ADMIN.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(ADMIN pma)
        {
            int result = 0;
            ADMIN k = context.ADMIN.FirstOrDefault(m => m.ID == pma.ID);
            if (k != null)
            {
               
                k.MATKHAU = pma.MATKHAU;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            ADMIN k = context.ADMIN.FirstOrDefault(m => m.ID == pMa);
            context.ADMIN.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<ADMIN> GetList()
        {
            List<ADMIN> list = new List<ADMIN>();
            list = context.ADMIN.ToList();
            return list;
        }

        public ADMIN GetDVByMa(string pMa)
        {
            ADMIN result = new ADMIN();
            result = context.ADMIN.FirstOrDefault(m => m.TAIKHOAN == pMa); 
            return result;
        }
    }
}
