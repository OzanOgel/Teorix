<%@ Page Title="Teorix-Reddedilen Yanıtlar" Language="C#" MasterPageFile="~/AdminPanel/Assets/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="YanitReddedilenler.aspx.cs" Inherits="TeorixProject.AdminPanel.Assets.Pages.YanitReddedilenler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="buttons2">
        <a href="YanıtOnayBekleyenler.aspx" class="btn_uye">Bekleyenler</a>
         <a href="YanitOnaylananlar.aspx" class="btn_uye">Onaylananlar</a>
         <a href="YanitReddedilenler.aspx" class="btn_uye">Reddedilenler</a>
        
    </div>

     <div class="tablelayoutTeori">
        <asp:ListView ID="lv_ReddedilenYanitlar" runat="server" OnItemCommand="lv_ReddedilenYanitlar_ItemCommand">
            <LayoutTemplate>
                <table border="1">
                    <thead>
                        <tr id="tablo-baslik">
                            <th>ID</th>
                            <th>Uye</th>
                            <th>Paylaşılma Tarihi</th>
                            <th>İçerik</th>
                            
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
                    <td><%# Eval("Uye") %></td>
               
                 
                    <td><%# Eval("tarihstr") %></td>

                    <td><%# Eval("icerik") %></td>
                    
                    <td><%# Eval("aktiflikStr") %></td>
                    <td>
                        
                        <asp:LinkButton ID="lbtn_YorumOnay" runat="server" CssClass="bankaldir" CommandArgument='<%# Eval("ID") %>' CommandName="Onayla">Onayla</asp:LinkButton>
                    </td>

                </tr>
            </ItemTemplate>

        </asp:ListView>
    </div>
</asp:Content>
