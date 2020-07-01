using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CSDL
{
    public partial class Form1 : Form
    {
        tv_kn_csdl tv_csdl = new tv_kn_csdl();
        public Form1()
        {
            InitializeComponent();
            tv_csdl = new tv_kn_csdl();
            //if(tv_csdl.moketnoi())
            //{
            //    MessageBox.Show("Mo dc csdl");
            //}
            //else
            //{
            //    MessageBox.Show("Khong mo dươc csdl");
            //}

            hienThiDulieu();
        }

        public void hienThiDulieu()
        {
       
            txt_ma_lop.Text = "";
            txt_ten_lop.Text = " ";
            txt_ma_lop.ReadOnly = false;
  

            DataTable banglop = new DataTable();
            string sql = " Select MaLop as 'Mã Lớp', Tenlop as 'Tên Lớp' from tbl_Lop";
            banglop = tv_csdl.Laybang(sql);
            dgv_hienthi.DataSource = banglop;

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_ma_lop.Focus();
            hienThiDulieu();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            String MaLop = txt_ma_lop.Text;
            String sql = "delete from tbl_Lop where MaLop ='"+ MaLop +"'";

            if (tv_csdl.CapnhatCSDL(sql))
                MessageBox.Show("Xóa thành công");
            else
                MessageBox.Show("Xóa không thành công");
            hienThiDulieu();
        }

        private void dgv_hienthi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txt_ma_lop.Text = dgv_hienthi.Rows[e.RowIndex].Cellss[0].Value.ToString();
                txt_ten_lop.Text = dgv_hienthi.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            String MaLop = txt_ma_lop.Text;
            String TenLop = txt_ten_lop.Text;
            String sql = "update tbl_Lop set TenLop =N'" + TenLop + "' where MaLop = '"+ MaLop +"'";

            if (tv_csdl.CapnhatCSDL(sql))
                MessageBox.Show("Cập nhật thành công");
            else
                MessageBox.Show("Cập nhật không thành công");
            hienThiDulieu();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if(txt_ma_lop.Text.Trim()==""|| txt_ten_lop.Text.Trim()=="")
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu");
                txt_ma_lop.Focus();
                return;
            }

            String MaLop = txt_ma_lop.Text;
            String TenLop = txt_ten_lop.Text;
            String sql = "insert into tbl_Lop values ('" + MaLop + "',N'" + TenLop + "')";

            if (tv_csdl.CapnhatCSDL(sql))
                MessageBox.Show("Lưu thành công");
            else
                MessageBox.Show("Lưu không thành công");
            hienThiDulieu();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            hienThiDulieu();
        }
    }
}
