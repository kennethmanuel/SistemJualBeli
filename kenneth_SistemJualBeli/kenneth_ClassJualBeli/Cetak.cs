using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//File stream object
using System.IO;

// Font
using System.Drawing;

//PrintPageEventArgs
using System.Drawing.Printing;


namespace kenneth_ClassJualBeli
{
    public class Cetak
    {
        // Nama dan ukuran font untuk dicetak
        private Font jenisFont;

        // File stream berisi tulisan yang akan dibaca dan dicetak ke printer
        private StreamReader fileCetak;

        // Margin kertas
        private float marginKiri, marginKanan, marginBawah, marginAtas;

        #region Constructors
        public Cetak(string namaFile, Font jenisFont, float marginKiri, float marginKanan, float marginBawah, float marginAtas)
        {
            this.FileCetak = new StreamReader(namaFile);
            this.JenisFont = JenisFont;
            this.marginAtas = marginAtas;
            this.marginKanan = marginKanan;
            this.marginBawah = marginBawah;
            this.MarginKiri = marginBawah;
        }
        #endregion

        #region Properties
        public Font JenisFont { get => jenisFont; set => jenisFont = value; }
        public StreamReader FileCetak { get => fileCetak; set => fileCetak = value; }
        public float MarginKiri { get => marginKiri; set => marginKiri = value; }
        public float MarginKanan { get => marginKanan; set => marginKanan = value; }
        public float MarginBawah { get => marginBawah; set => marginBawah = value; }
        public float MarginAtas { get => marginAtas; set => marginAtas = value; }
        #endregion

        private void CetakTulisan(object sender, PrintPageEventArgs e)
        {
            // Hitung jumlah baris maksimal yang dapat ditampilkan pada 1 halaman kertas
            int jumBarisPerHalaman = (int)((e.MarginBounds.Height - MarginBawah - MarginAtas) / jenisFont.GetHeight(e.Graphics));

            // Simpan posisi y terakhir tulisan telah tercetak
            float y = MarginAtas;

            // Simpan jumlah baris tulisan telah tercetak;
            int jumBaris = 0;

            // Simpan tulisan yang akan dicetak
            string tulisanCetak = FileCetak.ReadLine();

            // Filestream untuk mencetak tiap baris tulisan
            while (jumBaris < jumBarisPerHalaman && tulisanCetak != null)
            {
                y = MarginAtas + (jumBaris * jenisFont.GetHeight(e.Graphics));

                // Cetak tulisan sesuai jenis font dan margin (warna text hitam)
                e.Graphics.DrawString(tulisanCetak, JenisFont, Brushes.Black , MarginKiri, y);

                // Keep tracck jumlah baris tercetak
                jumBaris++;

                // Baca baris file berikutnya
                tulisanCetak = FileCetak.ReadLine(); 
            }
            // Cetak halaman berikutnya apabila tidak selesai
            if(tulisanCetak != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            } 
        } 

        public void CetakKePrinter(string pTipe)
        {
            // Object untuk cetak
            PrintDocument p = new PrintDocument();

            if(pTipe == "text ")
            {
                //Event hander untuk cetak tulisan
                p.PrintPage += new PrintPageEventHandler(CetakTulisan);
            }

            //Cetak tulisan
            p.Print();

            FileCetak.Close();
        }

    }
}
