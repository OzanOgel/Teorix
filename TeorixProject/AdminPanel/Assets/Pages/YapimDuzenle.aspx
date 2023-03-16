<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Assets/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="YapimDuzenle.aspx.cs" Inherits="TeorixProject.AdminPanel.Assets.Pages.YapimDuzenle" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="yapimbaslik">
        <h2>Yapım Duzenle</h2>
    </div>
    <div class="contanieryapim">
       
        <div class="dlltb">
            
            <div class="row">
                    <label>Tür Seç</label><br />
                    <asp:DropDownList ID="ddl_Turler" runat="server" AppendDataBoundItems="true" Style="width: 220px; height:35px;">
                        <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            <div class="row">
                    <label>Yapım Ismi</label><br />
                    <asp:TextBox ID="tb_YapımIsim" runat="server" CssClass="inputBox"></asp:TextBox>
                </div>
            <div class="row">
                    <label >Makale Resim</label><br />
                <asp:Image ID="img_resim" runat="server" Width="200"/>
                    <asp:FileUpload ID="fu_resim" runat="server" CssClass="file"></asp:FileUpload>
                </div>
            <div style="margin-top:20px;margin-left:100px;">
                    
                    <asp:CheckBox ID="cb_Aktiflik" runat="server" Text="aktiflik"></asp:CheckBox>
                </div>
            <div id="YapimEkle">
            <asp:LinkButton runat="server" ID="lbtn_YapımDuzenle" CssClass="yapimekle2" OnClick="lbtn_YapımDuzenle_Click">Yapım Ekle</asp:LinkButton>
            </div>
            <asp:Panel ID="pnl_Basarili" runat="server" CssClass="basarili" Visible="false"><div style="margin-top:25px;"><asp:Label ID="lbl_basarili" runat="server" CssClass="lblbasarili"></asp:Label></div></asp:Panel>
            <asp:Panel ID="pnl_Basarisiz" runat="server" CssClass="basarisiz" Visible="false"><div style="margin-top:25px;"><asp:Label ID="lbl_basarisiz" runat="server" CssClass="lblbasarisiz"></asp:Label></div></asp:Panel>
        </div>
</asp:Content>
