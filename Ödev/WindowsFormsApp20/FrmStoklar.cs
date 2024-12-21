using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp20
{
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=SERANUT\\SQLEXPRESS02;Initial Catalog=AtacanOteli;Integrated Security=True;");
       
        private void veriler1()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand(" Select * from Stoklar", baglanti);
            SqlDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = (oku1["Gida"].ToString());
                ekle.SubItems.Add(oku1["İcecek"].ToString());
                ekle.SubItems.Add(oku1["Cerezler"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void veriler2()
        {
            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand(" select * from Faturalar", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = (oku2["Elektrik"].ToString());
                ekle.SubItems.Add(oku2["Su"].ToString());
                ekle.SubItems.Add(oku2["İnternet"].ToString() );
                listView2.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            veriler1();
            veriler2();
        }

        private void BtnKaydet2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into Faturalar(Elektrik,Su,İnternet) values ('"+TxtElektrik.Text+"','"+TxtSu.Text+"','"+Txtİnternet.Text+"')", baglanti) ;
            komut2.ExecuteNonQuery();
            baglanti.Close() ;
            veriler2();
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into Stoklar(Gida,İcecek,Cerezler) values ('" + TxtGidalar.Text + "','" + TxtIcecekler.Text + "','" + TxtAtistirmaliklar.Text + "')", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            veriler1();
        }
    }
}
