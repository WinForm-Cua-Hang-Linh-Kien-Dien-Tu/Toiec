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
            KHOAHOC k = context.KHOAHOC.FirstOrDefault(m => m.ID_KH == pma.ID_KH);
            if (k != null)
            {
                k.GIA_TIEN = pma.GIA_TIEN;
                k.THOI_GIAN = pma.THOI_GIAN;
                k.TEN_KH = pma.TEN_KH;
                k.GIOI_THIEU = pma.GIOI_THIEU;
                k.VIDEO_GIOI_THIEU = pma.VIDEO_GIOI_THIEU;
                k.DANH_GIA = pma.DANH_GIA;
                k.LOAI_KH = pma.LOAI_KH;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int? pMa)
        {
            int result = 0;
            KHOAHOC k = context.KHOAHOC.FirstOrDefault(m => m.ID_KH == pMa);
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


        public List<KHOAHOC> GetListLimit()
        {
            List<KHOAHOC> list = new List<KHOAHOC>();
            list = context.KHOAHOC.OrderByDescending(x => x.DANH_GIA).Take(3).ToList();
            return list;
        }

        public KHOAHOC GetDVByMa(int? pMa)
        {
            KHOAHOC result = new KHOAHOC();
            result = context.KHOAHOC.FirstOrDefault(m => m.ID_KH == pMa);
            return result;
        }

        public List<string> GetTenKH()
        {
            List<string> list = new List<string>();
            list = (from a in context.KHOAHOC select a.TEN_KH).ToList();
            return list;
        }
    }
}
