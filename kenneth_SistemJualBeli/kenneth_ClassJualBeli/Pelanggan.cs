using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;

namespace kenneth_ClassJualBeli
{
    public class Pelanggan
    {
        private int kodePelanggan;
        private string nama;
        private string alamat;
        private string telepon;


        #region Constructors
        public Pelanggan(int kodePelanggan, string nama, string alamat, string telepon)
        {
            this.kodePelanggan = kodePelanggan;
            this.nama = nama;
            this.alamat = alamat;
            this.telepon = telepon;
        }
        #endregion

        #region Properties
        public int KodePelanggan { get => kodePelanggan; set => kodePelanggan = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Telepon { get => telepon; set => telepon = value; }
        #endregion

        #region Methods
        public static void TambahData(Pelanggan p)
        {
            string sql = "INSERT INTO pelanggan(KodePelanggan, Nama, Alamat, Telepon) VALUES('" + p.KodePelanggan + "', '" + p.Nama.Replace("'", "\\'") + "', '" + p.Alamat + "', '" + p.Telepon + "')";



            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Pelanggan p)
        {
            string sql = "UPDATE pelanggan SET nama='" + p.Nama.Replace("'", "\\'") + "', alamat='" + p.Alamat + "', telepon='" + p.Telepon + "' WHERE kodepelanggan='" + p.KodePelanggan+ "'";
                          

            Koneksi.JalankanPerintahDML(sql);
        } 

        public static void HapusData(Pelanggan p)
        {
            string sql = "DELETE FROM pelanggan WHERE kodepelanggan='" + p.KodePelanggan + "'";

            Koneksi.JalankanPerintahDML(sql);
        }
        #endregion


    }
}