using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yoneticiler
    {
        public int ID { get; set; }
        public int YoneticiTur_ID { get; set; }
        public string YoneticiTur { get; set; }
        public string Kullanici_Adi { get; set; }
        public string Eposta { get; set; }
        public string şifre { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime KayitOlmaTarihi { get; set; }
        public bool aktiflik { get; set; }
        public string AktiflikStr { get; set; }
    }
}
