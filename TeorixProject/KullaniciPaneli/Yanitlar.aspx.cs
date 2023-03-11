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
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["yid"]);
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
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Kalp butonunun ID'sini düzenleme
                var heart = e.Item.FindControl("heart") as HtmlGenericControl;
                var heartId = "heart" + e.Item.ItemIndex;
                heart.Attributes["id"] = heartId;
            }
            int id = Convert.ToInt32(Request.QueryString["yid"]);

            rp_Yanitlarkullanici.DataSource = dm.AktifYanitListele(id);
            rp_Yanitlarkullanici.DataBind();
        }
    }
}