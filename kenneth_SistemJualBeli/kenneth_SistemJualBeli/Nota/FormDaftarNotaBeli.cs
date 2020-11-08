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

namespace kenneth_SistemJualBeli
{
    public partial class FormDaftarNotaBeli : Form
    {
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
    }
}
