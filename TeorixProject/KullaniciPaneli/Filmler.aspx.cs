using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.KullaniciPaneli
{
    public partial class Filmler : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rpt_yapimlar.DataSource = dm.YapımLislete(2);
            rpt_yapimlar.DataBind();
        }
    }
}