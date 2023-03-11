using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.AdminPanel.Assets.Pages
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                Yoneticiler y = (Yoneticiler)Session["yonetici"];
                lbl_Yetkili.Text = "<i class='fa-solid fa-user'></i>" + y.Kullanici_Adi + " (" + y.YoneticiTur + ")";
                if (y.YoneticiTur == "Admin")
                {
                    pnl_Yonetici.Visible = true;
                    
                }
                else
                {
                    pnl_Yonetici.Visible = false;
                }
            }
            else
            {
                Response.Redirect("GirişYap.aspx");
            }
        }

        protected void lbtn_çikis_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            

        }
    }
}