using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kenneth_ClassJualBeli
{
    public class NotaBeliDetil
    {
        private int harga;
        private int jumlah;
        private Barang barang;

        #region Constructors
        public NotaBeliDetil(int harga, int jumlah, Barang barang)
        {
            this.Harga = harga;
            this.Jumlah = jumlah;
            this.Barang = barang;
        }
        #endregion

        #region Properties
        public int Harga { get => harga; set => harga = value; }
        public int Jumlah { get => jumlah; set => jumlah = value; }
        public Barang Barang { get => barang; set => barang = value; }
        #endregion

        #region Methods

        #endregion
    }
}