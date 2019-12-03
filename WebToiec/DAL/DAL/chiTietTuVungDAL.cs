using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class chiTietTuVungDAL : DBContext
    {
        public int Add(CHI_TIET_TU_VUNG p)
        {
            int result = 0;
            context.CHI_TIET_TU_VUNG.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(CHI_TIET_TU_VUNG pma)
        {
            int result = 0;
            CHI_TIET_TU_VUNG k = context.CHI_TIET_TU_VUNG.FirstOrDefault(m => m.ID == pma.ID);
            if (k != null)
            {
                k.ID_TUVUNG = pma.ID_TUVUNG;
                k.MA_CHU_DE = pma.MA_CHU_DE;
                k.NGHIA_CUA_TU = pma.NGHIA_CUA_TU;
                k.PHAT_AM = pma.PHAT_AM;
                k.PHIEN_AM = pma.PHIEN_AM;
                k.VI_DU = pma.VI_DU;
                k.HIN_HANH = pma.HIN_HANH;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            CHI_TIET_TU_VUNG k = context.CHI_TIET_TU_VUNG.FirstOrDefault(m => m.ID == pMa);
            context.CHI_TIET_TU_VUNG.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<CHI_TIET_TU_VUNG> GetList()
        {
            List<CHI_TIET_TU_VUNG> list = new List<CHI_TIET_TU_VUNG>();
            list = context.CHI_TIET_TU_VUNG.ToList();
            return list;
        }

        public CHI_TIET_TU_VUNG GetDVByMa(int pMa)
        {
            CHI_TIET_TU_VUNG result = new CHI_TIET_TU_VUNG();
            result = context.CHI_TIET_TU_VUNG.FirstOrDefault(m => m.ID == pMa);
            return result;
        }

        public List<CHI_TIET_TU_VUNG> GetDVByMaChuDe(int pMa)
        {
            List<CHI_TIET_TU_VUNG> list = new List<CHI_TIET_TU_VUNG>();
            list = context.CHI_TIET_TU_VUNG.Where(m => m.MA_CHU_DE == pMa).ToList();
            return list;
        }
    }
}
