using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetFrameWork.Interface
{
    public static class QuanLySach
    {
        private static List<Sach> SachList = new List<Sach>();
        public static int CapNhatThongTinSach(Sach p)
        {
            if (p == null)
            {
                return -3;
            }
            if (string.IsNullOrEmpty(p.MaSach))
            {
                return -4;
            }
            if (SachList.Count == 0 || SachList == null)
            {
                return -5;
            }
            foreach (var itemSP in SachList)
            {
                if (itemSP.MaSach == p.MaSach)
                {
                    itemSP.TenSach = p.TenSach;
                    itemSP.DonGia = p.DonGia;
                }

            }
            return 2;
            //throw new NotImplementedException();
        }

        public static List<Sach> HienThiThongTinSach()
        {
            return SachList;
            //throw new NotImplementedException();
        }

        public static int ThemSachMoi(Sach p)
        {
            //Neu p chua dc khoi tao
            if (p == null)
            {
                return -1;
            }
            if (string.IsNullOrEmpty(p.MaSach))
            {
                return -2;
            }
            //SPList = new List<Sach>();
            SachList.Add(p);
            return 1;
            //throw new NotImplementedException();
        }

        public static int XoaSach(Sach p)
        {
            if (p == null)
            {
                return -6;
            }
            if (string.IsNullOrEmpty(p.MaSach))
            {
                return -7;
            }
            if (SachList.Count == 0 || SachList == null)
            {
                return -8;
            }
            SachList = SachList.AsEnumerable().Where(c=>c.MaSach != p.MaSach).ToList();
            //foreach (var itemSP in SachList)
            //{
            //    if (itemSP.MaSach == p.MaSach)
            //    {
            //        SachList.Remove(itemSP);
            //    }

            //}
            return 3;
            //throw new NotImplementedException();
        }
    }
}
