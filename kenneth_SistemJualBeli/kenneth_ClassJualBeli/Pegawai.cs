using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kenneth_ClassJualBeli
{
    public class Pegawai
    {
        private int kodePegawai;
        private string nama;
        private DateTime tanggalLahir;
        private int alamat;
        private int gaji;
        private string username;
        private string password;

        public Jabatan Jabatan
        {
            get => default;
            set
            {
            }
        }

        public int KodePegawai { get => kodePegawai; set => kodePegawai = value; }
        public string Nama { get => nama; set => nama = value; }
        public DateTime TanggalLahir { get => tanggalLahir; set => tanggalLahir = value; }
        public int Alamat { get => alamat; set => alamat = value; }
        public int Gaji { get => gaji; set => gaji = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}