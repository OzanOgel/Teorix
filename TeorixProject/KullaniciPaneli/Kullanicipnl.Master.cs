using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.KullaniciPaneli
{
    public partial class Kullanicipnl : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Uyeler"] != null)
            {
                   
                Uyeler u = (Uyeler)Session["Uyeler"];
                lbl_username0.Text = "<i class='fa-solid fa-user'></i> " + u.KullaniciAdi;
                pnl_girisvar.Visible = true;
                pnl_girisyok.Visible = false;
            }
            else
            {
                pnl_girisvar.Visible = false;
                pnl_girisyok.Visible = true;
            }
           
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            
                Session["Uyeler"] = null;
                Response.Redirect("Index.aspx");

            
        }
    }
}