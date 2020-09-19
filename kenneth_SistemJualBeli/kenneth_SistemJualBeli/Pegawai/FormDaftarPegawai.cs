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
    public partial class FormDaftarPegawai : Form
    {
        public FormDaftarPegawai()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPegawai formTambahPegawai = new FormTambahPegawai();
            formTambahPegawai.Owner = this;
            formTambahPegawai.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPegawai formUbahPegawai = new FormUbahPegawai();
            formUbahPegawai.Owner = this;
            formUbahPegawai.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPegawai formHapusPegawai = new FormHapusPegawai();
            formHapusPegawai.Owner = this;
            formHapusPegawai.Show();
        }
    }
}
