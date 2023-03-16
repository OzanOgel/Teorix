using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.AdminPanel.Assets.Pages
{
    public partial class YapimDuzenle : System.Web.UI.Page
    {
       DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["yid"]);
                    ddl_Turler.DataTextField = "isim";
                    ddl_Turler.DataValueField = "ID";
                    ddl_Turler.DataSource = dm.TurListele();
                    ddl_Turler.DataBind();

                    Yapımlar y = dm.YapimGetir(id);
                    ddl_Turler.SelectedValue = y.Tur_ID.ToString();
                    tb_YapımIsim.Text = y.Isim;
                    img_resim.ImageUrl = "~/YapimResimleri/" + y.Resim;
                    cb_Aktiflik.Checked = y.aktiflik;
                }  
            }
            else
            {
                Response.Redirect("YapımListele.aspx");
            }
        }

        protected void lbtn_YapımDuzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["yid"]);

        }
    }
}