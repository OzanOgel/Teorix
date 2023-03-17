<%@ Page Title="Teorix-Aktif Yoneticiler" Language="C#" MasterPageFile="~/AdminPanel/Assets/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="YoneticilerAktif.aspx.cs" Inherits="TeorixProject.AdminPanel.Assets.Pages.YoneticilerAktif" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="buttonsUye">
        <a href="YoneticilerAktif.aspx" class="btn_uye">Aktif Yoneticiler</a>
        <a href="YoneticilerPasif.aspx" class="btn_uye">Pasif Yoneticiler</a>
    </div>
       
        <asp:ListView ID="lv_YoneticilerAktif" runat="server" OnItemCommand="lv_YoneticilerAktif_ItemCommand">

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
                                <th>Dogum Tarihi</th>
                                <th>Kayit Olma Tarihi</th>
                                
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
                    <td><%# Eval("Kullanici_Adi") %></td>
                    <td><%# Eval("Eposta") %>
                    <td><%# Eval("şifre") %></td>
                    <td><%# Eval("isim") %></td>

                    <td><%# Eval("soyisim") %></td>
                    <td><%# Eval("DogumTarihi") %></td>
                    <td><%# Eval("KayitOlmaTarihi") %></td>
                    
                    <td><%# Eval("AktiflikStr") %></td>

                    <td>
                        
                        <asp:LinkButton ID="lbtn_UyeBanla" runat="server" CssClass="sil" CommandArgument='<%# Eval("ID") %>' CommandName="BanAt">Banla</asp:LinkButton>
                        
                    </td>

                </tr>
                </div>
            </ItemTemplate>
        </asp:ListView>
</asp:Content>
