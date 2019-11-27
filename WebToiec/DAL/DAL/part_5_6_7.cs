using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class part_5_6_7 : DBContext
    {
        public int Add(PART_5_6_7 p)
        {
            int result = 0;
            context.PART_5_6_7.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(PART_5_6_7 pma)
        {
            int result = 0;
            PART_5_6_7 k = context.PART_5_6_7.FirstOrDefault(m => m.ID_CAU_PART5_6_7 == pma.ID_CAU_PART5_6_7);
            if (k != null)
            {
                k.ID_BAIGIANG = pma.ID_BAIGIANG;
                k.NOIDUNGCAUHOI = pma.NOIDUNGCAUHOI;
               
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            PART_5_6_7 k = context.PART_5_6_7.FirstOrDefault(m => m.ID_CAU_PART5_6_7 == pMa);
            context.PART_5_6_7.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<PART_5_6_7> GetList()
        {
            List<PART_5_6_7> list = new List<PART_5_6_7>();
            list = context.PART_5_6_7.ToList();
            return list;
        }

        public PART_5_6_7 GetDVByMa(int pMa)
        {
            PART_5_6_7 result = new PART_5_6_7();
            result = context.PART_5_6_7.FirstOrDefault(m => m.ID_CAU_PART5_6_7 == pMa);
            return result;
        }
    }
}
