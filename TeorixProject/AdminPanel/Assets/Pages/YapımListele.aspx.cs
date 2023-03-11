using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.AdminPanel.Assets.Pages
{
    public partial class YapımListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Yapımlar.DataSource = dm.YapımLislete();
            lv_Yapımlar.DataBind();
        }

        protected void lv_Yapımlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.YapimSil(id);

            }
            lv_Yapımlar.DataSource = dm.YapımLislete();
            lv_Yapımlar.DataBind();
        }
    }
}