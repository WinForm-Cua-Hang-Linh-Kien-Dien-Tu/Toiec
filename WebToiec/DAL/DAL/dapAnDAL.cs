using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class dapAnDAL : DBContext
    {
        public int Add(DAP_AN p)
        {
            int result = 0;
            context.DAP_AN.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(DAP_AN pma)
        {
            int result = 0;
            DAP_AN k = context.DAP_AN.FirstOrDefault(m => m.IDDAPAN == pma.IDDAPAN);
            if (k != null)
            {
                k.DAPAN_A = pma.DAPAN_A;
                k.DAPAN_B = pma.DAPAN_B;
                k.DAPAN_C = pma.DAPAN_C;
                k.DAPAN_D = pma.DAPAN_D;
                k.DAPANDUNG = pma.DAPANDUNG;
                k.IDCAU_34 = pma.IDCAU_34;
                k.IDCAUHOI_567 = pma.IDCAUHOI_567;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            DAP_AN k = context.DAP_AN.FirstOrDefault(m => m.IDDAPAN == pMa);
            context.DAP_AN.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<DAP_AN> GetList()
        {
            List<DAP_AN> list = new List<DAP_AN>();
            list = context.DAP_AN.ToList();
            return list;
        }

        public DAP_AN GetDVByMa(int pMa)
        {
            DAP_AN result = new DAP_AN();
            result = context.DAP_AN.FirstOrDefault(m => m.IDDAPAN == pMa);
            return result;
        }
    }
}
