using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.AdminPanel.Assets.Pages
{
    public partial class YorumOnayBekleyenler : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Yanitlar.DataSource = dm.BekleyenYanitListele();
            lv_Yanitlar.DataBind();
        }

        

        protected void lv_Yanitlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Onayla")
            {
                dm.yanitonayla(id);
            }
            if (e.CommandName == "Reddet")
            {
                dm.yanitReddet(id);
            }
            lv_Yanitlar.DataSource = dm.BekleyenYanitListele();
            lv_Yanitlar.DataBind();
        }
    }
}