using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kenneth_ClassJualBeli
{
    public class Barang
    {
        private string kodeBarang;
        private string nama;
        private int hargaJual;
        private string barcode;
        private int stok;
        private Kategori kategori;

        #region constructors
        public Barang(string kodeBarang, string nama, int hargaJual, string barcode, int stok, Kategori kategori)
        {
            this.KodeBarang = kodeBarang;
            this.Nama = nama;
            this.HargaJual = hargaJual;
            this.Barcode = barcode;
            this.Stok = stok;
            this.Kategori = kategori;
        }
        #endregion

        #region properties
        public string KodeBarang { get => kodeBarang; set => kodeBarang = value; }
        public string Nama { get => nama; set => nama = value; }
        public int HargaJual { get => hargaJual; set => hargaJual = value; }
        public string Barcode { get => barcode; set => barcode = value; }
        public int Stok { get => stok; set => stok = value; }
        public Kategori Kategori { get => kategori; set => kategori = value; }
        #endregion

        public static void TambahData(Barang b)
        {
            string sql = "INSERT INTO barang(kodebarang, barcode, nama, hargajual, stok, kodekategori) VALUES('" + b.KodeBarang + "', '" + b.Barcode + "', '" + b.Nama + "', '" + b.HargaJual + "', '" + b.Stok + "', '" + b.Kategori.KodeKategori + "')";
            Koneksi.JalankanPerintahDML(sql);
        }

        public static string GenerateCode(Kategori k)
        {
            string sql = "SELECT MAX(RIGHT(kodebarang,3)) FROM barang WHERE kodekategori = '" + k.KodeKategori + "';";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            string hasilKode = "";
            if(hasil.Read() == true)
            {
                if(hasil.GetValue(0).ToString() != "") //jika barang dengan kategori parameter belum ada
                {
                    int kodeTerbaru = int.Parse(hasil.GetValue(0).ToString());

                    //gunakan PadLeft 
                    hasilKode = k.KodeKategori + kodeTerbaru.ToString().PadLeft(3, '0');
                }
                else //jika sudah ada barang dengan kategori parameter
                {
                    hasilKode = k.KodeKategori + "001";
                }
            }

            return hasilKode;
        }

    }
}