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

namespace kenneth_SistemJualBeli.Nota
{
    public partial class FormTambahNotaBeli : Form
    {
        FormUtama formUtama;

        List<Supplier> listSupplier = new List<Supplier>();

        List<Barang> listBarang = new List<Barang>();

        NotaBeli notaBeli;

        public FormTambahNotaBeli()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormatDataGrid()
        {
            // Kosongi semua kolom di datagridview
            dataGridViewBarang.Columns.Clear();

            // Menambah kolom di datagridview
            dataGridViewBarang.Columns.Add("KodeBarang", "Kode");
            dataGridViewBarang.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewBarang.Columns.Add("HargaBeli", "Harga Beli");
            dataGridViewBarang.Columns.Add("Jumlah", "Jumlah");
            dataGridViewBarang.Columns.Add("SubTotal", "SubTotal");

            // Sesuaikan lebar kolom dengan isi data
            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaBeli"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Rata kanan harga jual, jumlah, subtotal
            dataGridViewBarang.Columns["HargaBeli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Pemisah ribuan pada harga jual dan subtotal 
            dataGridViewBarang.Columns["HargaBeli"].DefaultCellStyle.Format = "#,###";
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Format = "#,###";

            // Membuat data grid tidak bisa diganti-ganti oleh user
            dataGridViewBarang.AllowUserToAddRows = false;
            dataGridViewBarang.ReadOnly = true;
        }

        private void FormTambahNotaBeli_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.Owner.MdiParent;

            // Tampilkan semua supplier ke combobox
            listSupplier = Supplier.BacaData("","");
            comboBoxSupplier.DataSource = listSupplier;
            comboBoxSupplier.DisplayMember = "Nama";
            comboBoxSupplier.DropDownStyle = ComboBoxStyle.DropDownList;

            // Generate no nota baru
            textBoxNoNota.Text = NotaJual.GenerateNoNota();

            // Tampilkan pegawai yang sedang login
            labelKodePegawai.Text = formUtama.labelKodePegawai.Text;
            labelNamaPegawai.Text = formUtama.labelNamaPegawai.Text;

            // Set default tanggal ke hari ini
            dateTimePickerTanggal.Value = DateTime.Now;

            // Tampilkan data pelanggan di combobox dengan data binding
            listSupplier = Supplier.BacaData("", "");
            comboBoxSupplier.DataSource = listSupplier;
            comboBoxSupplier.DisplayMember = "Nama";

            // Tambahkan Kolom di datagridviewbarang
            FormatDataGrid();

            // Texbox barcode max 13 karakter
            textBoxBarcode.MaxLength = 13;

        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Barcode telah selesai diketik/discan
            if (textBoxBarcode.Text.Length == textBoxBarcode.MaxLength)
            {
                // Cari barang dengan barcode tsb di tabel barang
                listBarang = Barang.BacaData("barcode", textBoxBarcode.Text);

                // Apabila barang ditemukan
                if (listBarang.Count > 0)
                {
                    labelKodeBarang.Text = listBarang[0].KodeBarang;
                    labelNamaBarang.Text = listBarang[0].Nama;
                    labelHargaBarang.Text = listBarang[0].HargaJual.ToString();
                    textBoxJumlah.Text = "1";

                    textBoxJumlah.Focus();
                }
                else
                {
                    MessageBox.Show("Barang dengan barcode tersebut tidak ditemukan");
                }
            }
        }

        private int HitungGrandTotal()
        {
            int grandTotal = 0;
            for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
            {
                int subTotal = 0;
                grandTotal += subTotal;
            }
            return grandTotal;
        }

        private void textBoxBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 1. Hitung subtotal
                int subTotal = int.Parse(labelHargaBarang.Text) * int.Parse(textBoxJumlah.Text);

                // 2. Tambahkan ke datagridview
                dataGridViewBarang.Rows.Add(labelKodeBarang.Text, labelNamaBarang.Text, labelHargaBarang.Text, textBoxJumlah.Text, subTotal);

                // 3. Hitung grandtotal nota dan tampilkan di label grandtotal
                labelGrandTotal.Text = HitungGrandTotal().ToString("#, ###");

                // 4. Kosongi barcode, nama barang, harga jual, dan jumlah
                textBoxBarcode.Clear();
                labelKodeBarang.Text = "";
                labelNamaBarang.Text = "";
                textBoxJumlah.Clear();
                textBoxBarcode.Focus();
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier supplierDipilih = (Supplier)comboBoxSupplier.SelectedItem;

                notaBeli = new NotaBeli(textBoxNoNota.Text, dateTimePickerTanggal.Value, supplierDipilih, formUtama.pegawaiLogin);

                List<Barang> listBarangDibeli = new List<Barang>();

                for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
                {
                    listBarangDibeli = Barang.BacaData("KodeBarang", dataGridViewBarang.Rows[i].Cells["KodeBarang"].Value.ToString());
                    int hargaBeli = int.Parse(dataGridViewBarang.Rows[i].Cells["HargaBeli"].ToString());
                    int jumlah = int.Parse(dataGridViewBarang.Rows[i].Cells["Jumlah"].ToString());
                    notaBeli.TambahNotaBeliDetil(hargaBeli, jumlah, listBarangDibeli[0]);
                }

                // Simpan ke nota jual
                NotaBeli.TambahData(notaBeli);

                MessageBox.Show("Data nota beli telah tersimpan", "Informasi");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan. Pesan kesalahan: " + ex.Message);
            }
        }
    }
}
