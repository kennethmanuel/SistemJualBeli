using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        #endregion
    }
}