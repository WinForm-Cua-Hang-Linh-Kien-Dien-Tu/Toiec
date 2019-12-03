using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class tuVungDAL : DBContext
    {
        public int Add(TUVUNG p)
        {
            int result = 0;
            context.TUVUNG.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(TUVUNG pma)
        {
            int result = 0;
            TUVUNG k = context.TUVUNG.FirstOrDefault(m => m.ID_TUVUNG == pma.ID_TUVUNG);
            if (k != null)
            {
               
                k.TU = pma.TU;
                k.THELOAI = pma.THELOAI;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            TUVUNG k = context.TUVUNG.FirstOrDefault(m => m.ID_TUVUNG == pMa);
            context.TUVUNG.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<TUVUNG> GetList()
        {
            List<TUVUNG> list = new List<TUVUNG>();
            list = context.TUVUNG.ToList();
            return list;
        }

        public TUVUNG GetDVByMa(int pMa)
        {
            TUVUNG result = new TUVUNG();
            result = context.TUVUNG.FirstOrDefault(m => m.ID_TUVUNG == pMa);
            return result;
        }

        public string GetTenTV(int pMa)
        {
            string result = context.TUVUNG.FirstOrDefault(m => m.ID_TUVUNG == pMa).TU;
            return result;
        }


    }
}
