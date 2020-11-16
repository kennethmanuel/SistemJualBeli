using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Transactions;

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
            this.ListNotaBeliDetil = new List<NotaBeliDetil>();
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

            ListNotaBeliDetil.Add(notaBeliDetil);
        }

        // Menambah nota beli baru
        public static void TambahData(NotaBeli nota)
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                try
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
                    // Commit setelah semua perintah sql berhasil
                    tScope.Complete();
                }
                catch (Exception e)
                {
                    tScope.Dispose();

                    throw (new Exception("Penyimpanan transaksi pembelian gagal. Pesan kesalahan: " + e.Message));
                }
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

        public static List<NotaBeli> BacaData(string kriteria, string nilaiKriteria)
        {
            // sql1: menampilkan semua data dari tabel NotaBeli
            string sql1 = "";
            if (kriteria == "")
            {
                sql1 =
                    "SELECT n.nonota, n.tanggal, n.kodesupplier, s.nama AS namasupplier, s.alamat AS alamatsupplier, n.kodepegawai, p.nama AS namapegawai " +
                    "FROM notabeli n " +
                    "INNER JOIN supplier s ON n.kodesupplier = s.kodesupplier " +
                    "INNER JOIN pegawai p ON n.kodepegawai = p.kodepegawai " +
                    "ORDER BY n.nonota DESC "; 

            }
            else
            {
                sql1 =
                    "SELECT n.nonota, n.tanggal, n.kodesupplier, s.nama AS namasupplier, s.alamat AS alamatsupplier, n.kodepegawai, p.nama " +
                    "FROM notabeli n " +
                    "INNER JOIN supplier s ON n.kodesupplier = s.kodesupplier " +
                    "INNER JOIN pegawai p ON n.kodepegawai = p.kodepegawai " +
                    "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%' " +
                    "ORDER BY n.nonota DESC "; 
            }
            // Data reader 1: get semua data di tabel NotaBeli
            MySqlDataReader hasilData1 = Koneksi.JalankanPerintahQuery(sql1);
            List<NotaBeli> listHasilData = new List<NotaBeli>();

            while (hasilData1.Read() == true)
            {
                // Get nomor nota beli dari hasil data reader
                string nomorNota = hasilData1.GetValue(0).ToString();

                // Get tanggal nota dari hasil data reader
                DateTime tglNota = DateTime.Parse(hasilData1.GetValue(1).ToString());

                // Get supplier yang melakukan transaksi
                List<Supplier> listSupplier = Supplier.BacaData("kodesupplier", hasilData1.GetValue(2).ToString());

                // Get pegawai pembuat nota
                List<Pegawai> listPegawai = Pegawai.BacaData("p.kodepegawai", hasilData1.GetValue(5).ToString());

                // Nota Beli
                NotaBeli nota = new NotaBeli(nomorNota, tglNota, listSupplier[0], listPegawai[0]);

                // Query 2: get detil nota beli dari tiap nota beli
                // sql2: get barang yang ada di nota (tabel NotaBeliDetil)
                string sql2 =
                    "SELECT nbd.kodebarang, b.nama, nbd.harga, nbd.jumlah " +
                    "FROM notabeli n " +
                    "INNER JOIN notabelidetil nbd ON n.nonota = nbd.nonota " +
                    "INNER JOIN barang b ON nbd.kodebarang = b.kodebarang " +
                    "WHERE n.nonota = '" + nomorNota + "'";

                // Data reader 2: get semua data barang di NotaJualDetil
                MySqlDataReader hasilData2 = Koneksi.JalankanPerintahQuery(sql2);

                while (hasilData2.Read())
                {
                    // Barang yang terjual
                    List<Barang> listBarang = Barang.BacaData("B.KodeBarang", hasilData2.GetValue(0).ToString());

                    // Get harga beli transaksi
                    int hrgJual = int.Parse(hasilData2.GetValue(2).ToString());

                    // Get jumlah barang dibeli
                    int jumJual = int.Parse(hasilData2.GetValue(3).ToString());

                    // DetilNotaBeli
                    NotaBeliDetil detilNota = new NotaBeliDetil(hrgJual, jumJual, listBarang[0]);

                    // Simpan detil barang ke nota
                    nota.TambahNotaBeliDetil(hrgJual, jumJual, listBarang[0]);
                }
                // Save to list
                listHasilData.Add(nota);
            }
            return listHasilData;

        }
        #endregion


    }
}