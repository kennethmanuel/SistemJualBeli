using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace kenneth_ClassJualBeli
{
    public class Koneksi
    {
        private MySqlConnection koneksiDB;

        #region properties
        public MySqlConnection KoneksiDB { get => koneksiDB; private set => koneksiDB = value; }
        #endregion

        #region constructors
        public Koneksi(string namaServer, string namaDatabase, string username, string password)
        {
            string strConnectionString;
            if (password != "")
            {
                strConnectionString = "Server=" + namaServer + ";Database=" + namaDatabase + ";Uid=" + username + ";Pwd=" + password + ";charset=utf8";
            }
            else
            {
                strConnectionString = "Server=" + namaServer + ";Database=" + namaDatabase + ";Uid=" + username + ";charset=utf8";
            }

            this.KoneksiDB = new MySqlConnection();
            this.KoneksiDB.ConnectionString = strConnectionString;

            Connect();
        }
        #endregion

        

        #region method
        public void Connect()
        {
            //jika koneksi sedang terbuka maka tutup dulu
            if (KoneksiDB.State == System.Data.ConnectionState.Open)
            {
                KoneksiDB.Close();
            }
            KoneksiDB.Open();
        }
        #endregion

    }
}
