using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Teoriler
    {

        public int ID { get; set; }
        public int Yapım_ID { get; set; }
        public string Yapım { get; set; }
        public int Uye_ID { get; set; }
        public string uyeIsim { get; set; }
        public int Tur_ID { get; set; }
        public string Tur { get; set; }
        public int Yonetici_ID { get; set; }
        public string Yonetici { get; set; }
        public DateTime Paylasilma_Tarihi { get; set; }
        public string içerik { get; set; }
        public int Begeni_Sayisi { get; set; }
        public int Yanit_Sayisi { get; set; }
        public bool aktiflik { get; set; }
        public string aktiflikStr { get; set; }
        public string KullaniciAdi { get; set; }

        public string tarihstr { get; set; }




    }
}
