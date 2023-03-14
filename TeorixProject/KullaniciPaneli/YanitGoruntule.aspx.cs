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
    public partial class Yanitlar : System.Web.UI.Page
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
                int id = Convert.ToInt32(Request.QueryString["tid"]);
                if (dm.YanitSayisi(id) > 0)
                {
                   
                    rp_Yanitlarkullanici.DataSource = dm.AktifYanitListele(id);
                    rp_Yanitlarkullanici.DataBind();
                    pnl_Teoriyok.Visible = false;
                    pnl_Teoriler.Visible = true;
                }
                else
                {
                    pnl_Teoriyok.Visible = true;
                    pnl_Teoriler.Visible = false;
                }



            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void rp_Yanitlarkullanici_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
            int id = Convert.ToInt32(Request.QueryString["tid"]);

            rp_Yanitlarkullanici.DataSource = dm.AktifYanitListele(id);
            rp_Yanitlarkullanici.DataBind();
        }

        Yanit ya = new Yanit();
        protected void lbtn_yorumYap_Click(object sender, EventArgs e)
        {
            Yanit ya = new Yanit();
            Uyeler u2 = (Uyeler)Session["Uyeler"];
            ya.Uye_ID = u2.ID;
            ya.icerik = tb_yorum.Text;
            if(dm.Yanitkontrolsayi(ya.icerik,ya.Uye_ID) == false)
            {
                if (!string.IsNullOrEmpty(tb_yorum.Text))
                {
                    try
                    {


                        int id = Convert.ToInt32(Request.QueryString["tid"]);

                        ya.Teori_ID = id;

                        ya.PaylasilmaTarihi = DateTime.Today;
                        ya.icerik = tb_yorum.Text;
                        pnl_yorumpaylasildi.Visible = true;
                        pnl_yorumpaylasilmadi.Visible = false;
                        dm.yanitekle(ya);
                        dm.yanitsayisiarttir(id);
                        tb_yorum.Text = " ";




                    }
                    catch
                    {
                        pnl_yorumpaylasilmadi.Visible = true;
                        lbl_hata.Text = "Yanıt Paylaşırken Bir Hata Meydana Geldi";
                        pnl_yorumpaylasildi.Visible = false;


                    }


                }
                else
                {
                    pnl_yorumpaylasilmadi.Visible = true;
                    lbl_hata.Text = "Boş Yanıt Paylaşılamaz";
                    pnl_yorumpaylasildi.Visible = false;

                }
            }
           

            




           
        }

    }
            
            
            
        }
    
