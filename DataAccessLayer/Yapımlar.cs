using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yapımlar
    {
        public int ID { get; set; }
        public int Tur_ID { get; set; }
        public string Tur { get; set; }
        public int Yonetici_ID { get; set; }
        public string Yonetici { get; set; }
        public string Isim { get; set; }
        public string Resim { get; set; }
        public bool aktiflik { get; set; }
        public string AktiflikStr { get; set; }







    }
}
