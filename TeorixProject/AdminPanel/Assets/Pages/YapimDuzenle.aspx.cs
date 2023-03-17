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
            Yapımlar y = dm.YapimGetir(id);
            y.Tur_ID = Convert.ToInt32(ddl_Turler.SelectedItem.Value);
            y.Isim = tb_YapımIsim.Text;
            y.aktiflik = cb_Aktiflik.Checked;
            Yoneticiler y2 = (Yoneticiler)Session["yonetici"];
            y.Yonetici_ID = y2.ID;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                if (fi.Extension == ".jpeg" || fi.Extension == ".png" || fi.Extension == ".jpg")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    y.Resim = isim + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/YapimResimleri/" + isim + uzanti));

                }
                else
                {
                    pnl_Basarisiz.Visible = true;
                    pnl_Basarili.Visible = false;
                    lbl_basarisiz.Text = "Resim uzantısı sadece .jpg ,.jpeg veya .png olmalıdır";
                }
            }
            if (dm.YapimDuzenle(y))
            {
                cb_Aktiflik.Checked = false;
                tb_YapımIsim.Text = " ";
                ddl_Turler.SelectedValue = "0";
                pnl_Basarili.Visible = true;
                pnl_Basarisiz.Visible = false;
                lbl_basarili.Text = "Yapım Düzenleme Başarılı";
            }
            else
            {
                pnl_Basarisiz.Visible = true;
                pnl_Basarili.Visible = false;
                lbl_basarisiz.Text = "Yapım Düzenleme Başarısız";
            }




        }
    }
}