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
    public partial class FormTambahSupplier : Form
    {
        public FormTambahSupplier()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier s = new Supplier(int.Parse(textBoxKode.Text), textBoxNama.Text, textBoxAlamat.Text);

                Supplier.TambahData(s);

                MessageBox.Show("Data supplier telah tersimpan", "info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penyimpanan gagal. Pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }
    }
}
