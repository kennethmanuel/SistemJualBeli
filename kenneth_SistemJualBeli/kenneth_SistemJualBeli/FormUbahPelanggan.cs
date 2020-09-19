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
    }
}
