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
            
           
         
                pnl_yorumpaylasildi.Visible = false;
                pnl_yorumpaylasilmadi.Visible = false;

            



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
           
            int id = Convert.ToInt32(Request.QueryString["yid"]);
            if (e.CommandName == "Select")
            {
                Uyeler u2 = (Uyeler)Session["Uyeler"];
                int teoriID = Convert.ToInt32(e.CommandArgument);
                if(dm.BegeniKontrol(teoriID,u2.ID) == 0)
                {
                    if(Session["Uyeler"] != null)
                    {
                        dm.begeniarttir(teoriID);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Beğenmek İçin Lütfen Üye Girişi Yapın!');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Zaten Bu Teoriyi Beğendiniz!');", true);
                }
               
            }


            rp_teorilerkullanici.DataSource = dm.TeoriListeleYapim(id);
            rp_teorilerkullanici.DataBind();
        }

        protected void lbtn_yorumYap_Click(object sender, EventArgs e)
        {
            Uyeler u2 = (Uyeler)Session["Uyeler"];

            Teoriler t = new Teoriler();
            t.Uye_ID = u2.ID;
            t.içerik = tb_yorum.Text;

            if (dm.teorikontrolsayi(t.içerik, t.Uye_ID) == false)
            {
              

                if (!string.IsNullOrEmpty(tb_yorum.Text))
                {
                    try
                    {

                        int id = Convert.ToInt32(Request.QueryString["yid"]);
                        t.Uye_ID = u2.ID;
                        t.Paylasilma_Tarihi = DateTime.Today;
                        t.aktiflik = true;
                        

                        t.Yonetici_ID = 1;
                        t.Tur_ID = dm.yapimIDyegoreturgetir(id);
                        t.Begeni_Sayisi = 0;
                        t.Yanit_Sayisi = 0;
                        t.Yapım_ID = id;
                        t.tarihstr = DateTime.Now.Date.ToString().TrimEnd('0', ':');

                        dm.teoriekle(t);
                        pnl_yorumpaylasildi.Visible = true;
                        pnl_yorumpaylasilmadi.Visible = false;
                        dm.TeoriSayisiArttir(u2.ID);


                    }
                    catch
                    {
                        pnl_yorumpaylasilmadi.Visible = true;
                        lbl_hata.Text = "Teori Paylaşırken Bir Hata Meydana Geldi";
                        pnl_yorumpaylasildi.Visible = false;


                    }


                }
                else
                {
                    pnl_yorumpaylasilmadi.Visible = true;
                    lbl_hata.Text = "Boş Teori Paylaşılamaz";
                    pnl_yorumpaylasildi.Visible = false;

                }
            }
               




           
        }
        
        
       

        
    }
}