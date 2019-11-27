using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class cauHoi_3_4DAL : DBContext
    {
        public int Add(CAUHOI_3_4 p)
        {
            int result = 0;
            context.CAUHOI_3_4.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(CAUHOI_3_4 pma)
        {
            int result = 0;
            CAUHOI_3_4 k = context.CAUHOI_3_4.FirstOrDefault(m => m.ID_CAUHOI_34 == pma.ID_CAUHOI_34);
            if (k != null)
            {
                k.ID_CAU_PART_3_4 = pma.ID_CAU_PART_3_4;
                k.NOIDUNG = pma.NOIDUNG;
                k.STT = pma.STT;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            CAUHOI_3_4 k = context.CAUHOI_3_4.FirstOrDefault(m => m.ID_CAUHOI_34 == pMa);
            context.CAUHOI_3_4.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<CAUHOI_3_4> GetList()
        {
            List<CAUHOI_3_4> list = new List<CAUHOI_3_4>();
            list = context.CAUHOI_3_4.ToList();
            return list;
        }

        public CAUHOI_3_4 GetDVByMa(int pMa)
        {
            CAUHOI_3_4 result = new CAUHOI_3_4();
            result = context.CAUHOI_3_4.FirstOrDefault(m => m.ID_CAUHOI_34 == pMa);
            return result;
        }
    }
}
