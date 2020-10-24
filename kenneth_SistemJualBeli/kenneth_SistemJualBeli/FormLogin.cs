using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kenneth_ClassJualBeli;

namespace kenneth_SistemJualBeli
{
    public partial class FormLogin : Form
    {
        List<Pegawai> listPegawai = new List<Pegawai>();
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.Height = panelLogin.Height + 50;

            // For convinience
            textBoxServer.Text = "localhost";
            textBoxDatabase.Text = "si_jual_beli";
            textBoxUsername.Text = "andrew";
            textBoxPassword.Text = "1234";
        }

        private void linkLabelPengaturanLanjut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Height = 50 + panelLogin.Height + panelPengaturan.Height;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxServer.Text != "" && textBoxDatabase.Text != "")
            {
                this.Height = panelLogin.Height + 50;
            }
            else
            {
                MessageBox.Show("Nama server dan database tidak boleh dikosongi", "Kesalahan");
            }
           
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxUsername.Text == "")
                {
                    MessageBox.Show("Username tidak boleh dikosongi.");
                }
                else if (textBoxServer.Text == "")
                {
                    MessageBox.Show("Server tidak boleh dikosongi.");
                }
                else if (textBoxDatabase.Text == "")
                {
                    MessageBox.Show("Database tidak boleh dikosongi.");
                }
                else
                {
                    Koneksi koneksi = new Koneksi(textBoxServer.Text, textBoxDatabase.Text, textBoxUsername.Text, textBoxPassword.Text);

                    //uji coba create objek bertipe Koneksi menggunakan default constructor
                    Koneksi koneksi2 = new Koneksi();

                    // Enable FormUtama
                    this.Owner.Enabled = true;

                    listPegawai = Pegawai.BacaData("username", textBoxUsername.Text);
                    if(listPegawai.Count > 0)
                    {
                        FormUtama formUtama = (FormUtama)this.Owner;
                        formUtama.labelKodePegawai.Text = listPegawai[0].KodePegawai.ToString();
                        formUtama.labelNamaPegawai.Text = listPegawai[0].Nama;
                        formUtama.labelJabatan.Text = listPegawai[0].Jabatan.Nama;

                        formUtama.PengaturanHakAksesMenu(listPegawai[0].Jabatan);

                        MessageBox.Show("Koneksi berhasil. Selamat menggunakan aplikasi.", "Informasi");

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username tidak ditemukan");
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal: " + ex.Message);
            }
        }
    }
}
