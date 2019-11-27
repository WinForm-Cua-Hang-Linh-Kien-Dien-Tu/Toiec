﻿using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class chuDeTuVungDAL : DBContext
    {
        public int Add(CHUDE_TUVUNG p)
        {
            int result = 0;
            context.CHUDE_TUVUNG.Add(p);
            result = context.SaveChanges();
            return result;
        }
        public int Update(CHUDE_TUVUNG pma)
        {
            int result = 0;
            CHUDE_TUVUNG k = context.CHUDE_TUVUNG.FirstOrDefault(m => m.MACHUDE == pma.MACHUDE);
            if (k != null)
            {
                k.TENCHUDE = pma.TENCHUDE;
                             
            }
            result = context.SaveChanges();
            return result;
        }

        public int Delete(int pMa)
        {
            int result = 0;
            CHUDE_TUVUNG k = context.CHUDE_TUVUNG.FirstOrDefault(m => m.MACHUDE == pMa);
            context.CHUDE_TUVUNG.Remove(k);
            result = context.SaveChanges();
            return result;
        }
        public List<CHUDE_TUVUNG> GetList()
        {
            List<CHUDE_TUVUNG> list = new List<CHUDE_TUVUNG>();
            list = context.CHUDE_TUVUNG.ToList();
            return list;
        }

        public CHUDE_TUVUNG GetDVByMa(int pMa)
        {
            CHUDE_TUVUNG result = new CHUDE_TUVUNG();
            result = context.CHUDE_TUVUNG.FirstOrDefault(m => m.MACHUDE == pMa);
            return result;
        }
    }
}
