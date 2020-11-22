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
    public partial class FormDaftarNotaJual : Form
    {
        List<NotaJual> listNotaJual = new List<NotaJual>();

        string kriteria = "";

        public FormDaftarNotaJual()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaJual formTambahNotaJual = new FormTambahNotaJual();
            formTambahNotaJual.Owner = this;
            formTambahNotaJual.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatDataGrid()
        {
            // Kosongi kolom datagridview
            dataGridViewNota.Columns.Clear();

            // Tambah kolom ke datagridview
            dataGridViewNota.Columns.Add("NoNota", "No Nota");
            dataGridViewNota.Columns.Add("Tanggal", "Tanggal");
            dataGridViewNota.Columns.Add("KodePelanggan", "Kode Plg");
            dataGridViewNota.Columns.Add("NamaPelanggan", "Nama Pelanggan");
            dataGridViewNota.Columns.Add("AlamatPelanggan", "Alamat Pelanggan");
            dataGridViewNota.Columns.Add("KodePegawai", "Kode Peg");
            dataGridViewNota.Columns.Add("NamaPegawai", "Nama Pegawai");
            dataGridViewNota.Columns.Add("KodeBarang", "KodeBrg");
            dataGridViewNota.Columns.Add("NamaBarang", "Nama Barang" );
            dataGridViewNota.Columns.Add("Harga", "Harga");
            dataGridViewNota.Columns.Add("Jumlah", "Jumalah");

            // Lebar kolom sesuai panjang / isi data
            dataGridViewNota.Columns["NoNota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["KodePelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["NamaPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNota.Columns["AlamatPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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

            // Datagridview tidak bisa diganti user
            dataGridViewNota.AllowUserToAddRows = false;
            dataGridViewNota.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            // Kosongi datagridview
            dataGridViewNota.Rows.Clear();

            if(listNotaJual.Count > 0)
            {
                // tampilkan semua isi listNotaJual di datagridview
                foreach (NotaJual n in listNotaJual)
                {
                    foreach (NotaJualDetil njd in n.ListNotaJualDetil)
                    {
                        dataGridViewNota.Rows.Add(
                            n.NoNota,
                            n.Tanggal,
                            n.Pelanggan.KodePelanggan,
                            n.Pelanggan.Nama,
                            n.Pelanggan.Alamat,
                            n.Pegawai.KodePegawai,
                            n.Pegawai.Nama,
                            njd.Barang.KodeBarang,
                            njd.Barang.Nama,
                            njd.Harga,
                            njd.Jumlah);
                    }
                }    
            }
            else
            {
                dataGridViewNota.DataSource = null;
            }
        }

        private void FormDaftarNotaJual_Load(object sender, EventArgs e)
        {
            FormatDataGrid();

            listNotaJual = NotaJual.BacaData("", "");

            TampilDataGrid();
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            NotaJual.CetakNota(kriteria, textBoxCari.Text, "daftar_nota_jual.txt", new Font("Courier New", 12));

        }
    }
}
