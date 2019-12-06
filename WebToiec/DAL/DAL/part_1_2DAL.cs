using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class part_1_2DAL : DBContext
    {
        public int Add(PART_1_2 p)
        {
            int result = 0;
            context.PART_1_2.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(PART_1_2 pma)
        {
            int result = 0;
            PART_1_2 k = context.PART_1_2.FirstOrDefault(m => m.ID_CAU_PART1_2 == pma.ID_CAU_PART1_2);
            if (k != null)
            {
                k.ID_BAIGIANG = pma.ID_BAIGIANG;
                k.HINH = pma.HINH;
                k.AM_THANH = pma.AM_THANH;
                k.DAP_AN_DUNG = pma.DAP_AN_DUNG;
                k.TEXT = pma.TEXT;
               
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            PART_1_2 k = context.PART_1_2.FirstOrDefault(m => m.ID_CAU_PART1_2 == pMa);
            context.PART_1_2.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<PART_1_2> GetList()
        {
            List<PART_1_2> list = new List<PART_1_2>();
            list = context.PART_1_2.ToList();
            return list;
        }

        public PART_1_2 GetDVByMa(int pMa)
        {
            PART_1_2 result = new PART_1_2();
            result = context.PART_1_2.FirstOrDefault(m => m.ID_CAU_PART1_2 == pMa);
            return result;
        }

        public List<PART_1_2> GetCauHoiBG(int pMa)
        {
            var result = context.PART_1_2.Where(m => m.ID_BAIGIANG == pMa).ToList();
            return result;
        }
    }
}
