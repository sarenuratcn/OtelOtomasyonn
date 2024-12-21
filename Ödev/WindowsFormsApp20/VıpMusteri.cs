using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp20
{
    internal class VıpMusteri : Musteri
    {
        // Derived class for VIP customers

            public string VipLevel { get; set; } // New property for VIP customers

            // Constructor for VIP customer
            public VıpMusteri(int id, string adi, string soyadi, string cinsiyet, string telefon, string mail, string tc, string odaNo, decimal ucret, DateTime girisTarihi, DateTime cikisTarihi, string vipLevel, string VipSecenekler)
                : base(id, adi, soyadi, cinsiyet, telefon, mail, tc, odaNo, ucret, girisTarihi, cikisTarihi, vipLevel)
            {
                VipLevel = vipLevel;
            }

            // Overriding the ShowDetails method for VIP customers
            public override void ShowDetails()
            {
                base.ShowDetails(); // Call the base method
                Console.WriteLine($"VIP Level: {VipLevel}"); // Show VIP-specific information
            }       
    }
}
