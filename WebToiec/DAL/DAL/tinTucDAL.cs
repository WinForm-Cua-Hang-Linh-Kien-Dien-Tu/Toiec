using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class tinTucDAL : DBContext
    {
        public int Add(TIN_TUC p)
        {
            int result = 0;
            context.TIN_TUC.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(TIN_TUC pma)
        {
            int result = 0;
            TIN_TUC k = context.TIN_TUC.FirstOrDefault(m => m.ID == pma.ID);
            if (k != null)
            {
                k.TEN_TIN_TUC = pma.TEN_TIN_TUC;
                k.NGAY_DANG = pma.NGAY_DANG;
                k.NOI_DUNG = pma.NOI_DUNG;
                k.NGUON_TIN_TUC = pma.NGUON_TIN_TUC;
                k.HINH_ANH = pma.HINH_ANH;
               
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            TIN_TUC k = context.TIN_TUC.FirstOrDefault(m => m.ID == pMa);
            context.TIN_TUC.Remove(k);
            result = context.SaveChanges();
            return result;
        }

        public List<TIN_TUC> GetList()
        {
            List<TIN_TUC> list = new List<TIN_TUC>();
            list = context.TIN_TUC.ToList();
            return list;
        }

        public List<TIN_TUC> GetList(string pTen)
        {
            List<TIN_TUC> list = new List<TIN_TUC>();
            list = context.TIN_TUC.Where(m => m.TEN_TIN_TUC.Contains(pTen)).ToList();
            return list;
        }

        public List<TIN_TUC> GetList(DateTime? pNgayDang)
        {
            List<TIN_TUC> list = new List<TIN_TUC>();
            list = context.TIN_TUC.Where(m => m.NGAY_DANG == pNgayDang).ToList();
            return list;
        }

        public TIN_TUC GetDVByMa(int pMa)
        {
            TIN_TUC result = new TIN_TUC();
            result = context.TIN_TUC.FirstOrDefault(m => m.ID == pMa);
            return result;
        }
    }
}
