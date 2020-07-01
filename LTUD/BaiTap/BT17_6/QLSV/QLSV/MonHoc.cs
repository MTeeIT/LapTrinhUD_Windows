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
    public partial class MonHoc : Form
    {
        TV_KNCSDL connect = new TV_KNCSDL();
        public MonHoc()
        {
            InitializeComponent();
            hienthidulieu();
        }

        public void hienthidulieu()
        {
            DataTable bangMH = new DataTable();
            String sql = "SELECT ma_monhoc AS 'Mã môn học',ten_monhoc AS 'Tên môn học'FROM monhoc";
            bangMH = connect.LayBang(sql);

            // đô lên dgv
            dgvMH.DataSource = bangMH;

            txtMaMH.ReadOnly = false;
            txtMaMH.Text = " ";
            txtTenMH.Text = " ";
        }

        private void MonHoc_Load(object sender, EventArgs e)
        {

        }

        private void S(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            hienthidulieu();
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            String ma_MH = txtMaMH.Text.Trim();
            String ten_MH = txtTenMH.Text.Trim();

            //đổ vào sql
            String sql = "INSERT INTO monhoc VALUES('" + ma_MH + "',N'" + ten_MH + "')";

            //truy vấn kiểm tra
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Lưu thành công");
            else
                MessageBox.Show("Lưu thất bại");

            hienthidulieu();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            String ma_MH = txtMaMH.Text.Trim();
            String ten_MH = txtTenMH.Text.Trim();

            String sql = "DELETE FROM monhoc WHERE ma_monhoc = '" + ma_MH + "'";

            //Tryu vấn kiểm tra
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Xóa thành công");
            else
                MessageBox.Show("Xóa thất bại");

            hienthidulieu();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            String ma_MH = txtMaMH.Text.Trim();
            String ten_MH = txtTenMH.Text.Trim();

            String sql = "UPDATE monhoc SET ten_monhoc = N'" + ten_MH + "' WHERE ma_monhoc = '" + ma_MH + "'";

            //Tryu vấn kiểm tra
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Cập nhật thành công");
            else
                MessageBox.Show("Cập nhật thất bại");

            hienthidulieu();
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            hienthidulieu();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMH_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1)
            {
                txtMaMH.Text = dgvMH.Rows[index].Cells[0].Value.ToString();
                txtTenMH.Text = dgvMH.Rows[index].Cells[1].Value.ToString();

                txtMaMH.ReadOnly = true;
            }
        }
    }
}
