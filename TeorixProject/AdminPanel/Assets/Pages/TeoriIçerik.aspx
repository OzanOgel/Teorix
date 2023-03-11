<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Assets/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="TeoriIçerik.aspx.cs" Inherits="TeorixProject.AdminPanel.Assets.Pages.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS/Main.css" rel="stylesheet" />
    <div class="margin">


        <asp:Repeater ID="rp_teoriler" runat="server" OnItemCommand="rp_teoriler_ItemCommand">
            <ItemTemplate>
                <div class="bilgiler" style="margin-left: 200px;">
                    <%# Eval("UyeIsim") %> ( <%# Eval("KullaniciAdi") %>)
                </div>
                <br />

                <div class="kutu">
                    <label class="içerikoku"><%# Eval("içerik") %> </label>
                </div>
                <br />
                <div class="like">Like :  <%# Eval("Begeni_Sayisi") %></div>
                <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="siliçerik" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                <asp:LinkButton ID="lbtn_uyebanla" runat="server" CssClass="uyebanla" CommandArgument='<%# Eval("Uye_ID") %>' CommandName="Banla">Banla</asp:LinkButton>
                <asp:LinkButton ID="lbtn_BanKaldır" runat="server" CssClass="bankaldır" CommandArgument='<%# Eval("Uye_ID") %>' CommandName="BanKaldır">Ban Kaldır</asp:LinkButton>

            </ItemTemplate>
        </asp:Repeater>
        <asp:Panel ID="pnl_Uyeban" runat="server" CssClass="uyepnl">Üye Başarı İle Banlandı</asp:Panel>

        <asp:Panel ID="pnl_bankaldır" runat="server" CssClass="uyepnl">Üyenin Banı Başarı Ile Açıldı</asp:Panel>

        <asp:Panel ID="pnl_sil" runat="server" CssClass="uyepnl">Teori Başarı İle Silindi</asp:Panel>

    </div>

</asp:Content>
