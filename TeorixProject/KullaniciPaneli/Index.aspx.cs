using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeorixProject.KullaniciPaneli
{
    public partial class Index : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rpt_yapimlar.DataSource = dm.AktifYapımLislete();
            rpt_yapimlar.DataBind();
        }
    }
}