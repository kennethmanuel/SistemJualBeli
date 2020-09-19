using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kenneth_ClassJualBeli
{
    public class NotaJualDetil
    {
        private int harga;
        private int jumlah;

        public Barang Barang
        {
            get => default;
            set
            {
            }
        }

        public int Harga { get => harga; set => harga = value; }
        public int Jumlah { get => jumlah; set => jumlah = value; }
    }
}