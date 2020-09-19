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
    public partial class FormTambahBarang : Form
    {
        List<Kategori> listKategori = new List<Kategori>();
        public FormTambahBarang()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                Kategori selectedKategori = (Kategori)comboBoxKategori.SelectedItem;

                Barang b = new Barang(textBoxKode.Text, textBoxNamaBarang.Text, int.Parse(textBoxHargaJual.Text), textBoxBarcode.Text, int.Parse(textBoxStok.Text), selectedKategori);
                Barang.TambahData(b);

                MessageBox.Show("Data barang berhasil ditambahkan", "Informasi");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Gagal menambah data. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }

        private void FormTambahBarang_Load(object sender, EventArgs e)
        {
            //membaca data dari tabel kategori
            listKategori = Kategori.BacaData("", "");
            //menampilkan semua kategori yang ada di tabel kategori ke combobox menggunakana data binding 
            comboBoxKategori.DataSource = listKategori;
            comboBoxKategori.DisplayMember = "Nama";

            comboBoxKategori.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mendapatkan kategori yang dipilih user dari combobox
            Kategori selectedKategori = (Kategori)comboBoxKategori.SelectedItem;

            //generate kode barang sesuai dengan kategori yang dipilih
            string kodeBarang = Barang.GenerateCode(selectedKategori);

            //tampilkan ke textbox
            textBoxKode.Text = kodeBarang;

            textBoxBarcode.Focus();
        }
    }
}
