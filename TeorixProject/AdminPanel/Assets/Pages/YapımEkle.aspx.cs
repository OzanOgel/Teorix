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
    public partial class YapımEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_Turler.DataTextField = "isim";
                ddl_Turler.DataValueField = "ID";
                ddl_Turler.DataSource = dm.TurListele();
                ddl_Turler.DataBind();
            }

        }

        protected void lbtn_YapımEkle_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddl_Turler.SelectedItem.Value) != 0)
            {
                Yapımlar y = new Yapımlar();
                y.Tur_ID = Convert.ToInt32(ddl_Turler.SelectedItem.Value);
                y.Isim = tb_YapımIsim.Text;
                Yoneticiler y2 = (Yoneticiler)Session["yonetici"];
                y.Yonetici_ID = y2.ID;
                y.aktiflik = cb_Aktiflik.Checked;
               
                if(fu_resim.HasFile)
                {
                    FileInfo fi = new FileInfo(fu_resim.FileName);
                    if (fi.Extension == ".jpeg" || fi.Extension == ".png" || fi.Extension == ".jpg")
                    {
                        string uzanti = fi.Extension;
                        string isim = Guid.NewGuid().ToString();
                        y.Resim = isim + uzanti;
                        fu_resim.SaveAs(Server.MapPath("~/YapimResimleri/" + isim + uzanti));
                        if (dm.YapimEkle(y))
                        {
                            pnl_Basarili.Visible= true;
                            lbl_basarili.Visible = true;
                            lbl_basarili.Text = "Yapim Başarı ile Eklendi";
                        }
                        else
                        {
                            pnl_Basarili.Visible= false;
                            pnl_Basarisiz.Visible= true;
                            lbl_basarisiz.Text = "Yapım Eklenemedi";
                        }

                        

                    }
                    else
                    {
                        pnl_Basarisiz.Visible = true;
                        pnl_Basarili.Visible = false;
                        lbl_basarisiz.Text = "Resim uzantısı sadece .jpg ,.jpeg veya .png olmalıdır";
                    }
                }
                else
                {
                    y.Resim = "none.png";
                    if (dm.YapimEkle(y))
                    {
                        cb_Aktiflik.Checked = false;
                        tb_YapımIsim.Text = " ";
                        ddl_Turler.SelectedValue = "0";
                        pnl_Basarili.Visible = true;
                        pnl_Basarisiz.Visible = false;
                        lbl_basarili.Text = "Yapım Ekleme Başarılı";

                    }
                    else
                    {
                        pnl_Basarisiz.Visible = true;
                        pnl_Basarili.Visible = false;
                        lbl_basarisiz.Text = "Makale Eklenemedi";

                    }
                }
                

            }
            else
            {
                pnl_Basarisiz.Visible = true;
                pnl_Basarili.Visible = false;
                lbl_basarisiz.Text = "tür seçimi yapmalısınız";
            }
        }
    }
}