using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class baiGiangDAL : DBContext
    {
        public int Add(BAIGIANG p)
        {
            int result = 0;
            context.BAIGIANG.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(BAIGIANG pma)
        {
            int result = 0;
            BAIGIANG k = context.BAIGIANG.FirstOrDefault(m => m.ID_BAIGIANG == pma.ID_BAIGIANG);
            if (k != null)
            {
                k.ID_KH = pma.ID_KH;
                k.NOI_DUNG_BAI_GIANG = pma.NOI_DUNG_BAI_GIANG;
                k.DANH_GIA = pma.DANH_GIA;
                k.GIANG_VIEN = pma.GIANG_VIEN;
                k.ID_BAIGIANG = pma.ID_BAIGIANG;
                k.VIDEO = pma.VIDEO;
                k.PART = pma.PART;
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            BAIGIANG k = context.BAIGIANG.FirstOrDefault(m => m.ID_BAIGIANG == pMa);
            context.BAIGIANG.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<BAIGIANG> GetList()
        {
            List<BAIGIANG> list = new List<BAIGIANG>();
            list = context.BAIGIANG.ToList();
            return list;
        }

        public List<BAIGIANG> GetListLimit()
        {
            List<BAIGIANG> list = new List<BAIGIANG>();
            list = context.BAIGIANG.OrderByDescending(x => x.DANH_GIA).Take(3).ToList();
            return list;
        }

        public BAIGIANG GetDVByMa(int pMa)
        {
            BAIGIANG result = new BAIGIANG();
            result = context.BAIGIANG.FirstOrDefault(m => m.ID_BAIGIANG == pMa);
            return result;
        }
    }
}
