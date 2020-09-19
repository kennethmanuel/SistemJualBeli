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
            this.Enabled = false;
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusKategori formHapusKategori = new FormHapusKategori();
            formHapusKategori.Owner = this;
            formHapusKategori.Show();
        }
    }
}
