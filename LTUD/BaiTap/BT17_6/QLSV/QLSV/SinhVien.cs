using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class SinhVien : Form
    {
        TV_KNCSDL connect = new TV_KNCSDL();
        public SinhVien()
        {
            InitializeComponent();
            hienthidulieu();
        }

        public void hienthidulieu()
        {
            DataTable bangSV = new DataTable();
            String sql = "SELECT mssv AS 'Mã số sinh viên',ho_ten AS 'Họ tên'FROM sinhvien";
            bangSV = connect.LayBang(sql);

            // đô lên dgv
            dgvSV.DataSource = bangSV;

            txtMSSV.ReadOnly = false;
            txtMSSV.Text = " ";
            txtTenSV.Text = " ";
        }

        private void SinhVien_Load(object sender, EventArgs e)
        {

        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index != -1) { 
            txtMSSV.Text = dgvSV.Rows[index].Cells[0].Value.ToString();
            txtTenSV.Text = dgvSV.Rows[index].Cells[1].Value.ToString();

            txtMSSV.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            hienthidulieu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            String MS_SV = txtMSSV.Text.Trim();
            String tenSV = txtTenSV.Text.Trim();

            //đổ vào sql
            String sql = "INSERT INTO sinhvien VALUES('" + MS_SV + "',N'" + tenSV + "')";

            //truy vấn kiểm tra
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Lưu thành công");
            else
                MessageBox.Show("Lưu thất bại");

            hienthidulieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String MS_SV = txtMSSV.Text.Trim();
            String tenSV = txtTenSV.Text.Trim();
    
            String sql = "DELETE FROM sinhvien WHERE mssv = '" + MS_SV + "'";
          
            //Tryu vấn kiểm tra
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Xóa thành công");
            else
                MessageBox.Show("Xóa thất bại");

            hienthidulieu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String MS_SV = txtMSSV.Text.Trim();
            String tenSV = txtTenSV.Text.Trim();

            String sql = "UPDATE sinhvien SET ho_ten = N'"+tenSV+"' WHERE mssv = '" + MS_SV + "'";

            //Tryu vấn kiểm tra
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Cập nhật thành công");
            else
                MessageBox.Show("Cập nhật thất bại");

            hienthidulieu();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            hienthidulieu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void S(object sender, EventArgs e)
        {

        }
    }
}
