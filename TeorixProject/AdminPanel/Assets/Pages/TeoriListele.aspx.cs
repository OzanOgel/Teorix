using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.DynamicData;

namespace TeorixProject.AdminPanel.Assets.Pages
{
    public partial class TeoriListele : System.Web.UI.Page
    {

        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

            lv_Teoriler.DataSource = dm.TeoriListele();
            lv_Teoriler.DataBind();

            

        }

        protected void lv_Teoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.TeoriSil(id);

            }
            lv_Teoriler.DataSource = dm.TeoriListele();
            lv_Teoriler.DataBind();

        }

        protected void lbtn_Diziler_Click(object sender, EventArgs e)
        {
            int id = 1;

            dm.TeoriListele(id);
            lv_Teoriler.DataSource = dm.TeoriListele(id);
            lv_Teoriler.DataBind();
        }

        protected void lbtn_Filmler_Click(object sender, EventArgs e)
        {
            int id = 2;

            dm.TeoriListele(id);
            lv_Teoriler.DataSource = dm.TeoriListele(id);
            lv_Teoriler.DataBind();
        }

        protected void lbtn_Kitaplar_Click(object sender, EventArgs e)
        {
            int id = 3;

            dm.TeoriListele(id);
            lv_Teoriler.DataSource = dm.TeoriListele(id);
            lv_Teoriler.DataBind();
        }

        protected void lbtn_Tumu_Click(object sender, EventArgs e)
        {
            lv_Teoriler.DataSource = dm.TeoriListele();
            lv_Teoriler.DataBind();
        }
    }
}