using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.IO;
using System.Drawing;

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
            this.ListNotaJualDetil = new List<NotaJualDetil>();
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

            ListNotaJualDetil.Add(notaJualDetil);
        }

        // Menambah nota jual baru
        public static void TambahData(NotaJual nota)
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                try
                {
                    // INSERT ke tabel nota jual
                    string sql1 = 
                        "INSERT INTO notajual(nonota, tanggal, kodepelanggan, kodepegawai) " +
                        "VALUES ('" + nota.NoNota + "','" + nota.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "','" + nota.Pelanggan.KodePelanggan + "','" + nota.Pegawai.KodePegawai + "')";

                    Koneksi.JalankanPerintahDML(sql1);

                    // Mendapatkan semua detil barang yang ada di nota jual teserbut
                    foreach(NotaJualDetil detilNota in nota.ListNotaJualDetil)
                    {
                        // Insert ke tabel notajualdetil
                        string sql2 =
                            "INSERT INTO notajualdetil(nonota, kodebarang, harga, jumlah)" +
                            " VALUES ('" + nota.noNota + "','" + detilNota.Barang.KodeBarang + "','" + detilNota.Harga + "','" + detilNota.Jumlah + "')";

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

        public static List<NotaJual> BacaData(string kriteria, string nilaiKriteria)
        {
            // sql1: menampilkan semua data di tabel NotaJual
            string sql1 = "";
            if (kriteria == "")
            {
                sql1 =
                    "SELECT n.nonota, n.tanggal, n.kodepelanggan, plg.nama AS NamaPelanggan, plg.alamat AS AlamatPelanggan, n.kodepegawai, peg.nama AS NamaPegawai " +
                    "FROM notajual n " +
                    "INNER JOIN pelanggan plg ON n.kodepelanggan = plg.kodepelanggan " +
                    "INNER JOIN pegawai peg ON n.kodepegawai = peg.kodepegawai " + 
                    "ORDER BY n.nonota DESC";  

            }
            else
            {
                sql1 =
                    "SELECT n.nonota, n.tanggal, n.kodepelanggan, plg.nama AS namapelanggan, plg.alamat AS alamat pelanggan, n.kodepegawai, peg.nama AS namapegawai " +
                    "FROM notajual n " +
                    "INNER JOIN pelanggan plg ON n.kodepelanggan = plg.kodepelanggan " +
                    "INNER JOIN pegawai peg ON n.kodepegawai = peg.kodepegawai " +
                    "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%' " +
                    "ORDER BY n.nonota DESC";

            }
            // Data reader 1 : memperoleh semua data di tabel NotaJual
            MySqlDataReader hasilData1 = Koneksi.JalankanPerintahQuery(sql1);
            List<NotaJual> listHasildata = new List<NotaJual>();

            while (hasilData1.Read() == true)
            {
                // Mendapatkan nomor nota jual dari hasil data reader
                string nomorNota = hasilData1.GetValue(0).ToString();

                // Mendapatkan tanggal nota dari hasil data reader
                DateTime tglNota = DateTime.Parse(hasilData1.GetValue(1).ToString());

                // PELANGGAN yang melakukan transaksi (cari data di table pelanggan sesuai kode pelanggan yang dihasilkan)
                List<Pelanggan> listPelanggan = Pelanggan.BacaData("KodePelanggan", hasilData1.GetValue(2).ToString());

                // PEGAWAI PEMBUAT NOTA (cari data di tabel pegawai sesuai kode pegawai yang dihasilkan)
                List<Pegawai> listPegawai = Pegawai.BacaData("P.KodePegawai", hasilData1.GetValue(5).ToString());

                // NOTA JUAL
                // Create objek bertipe NotaJual
                NotaJual nota = new NotaJual(nomorNota, tglNota, listPelanggan[0], listPegawai[0]);

                // Query 2: mendapatkan detil nota jual dari tiap nota jual
                // sql2: mendapatkan barang yang ada di nota (dari tabel NotaJualDetil)
                string sql2 =
                    "SELECT njd.kodebarang, b.nama, njd.harga, njd.jumlah " +
                    "FROM notajual n " +
                    "INNER JOIN notajualdetil njd ON n.nonota = njd.nonota " +
                    "INNER JOIN barang b ON njd.kodebarang = b.kodebarang " +
                    "WHERE n.nonota = '" + nomorNota + "'";

                // Data reader 2: memperoleh semua data barang nota di tabel NotaJualDetil
                MySqlDataReader hasilData2 = Koneksi.JalankanPerintahQuery(sql2);

                while(hasilData2.Read() == true)
                {
                    // Barang yang terjual
                    List<Barang> listBarang = Barang.BacaData("B.KodeBarang", hasilData2.GetValue(0).ToString());

                    // Mendapatkan harga jual transaksi
                    int hrgJual = int.Parse(hasilData2.GetValue(2).ToString());

                    // Mendapatkan jumlah barang terjual
                    int jumJual = int.Parse(hasilData2.GetValue(3).ToString());

                    // Create objek DetilNotaJual
                    NotaJualDetil detilNota = new NotaJualDetil(hrgJual, jumJual, listBarang[0]);

                    // Simpan detil barang ke nota
                    nota.TambahNotaJualDetil(hrgJual, jumJual, listBarang[0]);
                }
                // Simpan ke list
                listHasildata.Add(nota);
            }
            return listHasildata;

        }

        public static void CetakNota(string Kriteria, string NilaiKriteria, string NamaFile, Font Font)
        {
            List<NotaJual> listNotaJual = new List<NotaJual>();

            // Baca data nota yang akan dicetak
            listNotaJual = NotaJual.BacaData(Kriteria, NilaiKriteria);

            // Simpan isi nota yang akan ditampilkan ke objek StreamWriter
            StreamWriter file = new StreamWriter(NamaFile);

            foreach (NotaJual nota in listNotaJual)
            {
                // Info perusahaan
                file.WriteLine("");
                file.WriteLine("TOKO MAJU MAKMUR UNTUNG SELALU");
                file.WriteLine("Jl. Raya Kallirungkut Surabaya");
                file.WriteLine("telp. (031) - 12345678");
                file.WriteLine("=".PadRight(50,'='));

                // Tampilkan header nota
                file.WriteLine("No.Nota: " + nota.NoNota);
                file.WriteLine("Tanggal: " + nota.Tanggal);
                file.WriteLine("");
                file.WriteLine("Pelanggan: " + nota.Pelanggan.Nama);
                file.WriteLine("Alamat   : " + nota.Pelanggan.Alamat);
                file.WriteLine("");
                file.WriteLine("Kasir    : " + nota.Pegawai.Nama);
                file.WriteLine("=".PadRight(50, '='));

                int grandTotal = 0;
                //Tampilkan barang yang terjual
                foreach (NotaJualDetil njd in nota.ListNotaJualDetil)
                {
                    string nama = njd.Barang.Nama;
                    // Jika nama terlalu panjang tampilkan 30 karakter
                    if(nama.Length > 30)
                    {
                        nama = nama.Substring(0, 30);
                    }

                    int jumlah = njd.Jumlah;
                    int harga = njd.Harga;
                    int subTotal = jumlah * harga;
                    file.Write(nama.PadRight(30, ' '));
                    file.Write(jumlah.ToString().PadRight(3, ' '));
                    file.Write(harga.ToString("#,###").PadRight(7, ' '));
                    file.Write(subTotal.ToString("#,###").PadRight(10, ' '));
                    file.WriteLine("");
                    grandTotal += subTotal;
                }
                file.WriteLine("=".PadRight(50,'='));
                file.WriteLine("TOTAL: " + grandTotal.ToString("#,###"));
                file.WriteLine("=".PadRight(50,'='));
                file.WriteLine("Terima kasih atas kunjungan Anda");
                file.WriteLine("");
            }
            file.Close();
            // Cetak ke printer
            Cetak c = new Cetak(NamaFile, Font, 20, 10, 10, 10);
            c.CetakKePrinter("text");

        }
        #endregion 
    }
}