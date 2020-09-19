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
    public partial class FormUbahSupplier : Form
    {
        List<Supplier> listSupplier = new List<Supplier>();
        public FormUbahSupplier()
        {
            InitializeComponent();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier s = new Supplier(int.Parse(textBoxKode.Text), textBoxNama.Text, textBoxAlamat.Text);

                Supplier.UbahData(s);

                MessageBox.Show("Data Supplier berhasil dirubah", "info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Perubahan gagal. Pesan kesalahan: " + ex.Message);
            }
        }

        private void textBoxKode_TextChanged(object sender, EventArgs e)
        {
            listSupplier = Supplier.BacaData("kodesupplier", textBoxKode.Text);

            if (listSupplier.Count > 0)
            {
                textBoxNama.Text = listSupplier[0].Nama;
                textBoxAlamat.Text = listSupplier[0].Alamat;
            }
            else
            {
                MessageBox.Show("Kode supplier tidak ditemukan.", "Kesalahan");
                textBoxKode.Text = "";
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarSupplier formDaftarSupplier = (FormDaftarSupplier)this.Owner;
            formDaftarSupplier.FormDaftarSupplier_Load(buttonKeluar, e);
            this.Close();
        }
    }
}
