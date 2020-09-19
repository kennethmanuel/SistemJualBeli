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
    public partial class FormDaftarSupplier : Form
    {
        public FormDaftarSupplier()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahSupplier formTambahSupplier = new FormTambahSupplier();
            formTambahSupplier.Owner = this;
            formTambahSupplier.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahSupplier formUbahSupplier = new FormUbahSupplier();
            formUbahSupplier.Owner = this;
            formUbahSupplier.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusSupplier formHapusSupplier = new FormHapusSupplier();
            formHapusSupplier.Owner = this;
            formHapusSupplier.Show();
        }
    }
}
