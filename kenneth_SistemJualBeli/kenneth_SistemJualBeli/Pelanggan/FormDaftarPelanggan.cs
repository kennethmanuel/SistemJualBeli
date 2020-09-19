using kenneth_ClassJualBeli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kenneth_SistemJualBeli
{
    public partial class FormDaftarPelanggan : Form
    {
        List<Pelanggan> listPelanggan = new List<Pelanggan>();
        public FormDaftarPelanggan()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPelanggan formTambahPelanggan = new FormTambahPelanggan();
            formTambahPelanggan.Owner = this;
            formTambahPelanggan.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPelanggan formUbahPelanggan = new FormUbahPelanggan();
            formUbahPelanggan.Owner = this;
            formUbahPelanggan.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPelanggan formHapusPelanggan = new FormHapusPelanggan();
            formHapusPelanggan.Owner = this;
            formHapusPelanggan.Show();
        }

        public void FormDaftarPelanggan_Load(object sender, EventArgs e)
        {
            listPelanggan = Pelanggan.BacaData("", "");

            if (listPelanggan.Count > 0)
            {
                dataGridViewPelanggan.DataSource = listPelanggan;
            }
            else
            {
                dataGridViewPelanggan.DataSource = null;
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCari.Text == "Kode Pelanggan")
            {
                listPelanggan = Pelanggan.BacaData("kodepelanggan", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "Nama")
            {
                listPelanggan = Pelanggan.BacaData("nama", textBoxCari.Text);
            }
            else if(comboBoxCari.Text == "Alamat")
            {
                listPelanggan = Pelanggan.BacaData("alamat", textBoxCari.Text);
            }
            else if(comboBoxCari.Text == "Telepon")
            {
                listPelanggan = Pelanggan.BacaData("telepon", textBoxCari.Text);
            }

            if (listPelanggan.Count > 0)
            {
                dataGridViewPelanggan.DataSource = listPelanggan;
            }
            else
            {
                dataGridViewPelanggan.DataSource = null;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
