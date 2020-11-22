using kenneth_SistemJualBeli.Nota;
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
    public partial class FormDaftarNotaBeli : Form
    {
        List<NotaBeli> listNotaBeli = new List<NotaBeli>();

        string kriteria = "";

        public FormDaftarNotaBeli()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaBeli formTambahNotaBeli = new FormTambahNotaBeli();
            formTambahNotaBeli.Owner = this;
            formTambahNotaBeli.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormatDataGrid()
        {
            // Kosongi kolom datagridview
            dataGridViewNota.Columns.Clear();

            // Tambah kolom ke datagridview
            dataGridViewNota.Columns.Add("NoNota", "No Nota");
            dataGridViewNota.Columns.Add("Tanggal", "Tanggal");
            dataGridViewNota.Columns.Add("KodeSupplier", "Kode Supplier");
            dataGridViewNota.Columns.Add("NamaSupplier", "Nama Supplier");
            dataGridViewNota.Columns.Add("AlamatSupplier", "Alamat Supplier");
            dataGridViewNota.Columns.Add("KodePegawai", "Kode Peg");
            dataGridViewNota.Columns.Add("NamaPegawai", "Nama Pegawai");
            dataGridViewNota.Columns.Add("KodeBarang", "KodeBrg");
            dataGridViewNota.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewNota.Columns.Add("Harga", "Harga");
            dataGridViewNota.Columns.Add("Jumlah", "Jumalah");

            // Lebar kolom sesuai panjang / isi data
            dataGridViewNota.Columns["NoNota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["KodeSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["NamaSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["AlamatSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["NamaPegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["Harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Harga dan jumlah rata kanan
            dataGridViewNota.Columns["Harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNota.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Harga ditampilkan dengan format pemisah ribuan (1000 delimiter)
            dataGridViewNota.Columns["Harga"].DefaultCellStyle.Format = "#,###";

            // DatagridvJualiew tidak bisa diganti user
            dataGridViewNota.AllowUserToAddRows = false;
            dataGridViewNota.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            // Clear datagridview
            dataGridViewNota.Rows.Clear();

            if (listNotaBeli.Count > 0)
            {
                // tampilkan semua isi listnotaBeli di datagridview
                foreach (NotaBeli n in listNotaBeli)
                {
                    foreach (NotaBeliDetil nbd in n.ListNotaBeliDetil)
                    {
                        dataGridViewNota.Rows.Add(
                            n.NoNota,
                            n.Tanggal,
                            n.Supplier.KodeSupplier,
                            n.Supplier.Nama,
                            n.Supplier.Alamat,
                            n.Pegawai.KodePegawai,
                            n.Pegawai.Nama,
                            nbd.Barang.KodeBarang,
                            nbd.Barang.Nama,
                            nbd.Harga,
                            nbd.Jumlah);
                    }
                }
            }
            else
            {
                dataGridViewNota.DataSource = null;
            }
        }

        private void FormDaftarNotaBeli_Load(object sender, EventArgs e)
        {
            FormatDataGrid();

            listNotaBeli = NotaBeli.BacaData("", "");

            TampilDataGrid();

        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            NotaBeli.CetakNota(kriteria, textBoxCari.Text, "daftar_nota_beli.txt", new Font("Courier New", 12));


        }
    }
}
