using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace kenneth_ClassJualBeli
{
    public class Pegawai
    {
        private int kodePegawai;
        private string nama;
        private DateTime tanggalLahir;
        private string alamat;
        private int gaji;
        private string username;
        private string password;

        #region constructors
        public Pegawai(int kodePegawai, string nama, DateTime tanggalLahir, string alamat, int gaji, string username, string password)
        {
            this.kodePegawai = kodePegawai;
            this.nama = nama;
            this.tanggalLahir = tanggalLahir;
            this.alamat = alamat;
            this.gaji = gaji;
            this.username = username;
            this.password = password;
        }
        #endregion

        #region properties
        public int KodePegawai { get => kodePegawai; set => kodePegawai = value; }
        public string Nama { get => nama; set => nama = value; }
        public DateTime TanggalLahir { get => tanggalLahir; set => tanggalLahir = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public int Gaji { get => gaji; set => gaji = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        #endregion

        #region methods
        public static void TambahData(Pegawai p)
        {
            string sql = "INSERT INTO pegawai(kodepegawai, nama, tgllahir, alamat, gaji, username, password) VALUES('" + p.KodePegawai + "', '" + p.Nama + "', '" + p.TanggalLahir + "', '" + p.Alamat + "', '" + p.Gaji + "', '" + p.Username + "', '" + p.Password + "')";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Pegawai p)
        {
            string sql = "UPDATE pegawai SET nama='" + p.Nama + "', tgllahir='" + p.TanggalLahir + "', alamat='" + p.Alamat + "', gaji='" + p.Gaji + "', username='" + p.Username + "', password='" + p.Password + "' WHERE p.KodePegawai='" + p.KodePegawai + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void HapusData(Pegawai p)
        {
            string sql = "DELETE FROM pegawai WHERE kodepegawai='" + p.KodePegawai + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        //public List<Pegawai> listPegawai(string kriteria, string nilaiKriteria)
        //{
        //    string sql = "";

        //    if (kriteria == "")
        //    {
        //        sql = "SELECT * FROM pegawai";
        //    }
        //    else
        //    {
        //        sql = "SELECT * FROM pegawai WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
        //    }

        //    MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

        //    List<Pegawai> listPegawai = new List<Pegawai>();

        //    while (hasil.Read() == true)
        //    {
        //        Pegawai p = new Pegawai(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString(), DateTime.Parse(hasil.GetValue(2).ToString()),hasil.GetValue(3).ToString(),int.Parse(hasil.GetValue(4).ToString()),hasil.GetValue(5).ToString(),hasil.GetValue(6).ToString());

        //        listPegawai.Add(p);
        //    }

        //    return listPegawai;
        //}

        //public static int GenerateCode()
        //{
        //    string sql = "SELECT MAX(kodepegawai) FROM pegawai";

        //    int hasilKode = 1;

        //    MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
        //    if (hasil.Read() == true)
        //    {
        //        hasilKode = int.Parse(hasil.GetValue(0).ToString()) + 1;
        //    }

        //    return hasilKode;
        //}
        #endregion
    }
}