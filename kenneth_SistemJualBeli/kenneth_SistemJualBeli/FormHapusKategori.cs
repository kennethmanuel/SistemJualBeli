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
    public partial class FormHapusKategori : Form
    {
        List<Kategori> listKategori = new List<Kategori>();
        public FormHapusKategori()
        {
            InitializeComponent();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data kategori akan dihapus. Apakah anda yakin?", "Konfirmasi", MessageBoxButtons.YesNo);

            if(konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Kategori k = new Kategori(textBoxKodeKategori.Text, textBoxNamaKategori.Text);

                    Kategori.HapusData(k);

                    MessageBox.Show("Data kategori telah terhapus");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Perubahan gagal. Pesan kesalahan: " + ex.Message);
                }
                
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {

        }

        private void textBoxKodeKategori_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKodeKategori.Text.Length == textBoxKodeKategori.MaxLength)
            {
                listKategori = Kategori.BacaData("KodeKategori", textBoxKodeKategori.Text);

                if (listKategori.Count > 0)
                {
                    textBoxNamaKategori.Text = listKategori[0].Nama;
                }
                else
                {
                    MessageBox.Show("Kode kategori tidak ditemukan.", "Kesalahan");
                    textBoxKodeKategori.Text = "";
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarKategori formDaftarKategori = (FormDaftarKategori)this.Owner;
            formDaftarKategori.FormDaftarKategori_Load(buttonKeluar, e);
            this.Close();
        }
    }
}
