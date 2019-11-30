using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class cauHoiPart_6_7DAL :DBContext
    {
        public int Add(CAUHOIPART_6_7 p)
        {
            int result = 0;
            context.CAUHOIPART_6_7.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(CAUHOIPART_6_7 pma)
        {
            int result = 0;
            CAUHOIPART_6_7 k = context.CAUHOIPART_6_7.FirstOrDefault(m => m.IDCAUHOI_567 == pma.IDCAUHOI_567);
            if (k != null)
            {
                k.ID_CAU_PART_567 = pma.ID_CAU_PART_567;
                k.NOI_DUNG = pma.NOI_DUNG;
               
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            CAUHOIPART_6_7 k = context.CAUHOIPART_6_7.FirstOrDefault(m => m.IDCAUHOI_567 == pMa);
            context.CAUHOIPART_6_7.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<CAUHOIPART_6_7> GetList()
        {
            List<CAUHOIPART_6_7> list = new List<CAUHOIPART_6_7>();
            list = context.CAUHOIPART_6_7.ToList();
            return list;
        }

        public CAUHOIPART_6_7 GetDVByMa(int pMa)
        {
            CAUHOIPART_6_7 result = new CAUHOIPART_6_7();
            result = context.CAUHOIPART_6_7.FirstOrDefault(m => m.IDCAUHOI_567 == pMa);
            return result;
        }
    }
}
