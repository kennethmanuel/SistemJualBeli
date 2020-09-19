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
    public partial class FormDaftarSupplier : Form
    {
        public List<Supplier> listSupplier = new List<Supplier>();
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

        public void FormDaftarSupplier_Load(object sender, EventArgs e)
        {
            listSupplier = Supplier.BacaData("", "");

            if (listSupplier.Count > 0)
            {
                dataGridViewSupplier.DataSource = listSupplier;
            }
            else
            {
                dataGridViewSupplier.DataSource = null;
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCari.Text == "Kode Supplier")
            {
                listSupplier = Supplier.BacaData("kodesupplier", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "Nama")
            {
                listSupplier = Supplier.BacaData("nama", textBoxCari.Text);
            }
            else if(comboBoxCari.Text == "Alamat")
            {
                listSupplier = Supplier.BacaData("alamat", textBoxCari.Text);
            }

            if (listSupplier.Count > 0)
            {
                dataGridViewSupplier.DataSource = listSupplier;
            }
            else
            {
                dataGridViewSupplier.DataSource = null;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
