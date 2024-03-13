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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            
            textId.Focus();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1L27QU\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        
        void temizle()
        {
            textId.Text = "";
            textAd.Text = "";
            textSoyad.Text = "";
            textMeslek.Text = "";
            maskedTextBoxMaas.Text = "";
            comboBoxSehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textAd.Focus();
        }
        
        private void buttonListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);                                  //komut nesnesi üreticez
            komut.Parameters.AddWithValue("@p1", textAd.Text);                                                                                                          //parametreleri deger olarak ekle //parametre 1 textad'tan al
            komut.Parameters.AddWithValue("@p2", textSoyad.Text);  //parametre 2 yi textsoyadtan al
            komut.Parameters.AddWithValue("@p3", comboBoxSehir.Text);
            komut.Parameters.AddWithValue("@p4",maskedTextBoxMaas.Text);
            komut.Parameters.AddWithValue("@p5", textMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);

            komut.ExecuteNonQuery();                              //  sorguyu çalıştıryor executenonquery    insert-update ve delete için kullanlılıyor okuma işlemlerinde değil tablo sonucu değişikliklerinde                 
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;               //herhangi bir hücreye çift tıkladığımızda onu seçilen hücreye aktarıcak
            textId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBoxSehir.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBoxMaas.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textMeslek.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text=="True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text=="False")
            {
                radioButton2.Checked = true;
            }
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel Where Perid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1", textId.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void buttonGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1, PerSoyad=@a2, PerSehir=@a3, PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where Perid=@a7", baglanti); ;
            komutguncelle.Parameters.AddWithValue("@a1", textAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2", textSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", comboBoxSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", maskedTextBoxMaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", textMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", textId.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgi Güncellendi");
        }

        private void buttonİstatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }

        private void buttonGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }
    }
}
