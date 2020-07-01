using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        ThuVienKNCSDL connect = new ThuVienKNCSDL();
        public Form1()
        {
            InitializeComponent();
            hienThiDuLieu();
        }

        public void hienThiDuLieu()
        {
            txtManganh.ReadOnly = false;
            txtManganh.Text = "";
            txtTenNganh.Text = "";

            DataTable nganh = new DataTable();
            String sql = "select * from nganh";
            nganh = connect.LayBang(sql);

            //du lieu hien tai duoc chua trong bien nganh
            dgvNganh.DataSource = nganh;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //lấy dữ liệu + xử lý dữ liệu
            String maNganh = txtManganh.Text.Trim();
            String tenNganh = txtTenNganh.Text.Trim();

            //bỏ dữ liệu vào sql
            String sql = "INSERT INTO nganh values('" + maNganh + "', N'" + tenNganh + "')";

            //truy vấn dữ liệu
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Thêm dữ liệu thành công");
            else MessageBox.Show("Thêm dữ liệu không thành công");

            //load lại datagridview
            hienThiDuLieu();
        }

        private void dgvNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtManganh.Text = dgvNganh.Rows[index].Cells[0].Value.ToString();
            txtTenNganh.Text = dgvNganh.Rows[index].Cells[1].Value.ToString();

            //khong duoc nhhap du lieu
            txtManganh.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String maNganh = txtManganh.Text.Trim();

            //bỏ vào sql
            String sql = "delete from nganh where ma_nganh ='"+maNganh+"'";

            //truy vấn sql
            //truy vấn dữ liệu
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Xoa dữ liệu thành công");
            else MessageBox.Show("Xoa dữ liệu không thành công");

            //load lại datagridview
            hienThiDuLieu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String maNganh = txtManganh.Text.Trim();
            String tenNganh = txtTenNganh.Text.Trim();
            //bỏ vào sql
            String sql = "update nganh set ten_nganh='"+tenNganh+"' where ma_nganh='"+maNganh+"'";

            //truy vấn sql
            //truy vấn dữ liệu
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Cap nhat dữ liệu thành công");
            else MessageBox.Show("Cap nhat dữ liệu không thành công");

            //load lại datagridview
            hienThiDuLieu();
        }

        private void btnThemDL_Click(object sender, EventArgs e)
        {
            hienThiDuLieu();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            hienThiDuLieu();
        }
    }
}
