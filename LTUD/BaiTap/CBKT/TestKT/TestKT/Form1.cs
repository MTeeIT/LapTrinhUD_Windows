using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestKT
{
    public partial class Frm_nganh : Form
    {
        TV_KNCSDL connect = new TV_KNCSDL();
        public Frm_nganh()
        {
            InitializeComponent();
            hienthidulieu();
        }

        public void hienthidulieu()
        {
            DataTable nganh = new DataTable();
            String sql = "SELECT ma_nganh AS 'Mã ngành', ten_nganh AS 'Tên ngành' FROM nganh";
            nganh = connect.LayBang(sql);

            //do dl len datagridview

            dgvNganh.DataSource = nganh;

            txtManganh.ReadOnly = false;
            txtManganh.Text = " ";
            txtTennganh.Text = " ";

      
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            hienthidulieu();
        }

        private void dgvNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index != -1)
            { 
                txtManganh.Text = dgvNganh.Rows[index].Cells[0].Value.ToString();
                txtTennganh.Text = dgvNganh.Rows[index].Cells[1].Value.ToString();

                txtManganh.ReadOnly = true;
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            String maNganh = txtManganh.Text.Trim();
            String tenNganh = txtTennganh.Text.Trim();

            String sql = "INSERT INTO nganh VALUES('" + maNganh + "',N'" + tenNganh + "')";
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Lưu thành công");
            else
                MessageBox.Show("Lưu không thành công");

            hienthidulieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String maNganh = txtManganh.Text.Trim();
            String tenNganh = txtTennganh.Text.Trim();

            String sql = "DELETE FROM nganh WHERE ma_nganh = '" + maNganh + "'";
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Xoá thành công");
            else
                MessageBox.Show("Xoá không thành công");

            hienthidulieu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String maNganh = txtManganh.Text.Trim();
            String tenNganh = txtTennganh.Text.Trim();

            String sql = "UPDATE nganh SET ten_nganh = N'" + tenNganh + "' WHERE ma_nganh = '" + maNganh + "'";
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Cập nhật thành công");
            else
                MessageBox.Show("Cập nhật không thành công");

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
    }
}
