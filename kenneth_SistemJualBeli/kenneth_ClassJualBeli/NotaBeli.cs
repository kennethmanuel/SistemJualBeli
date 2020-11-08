using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace kenneth_ClassJualBeli
{
    public class NotaBeli
    {
        private string noNota;
        private DateTime tanggal;
        private Supplier supplier;
        private Pegawai pegawai;
        private List<NotaBeliDetil> listNotaBeliDetil;

        #region Constructors
        public NotaBeli(string noNota, DateTime tanggal, Supplier supplier, Pegawai pegawai)
        {
            this.NoNota = noNota;
            this.Tanggal = tanggal;
            this.Supplier = supplier;
            this.Pegawai = pegawai;
            this.ListNotaBeliDetil = listNotaBeliDetil;
        }
        #endregion

        #region Properties
        public string NoNota { get => noNota; set => noNota = value; }
        public DateTime Tanggal { get => tanggal; set => tanggal = value; }
        public Supplier Supplier { get => supplier; set => supplier = value; }
        public Pegawai Pegawai { get => pegawai; set => pegawai = value; }
        public List<NotaBeliDetil> ListNotaBeliDetil { get => listNotaBeliDetil; private set => listNotaBeliDetil = value; }
        #endregion

        #region Methods
        // Menambahkan detil barang dalam nota
        public void TambahNotaBeliDetil(int harga, int jumlah, Barang barang)
        {
            NotaBeliDetil notaBeliDetil = new NotaBeliDetil(harga, jumlah, barang);

            listNotaBeliDetil.Add(notaBeliDetil);
        }

        // Menambah nota beli baru
        public static void TambahData(NotaBeli nota)
        {
            string sql1 = "INSERT INTO notabeli(nonota, tanggal, kodesupplier, kodepegawai) VALUES ('" + nota.NoNota + "','" + nota.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "','" + nota.Supplier.KodeSupplier + "','" + nota.Pegawai.KodePegawai + "')";

            Koneksi.JalankanPerintahDML(sql1);

            // Mendapatkan semua detil barang yang ada di nota beli
            foreach (NotaBeliDetil detilNota in nota.ListNotaBeliDetil)
            {
                string sql2 = "INSERT INTO notabelidetil(nonota, kodebarang, harga, jumlah) VALUES ('" + nota.NoNota + "','" + detilNota.Barang.KodeBarang + "','" + detilNota.Harga + "','" + detilNota.Jumlah + "')";

                Koneksi.JalankanPerintahDML(sql2);

                // Update stok barang dibeli
                Barang.UpdateStok("pembelian", detilNota.Barang.KodeBarang, detilNota.Jumlah);
            }
        }

        // Generate nomor nota
        public static string GenerateNoNota()
        {
            string sql = "SELECT RIGHT(nonota, 3) AS nouruttransaksi " +
                         "FROM notabeli " +
                         "WHERE DATE(tanggal) = DATE(CURRENT_DATE) " +
                         "ORDER BY tanggal DESC LIMIT 1";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            string hasilNoNota = "";
            if(hasil.Read() == true)
            {
                if(hasil.GetValue(0).ToString() != "")
                {
                    int noUrutTrans = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    hasilNoNota = DateTime.Now.Year +
                                  DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                  DateTime.Now.Day.ToString().PadLeft(2, '0') +
                                  noUrutTrans.ToString().PadLeft(3, '0');
                }
            }
            else
            {
                hasilNoNota = DateTime.Now.Year +
                              DateTime.Now.Month.ToString().PadLeft(2, '0') +
                              DateTime.Now.Day.ToString().PadLeft(2, '0') +
                              "001";
            }
            return hasilNoNota;
        } 
        #endregion


    }
}