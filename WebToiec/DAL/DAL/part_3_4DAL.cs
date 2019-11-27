using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class part_3_4DAL : DBContext
    {
        public int Add(PART_3_4 p)
        {
            int result = 0;
            context.PART_3_4.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(PART_3_4 pma)
        {
            int result = 0;
            PART_3_4 k = context.PART_3_4.FirstOrDefault(m => m.ID_CAU_PART3_4 == pma.ID_CAU_PART3_4);
            if (k != null)
            {
                k.ID_BAIGIANG = pma.ID_BAIGIANG;
                k.AMTHANH = pma.AMTHANH;
                k.TEXT = pma.TEXT;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            PART_3_4 k = context.PART_3_4.FirstOrDefault(m => m.ID_CAU_PART3_4 == pMa);
            context.PART_3_4.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<PART_3_4> GetList()
        {
            List<PART_3_4> list = new List<PART_3_4>();
            list = context.PART_3_4.ToList();
            return list;
        }

        public PART_3_4 GetDVByMa(int pMa)
        {
            PART_3_4 result = new PART_3_4();
            result = context.PART_3_4.FirstOrDefault(m => m.ID_CAU_PART3_4 == pMa);
            return result;
        }
    }
}
