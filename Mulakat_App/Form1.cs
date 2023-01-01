using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;

namespace Mulakat_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Veri.mdf;Integrated Security=True");
        SqlCommand joinTables = new SqlCommand("SELECT * FROM EgitimciList INNER JOIN KursList ON EgitimciList.EgitimciID=KursList.Egitimci");
        DataSet1TableAdapters.OgrenciListTableAdapter tb = new DataSet1TableAdapters.OgrenciListTableAdapter();
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void BtnListele_Click(object sender, EventArgs e)
        {
            if(RdbOgrenciList.Checked == true)
            {
                SqlCommand komut1 = new SqlCommand("Select OgrenciID,Ad,Soyad,Kurs,KursAd from OgrenciList Inner join KursList on OgrenciList.Kurs = KursList.KursID", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource= dt;
                dataGridView1.Columns["Kurs"].Visible= false;
            }
            if(RdbEgitimciList.Checked == true)
            {
                SqlCommand komut2 = new SqlCommand("Select * from EgitimciList", baglanti);
                SqlDataAdapter da1 = new SqlDataAdapter(komut2);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource=dt1;
            }
            if(RdbKursList.Checked== true)
            {
                SqlCommand komut3 = new SqlCommand("Select KursID,KursAd,Egitimci,Ad,Soyad from KursList Inner join EgitimciList on KursList.Egitimci=EgitimciList.EgitimciID", baglanti);
                SqlDataAdapter da2 = new SqlDataAdapter(komut3);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dataGridView1.DataSource= dt2;
                dataGridView1.Columns["Egitimci"].Visible= false;
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (RdbOgrenciList.Checked == true)
            {
                baglanti.Open();
                SqlCommand komut4 = new SqlCommand("insert into OgrenciList(Ad,Soyad,Kurs) values (@p1,@p2,@p3)", baglanti);
                komut4.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut4.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                komut4.Parameters.AddWithValue("@p3", TxtKursID.Text);
                komut4.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt İşlemi Gerçekleşti");
            }
            if (RdbEgitimciList.Checked == true)
            {
                baglanti.Open();
                SqlCommand komut5 = new SqlCommand("insert into EgitimciList(Ad,Soyad) values (@p1,@p2)", baglanti);
                komut5.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut5.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                komut5.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt İşlemi Gerçekleşti");
            }
            if (RdbKursList.Checked == true)
            {
                baglanti.Open();
                SqlCommand komut6 = new SqlCommand("insert into KursList(KursAd,Egitimci) values (@p1,@p2)", baglanti);
                komut6.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut6.Parameters.AddWithValue("@p2", TxtKursID);
                komut6.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt İşlemi Gerçekleşti");
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (RdbOgrenciList.Checked == true)
            {
                baglanti.Open();
                SqlCommand komut7 = new SqlCommand("update OgrenciList set Ad=@p1,Soyad=@p2,Kurs=@p3 where OgrenciID=@p4", baglanti);
                komut7.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut7.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                komut7.Parameters.AddWithValue("@p3", TxtKursID.Text);
                komut7.Parameters.AddWithValue("@p4", TxtID.Text);
                komut7.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Güncellendi");
            }
            if (RdbEgitimciList.Checked == true)
            {
                baglanti.Open();
                SqlCommand komut8 = new SqlCommand("update EgitimciList set Ad=@p1,Soyad=@p2 where EgitimciID=@p3", baglanti);
                komut8.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut8.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                komut8.Parameters.AddWithValue("@p3", TxtID.Text);
                komut8.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Güncellendi");
            }
            if (RdbKursList.Checked == true)
            {
                baglanti.Open();
                SqlCommand komut8 = new SqlCommand("update KursList set KursAd=@p1,Egitimci=@p2 where KursID=@p3", baglanti);
                    komut8.Parameters.AddWithValue("@p1", TxtAd.Text);
                    komut8.Parameters.AddWithValue("@p2", TxtKursID.Text);
                    komut8.Parameters.AddWithValue("@p3", TxtID.Text);
                    komut8.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt Güncellendi");
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (RdbOgrenciList.Checked == true)
            {
                baglanti.Open();
                SqlCommand komut10 = new SqlCommand("delete from OgrenciList where OgrenciID=@p1", baglanti);
                komut10.Parameters.AddWithValue("@p1", TxtID.Text);
                komut10.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti");
            }
            if(RdbEgitimciList.Checked == true)
            {
                baglanti.Open();
                SqlCommand komut10 = new SqlCommand("delete from EgitimciList where EgitimciID=@p1", baglanti);
                komut10.Parameters.AddWithValue("@p1", TxtID.Text);
                komut10.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti");
            }
            if(RdbKursList.Checked == true)
            {
                baglanti.Open();
                SqlCommand komut10 = new SqlCommand("delete from KursList where KursID=@p1", baglanti);
                komut10.Parameters.AddWithValue("@p1", TxtID.Text);
                komut10.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti");
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RdbOgrenciList.Checked == true)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtKursID.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            if (RdbEgitimciList.Checked == true)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtKursID.Text = " ";
            }
            if (RdbKursList.Checked == true)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtSoyad.Text= " ";
                TxtKursID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();


            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            if(RdbAd.Checked == true)
            {
                dataGridView1.DataSource = tb.AdaGoreListele(TxtAranacak.Text);
            }
            if(RdbSoyad.Checked == true)
            {
                dataGridView1.DataSource = tb.SoyadaGoreListele(TxtAranacak.Text);
            }
            
        }

        private void TxtAd_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
