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
    public partial class FormTambahPelanggan : Form
    {
        public FormTambahPelanggan()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
               Pelanggan p = new Pelanggan(int.Parse(textBoxKode.Text), textBoxNama.Text, textBoxAlamat.Text,textBoxTelepon.Text);

                Pelanggan.TambahData(p);

                MessageBox.Show("Data pelanggan telah tersimpan", "info");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Penyimpanan gagal. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }
    }
}
