<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KayitForm.aspx.cs" Inherits="TeorixProject.KullaniciPaneli.KayitForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-image: url("Assets/img/imgbacround.png");
        }

        .contanier {
            margin-top: 100px;
            margin-left: auto;
            margin-right: auto;
            width: 450px;
            height: 590px;
            border: 1px solid black;
            border-top-left-radius: 8px;
            border-top-right-radius: 8px;
            background-color: #ededed;
        }

            .contanier .header {
                width: 100%;
                background-color: forestgreen;
                height: 120px;
                border-top-left-radius: 8px;
                border-top-right-radius: 8px;
            }

        .textboxlar {
            margin-top: 30px;
            margin-left: 23px;
        }

        .minbox {
            border-radius: 6px;
            background-color: rgb(180, 180, 180, 0,67);
        }

        .maxbox {
            border-radius: 6px;
            background-color: rgb(180, 180, 180, 0,78);
            margin-left: 17px;
        }

        label {
            color: rgb(82, 82, 82, 0,62);
            margin-left: 10px;
        }

        .girisyap {
            
            padding: 10px 18px;
            background-color: forestgreen;
            border-radius: 5px;
            text-decoration: none;
            border: 1px solid black;
            margin-left: 150px;
            color: black;
        }

            .girisyap:hover {
                background-color: #228b22e1;
                text-decoration: underline;
            }
            .hatametin{
            word-break:break-word;
            color:red;
            margin-left:8px;
        }
            .girisyapildi{
                  word-break:break-word;
            color:green;
            margin-left:8px;
            font-size:15px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contanier">
            <div class="header"></div>
            <div class="textboxlar">
                <label style="margin-left: 70px;">İsim</label>
                <label style="margin-left: 180px;">Soyad</label><br />
                <asp:TextBox runat="server" ID="tb_isim" Width="170px" Height="20px" CssClass="minbox"></asp:TextBox>
                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox runat="server" ID="Tb_soyisim" Width="170px" Height="20px" CssClass="minbox"></asp:TextBox><br />
                <br />
                <label style="margin-left: 170px;">E-Posta</label>
                <asp:TextBox runat="server" ID="tb_mail" Width="350px" Height="20px" CssClass="maxbox"></asp:TextBox><br />
                <br />
                <label style="margin-left: 170px;">Şifre</label>
                <asp:TextBox runat="server" ID="tb_sifre" Width="350px" Height="20px" CssClass="maxbox"></asp:TextBox><br />
                <br />
                <label style="margin-left: 170px;">Şifre(Tekrar)</label>
                <asp:TextBox runat="server" ID="tb_sifretekrar" Width="350px" Height="20px" CssClass="maxbox"></asp:TextBox><br />
                <br />
                <label style="margin-left: 170px;">Kullanıcı Adı</label>
                <asp:TextBox runat="server" ID="tb_kullaniciadi" Width="350px" Height="20px" CssClass="maxbox"></asp:TextBox>

                <br />
                <br />
                <br />
                <asp:LinkButton runat="server" ID="lbtn_uyeol" CssClass="girisyap" OnClick="lbtn_uyeol_Click">Üye Ol</asp:LinkButton><br />
                <br />
                <br />
                <label style="color: rgb(82, 82, 82, 0,62);">Zaten Hesabın Varmı? <a href="KullaniciGiris.aspx">Giriş Yap</a></label>
                <asp:Panel ID="pnl_hata" runat="server" CssClass="hata" Visible="false">
                    <asp:Label ID="lbl_hata" runat="server" CssClass="hatametin"></asp:Label>            
                </asp:Panel>
                <asp:Panel ID="pnl_yonlendirme" runat="server" CssClass="hata">
                    

                     <asp:Label CssClass ="girisyapildi" runat="server" ID="lbl_yonlendir"></asp:Label>
                </asp:Panel>
               

            </div>
        </div>
    </form>
</body>
</html>
