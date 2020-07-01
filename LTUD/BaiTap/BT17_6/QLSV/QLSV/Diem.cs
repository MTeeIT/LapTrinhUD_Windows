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
    public partial class Diem : Form
    {
        TV_KNCSDL connnect = new TV_KNCSDL();
        public Diem()
        {
            InitializeComponent();
            hienthidulieu();
        }

        public void hienthidulieu()
        {
            cbTenSV.Enabled = true;
            cbTenMH.Enabled = true;
            txtDL1.Text = " ";
            txtDL2.Text = " ";
            txtDKT.Text = " ";

            DataTable bangDiem = new DataTable();
            String sql = "SELECT ho_ten AS 'Tên sinh viên',ten_monhoc AS 'Tên môn học', diem_lan_1 AS'Điểm lần 1', diem_lan_2 AS 'Điểm lần 2',diem_lan_3 AS 'Điểm kết thúc'FROM diem, sinhvien,monhoc WHERE sinhvien.mssv = diem.mssv and monhoc.ma_monhoc = diem. ma_monhoc";
            bangDiem = connnect.LayBang(sql);
            dgvDiem.DataSource = bangDiem;

            //hiern thị SV
            DataTable bangSV = new DataTable();
            sql = "Select * from sinhvien";
            bangSV = connnect.LayBang(sql);

            cbTenSV.DataSource = bangSV;
            cbTenSV.DisplayMember = "ho_ten";
            cbTenSV.ValueMember = "mssv";

            //đo DL MH
            DataTable bangMH = new DataTable();
            sql = "Select * from monhoc";
            bangMH = connnect.LayBang(sql);

            cbTenMH.DataSource = bangMH;
            cbTenMH.DisplayMember = "ten_monhoc";
            cbTenMH.ValueMember = "ma_monhoc";



        }

        private void Diem_Load(object sender, EventArgs e)
        {

        }

        private void dgvDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1)
            {
                String tenSV = dgvDiem.Rows[index].Cells[0].Value.ToString();
                cbTenSV.SelectedIndex = cbTenSV.FindStringExact(tenSV);

                String TenMH = dgvDiem.Rows[index].Cells[1].Value.ToString();
                cbTenMH.SelectedIndex = cbTenMH.FindStringExact(TenMH);

                txtDL1.Text = dgvDiem.Rows[index].Cells[2].Value.ToString();
                txtDL2.Text = dgvDiem.Rows[index].Cells[3].Value.ToString();
                txtDKT.Text = dgvDiem.Rows[index].Cells[4].Value.ToString();

                cbTenMH.Enabled = false;
                cbTenSV.Enabled = false;


            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            hienthidulieu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            String tenSV = cbTenSV.SelectedValue.ToString().Trim();
            String tenMH = cbTenMH.SelectedValue.ToString().Trim();

            float dl1 = float.Parse(txtDL1.Text.Trim());
            float dl2 = float.Parse(txtDL2.Text.Trim());
            float dkt = float.Parse(txtDKT.Text.Trim());

            String sql = "INSERT INTO diem VALUES('" + tenSV + "','" + tenMH + "','" + dl1 + "','" + dl2 + "','" + dkt + "')";


            if (connnect.CapnhatCSDL(sql))
                MessageBox.Show("Lưu thành công");
            else
                MessageBox.Show("Lưu thất bại");

            hienthidulieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String tenSV = cbTenSV.SelectedValue.ToString();
            String tenMH = cbTenMH.SelectedValue.ToString();

            String sql = "DELETE FROM diem WHERE mssv ='" + tenSV + "' and ma_monhoc='" + tenMH + "'";
       
            //Tryu vấn kiểm tra
            if (connnect.CapnhatCSDL(sql))
                MessageBox.Show("Xóa thành công");
            else
                MessageBox.Show("Xóa thất bại");

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            String tenSV = cbTenSV.SelectedValue.ToString().Trim();
            String tenMH = cbTenMH.SelectedValue.ToString().Trim();

            float dl1 = float.Parse(txtDL1.Text.Trim());
            float dl2 = float.Parse(txtDL2.Text.Trim());
            float dkt =float.Parse(txtDKT.Text.Trim());

            String sql = "UPDATE diem SET diem_lan_1 ='" + dl1 + "',diem_lan_2='" + dl2 + "',diem_lan_3='" + dkt + "' WHERE mssv='" + tenSV + "' and ma_monhoc='" + tenMH + "'";
            MessageBox.Show(sql);
            //Tryu vấn kiểm tra
            if (connnect.CapnhatCSDL(sql))
                MessageBox.Show("Sửa thành công");
            else
                MessageBox.Show("Sửa thất bại");

            hienthidulieu();
        }
    }
}
