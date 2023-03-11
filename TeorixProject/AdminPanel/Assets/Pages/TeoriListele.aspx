<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Assets/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="TeoriListele.aspx.cs" Inherits="TeorixProject.AdminPanel.Assets.Pages.TeoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../CSS/MainCss.css" rel="stylesheet" />

    <div class="buttons2">
        <asp:LinkButton ID="lbtn_Diziler" runat="server" OnClick="lbtn_Diziler_Click" CssClass="btn_uye">Diziler</asp:LinkButton>
        <asp:LinkButton ID="lbtn_Filmler" runat="server" OnClick="lbtn_Filmler_Click " CssClass="btn_uye">Filmler</asp:LinkButton>
        <asp:LinkButton ID="lbtn_Kitaplar" runat="server" OnClick="lbtn_Kitaplar_Click" CssClass="btn_uye">Kitaplar</asp:LinkButton>
        <asp:LinkButton ID="lbtn_Tumu" runat="server" OnClick="lbtn_Tumu_Click" CssClass="btn_uye">Tümü</asp:LinkButton>
    </div>







    <div class="tablelayoutTeori">
        <asp:ListView ID="lv_Teoriler" runat="server" OnItemCommand="lv_Teoriler_ItemCommand">
            <LayoutTemplate>
                <table border="1">
                    <thead>
                        <tr id="tablo-baslik">
                            <th>ID</th>
                            <th>Yapım</th>
                            <th>Uye Ismi</th>
                            <th>Tur</th>
                            <th>Paylaşılma Tarihi</th>

                            <th>Begeni Sayisi</th>
                            <th>Yanit Sayisi</th>
                            <th>aktiflik</th>
                            <th>Secenekler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>

                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Yapım") %></td>
                    <td><%# Eval("uyeIsim") %>(<%# Eval("KullaniciAdi") %>)</td>
                    <td><%# Eval("Tur") %></td>
                    <td><%# Eval("Paylasilma_Tarihi") %></td>

                    <td><%# Eval("Begeni_Sayisi") %></td>
                    <td><%# Eval("Yanit_Sayisi") %></td>
                    <td><%# Eval("aktiflikStr") %></td>
                    <td>
                        <a href='TeoriIçerik.aspx?teid=<%# Eval("ID") %>' class="icerik">Içerik</a>
                        <asp:LinkButton ID="lbtn_silIçerik" runat="server" CssClass="sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                    </td>

                </tr>
            </ItemTemplate>

        </asp:ListView>
    </div>

</asp:Content>
