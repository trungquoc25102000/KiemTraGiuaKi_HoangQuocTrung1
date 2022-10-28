using Kiemtragiuaki_HoangQuocTrung1.Services;
using KiemTraGiuaKi_HoangQuocTrung1.Services;
using KiemTraGiuaKi_HoangQuocTrung1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiemTraGiuaKi_HoangQuocTrung1
{
    public partial class frmChiTietLienLac : Form
    {
        public frmChiTietLienLac()
        {
            InitializeComponent();
            NapDsLophoc();
        }
        public NhomDanhBaViewModel SelecttedNhomDanhBa
        {
            get
            {
                return CmbNhom.SelectedItem as NhomDanhBaViewModel;
            }
        }
        public void NapDsLophoc()
        {
            var ls = NhomDanhBaServices.LayDanhSachNhom();
            CmbNhom.DataSource = ls;
            CmbNhom.DisplayMember = "TenNhom";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SelecttedNhomDanhBa != null)
            {
                var chitiet = new ChiTietLienLac
                {
                    TenLienLac = TxtTenLienLacs.Text,
                    Email = TxtEmail.Text,
                    DiaChi = TxtDiaChi.Text,
                    SoDienThoai = TxtSoDienThoai.Text,
                    MaNhom =SelecttedNhomDanhBa.MaNhom,
                };
                var kq = ChiTietLienLacServices.ThemChiTietLienLac(chitiet);
                if (kq == true) DialogResult = DialogResult.OK;else DialogResult=DialogResult.Cancel;
            }    
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
