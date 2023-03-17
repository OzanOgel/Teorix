<%@ Page Title="Teorix-Yanıtlar" Language="C#" MasterPageFile="~/KullaniciPaneli/Kullanicipnl.Master" AutoEventWireup="true" CodeBehind="YanitGoruntule.aspx.cs" Inherits="TeorixProject.KullaniciPaneli.Yanitlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style>
       .basarili {
            margin-top:50px;
            width: 600px;
            height: 80px;
            background-color: green;
            color: white;
            font-size: 24px;
            display: flex;
            justify-content: center;
            align-items: center;
            border:1px solid black;
            margin-left:auto;
            margin-right:auto;
        }
       .basarisiz{
           margin-top:50px;
            width: 600px;
            height: 80px;
            background-color: red;
            color: white;
            font-size: 24px;
            display: flex;
            justify-content: center;
            align-items: center;
            border:1px solid black;
            margin-left:auto;
            margin-right:auto;
        }
       .teoribilgiler{
           right:5px;
           bottom:40px;
           position:relative;
       }
        
    </style>

  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:Panel ID="pnl_girisvar" runat="server" CssClass="girisvar" >
            <asp:TextBox ID="tb_yorum" runat="server"  CssClass="forminput" TextMode="MultiLine"></asp:TextBox>
            <br /><br />
            <asp:LinkButton ID="lbtn_yorumYap" runat="server" CssClass="formbutton" OnClick="lbtn_yorumYap_Click">Yanıt Paylaş</asp:LinkButton>
       <asp:Panel ID="pnl_yorumpaylasildi" runat="server" CssClass="basarili">Yanıtınız Yönetici Tarafından Onaylandıktan Sonra Paylaşılacaktır</asp:Panel>
        <asp:Panel ID="pnl_yorumpaylasilmadi" runat="server" CssClass="basarisiz"><asp:Label ID="lbl_hata" runat="server"></asp:Label></asp:Panel>
        </asp:Panel>
    <asp:Panel ID="pnl_UyeOl" runat="server" Visible="false"><div style="margin-top:50px; margin-left:auto; margin-right:auto; width: 800px; height: 100px; text-align: center; font-size: 24px; border: 1px solid red; display: flex; align-items: center; justify-content: center;">
  
  <span style="color: red;"> <i class="fa-solid fa-ban"></i> Yanıt Paylaşabilmek için <a href="KullaniciGiris.aspx" style="text-decoration:none; color: red; color:cornflowerblue; text-decoration:underline;">üye</a> olmalısınız</span>
</div></asp:Panel>
   

    <asp:Panel runat="server" ID="pnl_Teoriyok" CssClass="teorinone" Visible="false">
        <label><i style="padding-right: 20px; font-size: 20pt;" class="fa-solid fa-ban"></i>Bu Teori ile ilgili Yanıt Paylaşılmamış!</label>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnl_Teoriler" CssClass="Teoriler">
        <h3 style="font-size:25pt;font-family: 'Cabin', sans-serif; margin-left:700px;">Yanıtlar</h3>
        <asp:Repeater ID="rp_Yanitlarkullanici" runat="server" OnItemCommand="rp_Yanitlarkullanici_ItemCommand">
            <ItemTemplate>
                <div style="margin-top: 50px;">
                    
                    <div class="contanierTeoriler">
                        <div class="isim"> <i class="fa-solid fa-at"></i><%# Eval("Uye") %>:</div>
                        <div class="teoribilgiler">
                        <ul>
                            <li>Tarih(<%# Eval("tarihstr") %>)</li>
                            

                           
                        </ul>
                    </div>
                         <div style="padding:8px"> <%# Eval("icerik") %></div>
                </div>
                        
                    </div>
                    
                
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>
