using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.AdminPanel.Assets.Pages
{

    public partial class YoneticilerAktif : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
           
            
            
                lv_YoneticilerAktif.DataSource = dm.YoneticiListele(1);
                lv_YoneticilerAktif.DataBind();
            
           

        }

        protected void lv_YoneticilerAktif_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "BanAt")
            {
                dm.YoneticiBanla(id);

            }

            lv_YoneticilerAktif.DataSource = dm.YoneticiListele(1);
            lv_YoneticilerAktif.DataBind();
        }
    }
}