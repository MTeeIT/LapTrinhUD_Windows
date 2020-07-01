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
    public partial class Lop : Form
    {
        TV_KNCSDL connect = new TV_KNCSDL();
        public Lop()
        {
            InitializeComponent();
            hienthidulieu();
        }

        public void hienthidulieu()
        {
            DataTable lop = new DataTable();
            String sql = "SELECT ma_lop AS 'Mã lớp', ten_lop AS 'Tên lớp', ma_nganh AS 'Mã ngành' FROM Lop";
            lop = connect.LayBang(sql);

            dgvLop.DataSource = lop;

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

        private void Lop_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String maLop = txtMalop.Text.Trim();
            String tenLop = txtTenlop.Text.Trim();
            String maNganh = cbNganh.SelectedValue.ToString().Trim();

            String sql = "INSERT INTO lop VALUES('" + maLop + "',N'" + tenLop + "','" + maNganh + "')";
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("Lưu thành công");
            else
                MessageBox.Show("Lưu không thành công");

            hienthidulieu();

        }
    }
}
