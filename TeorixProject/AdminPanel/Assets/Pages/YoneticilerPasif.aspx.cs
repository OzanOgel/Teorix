using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.AdminPanel.Assets.Pages
{
    public partial class YoneticilerPasif : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {


            lv_YoneticilerPasif.DataSource = dm.YoneticiListele(0);
            lv_YoneticilerPasif.DataBind();

        }

        protected void lv_YoneticilerPasif_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "BanKaldir")
            {
                dm.YoneticiBanKaldir(id);

            }
            lv_YoneticilerPasif.DataSource = dm.YoneticiListele(0);
            lv_YoneticilerPasif.DataBind();
        }
    }
}