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
    }
}
