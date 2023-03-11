using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.AdminPanel.Assets.Pages
{
    public partial class UyeListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Uyeler.DataSource = dm.UyeListele(1);
            lv_Uyeler.DataBind();
        }

        protected void lv_Uyeler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "BanAt")
            {
                dm.UyeBanla(id);

            }
           
            lv_Uyeler.DataSource = dm.UyeListele(1);
            lv_Uyeler.DataBind();

        }



    }
}