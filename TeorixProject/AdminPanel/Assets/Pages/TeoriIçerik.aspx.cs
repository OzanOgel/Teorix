using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.AdminPanel.Assets.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["teid"]);
                rp_teoriler.DataSource = dm.TekTeoriListele(id);
                rp_teoriler.DataBind();
            }
            else
            {
                Response.Redirect("TeoriListele.aspx");
            }
            pnl_Uyeban.Visible = false;
            pnl_bankaldır.Visible = false;
            pnl_sil.Visible = false;
        }



        protected void rp_teoriler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.TeoriSil(id);
                Response.Redirect("TeoriListele.aspx");
                pnl_sil.Visible = true;
                pnl_Uyeban.Visible = false;
                pnl_bankaldır.Visible = false;
            }
            int Uye_ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Banla")
            {
                dm.UyeBanla(Uye_ID);
                pnl_Uyeban.Visible = true;
                pnl_bankaldır.Visible = false;
                pnl_sil.Visible = false;

            }
            if (e.CommandName == "BanKaldır")
            {
                dm.UyeBanKaldır(Uye_ID);
                pnl_sil.Visible = false;
                pnl_Uyeban.Visible = false;
                pnl_bankaldır.Visible = true;
            }



        }
    }
}