<%@ Page Title="Teorix-Içerik Listele" Language="C#" MasterPageFile="~/AdminPanel/Assets/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="TeoriIçerik.aspx.cs" Inherits="TeorixProject.AdminPanel.Assets.Pages.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS/Main.css" rel="stylesheet" />
    <style>.Teoriler{
    margin-top:40px;
    font-family:Calibri;
    font-size:13pt;
}
.contanierTeoriler {
    padding:8px 8px 8px 8px;
    max-height: 400px;
    min-height: 100px;
    width: 80%;
    margin-left: auto;
    margin-right: auto;
   border-radius:10px;
   border:2px solid gray;
   font-family:Calibri;
}
.teoribilgiler ul li {
    display:inline-block;
}
.isim {
    margin-left: 180px;
    font-size: 20pt;
    font-family: 'Ubuntu', sans-serif;
    margin-bottom:10px;
}
.teoribilgiler{
    float:right;
}
.teoribilgiler ul {
    text-decoration:none;
    color:#808080bb;
    margin-right:170px;
    

}
    .teoribilgiler ul li a{
        text-decoration:none;
    }
    .butonlar{
        margin-top:100px;
        margin-left:500px;
    }
    .siliçerik{
        padding:10px 25px;
        background-color:red;
        border-radius:5px;
        text-decoration:none;
        color:black;
        
    }
    .siliçerik:hover{
        text-decoration:underline;
        color:white;
    }
    .bankaldır{
        padding:10px 25px;
        background-color:forestgreen;
        border-radius:5px;
        text-decoration:none;
        color:black;
    }
    .bankaldır:hover{
         text-decoration:underline;
        color:white;
    }
    
    </style>
    <div class="margin">


        <<asp:Panel runat="server" ID="pnl_Teoriler" CssClass="Teoriler">
        <h3 style="font-size: 25pt; font-family: 'Cabin', sans-serif; margin-left: 700px;">Teoriler</h3>
        <asp:Repeater ID="rp_teoriler" runat="server" OnItemCommand="rp_teoriler_ItemCommand">
            <ItemTemplate>
                <div style="margin-top: 50px;">
                    <div class="isim"><%# Eval("KullaniciAdi") %>:</div>
                    <div class="contanierTeoriler">
                        <%# Eval("içerik") %>
                    </div>
                    <div class="teoribilgiler">
                        <ul>
                            <li>Tarih(<%# Eval("tarihstr") %>) |</li>
                            <li> Beğeni Sayısı( <%# Eval("Begeni_Sayisi") %> )</li>
                            <li>Yanıt Sayısı(<%# Eval("Yanit_Sayisi") %>)</li>
                                

                            
                        </ul>
                    </div>
                </div>
                <div class="butonlar">
                <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="siliçerik" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                <asp:LinkButton ID="lbtn_uyebanla" runat="server" CssClass="siliçerik" CommandArgument='<%# Eval("Uye_ID") %>' CommandName="Banla">Banla</asp:LinkButton>
                <asp:LinkButton ID="lbtn_BanKaldır" runat="server" CssClass="bankaldır" CommandArgument='<%# Eval("Uye_ID") %>' CommandName="BanKaldır">Ban Kaldır</asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
        

        <asp:Panel ID="pnl_Uyeban" runat="server" CssClass="uyepnl">Üye Başarı İle Banlandı</asp:Panel>

        <asp:Panel ID="pnl_bankaldır" runat="server" CssClass="uyepnl">Üyenin Banı Başarı Ile Açıldı</asp:Panel>

        <asp:Panel ID="pnl_sil" runat="server" CssClass="uyepnl">Teori Başarı İle Silindi</asp:Panel>

    </div>

</asp:Content>
