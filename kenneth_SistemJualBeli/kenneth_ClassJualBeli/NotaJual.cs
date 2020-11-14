using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace kenneth_ClassJualBeli
{
    public class NotaJual
    {
        private string noNota;
        private DateTime tanggal;
        private Pelanggan pelanggan;
        private Pegawai pegawai;
        private List<NotaJualDetil> listNotaJualDetil;

        #region Constructors
        public NotaJual(string noNota, DateTime tanggal, Pelanggan pelanggan, Pegawai pegawai)
        {
            this.NoNota = noNota;
            this.Tanggal = tanggal;
            this.Pelanggan = pelanggan;
            this.Pegawai = pegawai;
            this.ListNotaJualDetil = listNotaJualDetil;
        }
        #endregion

        #region Properties
        public string NoNota { get => noNota; set => noNota = value; }
        public DateTime Tanggal { get => tanggal; set => tanggal = value; }
        public Pelanggan Pelanggan { get => pelanggan; set => pelanggan = value; }
        public Pegawai Pegawai { get => pegawai; set => pegawai = value; }
        public List<NotaJualDetil> ListNotaJualDetil { get => listNotaJualDetil; private set => listNotaJualDetil = value; }
        #endregion

        #region Methods

        // Menambahkan detil barang dalam nota
        public void TambahNotaJualDetil(int harga, int jumlah, Barang barang)
        {
            NotaJualDetil notaJualDetil = new NotaJualDetil(harga, jumlah, barang);

            listNotaJualDetil.Add(notaJualDetil);
        }

        // Menambah nota jual baru
        public static void TambahData(NotaJual nota)
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                try
                {
                    // INSERT ke tabel nota jual
                    string sql1 = "INSERT INTO notajual(nonota, tanggal, kodepelanggan, kodepegawai) VALUES ('" + nota.NoNota + "','" + nota.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "','" + nota.Pelanggan.KodePelanggan + "','" + nota.Pegawai.KodePegawai + "')";
                    Koneksi.JalankanPerintahDML(sql1);

                    // Mendapatkan semua detil barang yang ada di nota jual teserbut
                    foreach(NotaJualDetil detilNota in nota.ListNotaJualDetil)
                    {
                        // Insert ke tabel notajualdetil
                        string sql2 = "INSERT INTO notajualdetil(nonota, kodebarang, harga, jumlah) VALUES ('" + nota.noNota + "','" + detilNota.Barang.KodeBarang + "','" + detilNota.Harga + "','" + detilNota.Jumlah + "')";
                        Koneksi.JalankanPerintahDML(sql2);

                        // Update stok barang yang terjual
                        Barang.UpdateStok("penjualan", detilNota.Barang.KodeBarang, detilNota.Jumlah);
                    }
                    // Commit jika semua berhasil
                    tScope.Complete();

                }
                catch (Exception e)
                {
                    // Batalkan semua perintah yang ada dalam transaction scope tScope
                    tScope.Dispose();

                    throw (new Exception("Penyimpanan transaksi penjualan gagal. Pesan kesalahan: " + e.Message));
                }

            }

        }

        // Generate nomor nota
        public static string GenerateNoNota()
        {
            string sql = "SELECT RIGHT(nonota, 3) AS nouruttransaksi " +
                         "FROM notajual " +
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