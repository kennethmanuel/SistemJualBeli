using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kenneth_ClassJualBeli
{
    public class Barang
    {
        private string kodeBarang;
        private string nama;
        private int hargaJual;
        private string barcode;
        private int stok;

        #region properties
        public string KodeBarang { get => kodeBarang; set => kodeBarang = value; }
        public string Nama { get => nama; set => nama = value; }
        public int HargaJual { get => hargaJual; set => hargaJual = value; }
        public string Barcode { get => barcode; set => barcode = value; }
        public int Stok { get => stok; set => stok = value; }
        #endregion

        public Kategori Kategori
        {
            get => default;
            set
            {
            }
        }
    }
}