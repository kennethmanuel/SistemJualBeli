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
        private Barang barang; 

        #region Constructor
        public NotaJualDetil(int harga, int jumlah, Barang barang)
        {
            this.Harga = harga;
            this.Jumlah = jumlah;
            this.Barang = barang;
        }
        #endregion

        #region Propertires 
        public int Harga { get => harga; set => harga = value; }
        public int Jumlah { get => jumlah; set => jumlah = value; }
        public Barang Barang { get => barang; set => barang = value; }
        #endregion

        #region Methods



        #endregion


    }
}