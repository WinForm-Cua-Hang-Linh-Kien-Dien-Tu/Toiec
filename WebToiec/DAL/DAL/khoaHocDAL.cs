using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class khoaHocDAL : DBContext
    {
        public int Add(KHOAHOC p)
        {
            int result = 0;
            context.KHOAHOC.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(KHOAHOC pma)
        {
            int result = 0;
            KHOAHOC k = context.KHOAHOC.FirstOrDefault(m => m.ID_GIA == pma.ID_GIA);
            if (k != null)
            {
                k.GIATIEN = pma.GIATIEN;
                k.THOIGIAN = pma.THOIGIAN;
               
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            KHOAHOC k = context.KHOAHOC.FirstOrDefault(m => m.ID_GIA == pMa);
            context.KHOAHOC.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<KHOAHOC> GetList()
        {
            List<KHOAHOC> list = new List<KHOAHOC>();
            list = context.KHOAHOC.ToList();
            return list;
        }

        public KHOAHOC GetDVByMa(int pMa)
        {
            KHOAHOC result = new KHOAHOC();
            result = context.KHOAHOC.FirstOrDefault(m => m.ID_GIA == pMa);
            return result;
        }
    }
}
