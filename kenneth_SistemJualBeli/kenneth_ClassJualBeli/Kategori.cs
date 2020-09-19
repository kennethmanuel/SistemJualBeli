using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kenneth_ClassJualBeli
{
    public class Kategori
    {

        private string kodeKategori;
        private string nama;

        #region constructors
        public Kategori(string kodeKategori, string nama)
        {
            KodeKategori = kodeKategori;
            Nama = nama;
        }
        #endregion

        #region properties
        public string KodeKategori { get => kodeKategori; set => kodeKategori = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion

        #region Methods
        public static void TambahData(Kategori k)
        {
            string sql = "insert into kategori(KodeKategori, Nama) values('" + k.KodeKategori + "', '"+ k.Nama.Replace("'", "\\'") +"')";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Kategori k)
        {
            string sql = "update kategori set Nama='" + k.Nama.Replace("'", "\\'") + "' where KodeKategori='" + k.kodeKategori + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void HapusData(Kategori k)
        {
            string sql = "DELETE FROM kategori WHERE kodeKategori = '" + k.KodeKategori + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static List<Kategori> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT * FROM kategori";
            }
            else
            {
                sql = "SELECT * FROM kategori WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Kategori> listKategori = new List<Kategori>();

            while (hasil.Read() == true)
            {
                Kategori k = new Kategori(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString());

                listKategori.Add(k);
            }

            return listKategori;
        }

        public static string GenerateKode()
        {
            string sql = "SELECT MAX(kodekategori) FROM kategori";

            string hasilKode = "";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                int kodeBaru = int.Parse(hasil.GetValue(0).ToString()) + 1;

                hasilKode = kodeBaru.ToString().PadLeft(2, '0');
            }
            else
            {
                hasilKode = "01";
            }

            return hasilKode;
        }
        #endregion
    }
}