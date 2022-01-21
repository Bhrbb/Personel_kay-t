using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_kayıt
{
    public partial class frmGrafikler : Form
    {
        public frmGrafikler()
        {
            InitializeComponent();
        }

       SqlConnection baglanti=new SqlConnection("Data Source=WIN-NQQQ22LG27T\\MSSSQL;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void frmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select Persehir,Count(*) from tbl_personel group By Persehir", baglanti);
            SqlDataReader dr7 = komutg1.ExecuteReader();
            while (dr7.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr7[0], dr7[1]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select perMeslek,Avg(perMaas) From Tbl_personel group by PerMeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while(dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0],dr2[1]);
            }
            baglanti.Close();
        }
    }
}
