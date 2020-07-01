using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QL_CSDL
{
    class tv_kn_csdl
    {
        SqlConnection kn;
        SqlCommand lenh;

       public tv_kn_csdl()
        {
            kn = new SqlConnection();
            kn.ConnectionString = "Data Source=.;Initial Catalog=QLSV;Integrated Security=True";
        }

        public bool moketnoi()
        {
            try
            {
                kn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable Laybang( String str)
        {
            kn.Close();
            kn.Open();
            SqlDataAdapter bodocghi = new SqlDataAdapter(str, kn);
            DataTable ketqua = new DataTable();
            bodocghi.Fill(ketqua);
            kn.Close();
            return ketqua;
        }

        public bool CapnhatCSDL(string str)
        {
            try
            {
                kn.Open();
                lenh = new SqlCommand(str, kn);
                lenh.ExecuteNonQuery();
                kn.Close();
                return true;
               
            }
            catch
            {
                return false;
            }
        }
    }

}
