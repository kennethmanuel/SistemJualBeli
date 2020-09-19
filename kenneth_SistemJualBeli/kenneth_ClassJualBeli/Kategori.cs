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

        public Kategori(string kodeKategori, string nama)
        {
            KodeKategori = kodeKategori;
            Nama = nama;
        }

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
        #endregion
    }
}