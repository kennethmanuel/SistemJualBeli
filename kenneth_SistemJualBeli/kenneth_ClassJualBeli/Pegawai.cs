﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Transactions;

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
        private Jabatan jabatan;

        #region constructors
        public Pegawai(int kodePegawai, string nama, DateTime tanggalLahir, string alamat, int gaji, string username, string password, Jabatan jabatan)
        {
            this.kodePegawai = kodePegawai;
            this.nama = nama;
            this.tanggalLahir = tanggalLahir;
            this.alamat = alamat;
            this.gaji = gaji;
            this.username = username;
            this.password = password;
            this.Jabatan = jabatan;
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
        public Jabatan Jabatan { get => jabatan; set => jabatan = value; }
        #endregion

        #region methods
        public static void TambahData(Pegawai p)
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                try
                {
                    string sql = "INSERT INTO pegawai(kodepegawai, nama, tgllahir, alamat, gaji, username, password, idjabatan) VALUES('" + p.KodePegawai + "', '" + p.Nama + "', '" + p.TanggalLahir.ToString("yyyy-MM-dd") + "', '" + p.Alamat + "', '" + p.Gaji + "', '" + p.Username + "', '" + p.Password + "','" + p.Jabatan.IdJabatan + "')";

                    Koneksi.JalankanPerintahDML(sql);
                    ManajemenUser(p);

                    tScope.Complete();
                }
                catch (Exception e)
                {
                    tScope.Dispose();

                    throw (new Exception("Penambahan data pegawai gagal. Pesan kesalahan" + e.Message));

                }
            }
        }

        public static void UbahData(Pegawai p)
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                try
                {
                    string sql = "UPDATE pegawai SET nama='" + p.Nama.Replace("'", "\\'") + "', tgllahir='" + p.TanggalLahir.ToString("yyyy-MM-dd") + "', alamat='" + p.Alamat + "', gaji='" + p.Gaji + "', username='" + p.Username + "', password='" + p.Password + "' WHERE KodePegawai='" + p.KodePegawai + "'";

                    Koneksi.JalankanPerintahDML(sql);

                    string serverName = Koneksi.GetNamaServer();
                    UbahPasswordUser(p, serverName);

                    tScope.Complete();
                        
                }
                catch (Exception e)
                {
                    tScope.Dispose();

                    throw (new Exception("Ubah data pegawai gagal. Pesan kesalahan: " + e.Message));
                    
                }
            }
        }

        public static void HapusData(Pegawai p)
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                try
                {
                    string sql = "DELETE FROM pegawai WHERE kodepegawai='" + p.KodePegawai + "'";

                    Koneksi.JalankanPerintahDML(sql);
                    string serverName = Koneksi.GetNamaServer();
                    HapusUser(p, serverName);

                    tScope.Complete();
                }
                catch (Exception e)
                {
                    tScope.Dispose();

                    throw (new Exception("Penghapusan data pegawai gagal. Pesan kesalahan: " + e.Message));
                }
            }
        }

        public static List<Pegawai> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT p.kodepegawai, p.nama, p.tgllahir, p.alamat, p.gaji, p.username, p.password, j.idjabatan, j.nama AS 'jabatan' FROM pegawai p INNER JOIN jabatan j ON p.idjabatan = j.idjabatan ;";
            }
            else
            {
                sql = "SELECT p.kodepegawai, p.nama, p.tgllahir, p.alamat, p.gaji, p.username, p.password, j.idjabatan, j.nama AS 'jabatan' FROM pegawai p INNER JOIN jabatan j ON p.idjabatan = j.idjabatan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Pegawai> listPegawai = new List<Pegawai>();

            while (hasil.Read() == true)
            {
                Pegawai p = new Pegawai(
                    int.Parse(hasil.GetValue(0).ToString()),
                    hasil.GetValue(1).ToString(),
                    DateTime.Parse(hasil.GetValue(2).ToString()),
                    hasil.GetValue(3).ToString(),
                    int.Parse(hasil.GetValue(4).ToString()),
                    hasil.GetValue(5).ToString(), hasil.GetValue(6).ToString(),
                    new Jabatan(hasil.GetValue(7).ToString(), hasil.GetValue(8).ToString())
                    );

                listPegawai.Add(p);
            }

            return listPegawai;
        }

        public static int GenerateCode()
        {
            string sql = "SELECT MAX(kodepegawai) FROM pegawai";

            int hasilKode = 1;

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                hasilKode = int.Parse(hasil.GetValue(0).ToString()) + 1;
            }

            return hasilKode;
        }

        // USER BARU
        public static void BuatUserBaru(Pegawai pPegawai, string pNamaServer)
        {
            string sql = "CREATE USER '" + pPegawai.Username + "'@'" + pNamaServer + "' IDENTIFIED BY '" + pPegawai.Password + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void BeriHakAkses(Pegawai pPegawai, string pNamaServer, string pNamaDatabase)
        {
            string sql = "GRANT ALL PRIVILEGES ON " + pNamaDatabase + ".* TO '" + pPegawai.Username + "'@'" + pNamaServer + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void ManajemenUser(Pegawai p)
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                try
                {
                    string namaServer = Koneksi.GetNamaServer();
                    string namaDatabase = Koneksi.GetNamaDatabase();

                    Pegawai.BuatUserBaru(p, namaServer);
                    Pegawai.BeriHakAkses(p, namaServer, namaDatabase);

                    tScope.Complete();
                }
                catch (Exception e)
                {
                    tScope.Dispose();

                    throw (new Exception("Manajemen user gagal. Pesan kesalahann: " + e.Message));
                }

            }
        }

        public static void UbahPasswordUser(Pegawai pPegawai, string pNamaServer)
        {
            string sql = "SET PASSWORD FOR '" + pPegawai.Username + "'@'" + pNamaServer + "'=PASSWORD('" + pPegawai.Password + "')";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void HapusUser(Pegawai pPegawai, string pNamaServer)
        {
            string sql = "DROP USER '" + pPegawai.Username + "'@'" + pNamaServer + "'";
            Koneksi.JalankanPerintahDML(sql);
        }
        #endregion
    }
}