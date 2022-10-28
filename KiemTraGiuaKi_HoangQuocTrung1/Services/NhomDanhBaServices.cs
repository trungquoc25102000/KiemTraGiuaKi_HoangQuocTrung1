using KiemTraGiuaKi_HoangQuocTrung1.ViewModel;
using KiemTraGiuaKi_HoangQuocTrung1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiemtragiuaki_HoangQuocTrung1.Services
{
    public class NhomDanhBaServices
    {
        public static List<NhomDanhBaViewModel> LayDanhSachNhom()
        {
            var db = new AppDBContext();
            var rs=db.NhomDanhBas.Select(e => new NhomDanhBaViewModel
                {
                    MaNhom = e.MaNhom,
                    TenNhom = e.TenNhom,
                }).ToList();
            return rs;
        }
        public static Boolean ThemNhomDanhBa( NhomDanhBa Danhba)
        {
            var db = new AppDBContext();
            var rs = db.NhomDanhBas.Add(Danhba);
            db.SaveChanges();
            return true;
        }
        public static Boolean Xoa1NhomDanhBa(NhomDanhBaViewModel DanhBa)
        {
            var db = new AppDBContext();
            var NhomDanhBa = db.NhomDanhBas.Where(e => e.MaNhom == DanhBa.MaNhom ).FirstOrDefault();
            if (NhomDanhBa != null) db.NhomDanhBas.Remove(NhomDanhBa);
            db.SaveChanges();
            return true;
        }
    }
}
