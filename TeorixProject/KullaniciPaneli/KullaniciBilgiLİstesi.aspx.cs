using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.KullaniciPaneli
{
    public partial class KullaniciBilgiLİstesi : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Uyeler"] != null)
            {
                Uyeler u = (Uyeler)Session["Uyeler"];
                ltrl_eposta.Text = u.Eposta;
                ltrl_KayıtOlmaTrihi.Text = u.tarihstr;
                ltrl_kullaniciadi.Text = u.KullaniciAdi;
                ltrl_Soyİsim.Text = u.soyisim;
                ltrl_toplamteori.Text = u.ToplamTeoriSayısı.ToString();
                ltrl_İsim.Text = u.isim;
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
            
        }
    }
}