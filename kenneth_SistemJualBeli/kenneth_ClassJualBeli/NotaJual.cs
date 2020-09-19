using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kenneth_ClassJualBeli
{
    public class NotaJual
    {
        private string noNota;
        private DateTime tanggal;

        public Pelanggan Pelanggan
        {
            get => default;
            set
            {
            }
        }

        public NotaJualDetil NotaJualDetil
        {
            get => default;
            set
            {
            }
        }

        public string NoNota { get => noNota; set => noNota = value; }
        public DateTime Tanggal { get => tanggal; set => tanggal = value; }
    }
}