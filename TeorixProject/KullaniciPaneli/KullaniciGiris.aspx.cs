using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.KullaniciPaneli
{
    public partial class KullaniciGiriş : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lb_GirisYap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_eposta.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                Uyeler u = dm.uyegiriş(tb_eposta.Text, tb_sifre.Text);
                if (u != null)
                {

                    
                    
                        Session["Uyeler"] = u;
                        Response.Redirect("Index.aspx");
                    
                    
                    
                      
                    
                }
                else
                {
                    pnl_hata.Visible = true;
                    lbl_hata.Text = "Kullanıcı Bulunamadı";
                }





            }
            else
            {
                pnl_hata.Visible = true;
                lbl_hata.Text = "Kullanıcı Adı ve Şifre Boş olamaz";
            }
        }
    }
}