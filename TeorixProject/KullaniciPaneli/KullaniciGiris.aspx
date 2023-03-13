<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KullaniciGiris.aspx.cs" Inherits="TeorixProject.KullaniciPaneli.KullaniciGiriş" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
       body{
            background-image:url("Assets/img/imgbacround.png");
            
            
            
        }
        .contanier{
            margin-top:100px;
            margin-left:auto;
            margin-right:auto;
            width:300px;
            height:400px;
            border:1px solid black;
            border-top-left-radius:8px;
            border-top-right-radius:8px;
            background-color:#ededed;
            
            
        }
        .contanier .textbox{
            
            border-radius:15px;
            width:260px;
            height:25px;
            background-color:rgb(180, 180, 180, 0,67);
            margin-left:15px;
            
        }
        .contanier h2{
            color:rgb(82, 82, 82, 0,35);
            font-size:14pt;
            margin-left:20px;
        }
        .contanier h1{
            text-align:center;
            margin-left:500px;
            
        }
        .contanier .header{
            width:100%;
            background-color:forestgreen;
            height:80px;
            border-top-left-radius:8px;
            border-top-right-radius:8px;
            
        }
        .inc{
            margin-top:20px;
        }
        .girisyap{
            padding:10px 14px;
            background-color:forestgreen;
            border-radius:5px;
            text-decoration:none;
            border:1px solid black;
            margin-left:90px;
            color:black;
               
        }
        .girisyap:hover{
            background-color: #228b22e1;
            text-decoration:underline;
        }
        label{
            color:rgb(82, 82, 82, 0,62);
            font-size:11pt;
            margin-left:10px;
        }
        label a{
            text-decoration:underline;
            font-size:11pt;
            color:rgb(82, 82, 82, 0,83)

        }
        .hatametin{
            word-break:break-word;
            color:red;
            margin-left:8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div style="margin-left:650px;"><h1>Teorix Giriş</h1></div>
        <div class="contanier">
            <div class="header"></div>
            <div class="inc"></div>
            
            <h2>E-Posta Adresi:</h2>
            <asp:TextBox runat="server" ID="tb_eposta" CssClass="textbox"></asp:TextBox>
             <h2>Şifre:</h2>
            <asp:TextBox runat="server" ID="tb_sifre" CssClass="textbox" TextMode="Password"></asp:TextBox><br />
            <br /><br />
            <asp:LinkButton ID="lb_GirisYap" runat="server" CssClass="girisyap" OnClick="lb_GirisYap_Click">Giriş Yap</asp:LinkButton><br />
            <br />
            <label>Üye Değilmisin? Hemen <a href="KayitForm.aspx">Üye Ol</a></label>
            <asp:Panel ID="pnl_hata" runat="server" CssClass="hata" Visible="false"><asp:Label ID="lbl_hata" runat="server" CssClass="hatametin"></asp:Label></asp:Panel>
            
        </div>
    </form>
</body>
</html>
