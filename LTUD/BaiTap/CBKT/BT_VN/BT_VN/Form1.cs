using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_VN
{
    public partial class Form1 : Form
    {
        KN_CSDL conn = new KN_CSDL();
        public Form1()
        {
            InitializeComponent();
            hienthidulieu();
        }

        public void hienthidulieu()
        {
            DataTable nganh = new DataTable();
            String sql = "select * from nganh";
            nganh = conn.LayBang(sql);

            //do du lieu len dgvNganh tu bang nganh
            dgvNganh.DataSource = nganh;

            //thao tác khi thêm
            txtmanganh.ReadOnly = false;
            txtmanganh.Text = " ";
            txttennganh.Text = " ";
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            hienthidulieu();
        }

        private void dgvNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtmanganh.Text = dgvNganh.Rows[index].Cells[0].Value.ToString();
            txttennganh.Text = dgvNganh.Rows[index].Cells[1].Value.ToString();

            //không cho sửa dữ liệu
            txtmanganh.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String maNganh = txtmanganh.Text.Trim();
            String sql = "delete from nganh where ma_nganh = '" + maNganh + "'";
            if (conn.CapnhatCSDL(sql))
                MessageBox.Show("Xoá thành công");
            else
                MessageBox.Show("Xoá thất bại");
            hienthidulieu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String maNganh = txtmanganh.Text.Trim();
            String tenNganh = txttennganh.Text.Trim();
            String sql = "update nganh set ten_nganh ='"+tenNganh+"' where ma_nganh ='" + maNganh + "'";
            if (conn.CapnhatCSDL(sql))
                MessageBox.Show("Cập nhật thành công");
            else
                MessageBox.Show("Cập nhật thất bại");
            hienthidulieu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            String maNganh = txtmanganh.Text.Trim();
            String tenNganh = txttennganh.Text.Trim();
            String gioiTinh = "";
            if (rdNam.Checked == false && rdNu.Checked == false)
            {
                MessageBox.Show("Cần chọn giới tính");
            }
            else
            {
                gioiTinh = "Nu";
                if (rdNam.Checked)
                {
                    gioiTinh = "Nam";
                }
                MessageBox.Show(gioiTinh);
            }

            String sql = " INSERT INTO nganh VALUES ('" + maNganh + "',N'" + tenNganh + "', '"+gioiTinh+"')";
            if (conn.CapnhatCSDL(sql))
                MessageBox.Show("Lưu thành công");
            else
                MessageBox.Show("Lưu thất bại");
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

        private void lopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lop frm_lop = new Lop();
            this.Visible = false;
            frm_lop.ShowDialog();

        }
    }
}
