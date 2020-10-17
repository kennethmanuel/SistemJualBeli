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
    public partial class FormDaftarPegawai : Form
    {
        List<Pegawai> listPegawai = new List<Pegawai>();
        public FormDaftarPegawai()
        {
            InitializeComponent();
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

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatDataGrid()
        {
            dataGridViewPegawai.Columns.Add("KodePegawai", "KodePegawai");
            dataGridViewPegawai.Columns.Add("Nama", "Nama");
            dataGridViewPegawai.Columns.Add("TglLahir", "TglLahir");
            dataGridViewPegawai.Columns.Add("Alamat", "Alamat");
            dataGridViewPegawai.Columns.Add("Gaji", "Gaji");
            dataGridViewPegawai.Columns.Add("Username", "Username");
            dataGridViewPegawai.Columns.Add("Jabatan", "Jabatan");

            dataGridViewPegawai.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["TglLahir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Gaji"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Jabatan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewPegawai.Columns["Gaji"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewPegawai.Columns["Gaji"].DefaultCellStyle.Format
                 = "#,###";


            dataGridViewPegawai.AllowUserToAddRows = false;

            dataGridViewPegawai.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            if (listPegawai.Count > 0)
            {
                dataGridViewPegawai.Rows.Clear();
                foreach (Pegawai p in listPegawai)
                {
                    dataGridViewPegawai.Rows.Add(p.KodePegawai, p.Nama, p.TanggalLahir.ToShortDateString(), p.Alamat, p.Gaji, p.Username, p.Jabatan.Nama);
                }
            }
            else
            {
                dataGridViewPegawai.DataSource = null;
            }
        }

        private void FormDaftarPegawai_Load(object sender, EventArgs e)
        {
            FormatDataGrid();

            listPegawai = Pegawai.BacaData("", "");

            TampilDataGrid();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if(comboBoxCari.Text == "Kode Pegawai")
            {
                kriteria = "p.kodepegawai";
            }
            else if(comboBoxCari.Text == "Nama")
            {
                kriteria = "p.nama";
            }
            else if(comboBoxCari.Text == "TglLahir")
            {
                kriteria = "p.tgllahir";
            }
            else if(comboBoxCari.Text == "Alamat")
            {
                kriteria = "p.alamat";
            }
            else if(comboBoxCari.Text == "Gaji")
            {
                kriteria = "p.gaji";
            }
            else if(comboBoxCari.Text == "Username")
            {
                kriteria = "p.username";
            }
            else if(comboBoxCari.Text == "Jabatan")
            {
                kriteria = "j.nama";
            }

            listPegawai = Pegawai.BacaData(kriteria, textBoxCari.Text);

            TampilDataGrid();
        }
    }
}
