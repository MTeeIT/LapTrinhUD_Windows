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
    public partial class Lop : Form
    {
        KN_CSDL connect = new KN_CSDL();
        public Lop()
        {
            InitializeComponent();
            hienthidulieu();
        }
        public void hienthidulieu()
        {
            DataTable lop = new DataTable();
            String sql = "select ma_lop as 'Mã Lớp', ten_lop as 'Tên Lớp', ma_nganh as 'Mã Ngành' from Lop";
            lop = connect.LayBang(sql);

            //do du lieu len dgvNganh tu bang nganh
            dgvLop.DataSource = lop;

            //Thao tác khi thêm
            txtMalop.ReadOnly = false;
            txtMalop.Text = " ";
            txtTenlop.Text = " ";

            //combobox
            sql = "select * from nganh";
            DataTable bangNganh = new DataTable();

            bangNganh = connect.LayBang(sql);
            cbNganh.DataSource = bangNganh;
            cbNganh.DisplayMember = "ten_nganh";
            cbNganh.ValueMember = "ma_nganh";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            hienthidulieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String maLop = txtMalop.Text.Trim();
            String sql = "delete from lop where ma_lop = '" + maLop + "'";
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("ok");
            else MessageBox.Show("No");

            hienthidulieu();
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if( index != -1 )
            {
                txtMalop.Text = dgvLop.Rows[index].Cells[0].Value.ToString();
                txtTenlop.Text = dgvLop.Rows[index].Cells[1].Value.ToString();
                string maNganh   = dgvLop.Rows[index].Cells[2].Value.ToString();

                /*viết lại*/
                //lay ten nganh
                String sql = "select ten_nganh from nganh where ma_nganh = '"+maNganh+"'";
                //thực thi sql;

                DataTable bangNganh = new DataTable();
                bangNganh = connect.LayBang(sql);

                string tenNganh = bangNganh.Rows[0][0].ToString() ;

                cbNganh.SelectedIndex = cbNganh.FindStringExact(tenNganh);
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            hienthidulieu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            String maLop = txtMalop.Text.Trim();
            String tenLop = txtTenlop.Text.Trim();
            String maNganh = cbNganh.SelectedValue.ToString().Trim();

            String sql = "INSERT INTO lop VALUES('" + maLop + "',N'" + tenLop + "','" + maNganh + "')";
            if(connect.CapnhatCSDL(sql))
                MessageBox.Show("Lưu thành công");
                else
                MessageBox.Show("Lưu không thành công");

            hienthidulieu();

        }
    }
}
