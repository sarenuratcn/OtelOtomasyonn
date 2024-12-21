using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp20
{
    internal class Musteri
    {
        // Base class for all customers
        public int Musteriid { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyet { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string TC { get; set; }
        public string OdaNo { get; set; }
        public decimal Ucret { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public string VipSecenekler { get; set; }
        public ListViewItem.ListViewSubItem VıpSecenekler { get; internal set; }


        // Constructor
        public Musteri(int id, string adi, string soyadi, string cinsiyet, string telefon, string mail, string tc, string odaNo, decimal ucret, DateTime girisTarihi, DateTime cikisTarihi, string vipSecenekler)
        {
            Musteriid = id;
            Adi = adi;
            Soyadi = soyadi;
            Cinsiyet = cinsiyet;
            Telefon = telefon;
            Mail = mail;
            TC = tc;
            OdaNo = odaNo;
            Ucret = ucret;
            GirisTarihi = girisTarihi;
            CikisTarihi = cikisTarihi;
            VipSecenekler = vipSecenekler;
        }

        // Method to show customer information
        public virtual void ShowDetails()
        {
            Console.WriteLine($"ID: {Musteriid}, Name: {Adi} {Soyadi}, Gender: {Cinsiyet}, Phone: {Telefon}, Email: {Mail}, VipSecenekler: {VipSecenekler}");
        }
    }
}
