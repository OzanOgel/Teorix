using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TeorixProject.KullaniciPaneli
{
    public partial class TeorileriGoruntule : System.Web.UI.Page
    {
        

        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            



            if (Session["Uyeler"] != null)
            {
                pnl_girisvar.Visible = true;
                pnl_UyeOl.Visible = false;
            }
            else
            {
                pnl_girisvar.Visible = false;
                pnl_UyeOl.Visible = true;
            }


                if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["yid"]);
                
           

                if (dm.teoriSayisi(id) > 0)
                {
                    rp_teorilerkullanici.DataSource = dm.TeoriListeleYapim(id);
                    rp_teorilerkullanici.DataBind();
                    pnl_Teoriyok.Visible=false;
                    pnl_Teoriler.Visible=true;
                }
                else {
                    pnl_Teoriyok.Visible = true;
                    pnl_Teoriler.Visible = false;
                }
                
               
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
            
        }

        protected void rp_teorilerkullanici_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Kalp butonunun ID'sini düzenleme
                var heart = e.Item.FindControl("heart") as HtmlGenericControl;
                var heartId = "heart" + e.Item.ItemIndex;
                heart.Attributes["id"] = heartId;
            }
            int id = Convert.ToInt32(Request.QueryString["yid"]);
            
            rp_teorilerkullanici.DataSource = dm.TeoriListeleYapim(id);
            rp_teorilerkullanici.DataBind();
        }

        protected void lbtn_yorumYap_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["yid"]);
            Uyeler u2 = (Uyeler)Session["Uyeler"];
            
            Teoriler t = new Teoriler();
            
            t.Uye_ID= u2.ID;
            t.Paylasilma_Tarihi = DateTime.Today;
            t.aktiflik = true;
            t.içerik = tb_yorum.Text;
            t.Yonetici = "Ozi";
            t.Yonetici_ID = 1;
            t.Tur_ID = dm.yapimIDyegoreturgetir(id);
            t.Begeni_Sayisi = 0;
            t.Yanit_Sayisi = 0;
            t.Yapım_ID = id;
            t.tarihstr = DateTime.Now.Date.ToString().TrimEnd('0', ':');
            dm.teoriekle(t);

        }
    }
}