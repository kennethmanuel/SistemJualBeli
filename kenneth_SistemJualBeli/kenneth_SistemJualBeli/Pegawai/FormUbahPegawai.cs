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
    public partial class FormUbahPegawai : Form
    {
        List<Jabatan> listJabatan = new List<Jabatan>();
        
        public FormUbahPegawai()
        {
            InitializeComponent();
        }

        private void FormUbahPegawai_Load(object sender, EventArgs e)
        {
            listJabatan = Jabatan.BacaData("", "");

            comboBoxJabatan.DataSource = listJabatan;
            comboBoxJabatan.DisplayMember = "Nama";
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {

        }
    }
}
