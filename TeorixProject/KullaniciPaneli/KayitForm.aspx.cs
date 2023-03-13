using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace TeorixProject.KullaniciPaneli
{
    public partial class KayitForm : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_uyeol_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text) && !string.IsNullOrEmpty(tb_sifretekrar.Text) && !string.IsNullOrEmpty(tb_isim.Text) && !string.IsNullOrEmpty(Tb_soyisim.Text) && !string.IsNullOrEmpty(tb_kullaniciadi.Text))
            {
                if (tb_sifre.Text == tb_sifretekrar.Text)
                {
                    if(dm.Kullaniciadikontrol(tb_kullaniciadi.Text) > 0)
                    {
                        pnl_yonlendirme.Visible = false;
                        pnl_hata.Visible = true;
                        lbl_hata.Text = "*Bu Kullanıcı Adı Başkası Tarafından Kullanılıyor";
                    }
                    else
                    {
                        Uyeler u = new Uyeler();
                        u.KullaniciAdi = tb_kullaniciadi.Text;
                        u.isim = tb_isim.Text;
                        u.soyisim = Tb_soyisim.Text;
                        u.Eposta = tb_mail.Text;
                        u.şifre = tb_sifre.Text;
                        u.KayitOlmaTarihi = DateTime.Now;
                        u.tarihstr = DateTime.Now.Date.ToString().TrimEnd('0', ':');
                      

                        if (dm.uyeekle(u))
                        {
                            pnl_hata.Visible = false;
                            pnl_yonlendirme.Visible=true;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Kayıl Olma Başarılı Giriş Sayfasına Yönlendiriliyorsunuz');", true);

                            lbl_yonlendir.Text = "*Başarıyla Kayıt Olundu Giriş Sayfasına Yönlendiriliyorsunuz ";
                            Thread.Sleep(2000);
                            Response.Redirect("KullaniciGiris.aspx");
                           

                        }
                        else
                        {
                            pnl_yonlendirme.Visible = false;
                            pnl_hata.Visible = true;
                            lbl_hata.Text = "*Bir Hata Meydana Geldi";
                        }
                       




                    }

                }
                else
                {
                    pnl_yonlendirme.Visible = false;
                    pnl_hata.Visible = true;
                    lbl_hata.Text = "*Şifreler aynı değil";
                }
            }
            else
            {
                pnl_yonlendirme.Visible = false;
                pnl_hata.Visible = true;
                lbl_hata.Text = "*Lütfen boş bırakmayınız";
            }
        
            

        }
    }
}