using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 
using System.Configuration;

namespace kenneth_ClassJualBeli
{
    public class Koneksi
    {
        private MySqlConnection koneksiDB;

        #region properties
        public MySqlConnection KoneksiDB { get => koneksiDB; private set => koneksiDB = value; }
        #endregion

        #region constructors
        public Koneksi()
        {
            koneksiDB = new MySqlConnection();

            //set connection string sesuai yang ada di App.Config
            KoneksiDB.ConnectionString = ConfigurationManager.ConnectionStrings["namakoneksi"].ConnectionString;

            //panggil method connect
            Connect();
        }
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

            UpdateAppConfig(strConnectionString);
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

        public void UpdateAppConfig(string con)
        {
            //buka konfigurasi App.Config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //set App.Config pada section yang telah dibuat sebelumnya
            config.ConnectionStrings.ConnectionStrings["namakoneksi"].ConnectionString = con;

            //Simpan App.Config yang telah diupdate 
            config.Save(ConfigurationSaveMode.Modified, true);

            //Reload App.Config dengan pengaturan yang baru
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static void JalankanPerintahDML(string sql)
        {
            Koneksi k = new Koneksi();

            MySqlCommand c = new MySqlCommand(sql, k.koneksiDB);

            c.ExecuteNonQuery();
        }

        public static MySqlDataReader JalankanPerintahQuery(string sql)
        {
            Koneksi k = new Koneksi();

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            MySqlDataReader hasil = c.ExecuteReader();

            return hasil;
        }

        public static string GetNamaServer()
        {
            //ambil connection string yang tersimpan di App.config
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["namakoneksi"].ConnectionString;

            return con.DataSource;
        }

        public static string GetNamaDatabase()
        {
            //ambil connection string yang tersimpan di App.config
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["namakoneksi"].ConnectionString;

            return con.Database;
        }

        #endregion

    }
}
