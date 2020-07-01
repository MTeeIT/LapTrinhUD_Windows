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
    public partial class Lop : Form
    {
        ThuVienKNCSDL connect = new ThuVienKNCSDL();
        public Lop()
        {
            InitializeComponent();
            hienThiDuLieu();
        }



        public void hienThiDuLieu() {
            //hien thi datagridview

            //hien thi combobox
            //lay du lieu
            //sql
            String sql = "select * from nganh";

            //truy van du lieu
            DataTable bangNganh = new DataTable();
            bangNganh =connect.LayBang(sql);

            //do du lieu len combobox
            cbNganh.DataSource = bangNganh;
            cbNganh.DisplayMember = "ten_nganh";
            cbNganh.ValueMember = "ma_nganh";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //lay du lieu
            String maLop = textBox1.Text.Trim();
            String tenLop = textBox2.Text.Trim();
            String maNganh = cbNganh.SelectedValue.ToString().Trim();
            

            //bo sql
            String sql = "insert into lop values('"+maLop+"', N'"+tenLop+"', '"+maNganh+"')";
            MessageBox.Show(sql);

            //truy van
            if (connect.CapnhatCSDL(sql))
                MessageBox.Show("TTC");
            else MessageBox.Show("TKTC");
            //hienthidulieu
            hienThiDuLieu();
        }
    }
}
