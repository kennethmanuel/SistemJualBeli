using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace kenneth_ClassJualBeli
{
    public class Supplier
    {
        private int kodeSupplier;
        private string nama;
        private string alamat;

        #region Constructors
        public Supplier(int kodeSupplier, string nama, string alamat)
        {
            this.kodeSupplier = kodeSupplier;
            this.nama = nama;
            this.alamat = alamat;
        }
        #endregion

        #region Properties
        public int KodeSupplier { get => kodeSupplier; set => kodeSupplier = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        #endregion

        #region Methods
        public static void TambahData(Supplier s)
        {
            string sql = "INSERT INTO supplier(kodesupplier, nama, alamat) " + "VALUES('" + s.KodeSupplier + "', '" + s.Nama + "', '" + s.Alamat + "')";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Supplier s)
        {
            string sql = "UPDATE supplier SET nama='" + s.Nama + "', alamat='" + s.Alamat + "' WHERE kodesupplier='" + s.KodeSupplier + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void HapusData(Supplier s)
        {
            string sql = "DELETE FROM supplier WHERE kodesupplier='" + s.KodeSupplier + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static List<Supplier> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT * FROM supplier";
            }
            else
            {
                sql = "SELECT * FROM supplier WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Supplier> listSupplier = new List<Supplier>();

            while (hasil.Read() == true)
            {
                Supplier s = new Supplier(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString()); 

                listSupplier.Add(s);
            }

            return listSupplier;
        }
        public static int GenerateCode()
        {
            string sql = "SELECT MAX(kodesupplier) FROM supplier";

            int hasilKode = 1;

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                hasilKode = int.Parse(hasil.GetValue(0).ToString()) + 1;
            }

            return hasilKode;
        }
        #endregion
    }
}