<%@ Page Title="Teorix-Kitaplar" Language="C#" MasterPageFile="~/KullaniciPaneli/Kullanicipnl.Master" AutoEventWireup="true" CodeBehind="Kitaplar.aspx.cs" Inherits="TeorixProject.KullaniciPaneli.Kitaplar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rpt_yapimlar" runat="server">
        <ItemTemplate>
        
            
          <div class="cont">
             <div class="yapi">
             <a href="TeorileriGoruntule.aspx?yid=<%# Eval("ID") %>"> <img style="width:183px; height:275px;" src='../YapimResimleri/<%# Eval("Resim") %>'/> <span><%# Eval("isim") %></span> </a>
                
             </div>
          </div>
           
            
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
