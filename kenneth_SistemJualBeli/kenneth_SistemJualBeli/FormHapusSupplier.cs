﻿using System;
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
    public partial class FormHapusSupplier : Form
    {
        List<Supplier> listSupplier = new List<Supplier>();
        public FormHapusSupplier()
        {
            InitializeComponent();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data kategori akan dihapus. Apakah anda yakin?", "Konfirmasi", MessageBoxButtons.YesNo);

            if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Supplier s = new Supplier(int.Parse(textBoxKode.Text), textBoxNama.Text, textBoxAlamat.Text);

                    Supplier.HapusData(s);

                    MessageBox.Show("Data supplier telah terhapus");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Perubahan gagal. Pesan kesalahan: " + ex.Message);
                }

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
