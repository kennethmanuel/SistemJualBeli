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
    public partial class FormDaftarBarang : Form
    {
        List<Barang> listBarang = new List<Barang>();
        public FormDaftarBarang()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahBarang formTambahBarang = new FormTambahBarang();
            formTambahBarang.Owner = this;
            formTambahBarang.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //method  utk tambah kolom
        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Add("KodeBarang", "KodeBarang");
            dataGridViewBarang.Columns.Add("Barcode", "Barcode");
            dataGridViewBarang.Columns.Add("NamaBarang", "NamaBarang");
            dataGridViewBarang.Columns.Add("HargaJual", "HargaJual");
            dataGridViewBarang.Columns.Add("Stok", "Stok");
            dataGridViewBarang.Columns.Add("KodeKategori", "KodeKategori");
            dataGridViewBarang.Columns.Add("NamaKategori", "NamaKategori");

            //atur alignment
            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["Stok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //pemisah ribuan harga jual
            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Format = "#,###";

            //lebar kolom flex
            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Barcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["KodeKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void TampilDataGrid()
        {
            if (listBarang.Count > 0)
            {
                dataGridViewBarang.Rows.Clear();
                foreach (Barang b in listBarang)
                {
                    dataGridViewBarang.Rows.Add(b.KodeBarang, b.Barcode, b.Nama, b.HargaJual, b.Stok, b.Kategori.KodeKategori, b.Kategori.Nama);
                }
            }
            else
            {
                dataGridViewBarang.DataSource = null;
            }
        }
        private void FormDaftarBarang_Load(object sender, EventArgs e)
        {
            FormatDataGrid();

            listBarang = Barang.BacaData("", "");

            TampilDataGrid();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "Kode Barang")
            {
                kriteria = "b.kodebarang";
            }
            else if (comboBoxCari.Text == "Nama Barang")
            {
                kriteria = "b.nama";
            }
            else if (comboBoxCari.Text == "Barcode")
            {
                kriteria = "b.barcode";
            }
            else if (comboBoxCari.Text == "Harga Jual")
            {
                kriteria = "b.hargajual";
            }
            else if (comboBoxCari.Text == "Kode Kategori")
            {
                kriteria = "b.kodekategori";
            }
            else if (comboBoxCari.Text == "Stok")
            {
                kriteria = "b.stok";
            }
            else if (comboBoxCari.Text == "Nama Kategori")
            {
                kriteria = "k.nama";
            }

            listBarang = Barang.BacaData(kriteria, textBoxCari.Text);

            TampilDataGrid();
        }
    }
}
