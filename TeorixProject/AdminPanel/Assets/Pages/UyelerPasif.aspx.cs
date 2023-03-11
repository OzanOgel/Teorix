using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.AdminPanel.Assets.Pages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Uyeler_Pasif.DataSource = dm.UyeListele(0);
            lv_Uyeler_Pasif.DataBind();
        }

        protected void lv_Uyeler_Pasif_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "BanKaldir")
                {
                    dm.UyeBanKaldır(id);

                }
                lv_Uyeler_Pasif.DataSource = dm.UyeListele(0);
                lv_Uyeler_Pasif.DataBind();
            
   
           
        }
    }
}