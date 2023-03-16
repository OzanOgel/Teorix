<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KayitForm.aspx.cs" Inherits="TeorixProject.KullaniciPaneli.KayitForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="preconnect" href="https://fonts.googleapis.com"/>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Tilt+Prism&display=swap" rel="stylesheet"/>
    <title>Teorix Kayıt</title>
    <style>
        body{
            background-color:#EFEFEF;
        }
     .contanier{
         margin-top:50px;
         margin-left:350px;
         
         width:850px;
         height:650px;
         border:1px solid gray;
         border-bottom-left-radius:30px;
          border-top-left-radius:30px;
          background-color:#ffffff;
          border-radius:30px;
       
          
     }
     
     .left{
         width:350px;
         height:650px;
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
         height:30px;
        font-size:15pt;
       transition-property:border-bottom;
       transition-duration:250ms;

         
         
  
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
         
         left:250px;
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
        bottom:70px;
         position:relative;
         font-family:Calibri;
         right:20px;
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
       bottom:40px;
         color:red;
         word-break:break-word;
         position:relative;
         font-size:17px;

     }
     .right{
         left:50px;
         top:20px;
         position:relative;
     }
     span{
         font-size:16pt;
         color:gray;
     }
     .hatametin{
         color:red !important;
         word-break:break-word;
     }

    
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contanier">
      <div class="left"> </div>
          <h1>Teorix</h1>
                <div class="right">
                    <span>Isim:</span><span style="left:180px; position:relative;">Soy İsim:</span><br />
                <asp:TextBox runat="server" ID="tb_isim" Width="170px" Height="20px" CssClass="textbox"></asp:TextBox>
                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
            <asp:TextBox runat="server" ID="Tb_soyisim" Width="170px" Height="20px" CssClass="textbox" ></asp:TextBox><br />
                <br />
             <span>Mail:</span><br />
                <asp:TextBox runat="server" ID="tb_mail" CssClass="textbox"></asp:TextBox><br />
                <br />
                    <span>Kullanıcı Adı:</span><br />
            <asp:TextBox runat="server" ID="tb_kullaniciadi" CssClass="textbox" ></asp:TextBox>
            <br />
              
                
               <span>Şifre:</span><br />
                <asp:TextBox runat="server" ID="tb_sifre" CssClass="textbox"  TextMode="Password"></asp:TextBox><br />
                
                <br />
                <span>Şifre(Tekrar)</span>:<br />
                <asp:TextBox runat="server" ID="tb_sifretekrar" CssClass="textbox" TextMode="Password"></asp:TextBox><br />

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
