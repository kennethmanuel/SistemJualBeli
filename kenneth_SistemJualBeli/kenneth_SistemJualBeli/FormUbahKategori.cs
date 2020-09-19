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
    public partial class FormUbahKategori : Form
    {
        public FormUbahKategori()
        {
            InitializeComponent();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Kategori k = new Kategori(textBoxKodeKategori.Text, textBoxNamaKategori.Text);

                Kategori.UbahData(k);

                MessageBox.Show("Data kategori berhasil dirubah", "info");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Perubahan gagal. Pesan kesalahan: " + ex.Message);
            }
        }
    }
}
