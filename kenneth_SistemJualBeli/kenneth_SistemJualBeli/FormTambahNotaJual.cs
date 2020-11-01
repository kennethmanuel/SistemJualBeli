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
    public partial class FormTambahNotaJual : Form
    {
        FormUtama formUtama;
        List<Pelanggan> listPelanggan = new List<Pelanggan>();
        public FormTambahNotaJual()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTambahNotaJual_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.Owner.MdiParent;

            // Generate no nota baru
            textBoxNoNota.Text = NotaJual.GenerateNoNota();

            // Tampilkan pegawai yang sedang login
            labelKodePegawai.Text = formUtama.labelKodePegawai.Text;
            labelNamaPegawai.Text = formUtama.labelNamaPegawai.Text;

            // Set default tanggal ke hari ini
            dateTimePickerTanggal.Value = DateTime.Now;

            // Tampilkan data pelanggan di combobox dengan data binding
            listPelanggan = Pelanggan.BacaData("", "");
            comboBoxPelanggan.DataSource = listPelanggan;
            comboBoxPelanggan.DisplayMember = "Nama";
        }

        private void comboBoxPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxPelanggan.SelectedIndex != -1)
            {
                Pelanggan selectedPelanggan = (Pelanggan)comboBoxPelanggan.SelectedItem;
                labelAlamat.Text = selectedPelanggan.Alamat;

            }
            else
            {
                labelAlamat.Text = "";

            }
        }
    }
}
