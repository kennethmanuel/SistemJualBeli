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
    public partial class FormHapusPegawai : Form
    {
        List<Jabatan> listJabatan = new List<Jabatan>();
        List<Pegawai> listPegawai = new List<Pegawai>();

        public FormHapusPegawai()
        {
            InitializeComponent();
        }

        private void textBoxKodePegawai_TextChanged(object sender, EventArgs e)
        {
            listPegawai = Pegawai.BacaData("KodePegawai", textBoxKodePegawai.Text);

            if(listPegawai.Count > 0)
            {
                textBoxNamaPegawai.Text = listPegawai[0].Nama;
                dateTimePickerTanggalLahir.Value = listPegawai[0].TanggalLahir;
                textBoxAlamat.Text = listPegawai[0].Alamat;
                textBoxGaji.Text = listPegawai[0].Gaji.ToString();
                textBoxUsername.Text = listPegawai[0].Username;
            }

        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                Jabatan selectedJabatan = (Jabatan)comboBoxJabatan.SelectedItem;

                Pegawai p = new Pegawai(int.Parse(textBoxKodePegawai.Text), textBoxNamaPegawai.Text, dateTimePickerTanggalLahir.Value, textBoxAlamat.Text, int.Parse(textBoxGaji.Text), textBoxUsername.Text, textBoxPassword.Text, selectedJabatan);

                Pegawai.HapusData(p);

                MessageBox.Show("Data pegawai berhasil dihapus", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data pegawai gagal dihapus. Pesan kesalahan:" + ex.Message, "Kesalahan");
            }
        }

        private void FormHapusPegawai_Load(object sender, EventArgs e)
        {

        }
    }
}
