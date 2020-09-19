using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kenneth_ClassJualBeli
{
    public class NotaBeli
    {
        private string noNota;
        private DateTime tanggal;

        public Pegawai Pegawai
        {
            get => default;
            set
            {
            }
        }

        public Supplier Supplier
        {
            get => default;
            set
            {
            }
        }

        public NotaBeliDetil NotaBeliDetil
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