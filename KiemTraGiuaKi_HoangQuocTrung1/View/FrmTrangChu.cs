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
    public partial class FrmTrangChu : Form
    {
        public FrmTrangChu()
        {
            InitializeComponent();
            NapDsNhom();
            NapDsChiTietLienLac();
            
        }
        public void reset()
        {
            TxtTen.Clear();
            TxtDiaChi.Clear();
            TxtSdt.Clear();
            TxtEmail.Clear();
        }
        public void NapDsNhom()
        {
            var rs = NhomDanhBaServices.LayDanhSachNhom();
            nhomDanhBaViewModelBindingSource.DataSource = rs;
            DgvNhom.DataSource = nhomDanhBaViewModelBindingSource;

        }
        public void NapDsChiTietLienLac()
        {
            var rs = ChiTietLienLacServices.LayDanhSachChiTietLienLac();
            chiTietLienLacViewModelBindingSource.DataSource = rs;
            DgvChiTietLienLac.DataSource = rs;
        }
        public NhomDanhBaViewModel SelectedNhomDanhBa
        {
            get
            {
                return nhomDanhBaViewModelBindingSource.Current as NhomDanhBaViewModel;
            }
        }
        public ChiTietLienLacViewModel SelecttedChiTietLienLac
        {
            get
            {
                return chiTietLienLacViewModelBindingSource.Current as ChiTietLienLacViewModel;
            }
        }
        private void DgvChiTietLienLac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SelecttedChiTietLienLac != null)
            {
                TxtTen.Text = SelecttedChiTietLienLac.TenLienLac;
                TxtDiaChi.Text = SelecttedChiTietLienLac.DiaChi;
                TxtEmail.Text = SelecttedChiTietLienLac.Email;
                TxtSdt.Text = SelecttedChiTietLienLac.SoDienThoai;
            }
        }
        private void DgvNhom_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectedNhomDanhBa != null)
            {
                var ls=ChiTietLienLacServices.LayDanhSachChiTietLienLacTheoID(SelectedNhomDanhBa.MaNhom);
                chiTietLienLacViewModelBindingSource.DataSource = ls;
                DgvChiTietLienLac.DataSource=chiTietLienLacViewModelBindingSource;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(SelectedNhomDanhBa!=null)
            {
                var rs = MessageBox.Show("Bạn có chắc muốn xóa hay k?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    var ls = NhomDanhBaServices.Xoa1NhomDanhBa(SelectedNhomDanhBa);
                    if (ls == true) NapDsNhom();
                }
            }    
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var f = new FrmNhomDanhBa();
            var rs=f.ShowDialog();
            if(rs== DialogResult.OK)
            {
                NapDsNhom();
            }    
        }

        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var f = new frmChiTietLienLac();
            var rs = f.ShowDialog();
            if(rs== DialogResult.OK)
            {
                NapDsChiTietLienLac();
            }    
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if(SelecttedChiTietLienLac!=null)
            {
                var rs = MessageBox.Show("Bạn có chắc muốn xóa hay k?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    var ls = ChiTietLienLacServices.Xoa1ChiTietLienLac(SelecttedChiTietLienLac);
                    if (ls == true)
                    {
                        reset();
                        NapDsChiTietLienLac();
                    }
                }
            }    
        }

        private void txtTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SelectedNhomDanhBa != null)
                {
                    var ls = ChiTietLienLacServices.LayDanhSachTheoTenLienLac(SelectedNhomDanhBa.MaNhom, txtTimkiem.Text);
                    chiTietLienLacViewModelBindingSource.DataSource = ls;
                    DgvChiTietLienLac.DataSource = chiTietLienLacViewModelBindingSource;
                }
            }
        }
    }
}
