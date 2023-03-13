using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Uyeler
    {
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Eposta { get; set; }
        public string şifre { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        
        public DateTime KayitOlmaTarihi { get; set; }
        public int ToplamTeoriSayısı { get; set; }
        public bool aktiflik { get; set; }
        public string AktiflikStr { get; set; }
        public string tarihstr { get; set; }



    }
}
