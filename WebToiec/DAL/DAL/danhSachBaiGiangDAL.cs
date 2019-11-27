using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class danhSachBaiGiangDAL : DBContext
    {
        public int Add(DANHSACH_BAIGIANG p)
        {
            int result = 0;
            context.DANHSACH_BAIGIANG.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(DANHSACH_BAIGIANG pma)
        {
            int result = 0;
            DANHSACH_BAIGIANG k = context.DANHSACH_BAIGIANG.FirstOrDefault(m => m.ID_DANHSACH == pma.ID_DANHSACH);
            if (k != null)
            {
                k.TENDANHSACH = pma.TENDANHSACH;
              
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            DANHSACH_BAIGIANG k = context.DANHSACH_BAIGIANG.FirstOrDefault(m => m.ID_DANHSACH == pMa);
            context.DANHSACH_BAIGIANG.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<DANHSACH_BAIGIANG> GetList()
        {
            List<DANHSACH_BAIGIANG> list = new List<DANHSACH_BAIGIANG>();
            list = context.DANHSACH_BAIGIANG.ToList();
            return list;
        }

        public DANHSACH_BAIGIANG GetDVByMa(int pMa)
        {
            DANHSACH_BAIGIANG result = new DANHSACH_BAIGIANG();
            result = context.DANHSACH_BAIGIANG.FirstOrDefault(m => m.ID_DANHSACH == pMa);
            return result;
        }
    }
}
