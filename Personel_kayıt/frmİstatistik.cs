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
    public partial class frmİstatistik : Form
    {
        public frmİstatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=WIN-NQQQ22LG27T\\MSSSQL;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void frmİstatistik_Load(object sender, EventArgs e)
        {   //toplam Personel

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select Count(*) From Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();// select biçin sorguyu çalıştır.
            while (dr1.Read())
            {
                lblToplamPer.Text=dr1[0].ToString();
            }
            

            baglanti.Close();
            
            //evli Personel
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                lblEvli.Text=dr2[0].ToString();
            }
            baglanti.Close();
            //bekar Personel
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) From Tbl_Personel where Perdurum=0", baglanti);
            SqlDataReader dr3= komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekar.Text=dr3[0].ToString();
            }

            baglanti.Close();
            //sehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count (distinct(Persehir)) from Tbl_PErsonel", baglanti);
            SqlDataReader dr4=komut4.ExecuteReader();
            while(dr4.Read())
            {
                LblSehir.Text=dr4[0].ToString();
            }
            baglanti.Close();
            // toplam Maas
            baglanti.Open ();
            SqlCommand komut5 = new SqlCommand("select sum(PerMaas) from Tbl_personel", baglanti);
            SqlDataReader dr5= komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamMaas.Text=dr5[0].ToString();
            }
            baglanti.Close();
            // ort maas
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(Permaas) from Tbl_personel", baglanti);
            SqlDataReader dr6=komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtMaas.Text=dr6[0].ToString();
            }
            baglanti.Close ();
        }
    }
}
