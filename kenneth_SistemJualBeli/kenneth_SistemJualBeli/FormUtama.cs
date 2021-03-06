﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//reference yang digunakan sehingga dapat menggunakan class-class yang ada di kenneth_ClassJualBeli
using kenneth_ClassJualBeli; 
namespace kenneth_SistemJualBeli
{
    public partial class FormUtama : Form
    {
        public Pegawai pegawaiLogin;

        public FormUtama()
        {
            InitializeComponent();
        }

        private void FormUtama_Load(object sender, EventArgs e)
        {
            //fullscreen
            this.WindowState = FormWindowState.Maximized;

            //ubah menjadi MDIParent (MDIContainer)
            this.IsMdiContainer = true;

            //membuat form menu (form utama) tidak dapat diakses sampai user login
            this.Enabled = false;

            //menampilkan form login
            FormLogin formLogin = new FormLogin();
            formLogin.Owner = this;
            formLogin.Show();
        }
        private void kategoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form checkForm = Application.OpenForms["FormDaftarKategori"];

            if (checkForm == null)
            {
                FormDaftarKategori form = new FormDaftarKategori();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                checkForm.Show();
                checkForm.BringToFront();
            }
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form checkForm = Application.OpenForms["FormDaftarBarang"];

            if (checkForm == null)
            {
                FormDaftarBarang form = new FormDaftarBarang();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                checkForm.Show();
                checkForm.BringToFront();
            }
        }

        private void pegawaiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form checkForm = Application.OpenForms["FormDaftarPegawai"];

            if (checkForm == null)
            {
                FormDaftarPegawai form = new FormDaftarPegawai();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                checkForm.Show();
                checkForm.BringToFront();
            }
        }

        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form checkForm = Application.OpenForms["FormDaftarPelanggan"];

            if (checkForm == null)
            {
                FormDaftarPelanggan form = new FormDaftarPelanggan();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                checkForm.Show();
                checkForm.BringToFront();
            }
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form checkForm = Application.OpenForms["FormDaftarSupplier"];

            if (checkForm == null)
            {
                FormDaftarSupplier form = new FormDaftarSupplier();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                checkForm.Show();
                checkForm.BringToFront();
            }
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form checkForm = Application.OpenForms["FormDaftarNotaJual"];

            if (checkForm == null)
            {
                FormDaftarNotaJual form = new FormDaftarNotaJual();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                checkForm.Show();
                checkForm.BringToFront();
            }
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form checkForm = Application.OpenForms["FormDaftarNotaBeli"];

            if (checkForm == null)
            {
                FormDaftarNotaBeli form = new FormDaftarNotaBeli();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                checkForm.Show();
                checkForm.BringToFront();
            }
        }

        public void PengaturanHakAksesMenu(Jabatan j)
        {
            // (Pegawai Pembelian)
            if(j.IdJabatan == "J1")
            {
                pembelianToolStripMenuItem.Visible = true;
                laporanPembelianToolStripMenuItem.Visible = true;

                masterToolStripMenuItem.Visible = false;
                laporanMasterToolStripMenuItem.Visible = false;
                penjualanToolStripMenuItem.Visible = false;
                laporanPenjualanToolStripMenuItem.Visible = false;
            }
            // (Kasir)
            else if (j.IdJabatan == "J2")
            {
                penjualanToolStripMenuItem.Visible = true;
                laporanPenjualanToolStripMenuItem.Visible = true;

                masterToolStripMenuItem.Visible = false;
                laporanMasterToolStripMenuItem.Visible = false;
                pembelianToolStripMenuItem.Visible = false;
                laporanPembelianToolStripMenuItem.Visible = false;
            } 
            // (Manager)
            else if(j.IdJabatan == "J3")
            {
                penjualanToolStripMenuItem.Visible = true;
                laporanPenjualanToolStripMenuItem.Visible = true;
                masterToolStripMenuItem.Visible = true;
                laporanMasterToolStripMenuItem.Visible = true;
                pembelianToolStripMenuItem.Visible = true;
                laporanPembelianToolStripMenuItem.Visible = true;
            }

        }

        private void labelKodePegawai_Click(object sender, EventArgs e)
        {

        }
    }

}
