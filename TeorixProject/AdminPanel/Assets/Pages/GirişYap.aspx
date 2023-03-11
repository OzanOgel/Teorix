<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GirişYap.aspx.cs" Inherits="TeorixProject.AdminPanel.Assets.Pages.GirişYap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teorix-Giriş Yap</title>
    <link href="../CSS/GirişCss.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Anton&display=swap" rel="stylesheet"> 
</head>
<body>
    
    <form id="form1" runat="server">
        <div class="tittle">
        <h1 class="baslik">Teorix Yönetici Giriş Paneli</h1>
            </div>

        
        
        <div class="contanier">
            <div class="Yazi">
                
                <h2 > Teorix</h2>
            </div>
            <div class="textboxlar">
                
                <asp:TextBox ID="tb_Eposta" runat="server" CssClass="Textbox" placeholder="Mail Adresiniz" TextMode="Email"></asp:TextBox>
                <asp:TextBox ID="tb_Sifre" runat="server" CssClass="Textbox" placeholder="Şifreniz" TextMode="Password"></asp:TextBox>
                
            </div>
            <div class="login"></div>
            <asp:LinkButton ID="lbtn_giris" runat="server" Text="Giriş Yap" CssClass="loginButton" OnClick="lbtn_giris_Click"> </asp:LinkButton>
            <asp:Panel ID="pnl_hata" runat="server" CssClass="hata" Visible="false"><asp:Label ID="lbl_hata" runat="server" CssClass="hatametin"></asp:Label></asp:Panel>
        </div>
    </form>
</body>
</html>
