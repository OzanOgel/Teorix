<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Assets/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="UyeListele.aspx.cs" Inherits="TeorixProject.AdminPanel.Assets.Pages.UyeListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../CSS/MainCss.css" rel="stylesheet" />
    <div class="buttonsUye">
        <a href="UyeListele.aspx" class="btn_uye">Aktif Uyeler</a>
        <a href="UyelerPasif.aspx" class="btn_uye">Pasif Uyeler</a>
    </div>
       
        <asp:ListView ID="lv_Uyeler" runat="server" OnItemCommand="lv_Uyeler_ItemCommand">

            <LayoutTemplate>

                <div class="tablelayout">
                    <table border="1" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr id="tablo-baslik">
                                <th>ID</th>
                                <th>Kullanici Adi</th>
                                <th>E-posta</th>
                                <th>Sifre</th>
                                <th>Isim</th>

                                <th>Soy İsim</th>
                               
                                <th>Kayit Olma Tarihi</th>
                                <th>Toplam Teori Sayısı</th>
                                <th>Aktiflik</th>
                                <th>Seçenekler</th>
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
                    <td><%# Eval("KullaniciAdi") %></td>
                    <td><%# Eval("Eposta") %>
                    <td><%# Eval("şifre") %></td>
                    <td><%# Eval("isim") %></td>

                    <td><%# Eval("soyisim") %></td>
                   
                    <td><%# Eval("KayitOlmaTarihi") %></td>
                    <td><%# Eval("ToplamTeoriSayısı") %></td>
                    <td><%# Eval("AktiflikStr") %></td>

                    <td>
                        
                        <asp:LinkButton ID="lbtn_UyeBanla" runat="server" CssClass="sil" CommandArgument='<%# Eval("ID") %>' CommandName="BanAt">Banla</asp:LinkButton>
                        
                    </td>

                </tr>
                </div>
            </ItemTemplate>
        </asp:ListView>
    
    

</asp:Content>
