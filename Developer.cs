using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiEga
{
    public class Developer
    {
        private string nama_dev;
        private string id_dev;
        private string status_kontrak;
        private int fitur_selesai;
        private int jumlah_bug;

        public string Nama {  get { return nama_dev; } set { nama_dev = value; } }
        public string Id { get { return id_dev; } set { id_dev = value; } }
        public string Status { get { return status_kontrak; } set { status_kontrak = value; } }
        public int Fitur { get { return fitur_selesai; } set { fitur_selesai = value; } }
        public int Jumlah { get {  return jumlah_bug; } set { jumlah_bug = value; } }
    }
}
