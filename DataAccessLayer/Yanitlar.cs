using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yanitlar
    {
        public int ID { get; set; }
        public int Teori_ID { get; set; }
        public int Uye_ID { get; set; }

        public string Uye { get; set; }
        
        public DateTime PaylasilmaTarihi { get; set; }
        public string icerik { get; set; }
        public int BegeniSayisi { get; set; }
        public bool aktiflik { get; set; }
        public string aktiflikStr { get; set; }

        public string durum { get; set; }


    }
}
