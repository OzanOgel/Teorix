<%@ Page Title="" Language="C#" MasterPageFile="~/KullaniciPaneli/Kullanicipnl.Master" AutoEventWireup="true" CodeBehind="KullaniciBilgiLİstesi.aspx.cs" Inherits="TeorixProject.KullaniciPaneli.KullaniciBilgiLİstesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
		body {
			font-family: Arial, sans-serif;
			font-size: 14px;
			text-align: center;
		}

		h1 {
			margin-top: 20px;
			margin-bottom: 10px;
			font-size: 24px;
			font-weight: bold;
		}

		ul {
			list-style: none;
			padding: 0;
			margin: 0;
			text-align: left;
			display: inline-block;
			border: 1px solid #ddd;
			border-radius: 10px;
			box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1);
		}

		li {
			padding: 10px 20px;
			border-bottom: 1px solid #ddd;
		}

		li:last-child {
			border-bottom: none;
		}

		li strong {
			display: inline-block;
			width: 200px;
			font-weight: normal;
			color: #888;
		}
	</style>


	
	
    <h1>Kullanıcı Bilgileri</h1>
	<ul>
		<li><strong>Kullanıcı Adı:</strong> <asp:Literal runat="server" ID="ltrl_kullaniciadi" ></asp:Literal></li>
		<li><strong>Eposta:</strong>  <asp:Literal runat="server" ID="ltrl_eposta" ></asp:Literal></li>
		<li><strong>İsim:</strong>  <asp:Literal runat="server" ID="ltrl_İsim" ></asp:Literal></li>
		<li><strong>Soyisim:</strong>   <asp:Literal runat="server" ID="ltrl_Soyİsim" ></asp:Literal></li>
		<li><strong>Kayıt Olma Tarihi:</strong>  <asp:Literal runat="server" ID="ltrl_KayıtOlmaTrihi" ></asp:Literal></li>
		<li><strong>Toplam Teori Sayısı:</strong>  <asp:Literal runat="server" ID=ltrl_toplamteori></asp:Literal></li>
	</ul>
</asp:Content>
