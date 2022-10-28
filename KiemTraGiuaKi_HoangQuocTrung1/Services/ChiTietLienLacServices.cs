using KiemTraGiuaKi_HoangQuocTrung1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTraGiuaKi_HoangQuocTrung1.Services
{
    public class ChiTietLienLacServices
    {
        public static List<ChiTietLienLacViewModel> LayDanhSachChiTietLienLac()
        {
            var db = new AppDBContext();
            var rs = db.ChiTietLienLacs.Select(e => new ChiTietLienLacViewModel
            {
                MaLienlac = e.MaLienLac,
                TenLienLac = e.TenLienLac,
                Email = e.Email,
                SoDienThoai = e.SoDienThoai,
                DiaChi = e.DiaChi,
                MaNhom = e.MaNhom
            }).ToList();
            return rs;
        }
        public static List<ChiTietLienLacViewModel> LayDanhSachChiTietLienLacTheoID(int MaNhom)
        {
            var db = new AppDBContext();
            var rs = db.ChiTietLienLacs.Where(e=>e.MaNhom==MaNhom)
                .Select(e => new ChiTietLienLacViewModel
            {
                MaLienlac = e.MaLienLac,
                TenLienLac = e.TenLienLac,
                Email = e.Email,
                SoDienThoai = e.SoDienThoai,
                DiaChi = e.DiaChi,
                MaNhom = e.MaNhom
            }).ToList();
            return rs;
        }
        public static Boolean ThemChiTietLienLac(ChiTietLienLac Chitiet)
        {
            var db = new AppDBContext();
            var rs = db.ChiTietLienLacs.Add(Chitiet);
            db.SaveChanges();
            return true;
        }
        public static Boolean Xoa1ChiTietLienLac(ChiTietLienLacViewModel ChiTiet)
        {
            var db = new AppDBContext();
            var ChiTietLienLac = db.ChiTietLienLacs.Where(e => e.MaLienLac==ChiTiet.MaLienlac).FirstOrDefault();
            if (ChiTietLienLac != null) db.ChiTietLienLacs.Remove(ChiTietLienLac);
            db.SaveChanges();
            return true;
        }
        public static List<ChiTietLienLacViewModel> LayDanhSachTheoTenLienLac(int MaNhom,String TenCanTim)
        {
            var rs = LayDanhSachChiTietLienLacTheoID(MaNhom);
            var ds = rs.Where(e => e.TenLienLac.ToLower().Contains(TenCanTim.ToLower()));
            return ds.ToList();
        }
    }
}
