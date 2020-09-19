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
    public partial class FormUbahPelanggan : Form
    {
        List<Pelanggan> listPelanggan = new List<Pelanggan>();
        public FormUbahPelanggan()
        {
            InitializeComponent();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Pelanggan p = new Pelanggan(int.Parse(textBoxKode.Text),textBoxNama.Text, textBoxAlamat.Text,textBoxTelepon.Text);

                Pelanggan.UbahData(p);

                MessageBox.Show("Data pelanggan berhasil dirubah", "info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Perubahan gagal. Pesan kesalahan: " + ex.Message);
            }
        }

        private void textBoxKode_TextChanged(object sender, EventArgs e)
        {
            listPelanggan = Pelanggan.BacaData("kodepelanggan", textBoxKode.Text);

            if (listPelanggan.Count > 0)
            {
                textBoxNama.Text = listPelanggan[0].Nama;
                textBoxAlamat.Text = listPelanggan[0].Alamat;
                textBoxTelepon.Text = listPelanggan[0].Telepon;
            }
            else
            {
                MessageBox.Show("Kode pelanggan tidak ditemukan.", "Kesalahan");
                textBoxKode.Text = "";
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPelanggan formDaftarPelanggan = (FormDaftarPelanggan)this.Owner;
            formDaftarPelanggan.FormDaftarPelanggan_Load(buttonKeluar, e);
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKode.Clear();
            textBoxNama.Clear();
            textBoxAlamat.Clear();
            textBoxTelepon.Clear();
            textBoxKode.Focus();
        }
    }
}
