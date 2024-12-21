using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp20
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }


        private void BtnYeniMusteri_Click(object sender, EventArgs e)
        {
            FrmYeniMusteri fr= new FrmYeniMusteri();
            fr.Show();   
        }

        private void BtnMusteriler_Click(object sender, EventArgs e)
        {
            FrmMusteriler fr = new FrmMusteriler();
            fr.Show();
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void BtnOdalar_Click(object sender, EventArgs e)
        {
            FrmOdalar fr = new FrmOdalar();
            fr.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text=DateTime.Now.ToLongTimeString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMesajlar fr = new FrmMesajlar();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("pansiyon kayıt uygulaması");
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void BtnGelirGider_Click(object sender, EventArgs e)
        {
            FrmGelirGider fr= new FrmGelirGider();
            fr.Show(); 
        }

        private void BtnStoklar_Click(object sender, EventArgs e)
        {
            FrmStoklar fr= new FrmStoklar();
            fr.Show();
        }

        private void BtnAdminGiris_Click_1(object sender, EventArgs e)
        {
            AdminGiris fr = new AdminGiris();
            fr.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FrmsifreGuncelle fr = new FrmsifreGuncelle();
            fr.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void BtnMusteri_Click(object sender, EventArgs e)
        {
            VıpMusteriler fr = new VıpMusteriler();
            fr.Show();
        }
    }
}
