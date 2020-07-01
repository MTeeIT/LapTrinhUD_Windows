using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class ThuVienKNCSDL
    {
        SqlConnection sqlketnoi;
        SqlCommand sqllenh;
        public ThuVienKNCSDL()
        {
            sqlketnoi = new SqlConnection();
            string chuoiketnoi = @"Data Source=DESKTOP-1OI4S3R\SQLEXPRESS;Initial Catalog=QUANLY_NHAHANG;Integrated Security=True";
            sqlketnoi.ConnectionString = chuoiketnoi;
            sqllenh = new SqlCommand();
        }
        public bool Moketnoi()
        {
            try
            {
                sqlketnoi.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Dongketnoi()
        {
            sqlketnoi.Close();
        }
        public bool CapnhatCSDL(string str)
        {
            try
            {
                this.Moketnoi();
                sqllenh.Connection = sqlketnoi;
                sqllenh.CommandText = str;
                sqllenh.ExecuteNonQuery();
                this.Dongketnoi();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable LayBang(string str)
        {
            this.Moketnoi();
            SqlDataAdapter bodocghi = new SqlDataAdapter(str, sqlketnoi);
            DataTable bang = new DataTable();
            bodocghi.Fill(bang);
            this.Dongketnoi();
            return bang;
        }
    }
}
