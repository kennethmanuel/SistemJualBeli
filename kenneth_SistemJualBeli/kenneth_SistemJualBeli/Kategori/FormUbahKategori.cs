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
    public partial class FormUbahKategori : Form
    {
        List<Kategori> listKategori = new List<Kategori>();
        public FormUbahKategori()
        {
            InitializeComponent();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Kategori k = new Kategori(textBoxKodeKategori.Text, textBoxNamaKategori.Text);

                Kategori.UbahData(k);

                MessageBox.Show("Data kategori berhasil dirubah", "info");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Perubahan gagal. Pesan kesalahan: " + ex.Message);
            }
        }
        private void FormUbahKategori_Load(object sender, EventArgs e)
        {
            textBoxKodeKategori.MaxLength = 2;
        }

        private void textBoxKodeKategori_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKodeKategori.Text.Length == textBoxKodeKategori.MaxLength)
            {
                listKategori = Kategori.BacaData("KodeKategori", textBoxKodeKategori.Text);

                if (listKategori.Count > 0)
                {
                    textBoxNamaKategori.Text = listKategori[0].Nama;
                    textBoxNamaKategori.Focus();
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

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKodeKategori.Clear();
            textBoxNamaKategori.Clear();
            textBoxKodeKategori.Focus();
        }
    }
}
