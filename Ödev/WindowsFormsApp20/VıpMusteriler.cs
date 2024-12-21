using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp20
{
    public partial class VıpMusteriler : Form
    {
        // id'yi formun sınıf düzeyinde tanımlıyoruz
        private int id;

        // Liste oluşturuluyor, tüm müşterileri burada saklayacağız
        private List<Musteri> musteriler = new List<Musteri>();

        public VıpMusteriler()
        {
            InitializeComponent();
        }

        // Method to add a regular customer
        private void AddRegularCustomer()
        {
            Musteri yeniMusteri = new Musteri(
                1, // ID
                TxtAdi.Text, // Name
                TxtSoyadi.Text, // Surname
                comboBox1.Text, // Gender
                MskTelefonNo.Text, // Phone
                TxtMail.Text, // Email
                TxtTcNo.Text, // TC
                TxtOdaNo.Text, // Room number
                decimal.Parse(TxtUcret.Text), // Fee
                DtpGirisTarihi.Value, // Check-in date
                DtpCikisTarihi.Value, // Check-out date
                comboBox2.Text // VipSeçenekler

            );

            musteriler.Add(yeniMusteri);
            MessageBox.Show("Müşteri eklendi");
        }

        // Method to add a VIP customer
        private void AddVipCustomer()
        {
            VıpMusteri yeniVipMusteri = new VıpMusteri(
                2, // ID
                TxtAdi.Text, // Name
                TxtSoyadi.Text, // Surname
                comboBox1.Text, // Gender
                MskTelefonNo.Text, // Phone
                TxtMail.Text, // Email
                TxtTcNo.Text, // TC
                TxtOdaNo.Text, // Room number
                decimal.Parse(TxtUcret.Text), // Fee
                DtpGirisTarihi.Value, // Check-in date
                DtpCikisTarihi.Value, // Check-out date
                "Gold", // VIP Level
                comboBox2.Text // VipSeçenekler

            );

            musteriler.Add(yeniVipMusteri);
            MessageBox.Show("VIP müşteri eklendi");
        }

        // Show customer details in the ListView
        private void ShowCustomerDetails()
        {
            listView1.Items.Clear();
            foreach (var musteri in musteriler)
            {
                ListViewItem item = new ListViewItem(musteri.Musteriid.ToString());
                item.SubItems.Add(musteri.Adi);
                item.SubItems.Add(musteri.Soyadi);
                item.SubItems.Add(musteri.Cinsiyet);
                item.SubItems.Add(musteri.Telefon);
                item.SubItems.Add(musteri.Mail);
                item.SubItems.Add(musteri.TC);
                item.SubItems.Add(musteri.OdaNo);
                item.SubItems.Add(musteri.Ucret.ToString());
                item.SubItems.Add(musteri.GirisTarihi.ToString("yyyy-MM-dd"));
                item.SubItems.Add(musteri.CikisTarihi.ToString("yyyy-MM-dd"));
                item.SubItems.Add(musteri.VipSecenekler);
                listView1.Items.Add(item);
            }
        }

        // Button click event to add a regular customer
        private void BtnRegularCustomer_Click(object sender, EventArgs e)
        {
            AddRegularCustomer();
            ShowCustomerDetails();
        }

        // Button click event to add a VIP customer
        private void BtnVipCustomer_Click(object sender, EventArgs e)
        {
            AddVipCustomer();
            ShowCustomerDetails();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=SERANUT\SQLEXPRESS02;Initial Catalog=AtacanOteli;Integrated Security=True");

        private void verilergosterr()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select* from MusteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Musteriid"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Mail"].ToString());
                ekle.SubItems.Add(oku["TC"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());
                ekle.SubItems.Add(oku["VipSecenekler"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void BtnVerileriGoster_Click(object sender, EventArgs e)
        {
            verilergosterr();
        }

        private void Musterii_Load(object sender, EventArgs e)
        {
            // Seçili öğe olup olmadığını kontrol et
            if (listView1.SelectedItems.Count > 0)
            {
                // Seçili öğe varsa, id'yi al
                try
                {
                    id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                    TxtAdi.Text = listView1.SelectedItems[0].SubItems[1].Text;
                    TxtSoyadi.Text = listView1.SelectedItems[0].SubItems[2].Text;
                    comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
                    MskTelefonNo.Text = listView1.SelectedItems[0].SubItems[4].Text;
                    TxtMail.Text = listView1.SelectedItems[0].SubItems[5].Text;
                    TxtTcNo.Text = listView1.SelectedItems[0].SubItems[6].Text;
                    TxtOdaNo.Text = listView1.SelectedItems[0].SubItems[7].Text;
                    TxtUcret.Text = listView1.SelectedItems[0].SubItems[8].Text;
                    DtpGirisTarihi.Text = listView1.SelectedItems[0].SubItems[9].Text;
                    DtpCikisTarihi.Text = listView1.SelectedItems[0].SubItems[10].Text;
                    comboBox2.Text = listView1.SelectedItems[0].SubItems[11].Text;

                }
                catch (Exception ex)
                {
                    // Hata oluşursa kullanıcıya bilgi ver
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtOdaNo.Text == "101")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda101", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilergosterr();
            }
            if (TxtOdaNo.Text == "102")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda102", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilergosterr();
            }
            if (TxtOdaNo.Text == "103")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda103", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilergosterr();
            }
            if (TxtOdaNo.Text == "104")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda104", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilergosterr();
            }
            if (TxtOdaNo.Text == "105")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda105", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilergosterr();
            }
            if (TxtOdaNo.Text == "106")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda106", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilergosterr();
            }
            if (TxtOdaNo.Text == "107")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda107", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilergosterr();
            }
            if (TxtOdaNo.Text == "108")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda108", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilergosterr();
            }
            if (TxtOdaNo.Text == "109")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda109", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilergosterr();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update MusteriEkle set Adi='" + TxtAdi.Text + "',Soyadi='" + TxtSoyadi.Text + "',Cinsiyet='" + comboBox1.Text + "',Telefon='" + MskTelefonNo.Text + "',Mail='" + TxtMail.Text + "',TC='" + TxtTcNo.Text + "',OdaNo='" + TxtOdaNo.Text + "',Ucret='" + TxtUcret.Text + "',GirisTarihi='" + DtpGirisTarihi.Value.ToString("yyyy.MM.dd") + "',CikisTarihi='" + DtpCikisTarihi.Value.ToString("yyyy.MM.dd") + "' where Musteriid='" + id + "'VipSecenekler='" + comboBox2.Text + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilergosterr();
        }

        private void BtnSill_Click(object sender, EventArgs e)
        {
            if (TxtOdaNo.Text == "101")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from MusteriEkle where Musteriid=(" + id + ")", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilergosterr();
            
            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("delete from Oda101", baglanti);
            //komut.ExecuteNonQuery();
            //baglanti.Close();
            //verilergosterr();
        }
            // Diğer oda numaraları için benzer silme işlemleri
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtAdi.Clear();
            TxtSoyadi.Clear();
            comboBox1.Text = "";
            MskTelefonNo.Text = "";
            TxtMail.Text = "";
            TxtTcNo.Clear();
            TxtOdaNo.Clear();
            TxtUcret.Clear();
            DtpCikisTarihi.Text = "";
            DtpGirisTarihi.Text = "";
            comboBox2.Text = "";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçili öğe olup olmadığını kontrol et
            if (listView1.SelectedItems.Count > 0)
            {
                try
                {
                    // Seçili öğe varsa, id'yi al
                    id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);  // ID'yi al

                    // Seçili öğenin diğer bilgilerini al
                    TxtAdi.Text = listView1.SelectedItems[0].SubItems[1].Text;
                    TxtSoyadi.Text = listView1.SelectedItems[0].SubItems[2].Text;
                    comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
                    MskTelefonNo.Text = listView1.SelectedItems[0].SubItems[4].Text;
                    TxtMail.Text = listView1.SelectedItems[0].SubItems[5].Text;
                    TxtTcNo.Text = listView1.SelectedItems[0].SubItems[6].Text;
                    TxtOdaNo.Text = listView1.SelectedItems[0].SubItems[7].Text;
                    TxtUcret.Text = listView1.SelectedItems[0].SubItems[8].Text;
                    DtpGirisTarihi.Text = listView1.SelectedItems[0].SubItems[9].Text;
                    DtpCikisTarihi.Text = listView1.SelectedItems[0].SubItems[10].Text;
                    comboBox2.Text = listView1.SelectedItems[0].SubItems[11].Text;

                }
                catch (Exception ex)
                {
                    // Hata oluşursa kullanıcıyı bilgilendir
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                // Eğer hiç öğe seçili değilse, kullanıcıya bir mesaj gösterebiliriz
                MessageBox.Show("Lütfen bir müşteri seçiniz.");
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from MusteriEkle where Adi like '%" + TxtAra.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Musteriid"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Mail"].ToString());
                ekle.SubItems.Add(oku["TC"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());
                ekle.SubItems.Add(oku["VipSecenekler"].ToString());
                listView1.Items.Add(ekle);
            }
                baglanti.Close();
        }
    }
}

             