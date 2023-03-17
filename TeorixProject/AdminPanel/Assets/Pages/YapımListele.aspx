<%@ Page Title="Teorix-Yapım Listele" Language="C#" MasterPageFile="~/AdminPanel/Assets/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="YapımListele.aspx.cs" Inherits="TeorixProject.AdminPanel.Assets.Pages.YapımListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS/MainCss.css" rel="stylesheet" />
     <div class="tablelayoutYapim">
        <asp:ListView ID="lv_Yapımlar" runat="server" OnItemCommand="lv_Yapımlar_ItemCommand">
            <LayoutTemplate>
                <table border="1">
                    <thead>
                        <tr id="tablo-baslik">
                            <th>ID</th>
                            <th>Tur</th>
                            <th>Yonetici</th>
                            <th>Isim</th>
                            <th>Resim</th>

                            <th>aktiflik</th>
                            <th>Seçenekler</th>
                          
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>

                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Tur") %></td>
                    <td><%# Eval("Yonetici") %></td>
                    
                    <td><%# Eval("Isim") %></td>

                    <td><%# Eval("Resim") %></td>
                   
                    <td><%# Eval("aktiflikStr") %></td>
                    <td>
                        <a href='YapimDuzenle.aspx?yid=<%# Eval("ID") %>' class="icerik">Düzenle</a>
                      
                        <asp:LinkButton ID="lbtn_silYapım" runat="server" CssClass="sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                    </td>

                </tr>
            </ItemTemplate>

        </asp:ListView>
          
    </div>
    <div class="yapimekle">
        <a href="YapımEkle.aspx"class="btn_uye">Yapım Ekle</a>
    </div>
    

</asp:Content>
