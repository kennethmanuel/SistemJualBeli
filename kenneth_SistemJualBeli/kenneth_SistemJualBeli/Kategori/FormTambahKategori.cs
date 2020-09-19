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
    public partial class FormTambahKategori : Form
    {
        public FormTambahKategori()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                Kategori k = new Kategori(textBoxKodeKategori.Text, textBoxNamaKategori.Text);

                Kategori.TambahData(k);

                MessageBox.Show("Data kategori telah tersimpan", "info");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Penyimpanan gagal. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            //Update data yang ada di FormDaftarKategori
            FormDaftarKategori formDaftarKategori = (FormDaftarKategori)this.Owner;
            formDaftarKategori.FormDaftarKategori_Load(buttonKeluar, e);
            this.Close();
        }

        private void FormTambahKategori_Load(object sender, EventArgs e)
        {
            string kodeBaru = Kategori.GenerateKode();

            textBoxKodeKategori.Text = kodeBaru;
            textBoxNamaKategori.Focus();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNamaKategori.Clear();
            textBoxNamaKategori.Focus();
        }
    }
}
