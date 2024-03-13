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

namespace Personel_Kayit
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1L27QU\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) From Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read()) //dr1 komutu okuma işlemi yaptığı sürece satırloarı sıarayla okuyor
            {
                labelToplamPersonel.Text = dr1[0].ToString(); //dr1 satırın kümesi olsun dr1[0] birinci indeksi veriyor yani Queryde ki ilk sutünü  veriyor en son 12de kaldığı için 12 yazdırır!
            }
            baglanti.Close();
            //Evli Personel Sayisi

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count (*) From Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                labelEvliPersonel.Text = dr2[0].ToString();

            }
            baglanti.Close();
            //Bekar Personel Sayisi
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                labelBekarPersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Sehir Sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count (distinct (PerSehir)) From Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                labelSehirSayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //Toplam Maas
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();//komut5 ten gelen degeri çalıştır
            while (dr5.Read())
            {
                labelToplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();


            //Ortalama Maas
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();//komut5 ten gelen degeri çalıştır
            while (dr6.Read())
            {
                labelOrtalamaMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
