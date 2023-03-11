using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.AdminPanel.Assets.Pages
{
    public partial class YanitReddedilenler : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_ReddedilenYanitlar.DataSource = dm.ReddedilenYanitListele();
            lv_ReddedilenYanitlar.DataBind();
        }

        protected void lv_ReddedilenYanitlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Onayla")
            {
                dm.yanitonayla(id);
            }
            lv_ReddedilenYanitlar.DataSource = dm.ReddedilenYanitListele();
            lv_ReddedilenYanitlar.DataBind();
        }
    }
}