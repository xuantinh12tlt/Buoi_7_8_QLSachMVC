using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetFrameWork.Interface
{
    public interface ISach
    {
        //Add, Update, Delete, Display
        int ThemSachMoi(Sach p);
        int CapNhatThongTinSach(Sach p);
        int XoaSach(Sach p);
        List<Sach> HienThiThongTinSach();
        //The MOdifier public is not valid for this item in C# 7.3 with Interface
    } 
}
