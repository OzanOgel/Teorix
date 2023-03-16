<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KullaniciGiris.aspx.cs" Inherits="TeorixProject.KullaniciPaneli.KullaniciGiriş" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
<link rel="preconnect" href="https://fonts.gstatic.com"/> 
<link href="https://fonts.googleapis.com/css2?family=Tilt+Prism&display=swap" rel="stylesheet"/>
    <link href="../AdminPanel/Assets/fontawesome/css/all.css" rel="stylesheet" />
    <title>Teorix Giriş</title>
  
    <style>
        body{
            background-color:#EFEFEF;
        }
     .contanier{
         margin-top:50px;
         margin-left:350px;
         
         width:800px;
         height:600px;
         border:1px solid gray;
         border-bottom-left-radius:30px;
          border-top-left-radius:30px;
          background-color:#ffffff;
          border-radius:30px;
          
         
          
     }
     
     .left{
         width:350px;
         height:600px;
         float:left;
         border-right:1px solid red;
         background-image:url("Assets/img/maznara.jpg");
         background-repeat:no-repeat;
          background-size: 100% 100%;
          border-bottom-left-radius:30px;
          border-top-left-radius:30px;
     }
     .contanier h1{
         font-family: 'Tilt Prism', cursive;
          color:#916EC9;
          font-size:40pt;
          left:135px;
          position:relative;
     }
     .textbox{
         outline:none;
         border-top:none;
         border-left:none;
         border-right:none;
         border-color:rgb(109, 109, 109, 0,72);
         width:300px;
         height:50px;
        font-size:15pt;
       transition-property:border-bottom;
       transition-duration:1s;

         
         
  
     }
     .textbox::placeholder{
         
         font-size:15pt;
         padding:20px;
         
         
     }
     .textbox:focus{
  border-bottom:2px solid #916EC9;
     }
     .inc{
         top:50px;
         position:relative;
        left:50px;
     }
     .girisyap{
         text-decoration:none;
         background-color:#916EC9;
         padding:13px 35px;
         color:white;
         font-family:Calibri;
         font-weight:900;
         border-radius:30px;
         top:40px;
         left:200px;
         position:relative;
     }
     .contanier i{
        top:10px;
         font-size:25pt;
         color:lightgray;
         position:relative;
         right:10px;

     }
     label{
         color:gray;
         font-size:15pt;
         top:100px;
         position:relative;
         font-family:Calibri;
     }
     label a{
         opacity:0,2;
         text-decoration:none;
         color:#916EC9;
     }
     label a:hover{
         text-decoration:underline;
     }
     .hata{
         top:140px;
         color:red;
         word-break:break-word;
         position:relative;
         font-size:17px;

     }
     

    
   

    </style>
</head>
<body>
    <form id="form1" runat="server">
       
      
       
     
            <div class="contanier">
                
                <div class="left"></div>

                <div class="right">
                    
                    <h1>Teorix</h1>
                    <div class="inc">
                         
          <i class="fa-regular fa-envelope"></i>
            <asp:TextBox runat="server" ID="tb_eposta" CssClass="textbox" placeholder="E-Posta"></asp:TextBox>
            <br /><br />
                      <br /><i class="fa-solid fa-lock"></i>
            <asp:TextBox runat="server" ID="tb_sifre" CssClass="textbox" TextMode="Password" placeholder="Şifre"></asp:TextBox><br />
            <br /><br />
            <asp:LinkButton ID="lb_GirisYap" runat="server" CssClass="girisyap" OnClick="lb_GirisYap_Click">Giriş Yap</asp:LinkButton><br />
            <br />
            <label>Üye Değilmisin? Hemen <a href="KayitForm.aspx">Üye Ol</a></label>
            <asp:Panel ID="pnl_hata" runat="server" CssClass="hata" Visible="false"><asp:Label ID="lbl_hata" runat="server" CssClass="hatametin">*sadsads adsadsa dsadsa dsadsadsadadsadsadsadsad</asp:Label></asp:Panel>
                        </div>
                </div>
            </div>
       
    </form>
</body>
</html>
