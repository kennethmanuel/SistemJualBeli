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
    public partial class FormDaftarKategori : Form
    {
        public List<Kategori> listKategori = new List<Kategori>();
        public FormDaftarKategori()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahKategori formTambahKategori = new FormTambahKategori();
            formTambahKategori.Owner = this;
            formTambahKategori.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahKategori formUbahKategori = new FormUbahKategori();
            formUbahKategori.Owner = this;
            formUbahKategori.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusKategori formHapusKategori = new FormHapusKategori();
            formHapusKategori.Owner = this;
            formHapusKategori.Show();
        }

        public void FormDaftarKategori_Load(object sender, EventArgs e)
        {
            listKategori = Kategori.BacaData("", "");

            if (listKategori.Count > 0)
            {
                dataGridViewKategori.DataSource = listKategori;
            }
            else
            {
                dataGridViewKategori.DataSource = null;
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCari.Text == "Kode Kategori")
            {
                listKategori = Kategori.BacaData("kodekategori", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "Nama Kategori")
            {
                listKategori = Kategori.BacaData("nama", textBoxCari.Text);
            }

            if (listKategori.Count > 0)
            {
                dataGridViewKategori.DataSource = listKategori;
            }
            else
            {
                dataGridViewKategori.DataSource = null;
            }

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
