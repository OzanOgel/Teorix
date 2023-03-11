using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.AdminPanel.Assets.Pages
{
    public partial class YanitOnaylananlar : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_OnaylananYanitlar.DataSource = dm.OnaylananYanitListele();
            lv_OnaylananYanitlar.DataBind();
        }

        protected void lv_OnaylananYanitlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Reddet")
            {
                dm.yanitReddet(id);
            }
            lv_OnaylananYanitlar.DataSource = dm.OnaylananYanitListele();
            lv_OnaylananYanitlar.DataBind();
        }
    }
}