using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace kenneth_ClassJualBeli
{
    public class Jabatan
    {
        private string idJabatan;
        private string nama;

        #region constructors
        public Jabatan(string idJabatan, string nama)
        {
            this.idJabatan = idJabatan;
            this.nama = nama;
        }
        #endregion

        #region Properties
        public string IdJabatan { get => idJabatan; set => idJabatan = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion

        #region methods
        public static List<Jabatan> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT * FROM jabatan";
            }
            else
            {
                sql = "SELECT * FROM jabatan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Jabatan> listJabatan = new List<Jabatan>();

            while (hasil.Read() == true)
            {
                Jabatan j = new Jabatan(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString());

                listJabatan.Add(j);
            }

            return listJabatan;
        }

        #endregion
    }
}