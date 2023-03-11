<%@ Page Title="" Language="C#" MasterPageFile="~/KullaniciPaneli/Kullanicipnl.Master" AutoEventWireup="true" CodeBehind="TeorileriGoruntule.aspx.cs" Inherits="TeorixProject.KullaniciPaneli.TeorileriGoruntule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .basarili {
            margin-top:50px;
            width: 600px;
            height: 80px;
            background-color: green;
            color: white;
            font-size: 24px;
            display: flex;
            justify-content: center;
            align-items: center;
            border:1px solid black;
            margin-left:auto;
            margin-right:auto;
        }

        .heart {
            color: grey;
            cursor: pointer;
            font-size: 20px;
        }



            .heart.active {
                color: red;
                animation-name: fillHeart;
                animation-duration: 0.5s;
            }

        @keyframes fillHeart {
            0% {
                transform: scale(1);
            }

            50% {
                transform: scale(1.2);
            }

            100% {
                transform: scale(1);
            }
        }
    </style>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            const hearts = document.querySelectorAll(".heart");
            hearts.forEach(heart => {
                heart.addEventListener("click", function () {
                    this.classList.toggle("active");
                });
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnl_girisvar" runat="server" CssClass="girisvar">
        <asp:TextBox ID="tb_yorum" runat="server" CssClass="forminput" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <asp:LinkButton ID="lbtn_yorumYap" runat="server" CssClass="formbutton" OnClick="lbtn_yorumYap_Click">Teori Paylaş</asp:LinkButton>
        <asp:Panel ID="pnl_yorumpaylasildi" runat="server" CssClass="basarili">Teori Başarı ile Paylaşıldı</asp:Panel>
    </asp:Panel>
    <asp:Panel ID="pnl_UyeOl" runat="server" Visible="false">
        <div style="margin-top: 50px; margin-left: auto; margin-right: auto; width: 800px; height: 100px; text-align: center; font-size: 24px; border: 1px solid red; display: flex; align-items: center; justify-content: center;">

            <span style="color: red;"><i class="fa-solid fa-ban"></i>Teori Paylaşabilmek için <a href="#" style="text-decoration: none; color: red; color: cornflowerblue; text-decoration: underline;">üye</a> olmalısınız</span>
        </div>
    </asp:Panel>


    <asp:Panel runat="server" ID="pnl_Teoriyok" CssClass="teorinone" Visible="false">
        <label><i style="padding-right: 20px; font-size: 20pt;" class="fa-solid fa-ban"></i>Bu Yapımla ilgili Teori Paylaşılmamış!</label>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnl_Teoriler" CssClass="Teoriler">
        <h3 style="font-size: 25pt; font-family: 'Cabin', sans-serif; margin-left: 700px;">Teoriler</h3>
        <asp:Repeater ID="rp_teorilerkullanici" runat="server" OnItemCommand="rp_teorilerkullanici_ItemCommand">
            <ItemTemplate>
                <div style="margin-top: 50px;">
                    <div class="isim"><%# Eval("KullaniciAdi") %>:</div>
                    <div class="contanierTeoriler">
                        <%# Eval("içerik") %>
                    </div>
                    <div class="teoribilgiler">
                        <ul>
                            <li>Tarih(<%# Eval("Paylasilma_Tarihi") %>) |</li>
                            <li>Beğeni Sayısı( <%# Eval("Begeni_Sayisi") %> ) <i class="far fa-heart heart"></i>|</li>
                            <li><a href="Yanitlar.aspx?tid=<%# Eval("ID") %>">Yanıt Sayısı(<%# Eval("Yanit_Sayisi") %>)</a>

                            </li>
                        </ul>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>








