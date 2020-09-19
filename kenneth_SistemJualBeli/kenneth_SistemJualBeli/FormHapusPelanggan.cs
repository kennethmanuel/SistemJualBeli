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
    public partial class FormHapusPelanggan : Form
    {
        public FormHapusPelanggan()
        {
            InitializeComponent();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data kategori akan dihapus. Apakah anda yakin?", "Konfirmasi", MessageBoxButtons.YesNo);

            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Pelanggan p = new Pelanggan(int.Parse(textBoxKode.Text), textBoxNama.Text, textBoxAlamat.Text, textBoxTelepon.Text);

                    Pelanggan.HapusData(p);

                    MessageBox.Show("Data pelanggan telah terhapus");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Perubahan gagal. Pesan kesalahan: " + ex.Message);
                }

            }
        }
    }
}
