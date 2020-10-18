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
    public partial class FormTambahPegawai : Form
    {
        List<Jabatan> listJabatan = new List<Jabatan>();

        public FormTambahPegawai()
        {
            InitializeComponent();
        }

        private void FormTambahPegawai_Load(object sender, EventArgs e)
        {
            listJabatan = Jabatan.BacaData("", "");

            comboBoxJabatan.DataSource = listJabatan;
            comboBoxJabatan.DisplayMember = "Nama";

            try
            {
                string kodeBaru = Pegawai.GenerateCode().ToString();
                textBoxKodePegawai.Text = kodeBaru;
                textBoxNamaPegawai.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan:" + ex.Message);
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                Jabatan selectedJabatan = (Jabatan)comboBoxJabatan.SelectedItem;

                Pegawai p = new Pegawai(int.Parse(textBoxKodePegawai.Text), textBoxNamaPegawai.Text, dateTimePickerTanggalLahir.Value, textBoxAlamat.Text, int.Parse(textBoxGaji.Text), textBoxUsername.Text, textBoxPassword.Text, selectedJabatan);

                Pegawai.TambahData(p);

                MessageBox.Show("Data pegawai berhasil ditambahkan", "Info");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Data pegawai gagal ditambahkan. Pesan kesalahan:" + ex.Message, "Kesalahan");
            }
        }

        private void textBoxKodePegawai_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
