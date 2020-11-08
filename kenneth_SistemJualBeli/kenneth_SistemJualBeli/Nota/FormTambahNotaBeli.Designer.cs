namespace kenneth_SistemJualBeli.Nota
{
    partial class FormTambahNotaBeli
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.labelHargaBarang = new System.Windows.Forms.Label();
            this.labelNamaBarang = new System.Windows.Forms.Label();
            this.labelKodeBarang = new System.Windows.Forms.Label();
            this.textBoxJumlah = new System.Windows.Forms.TextBox();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.labelNamaPegawai = new System.Windows.Forms.Label();
            this.labelAlamat = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewBarang = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.labelKodePegawai = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerTanggal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNoNota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelGrandTotal = new System.Windows.Forms.Label();
            this.buttonCetak = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarang)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Navy;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(705, 588);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(133, 55);
            this.buttonKeluar.TabIndex = 45;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.Navy;
            this.buttonSimpan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.ForeColor = System.Drawing.Color.White;
            this.buttonSimpan.Location = new System.Drawing.Point(278, 588);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(133, 55);
            this.buttonSimpan.TabIndex = 43;
            this.buttonSimpan.Text = "SIMPAN ";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // labelHargaBarang
            // 
            this.labelHargaBarang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHargaBarang.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelHargaBarang.Location = new System.Drawing.Point(561, 236);
            this.labelHargaBarang.Name = "labelHargaBarang";
            this.labelHargaBarang.Size = new System.Drawing.Size(134, 28);
            this.labelHargaBarang.TabIndex = 24;
            // 
            // labelNamaBarang
            // 
            this.labelNamaBarang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelNamaBarang.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelNamaBarang.Location = new System.Drawing.Point(319, 236);
            this.labelNamaBarang.Name = "labelNamaBarang";
            this.labelNamaBarang.Size = new System.Drawing.Size(236, 28);
            this.labelNamaBarang.TabIndex = 23;
            // 
            // labelKodeBarang
            // 
            this.labelKodeBarang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelKodeBarang.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelKodeBarang.Location = new System.Drawing.Point(151, 236);
            this.labelKodeBarang.Name = "labelKodeBarang";
            this.labelKodeBarang.Size = new System.Drawing.Size(162, 28);
            this.labelKodeBarang.TabIndex = 22;
            // 
            // textBoxJumlah
            // 
            this.textBoxJumlah.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textBoxJumlah.Location = new System.Drawing.Point(701, 236);
            this.textBoxJumlah.Name = "textBoxJumlah";
            this.textBoxJumlah.Size = new System.Drawing.Size(111, 28);
            this.textBoxJumlah.TabIndex = 21;
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textBoxBarcode.Location = new System.Drawing.Point(12, 236);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(133, 28);
            this.textBoxBarcode.TabIndex = 17;
            this.textBoxBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxBarcode_KeyDown);
            // 
            // labelNamaPegawai
            // 
            this.labelNamaPegawai.AutoSize = true;
            this.labelNamaPegawai.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelNamaPegawai.Location = new System.Drawing.Point(177, 124);
            this.labelNamaPegawai.Name = "labelNamaPegawai";
            this.labelNamaPegawai.Size = new System.Drawing.Size(136, 21);
            this.labelNamaPegawai.TabIndex = 16;
            this.labelNamaPegawai.Text = "Nama Pegawai";
            // 
            // labelAlamat
            // 
            this.labelAlamat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAlamat.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelAlamat.Location = new System.Drawing.Point(591, 61);
            this.labelAlamat.Name = "labelAlamat";
            this.labelAlamat.Size = new System.Drawing.Size(221, 55);
            this.labelAlamat.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(712, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 21);
            this.label12.TabIndex = 14;
            this.label12.Text = "Jumlah";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(596, 212);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 21);
            this.label11.TabIndex = 13;
            this.label11.Text = "Harga";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(366, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 21);
            this.label10.TabIndex = 12;
            this.label10.Text = "Nama Barang";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(177, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 21);
            this.label9.TabIndex = 11;
            this.label9.Text = "Kode";
            // 
            // dataGridViewBarang
            // 
            this.dataGridViewBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBarang.Location = new System.Drawing.Point(13, 351);
            this.dataGridViewBarang.Name = "dataGridViewBarang";
            this.dataGridViewBarang.RowHeadersWidth = 51;
            this.dataGridViewBarang.RowTemplate.Height = 24;
            this.dataGridViewBarang.Size = new System.Drawing.Size(825, 231);
            this.dataGridViewBarang.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(29, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 21);
            this.label8.TabIndex = 10;
            this.label8.Text = "Barcode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(479, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 21);
            this.label7.TabIndex = 8;
            this.label7.Text = "Alamat: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(479, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "Supplier: ";
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSupplier.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Items.AddRange(new object[] {
            "Alamat",
            "Kode Supplier",
            "Nama"});
            this.comboBoxSupplier.Location = new System.Drawing.Point(591, 22);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(221, 29);
            this.comboBoxSupplier.TabIndex = 1;
            this.comboBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupplier_SelectedIndexChanged);
            // 
            // labelKodePegawai
            // 
            this.labelKodePegawai.AutoSize = true;
            this.labelKodePegawai.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelKodePegawai.Location = new System.Drawing.Point(117, 124);
            this.labelKodePegawai.Name = "labelKodePegawai";
            this.labelKodePegawai.Size = new System.Drawing.Size(54, 21);
            this.labelKodePegawai.TabIndex = 6;
            this.labelKodePegawai.Text = "Kode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(23, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pegawai:";
            // 
            // dateTimePickerTanggal
            // 
            this.dateTimePickerTanggal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateTimePickerTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTanggal.Location = new System.Drawing.Point(133, 61);
            this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            this.dateTimePickerTanggal.Size = new System.Drawing.Size(185, 28);
            this.dateTimePickerTanggal.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(23, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tanggal: ";
            // 
            // textBoxNoNota
            // 
            this.textBoxNoNota.Enabled = false;
            this.textBoxNoNota.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textBoxNoNota.Location = new System.Drawing.Point(133, 19);
            this.textBoxNoNota.Name = "textBoxNoNota";
            this.textBoxNoNota.Size = new System.Drawing.Size(185, 28);
            this.textBoxNoNota.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(23, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "No Nota:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.labelHargaBarang);
            this.panel1.Controls.Add(this.labelNamaBarang);
            this.panel1.Controls.Add(this.labelKodeBarang);
            this.panel1.Controls.Add(this.textBoxJumlah);
            this.panel1.Controls.Add(this.textBoxBarcode);
            this.panel1.Controls.Add(this.labelNamaPegawai);
            this.panel1.Controls.Add(this.labelAlamat);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.labelGrandTotal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxSupplier);
            this.panel1.Controls.Add(this.labelKodePegawai);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateTimePickerTanggal);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxNoNota);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(13, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 270);
            this.panel1.TabIndex = 47;
            // 
            // labelGrandTotal
            // 
            this.labelGrandTotal.Font = new System.Drawing.Font("Tahoma", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrandTotal.Location = new System.Drawing.Point(477, 120);
            this.labelGrandTotal.Name = "labelGrandTotal";
            this.labelGrandTotal.Size = new System.Drawing.Size(335, 77);
            this.labelGrandTotal.TabIndex = 9;
            this.labelGrandTotal.Text = "0";
            this.labelGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonCetak
            // 
            this.buttonCetak.BackColor = System.Drawing.Color.Navy;
            this.buttonCetak.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCetak.ForeColor = System.Drawing.Color.White;
            this.buttonCetak.Location = new System.Drawing.Point(417, 588);
            this.buttonCetak.Name = "buttonCetak";
            this.buttonCetak.Size = new System.Drawing.Size(133, 55);
            this.buttonCetak.TabIndex = 44;
            this.buttonCetak.Text = "CETAK";
            this.buttonCetak.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(830, 60);
            this.label1.TabIndex = 46;
            this.label1.Text = "TAMBAH NOTA BELI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTambahNotaBeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(846, 645);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.dataGridViewBarang);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCetak);
            this.Controls.Add(this.label1);
            this.Name = "FormTambahNotaBeli";
            this.Text = "FormTambahNotaBeli";
            this.Load += new System.EventHandler(this.FormTambahNotaBeli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Label labelHargaBarang;
        private System.Windows.Forms.Label labelNamaBarang;
        private System.Windows.Forms.Label labelKodeBarang;
        private System.Windows.Forms.TextBox textBoxJumlah;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.Label labelNamaPegawai;
        private System.Windows.Forms.Label labelAlamat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridViewBarang;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.Label labelKodePegawai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerTanggal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNoNota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelGrandTotal;
        private System.Windows.Forms.Button buttonCetak;
        private System.Windows.Forms.Label label1;
    }
}